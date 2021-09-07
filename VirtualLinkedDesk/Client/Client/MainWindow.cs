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
using System.IO;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Net.Security;

using System.Runtime.InteropServices;
using System.Collections.Concurrent;

using System.Security.Cryptography.X509Certificates;
using System.Security.Authentication;

using BitmapLibrary;                                                                                                                    //Biblioteca bitmap

using static Client.User32;
using static Client.Utils;

public struct InputParameters {
    public IPEndPoint endPoint;
    public string password;
    public bool encryptedConnection;
    public byte fps;
    public byte colorDepth;
    public string serverHostName;
    public X509Certificate2 certificate;
}


namespace Client {
    public partial class MainWindow : Form {

        private SessionObjects sessionObjects = new SessionObjects();


        public MainWindow(IPEndPoint endPoint, byte fps, byte colorDepth, string password, bool encryptedConnection,
            string expectedServerName = null, X509Certificate2 certificate = null) {

            InitializeComponent();

            sessionObjects.protocol = "RDE 01.00";
            sessionObjects.inputParamneters.endPoint = endPoint;
            sessionObjects.inputParamneters.fps = fps;
            sessionObjects.inputParamneters.colorDepth = colorDepth;
            sessionObjects.inputParamneters.password = password;
            sessionObjects.inputParamneters.encryptedConnection = encryptedConnection;
            sessionObjects.form = this;
            sessionObjects.topEdge = (short)disconnectPseudoButton.Size.Height;

            if (!sessionObjects.inputParamneters.encryptedConnection) {

                sessionObjects.topEdge = (short)(sessionObjects.topEdge + connectionNotSecureLabel.Size.Height);
                connectionNotSecureLabel.Visible = true;

            }

            else {

                sessionObjects.inputParamneters.serverHostName = expectedServerName;
                sessionObjects.inputParamneters.certificate = certificate;

                disconnectPseudoButton.Location = new Point((this.ClientSize.Width / 2) - (disconnectPseudoButton.Size.Width / 2), 0);

            }

            sessionObjects.windowHandle = Handle;

            connectService();

        }


        public void connectService() {

            Thread clientThread = new Thread(new MyThread().connectEndPoint);
            clientThread.Start(sessionObjects);

        }

        private void paintWindow(object sender, PaintEventArgs e) {

            if (sessionObjects.bitmapOffScreen != null) {

                if (sessionObjects.inputParamneters.colorDepth == 0) {                                                                  //Compresion

                    if (sessionObjects.compressionBitmap != null) {

                        if (sessionObjects.imageSize.IsEmpty) {
                            sessionObjects.imageSize = computeImageSize(this.ClientSize);
                        }

                        sessionObjects.edgeStart[0] = (short)((this.ClientSize.Width - sessionObjects.imageSize.Width)/2);
                        sessionObjects.edgeStart[1] = (short)(((this.ClientSize.Height - sessionObjects.imageSize.Height)/2) +
                            sessionObjects.topEdge);

                        e.Graphics.DrawImage(sessionObjects.compressionBitmap, sessionObjects.edgeStart[0],
                            sessionObjects.edgeStart[1], sessionObjects.imageSize.Width, sessionObjects.imageSize.Height -
                            sessionObjects.topEdge);

                    }

                }

                else {

                    dynamic g = this.CreateGraphics();
                    IntPtr canvas_dc = g.GetHdc();

                    if (sessionObjects.imageSize.IsEmpty) {
                        sessionObjects.imageSize = computeImageSize(this.ClientSize);
                    }

                    sessionObjects.bitmapOffScreen.copyTo(canvas_dc, sessionObjects.imageSize.Width, sessionObjects.imageSize.Height);
                    g.ReleaseHdc(canvas_dc);

                }
            }

        }

        private void handleKeyDownEvent(object sender, KeyEventArgs e) {

            if (sessionObjects.bitmapOffScreen != null) {
                handleKeyBoardEvent(e, 0);
            }
        }

        private void handleKeyUpEvent(object sender, KeyEventArgs e) {

            if (sessionObjects.bitmapOffScreen != null) {
                handleKeyBoardEvent(e, 1);
            }
        }

