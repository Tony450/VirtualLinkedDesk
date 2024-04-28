/*****************************************************************************
* Copyright (C) 2021 Antonio Manuel Hernández De León, <tony450.vld@gmail.com>.
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <https://www.gnu.org/licenses/>.
*****************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Net.Security;

using System.Runtime.InteropServices;
using System.IO;

using System.Security.Cryptography.X509Certificates;
using System.Security.Authentication;

using BitmapLibrary;                                                                                                            //Bitmap library

using Header;

using static Server.User32;
using static Server.Utils;


public struct InputParameters {
    public IPEndPoint endPoint;
    public bool encryptedConnection;
    public X509Certificate2 certificate;
}


namespace Server {

    public partial class MainWindow : Form {

        SessionObjects sessionObjects = new SessionObjects();

        unsafe public MainWindow(IPEndPoint endPoint, bool encryptedConnection, X509Certificate2 certificate = null) {
            InitializeComponent();

            sessionObjects.protocol = "RDE 01.00";
            sessionObjects.inputParamneters.endPoint = endPoint;
            sessionObjects.inputParamneters.encryptedConnection = encryptedConnection;
            sessionObjects.password = initPassword();
            //sessionObjects.password = "0123456789";                           //For tests
            sessionObjects.clientsConnected = 0;
            passwordBox.Text = sessionObjects.password;

            sessionObjects.form = this;
            sessionObjects.socketsStream = new List<Socket>();


            initTimer();

            if (!sessionObjects.inputParamneters.encryptedConnection) {
                connectionNotSecureLabel.Visible = true;
            }

            else {
                sessionObjects.inputParamneters.certificate = certificate;
            }

            startService();

        }


        private string initPassword() {

            void fillPasswordArray(ref string[] password, string source, int numberOfItems) {

                Random random = new Random();
                int randomNumber;
                int randomPosition;

                for (int i = 0; i < numberOfItems; i++) {

                    randomNumber = random.Next(source.Length);                                                                  //Less than 10

                    do {
                        randomPosition = random.Next(password.Length);
                    } while (password[randomPosition] != null);

                    password[randomPosition] = source[randomNumber].ToString();

                }

            }


            string [] password = new string[Constants.passwordLength];

            string numbers = "0123456789";
            string lowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
            string capitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            Random random = new Random();

            int random1;
            int random2;
            int random3;

            do {                                                                                                                //It generates three random numbers in the interval [2, 4] and the addition of them must be 10.

               random1 = random.Next(2, 5);
               random2 = random.Next(2, 5);
               random3 = random.Next(2, 5);

            } while (random1 + random2 + random3 != password.Length);

            fillPasswordArray(ref password, numbers, random1);
            fillPasswordArray(ref password, lowercaseLetters, random2);
            fillPasswordArray(ref password, capitalLetters, random3);

            return String.Join("", password);

        }


        private void initTimer() {

            sessionObjects.fpsTimer = new System.Timers.Timer();
            sessionObjects.fpsTimer.Elapsed += captureScreen;                                                                   //The event that triggers is captureScreen
            sessionObjects.fpsTimer.AutoReset = true;                                                                           //It triggers repetitive events

        }


        public void startService() {

            Thread conectionHanlderThread = new Thread(new MyThread().handleIncomingConnections);
            conectionHanlderThread.Start(sessionObjects);

        }

        unsafe private void captureScreen(Object source, System.Timers.ElapsedEventArgs e) {

            try {

                if (!sessionObjects.form.IsDisposed) {
                    connectedClientsBox.Invoke((Action)delegate {
                        connectedClientsBox.Lines = sessionObjects.machineClientsName.ToArray();
                    });
                }

            }

            catch (Exception) {

            }

            sessionObjects.bitmapScreen.copyTo(sessionObjects.bitmapOffScreen);

            if (sessionObjects.colorDepth == 0) {                                                                               //Compression

                Image image = Image.FromHbitmap(sessionObjects.bitmapOffScreen.getHBitmap());                                   //Change it, each iteration?
                System.Drawing.Bitmap compressionbitmap = new System.Drawing.Bitmap(image);


                MemoryStream memoryStream = new MemoryStream();
                compressionbitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);

                lock (sessionObjects.mutex) {                                                                                   //Implicit mutual exclusion
                    sessionObjects.buffer = memoryStream.ToArray();                                                             //We write in the shared buffer
                    Monitor.PulseAll(sessionObjects.mutex);
                }

            }


            else {                                                                                                              //No compression

                lock (sessionObjects.mutex) {                                                                                   //Implicit mutual exclusion

                    Marshal.Copy(sessionObjects.bitmapOffScreen.getData(), sessionObjects.buffer, 0,                            //We write in the shared buffer
                        sessionObjects.buffer.Length);
                    Monitor.PulseAll(sessionObjects.mutex);

                }

            }

        }

        private void allowControlButtonNoClick(object sender, EventArgs e) {

            pictureAllowControlButtonNoBox.Enabled = false;
            pictureAllowControlButtonNoBox.Visible = false;

            sessionObjects.allowControl = false;

            pictureAllowControlButtonYesBox.Enabled = true;
            pictureAllowControlButtonYesBox.Visible = true;

        }

        private void allowControlButtonYesClick(object sender, EventArgs e) {

            pictureAllowControlButtonYesBox.Enabled = false;
            pictureAllowControlButtonYesBox.Visible = false;

            sessionObjects.allowControl = true;

            pictureAllowControlButtonNoBox.Enabled = true;
            pictureAllowControlButtonNoBox.Visible = true;

        }

        private void disconnectButtonClick(object sender, EventArgs e) {

            foreach (Socket socket in sessionObjects.socketsStream) {
                socket.Close();
            }

            this.Dispose();

        }

    }


    public class MyThread {

        SessionObjects sessionObjects;
        Stream networkManager;
        byte clientId;

        private bool handshake() {

            byte[] buffer;
            bool correct = true;

            buffer = Encoding.ASCII.GetBytes(sessionObjects.protocol);                                                          //Protocol (send)
            send(ref buffer);

            receive(ref buffer, buffer.Length);                                                                                 //Protocol (receive)
            string receivedProtocol = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
            if (!String.Equals(sessionObjects.protocol, receivedProtocol)) {
                correct = false;
            }

            buffer = new byte[Constants.passwordLength];                                                                        //Password
            receive(ref buffer, buffer.Length);
            string receivedPassword = Encoding.ASCII.GetString(buffer, 0, buffer.Length);

            buffer = new byte[Constants.accessEncodingSize];

            if (!String.Equals(sessionObjects.password, receivedPassword)) {
                correct = false;
                buffer[0] = 0;                                                                                                  //Incorrect
            }

            else {
                buffer[0] = 1;                                                                                                  //Correct
            }

            send(ref buffer);                                                                                                   //Password verification

            return correct;

        }

        private bool initialization() {

            if (handshake()) {

                byte[] buffer = new byte[Constants.machineNameEncodingSize];
                buffer[0] = (byte)Environment.MachineName.Length;                                                               //Hostname length (send)
                send(ref buffer);

                buffer = Encoding.ASCII.GetBytes(Environment.MachineName);                                                      //Hostname (send)
                send(ref buffer);

                if (sessionObjects.clientsConnected == 0) {

                    sessionObjects.bitmapScreen = new BitmapScreen();                                                           //We create the screen bitmap
                    sessionObjects.machineClientsName = new List<string>();

                }

                buffer = BitConverter.GetBytes(sessionObjects.bitmapScreen.getWidth());                                         //Screen dimentions
                send(ref buffer);
                buffer = BitConverter.GetBytes(sessionObjects.bitmapScreen.getHeight());
                send(ref buffer);


                buffer = new byte[Constants.machineNameEncodingSize];                                                           //Hostname (receive)
                receive(ref buffer, buffer.Length);


                if (buffer[0] <= Constants.maxMachineNameLength) {

                    buffer = new byte[buffer[0]];
                    receive(ref buffer, buffer.Length);                                                                         //Hostname (receive)

                    sessionObjects.machineClientsName.Add(Encoding.ASCII.GetString(buffer, 0, buffer.Length));                  //We add the client name

                    receive(ref buffer, Constants.fpsEncodingSize);                                                             //FPS
                    byte fps = buffer[0];


                    if (fps == 5 || fps == 10 || fps == 15 || fps == 20 || fps == 25) {

                        receive(ref buffer, Constants.colorDepthEncodingSize);                                                 //Color depth
                        byte colorDepth = buffer[0];


                        if (colorDepth == 0 || colorDepth == 1 || colorDepth == 4 || colorDepth == 8 || colorDepth == 16 ||
                           colorDepth == 24 || colorDepth == 32) {


                            if (sessionObjects.clientsConnected == 0) {                                                         //If it is the only client I do it, otherwise I don't

                                sessionObjects.fps = fps;                                                                       //FPS are set by the first client
                                sessionObjects.fpsTimer.Interval = 1000 / fps;                                                  //1000 ms = 1 fps, 500 ms = 2 fps, 200 ms = 5 fps, 100 ms = 10 fps, 66 ms = 15 fps, 50 ms = 20 fps, 40 ms = 25 fps

                                sessionObjects.colorDepth = colorDepth;

                                if (sessionObjects.colorDepth == 0) {                                                           //0 means that compression is set, consequently it is 24
                                    colorDepth = 24;
                                }

                                sessionObjects.bitmapOffScreen = new BitmapOffScreen(sessionObjects.bitmapScreen.getWidth(),
                                    sessionObjects.bitmapScreen.getHeight(), colorDepth);

                                if (sessionObjects.colorDepth != 0) {                                                           //If no compression...
                                    sessionObjects.buffer = new byte[sessionObjects.bitmapOffScreen.getSize()];                 //The buffer will always have the same size
                                }

                                sessionObjects.mutex = new Object();
                                sessionObjects.fpsTimer.Enabled = true;                                                         //We start the time event

                            }

                            clientId = sessionObjects.clientsConnected;
                            sessionObjects.clientsConnected++;                                                                  //Automate it with Interlocked.Increment

                            return true;

                        }

                        else {
                            showErrorMessage("Error interno", "Se ha producido un error en el protocolo");
                            sessionObjects.form.Invoke((Action)delegate {
                                sessionObjects.form.Dispose();
                            });
                            return false;
                        }

                    }

                    else {
                        showErrorMessage("Error interno", "Se ha producido un error en el protocolo");
                        sessionObjects.form.Invoke((Action)delegate {
                            sessionObjects.form.Dispose();
                        });
                        return false;
                    }

                }

                else {
                    showErrorMessage("Error interno","Se ha producido un error en el protocolo");
                    sessionObjects.form.Invoke((Action)delegate {
                        sessionObjects.form.Dispose();
                    });
                    return false;
                }

            }

            else {
                return false;
            }

        }

        unsafe private void executeKeyDownEvent(ref byte[] buffer) {

            INPUT[] pInputs = new INPUT[1];
            pInputs[0].type = (uint)INPUT_TYPE.INPUT_KEYBOARD;

            byte[] keyPressed = new byte[2];
            Array.Copy(buffer, 1, keyPressed, 0, keyPressed.Length);
            pInputs[0].U.ki.wVk = (VirtualKeyShort) BitConverter.ToInt16(keyPressed, 0);
            pInputs[0].U.ki.dwFlags = KEYEVENTF.EXTENDEDKEY;

            SendInput(1, pInputs, sizeof(INPUT));

        }


        unsafe private void executeKeyUpEvent(ref byte[] buffer) {

            INPUT[] pInputs = new INPUT[1];
            pInputs[0].type = (uint)INPUT_TYPE.INPUT_KEYBOARD;

            byte[] keyPressed = new byte[2];
            Array.Copy(buffer, 1, keyPressed, 0, keyPressed.Length);
            pInputs[0].U.ki.wVk = (VirtualKeyShort) BitConverter.ToInt16(keyPressed, 0);
            pInputs[0].U.ki.dwFlags = KEYEVENTF.KEYUP | KEYEVENTF.EXTENDEDKEY;

            SendInput(1, pInputs, sizeof(INPUT));

        }

        unsafe private void executeMouseMoveEvent(ref byte[] buffer) {

            ushort map(double value, double from1, double to1, double from2, double to2) {
                return (ushort)(uint)(int)((value - from1) / (to1 - from1) * (to2 - from2) + from2);
            }

            INPUT[] pInputs = new INPUT[1];
            pInputs[0].U.mi.dwFlags = MOUSEEVENTF.MOVE | MOUSEEVENTF.ABSOLUTE | MOUSEEVENTF.VIRTUALDESK;

            byte[] coordinates = new byte[2];
            Array.Copy(buffer, 1, coordinates, 0, coordinates.Length);
            ushort x = BitConverter.ToUInt16(coordinates, 0);
            Array.Copy(buffer, 3, coordinates, 0, coordinates.Length);
            ushort y = BitConverter.ToUInt16(coordinates, 0);

            pInputs[0].U.mi.dx = map(x, 0, sessionObjects.bitmapScreen.getWidth(), 0, 65535);
            pInputs[0].U.mi.dy = map(y, 0, sessionObjects.bitmapScreen.getHeight(), 0, 65535);

            SendInput(1, pInputs, sizeof(INPUT));

        }


        unsafe private void executeMouseDownEvent(ref byte[] buffer) {

            INPUT[] pInputs = new INPUT[1];

            switch (buffer[1]) {
                case 0:
                    pInputs[0].U.mi.dwFlags = MOUSEEVENTF.LEFTDOWN;
                    break;
                case 1:
                    pInputs[0].U.mi.dwFlags = MOUSEEVENTF.RIGHTDOWN;
                    break;
                case 2:
                    pInputs[0].U.mi.dwFlags = MOUSEEVENTF.MIDDLEDOWN;
                    break;
                case 3:
                    pInputs[0].U.mi.dwFlags = MOUSEEVENTF.XDOWN;
                    pInputs[0].U.mi.mouseData = 0X0001;                                                                         //Put it inside a structure
                    break;
                case 4:
                    pInputs[0].U.mi.dwFlags = MOUSEEVENTF.XDOWN;
                    pInputs[0].U.mi.mouseData = 0X0002;                                                                         //Put it inside a structure
                    break;
                default:
                    break;
            }

            SendInput(1, pInputs, sizeof(INPUT));

        }

        unsafe private void executeMouseUpEvent(ref byte[] buffer) {

            INPUT[] pInputs = new INPUT[1];

            switch (buffer[1]) {
                case 0:
                    pInputs[0].U.mi.dwFlags = MOUSEEVENTF.LEFTUP;
                    break;
                case 1:
                    pInputs[0].U.mi.dwFlags = MOUSEEVENTF.RIGHTUP;
                    break;
                case 2:
                    pInputs[0].U.mi.dwFlags = MOUSEEVENTF.MIDDLEUP;
                    break;
                case 3:
                    pInputs[0].U.mi.dwFlags = MOUSEEVENTF.XUP;
                    pInputs[0].U.mi.mouseData = 0X0001;                                                                         //Put it inside a structure
                    break;
                case 4:
                    pInputs[0].U.mi.dwFlags = MOUSEEVENTF.XUP;
                    pInputs[0].U.mi.mouseData = 0X0002;                                                                         //Put it inside a structure
                    break;
                default:
                    break;
            }

            SendInput(1, pInputs, sizeof(INPUT));

        }

        unsafe private void executeMouseWheelEvent(ref byte[] buffer) {

            INPUT[] pInputs = new INPUT[1];

            pInputs[0].U.mi.dwFlags = MOUSEEVENTF.WHEEL;


            byte[] aux = new byte[2];
            Array.Copy(buffer, 1, aux, 0, aux.Length);
            short delta = BitConverter.ToInt16(aux, 0);

            pInputs[0].U.mi.mouseData = delta;

            SendInput(1, pInputs, sizeof(INPUT));
        }

        private void receive(ref byte[] buffer, int size) {

            int bytesPending = size;
            int offset = 0;
            int bytesRec;

            while (bytesPending > 0) {

                if (networkManager.CanRead) {

                    bytesRec = ((Stream)networkManager).Read(buffer, offset, bytesPending);
                    bytesPending = bytesPending - bytesRec;
                    offset = offset + bytesRec;

                }

            }

        }


        private void receiveAsync(byte[] buffer) {

            beginReceiveAsync();

            void beginReceiveAsync () {

                try {

                    if (socketConnected(sessionObjects.socketsStream.ToArray()[clientId])) {
                        ((Stream)networkManager).BeginRead(buffer, 0, buffer.Length, new AsyncCallback(endReceiveAsync),
                            ((Stream)networkManager));
                    }

                }

                catch (Exception exception) {

                    if (exception is IOException || exception is ObjectDisposedException) {
                        //terminateConnection();
                    }

                }

            }


            void endReceiveAsync(IAsyncResult ar) {

                try {

                    if (socketConnected(sessionObjects.socketsStream.ToArray()[clientId])) {

                        int bytesReaded = ((Stream)networkManager).EndRead(ar);

                        if (sessionObjects.allowControl) {

                            switch (buffer[0]) {
                                case 0:                                                                                                 //KeyDown event
                                    executeKeyDownEvent(ref buffer);
                                    break;
                                case 1:                                                                                                 //KeyUp event
                                    executeKeyUpEvent(ref buffer);
                                    break;
                                case 2:                                                                                                 //MouseMove event
                                    executeMouseMoveEvent(ref buffer);
                                    break;
                                case 3:                                                                                                 //MouseDown event
                                    executeMouseDownEvent(ref buffer);
                                    break;
                                case 4:                                                                                                 //MouseUp event
                                    executeMouseUpEvent(ref buffer);
                                    break;
                                case 5:                                                                                                 //MouseWheel event
                                    executeMouseWheelEvent(ref buffer);
                                    break;
                                default:
                                    break;
                            }

                        }

                        beginReceiveAsync();

                    }
                }

                catch (Exception exception) {

                    if (exception is IOException || exception is ObjectDisposedException) {
                        //terminateConnection();
                    }

                }

            }

        }



        private bool socketConnected(Socket socket) {

            bool part1 = socket.Poll(1000, SelectMode.SelectRead);
            bool part2 = (socket.Available == 0);

            if (part1 && part2) {
                return false;
            }

            else {
                return true;
            }

        }


        private void send(ref byte[] buffer) {
            ((Stream)networkManager).Write(buffer, 0, buffer.Length);
        }


        unsafe public void mainFunctionality(Object obj) {

            sessionObjects = (SessionObjects)obj;
            bool correct = true;


            if (!sessionObjects.inputParamneters.encryptedConnection) {

                networkManager = (NetworkStream)sessionObjects.networkManager;

            }

            else {

                networkManager = (SslStream)sessionObjects.networkManager;

                try {

                    ((SslStream)networkManager).AuthenticateAsServer(sessionObjects.inputParamneters.certificate, true,
                        SslProtocols.Tls12, false);
                }

                catch (AuthenticationException e) {
                    showErrorMessage("Error en la autenticación", "No se pudo realizar la autenticación con el otro extremo");
                    sessionObjects.form.Invoke((Action)delegate {
                        sessionObjects.form.Dispose();
                    });
                    correct = false;
                }

            }

            if (correct) {

                if (initialization()) {

                    byte[] buffer = new byte[Constants.requestsSize];

                    receiveAsync(buffer);

                    while (true) {

                        try {

                            if (socketConnected(sessionObjects.socketsStream.ToArray()[clientId])) {

                                lock (sessionObjects.mutex) {

                                    Monitor.Wait(sessionObjects.mutex);
                                    //BitConverter.GetBytes(HostToNetworkOrder(memoryStream.Capacity)); 			//BIG ENDIAN

                                    byte[] imageSize = BitConverter.GetBytes(sessionObjects.buffer.Length);
                                    send(ref imageSize);
                                    send(ref sessionObjects.buffer);

                                }

                            }

                            else {

                                terminateConnection();
                                break;

                            }

                        }

                        catch (Exception exception) {

                            if (exception is IOException || exception is ObjectDisposedException) {
                                terminateConnection();
                            }

                            break;

                        }

                    }

                }

            }

        }

        private void terminateConnection() {

            showInformationMessage("Conexión terminada", "Se ha finalizado la conexión de escritorio remoto");

            if (!sessionObjects.form.IsDisposed) {
                sessionObjects.form.Invoke((Action)delegate {
                    sessionObjects.form.Dispose();
                });
            }

            sessionObjects.fpsTimer.Enabled = false;
        }


        public void handleIncomingConnections(Object obj) {

            sessionObjects = (SessionObjects)obj;

            Socket listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
            bool listening = false;

            try {
                listener.Bind(sessionObjects.inputParamneters.endPoint);
                listening = true;
            }

            catch (SocketException exception) {
                showErrorMessage("Error en la escucha de conexiones", "Se ha producido un error al escuchar en la dirección " +
                    "especificada");
            }


            if (listening) {

                listener.Listen(10);

                Stream networkManager;

                while (true) {

                    Socket conectionHandler = listener.Accept();

                    if (!sessionObjects.inputParamneters.encryptedConnection) {
                        networkManager = new NetworkStream(conectionHandler);
                    }

                    else {

                        Func<object, X509Certificate, X509Chain, SslPolicyErrors, bool>
                            ValidateClientCertificate = (sender, certificate, chain, sslPolicyErrors) => {

                                bool problems = false;
                                string message = "";
                                bool validated = false;

                                if (sslPolicyErrors == SslPolicyErrors.None) {
                                    validated = true;
                                }

                                else if (sslPolicyErrors == SslPolicyErrors.RemoteCertificateChainErrors) {
                                    problems = true;
                                    message = string.Concat(message, "- No se puede validar la cadena de certificación del " +
                                        "cliente");
                                }

                                else if (sslPolicyErrors == SslPolicyErrors.RemoteCertificateNameMismatch) {
                                    problems = true;
                                    //message = string.Concat(message, "- El cliente no tiene el nombre que has especificado");
                                }

                                else if (sslPolicyErrors == SslPolicyErrors.RemoteCertificateNotAvailable) {
                                    problems = true;
                                    message = string.Concat(message, "- El otro extremo no ha suministrado su certificado");
                                }

                                if (problems) {                                                                                 //If there were problems...

                                    string caption = "Problemas de autenticación encontrados";

                                    message = string.Concat(message, "\n\n¿Estás seguro de que quieres continuar?");
                                    DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning);

                                    if (result == DialogResult.Yes) {
                                        validated = true;

                                    }

                                    else if (result == DialogResult.No) {
                                        validated = false;
                                    }

                                }

                                return validated;

                            };


                        networkManager = new SslStream(new NetworkStream(conectionHandler), false,
                            new RemoteCertificateValidationCallback(ValidateClientCertificate), null);

                    }

                    sessionObjects.networkManager = networkManager;
                    sessionObjects.socketsStream.Add(conectionHandler);

                    Thread serverThread = new Thread(new MyThread().mainFunctionality);
                    serverThread.Start(sessionObjects);

                }

            }

        }

        private void showErrorMessage(string caption, string message) {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        private void showInformationMessage(string caption, string message) {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }


    public class SessionObjects {
        public string protocol;
        public InputParameters inputParamneters;
        public string password;
        public byte fps;
        public byte colorDepth;
        public List<string> machineClientsName;
        public Stream networkManager;
        public System.Timers.Timer fpsTimer;
        public BitmapScreen bitmapScreen;
        public BitmapOffScreen bitmapOffScreen;
        public byte[] buffer;
        public object mutex;
        public byte clientsConnected;
        public bool allowControl = true;
        public MainWindow form;
        public List<Socket> socketsStream;
    }


    public static class Constants {
        public const byte passwordLength = 10;
        public const byte machineNameEncodingSize = 1;
        public const byte colorDepthEncodingSize = 1;
        public const byte fpsEncodingSize = 1;
        public const byte requestsSize = 5;
        public const byte accessEncodingSize = 1;
        public const byte maxMachineNameLength = 15;
    }

}