        private void handleKeyBoardEvent(KeyEventArgs e, byte type) {

            byte[] buffer = new byte[Constants.requestsSize];
            buffer[0] = type;
            Array.Copy(BitConverter.GetBytes((short)e.KeyValue), 0, buffer, 1, 2);
            sessionObjects.requestsQueue.Enqueue(buffer);

        }


        private void handleMouseDownEvent(object sender, MouseEventArgs e) {

            if (sessionObjects.bitmapOffScreen != null) {
                if (insideEdges(e)) {
                    handleMouseButtonEvent(e, 3);                                                                                       //Evento MouseDown
                }
            }

        }

        private void handleMouseUpEvent(object sender, MouseEventArgs e) {

            if (sessionObjects.bitmapOffScreen != null) {
                if (insideEdges(e)) {
                    handleMouseButtonEvent(e, 4);                                                                                       //Evento MouseUp
                }
            }

        }


        private void handleMouseButtonEvent(MouseEventArgs e, byte type) {

            byte[] buffer = new byte[Constants.requestsSize];
            buffer[0] = type;

            switch (e.Button.ToString()) {
                case "Left":
                    buffer[1] = 0;
                    break;
                case "Right":
                    buffer[1] = 1;
                    break;
                case "Middle":
                    buffer[1] = 2;
                    break;
                case "XButton1":
                    buffer[1] = 3;
                    break;
                case "XButton2":
                    buffer[1] = 4;
                    break;
                default:
                    break;
            }

            sessionObjects.requestsQueue.Enqueue(buffer);

        }

        private void handleMouseMoveEvent(object sender, MouseEventArgs e) {

            if (sessionObjects.bitmapOffScreen != null) {

                if (insideEdges(e)) {

                    ushort map(double value, double from1, double to1, double from2, double to2) {
                        return (ushort)(uint)(int)((value - from1) / (to1 - from1) * (to2 - from2) + from2);
                    }

                    int XvalueAdapted = e.X - sessionObjects.edgeStart[0];
                    int YvalueAdapted = e.Y - sessionObjects.edgeStart[1];


                    ushort x = map(XvalueAdapted, 0, sessionObjects.imageSize.Width, 0, sessionObjects.bitmapOffScreen.getWidth());
                    ushort y = map(YvalueAdapted, 0, sessionObjects.imageSize.Height - sessionObjects.topEdge, 0,
                        sessionObjects.bitmapOffScreen.getHeight());

                    byte[] buffer = new byte[Constants.requestsSize];
                    buffer[0] = 2;                                                                                                      //Evento MouseUp

                    Array.Copy(BitConverter.GetBytes(x), 0, buffer, 1, 2);
                    Array.Copy(BitConverter.GetBytes(y), 0, buffer, 3, 2);

                    sessionObjects.requestsQueue.Enqueue(buffer);

                }

            }

        }

        private void handleMouseWheelEvent(object sender, MouseEventArgs e) {

            if (sessionObjects.bitmapOffScreen != null) {

                if (insideEdges(e)) {

                    byte[] buffer = new byte[Constants.requestsSize];
                    buffer[0] = 5;                                                                                                      //Evento MouseWheel

                    short delta = (short)e.Delta;
                    Array.Copy(BitConverter.GetBytes(delta), 0, buffer, 1, 2);                                                          //Copiamos dos bytes ( de la poisicon 1 a 3)

                    sessionObjects.requestsQueue.Enqueue(buffer);

                }

            }

        }


        private Size computeImageSize(Size clientSize) {

            double ratio = (double) sessionObjects.bitmapOffScreen.getWidth() / sessionObjects.bitmapOffScreen.getHeight();             //Siempre va a dar 1.778 (16/9)
            int w = (int)(ratio * clientSize.Height);

            if (w > clientSize.Width) {
                w = clientSize.Width;
            }
            int h = (int)(w / ratio);

            return new Size(w, h);
        }


        private void handleResizeEvent(object sender, EventArgs e) {                                                                    //Cuando cambia el tamanio

            if (!sessionObjects.inputParamneters.encryptedConnection) {
                connectionNotSecureLabel.Size = new Size(this.ClientSize.Width, 25);
                disconnectPseudoButton.Location = new Point((this.ClientSize.Width / 2) - (disconnectPseudoButton.Size.Width / 2), 25);
            }

            else {
                disconnectPseudoButton.Location = new Point((this.ClientSize.Width / 2) - (disconnectPseudoButton.Size.Width / 2), 0);
            }


            if (sessionObjects.form.CanFocus) {
                sessionObjects.form.Focus();
            }


            if (sessionObjects.bitmapOffScreen != null) {
                sessionObjects.imageSize = computeImageSize(this.ClientSize);
            }

        }


        private bool insideEdges(MouseEventArgs e) {

            short[] edgeFinish = new short[2];
            edgeFinish[0] = (short)(sessionObjects.imageSize.Width + sessionObjects.edgeStart[0]);
            edgeFinish[1] = (short)(sessionObjects.imageSize.Height + sessionObjects.edgeStart[1]);

            if ((e.X >= sessionObjects.edgeStart[0] && e.Y >= sessionObjects.edgeStart[1]) &&
                (e.X <= edgeFinish[0] && e.Y <= edgeFinish[1])) {

                return true;

            }

            else {
                return false;
            }

        }

        private void disconnectButtonClick(object sender, MouseEventArgs e) {

            //this.Dispose();

        }
    }


    public class MyThread {

        SessionObjects sessionObjects;

        private bool handshake() {

            byte[] buffer;
            bool correct = true;

            buffer = new byte[sessionObjects.protocol.Length];                                                                          //Protocolo (Recibo)
            receive(ref buffer, buffer.Length);
            string receivedProtocol = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
            if (!String.Equals(sessionObjects.protocol, receivedProtocol)) {
                correct = false;
            }

            buffer = Encoding.ASCII.GetBytes(sessionObjects.protocol);                                                                  //Protocolo (Envio)
            send(ref buffer);

            buffer = Encoding.ASCII.GetBytes(sessionObjects.inputParamneters.password);                                                 //Contraseña (Envio)
            send(ref buffer);

            buffer = new byte[Constants.accessEncodingSize];                                                                            //Verificacion contraseña
            receive(ref buffer, buffer.Length);


            if (buffer[0] == 0) {                                                                                                       //Contrasena incorrecta

                showWarningMessage("Autenticación fallida", "La contraseña que has introducido es incorrecta");
                sessionObjects.form.Invoke((Action)delegate {
                    sessionObjects.form.Dispose();
                });
                correct = false;

            }


            return correct;

        }


        private bool initialization() {

            if (handshake()) {

                byte[] buffer = new byte[Constants.machineNameEncodingSize];                                                            //Longitud nombre maquina (Recibo)
                receive(ref buffer, buffer.Length);

                if (buffer[0] <= Constants.maxMachineNameLengh) {

                    buffer = new byte[buffer[0]];
                    receive(ref buffer, buffer.Length);                                                                                 //Nombre maquina (Recibo)
                    sessionObjects.machineServerName = Encoding.ASCII.GetString(buffer, 0, buffer.Length);

                    sessionObjects.form.Invoke((Action)delegate {
                        sessionObjects.form.Text = sessionObjects.form.Text + " - Conexión con " + sessionObjects.machineServerName;
                    });

                    sessionObjects.serverScreenDimensions = new ushort[2];

                    buffer = new byte[Constants.screenDimensionsEncodingSize];
                    receive(ref buffer, buffer.Length);                                                                                 //Dimensiones pantalla
                    sessionObjects.serverScreenDimensions[0] = BitConverter.ToUInt16(buffer, 0);
                    receive(ref buffer, buffer.Length);
                    sessionObjects.serverScreenDimensions[1] = BitConverter.ToUInt16(buffer, 0);

                    if ((sessionObjects.serverScreenDimensions[0] > 200 && sessionObjects.serverScreenDimensions[0] < 7680) &&
                        (sessionObjects.serverScreenDimensions[1] > 200 && sessionObjects.serverScreenDimensions[1] < 4320)) {          //Maximo resolucion 8k

                        buffer = new byte[Constants.machineNameEncodingSize];
                        buffer[0] = (byte)Environment.MachineName.Length;                                                               //Longitud nombre maquina (Envio)
                        send(ref buffer);

                        buffer = Encoding.ASCII.GetBytes(Environment.MachineName);                                                      //Nombre maquina (Envio)
                        send(ref buffer);

                        buffer = new byte[Constants.fpsEncodingSize];
                        buffer[0] = sessionObjects.inputParamneters.fps;                                                                //FPS
                        send(ref buffer);

                        buffer[0] = sessionObjects.inputParamneters.colorDepth;                                                         //Profundidad de color
                        send(ref buffer);

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
                return false;
            }

        }

        private void receive(ref byte[] buffer, int size) {

            int bytesPending = size;
            int offset = 0;
            int bytesRec;

            while (bytesPending > 0) {

                if (sessionObjects.networkManager.CanRead) {

                    bytesRec = sessionObjects.networkManager.Read(buffer, offset, bytesPending);
                    bytesPending -= bytesRec;
                    offset += bytesRec;

                }

            }

        }

        private void send(ref byte[] buffer) {

            sessionObjects.networkManager.Write(buffer, 0, buffer.Length);

        }


        private void invalidateWindow(IntPtr hwnd) {

            RECT rct;
            GetClientRect(hwnd, out rct);

            IntPtr pnt = Marshal.AllocHGlobal(Marshal.SizeOf(rct));

            Marshal.StructureToPtr(rct, pnt, false);
            InvalidateRect(hwnd, pnt, false);

        }

        public void mainFunctionality() {

            bool correct = true;


            if (sessionObjects.inputParamneters.encryptedConnection) {

                try {

                    ((SslStream)sessionObjects.networkManager).AuthenticateAsClient(sessionObjects.inputParamneters.serverHostName,
                        new X509Certificate2Collection(sessionObjects.inputParamneters.certificate), SslProtocols.Tls12, false);

                }

                catch (AuthenticationException e) {

                    showErrorMessage("Error en la autentidación", "No se pudo realizar la autenticación con el otro extremo");
                    sessionObjects.form.Invoke((Action)delegate {
                        sessionObjects.form.Dispose();
                    });
                    correct = false;

                }

            }

            if (correct) {

                if (initialization()) {

                    byte[] bufferImageSize = new byte[Constants.imageBytesEncodingSize];

                    sessionObjects.requestsQueue = new ConcurrentQueue<byte[]>();
                    Thread senderEventsThread = new Thread(new MyThread().sendQueuedEvents);
                    senderEventsThread.Start(sessionObjects);

                    sessionObjects.bitmapOffScreen = new BitmapOffScreen(sessionObjects.serverScreenDimensions[0],
                        sessionObjects.serverScreenDimensions[1], sessionObjects.inputParamneters.colorDepth);

                    while (true) {


                        receive(ref bufferImageSize, Constants.imageBytesEncodingSize);
                        //NetworktoHostOrder
                        int bitmapSize = BitConverter.ToInt32(bufferImageSize, 0);

                        if (bitmapSize > 0 && bitmapSize <= 104857600) {                                                                //100 MB de tamaño maximo

                            byte[] buffer = new byte[bitmapSize];
                            receive(ref buffer, bitmapSize);


                            if (sessionObjects.inputParamneters.colorDepth == 0) {                                                      //Compresion

                                MemoryStream memoryStream = new MemoryStream(buffer);                                                   //MemoryStream hereda de Stream
                                sessionObjects.compressionBitmap = new System.Drawing.Bitmap(memoryStream);

                            }


                            else {                                                                                                      //Sin compresion

                                Span<byte> s;
                                unsafe {
                                    s = new Span<byte>(sessionObjects.bitmapOffScreen.getData().ToPointer(),
                                        sessionObjects.bitmapOffScreen.getSize());
                                }
                                MemoryExtensions.CopyTo(buffer, s);

                            }

                            invalidateWindow(sessionObjects.windowHandle);

                        }

                        else {

                            showErrorMessage("Error interno", "Se ha producido un error en el protocolo");
                            sessionObjects.form.Invoke((Action)delegate {
                                sessionObjects.form.Dispose();
                            });
                            break;

                        }

                    }

                }

            }

        }

        public void connectEndPoint(Object obj) {

            sessionObjects = (SessionObjects)obj;

            Socket connectSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            bool connected = false;

            try {
                connectSocket.Connect(sessionObjects.inputParamneters.endPoint);
                connected = true;
            }

            catch (SocketException exception) {
                showErrorMessage("Parte servidora no disponible", "No se ha podido contactar con la parte servidora");
            }


            if (connected) {

                sessionObjects.form.Invoke((Action)delegate {
                    sessionObjects.form.Opacity = 1D;
                });

                if (!sessionObjects.inputParamneters.encryptedConnection) {

                    sessionObjects.networkManager = new NetworkStream(connectSocket);

                }

                else {

                    Func<object, X509Certificate, X509Chain, SslPolicyErrors, bool>
                        ValidateServerCertificate = (sender, certificate, chain, sslPolicyErrors) => {

                            bool problems = false;
                            string message = "";
                            bool validated = false;

                            if (sslPolicyErrors == SslPolicyErrors.None) {
                                validated =  true;
                            }

                            else if (sslPolicyErrors == SslPolicyErrors.RemoteCertificateChainErrors) {
                                problems = true;
                                message = string.Concat(message, "- No se puede validar la cadena de certificación del servidor");
                            }

                            else if (sslPolicyErrors == SslPolicyErrors.RemoteCertificateNameMismatch) {
                                problems = true;
                                message = string.Concat(message, "- El servidor no tiene el nombre que has especificado");
                            }

                            else if (sslPolicyErrors == SslPolicyErrors.RemoteCertificateNotAvailable) {
                                problems = true;
                                message = string.Concat(message, "- El otro extremo no ha suministrado su certificado");
                            }


                            if (problems) {                                                                                             //Si ha habido problemas...

                                string caption = "Problemas de autenticación encontrados";

                                message = string.Concat(message, "\n\n¿Estás seguro de que quieres continuar?");
                                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning);

                                if (result == DialogResult.Yes) {
                                    validated =  true;

                                }

                                else if (result == DialogResult.No) {
                                    validated =  false;
                                }
                            }

                            return validated;
                        };

                    sessionObjects.networkManager = new SslStream(new NetworkStream(connectSocket), false,
                        new RemoteCertificateValidationCallback(ValidateServerCertificate), null);

                }

                sessionObjects.socketStream = connectSocket;

                mainFunctionality();

            }

            else {

                sessionObjects.form.Invoke((Action)delegate {
                    sessionObjects.form.Dispose();
                });

            }

        }

        public void sendQueuedEvents(Object obj) {

            sessionObjects = (SessionObjects)obj;

            while (true) {

                byte[] buffer;
                if (sessionObjects.requestsQueue.TryPeek(out buffer)) {                                                                 //Si hay operaciones pendientes...
                    if (sessionObjects.requestsQueue.TryDequeue(out buffer)) {
                        send(ref buffer);
                    }
                }
            }

        }

        private void showErrorMessage(string caption, string message) {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void showWarningMessage(string caption, string message) {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void showInformationMessage(string caption, string message) {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }


    public class SessionObjects {
        public string protocol;
        public InputParameters inputParamneters;
        public string machineServerName;
        public ushort[] serverScreenDimensions;
        public Stream networkManager;
        public IntPtr windowHandle;
        public System.Drawing.Bitmap compressionBitmap;
        public BitmapOffScreen bitmapOffScreen;
        public ConcurrentQueue<byte[]> requestsQueue;
        public Size imageSize;
        public short[] edgeStart = new short[2];
        public short topEdge;
        public MainWindow form;
        public Socket socketStream;
    }


    public static class Constants {
        public const byte machineNameEncodingSize = 1;
        public const byte screenDimensionsEncodingSize = 2;
        public const byte fpsEncodingSize = 1;
        public const byte requestsSize = 5;
        public const byte imageBytesEncodingSize = 4;
        public const byte accessEncodingSize = 1;
        public const byte maxMachineNameLengh = 15;
    }


}
