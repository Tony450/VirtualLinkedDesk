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
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Diagnostics;


namespace Client {
    public partial class InitConfWindow : Form {

        private string certificateFilePath;

        unsafe public InitConfWindow() {
            InitializeComponent();

        }

        private void connectButtonClick(object sender, EventArgs e) {

            //https://stackoverflow.com/questions/816566/how-do-you-get-the-current-project-directory-from-c-sharp-code-when-creating-a-c
            //O buscar como poner un icono al raton
            //this.Hide();

            MainWindow mainWindow;

            string fps = FPSComboBox.Text;
            string colorDepth = colorDepthBox.Text;

            if (FPSComboBox.Text == "") {
                fps = "20";
            }

            if (colorDepthBox.Text == "") {
                colorDepth = "0";
            }

            try {

                IPEndPoint endPoint = IPEndPoint.Parse(endPointBox.Text);

                if (passwordBox.Text != "") {

                    if (!encryptedConnectionCheckBox.Checked) {                                                                             //Conexion no cifrada

                        mainWindow = new MainWindow(endPoint, byte.Parse(fps), byte.Parse(colorDepth),
                            passwordBox.Text, encryptedConnectionCheckBox.Checked);

                        mainWindow.ShowDialog();

                    }

                    else {                                                                                                                  //Conexion cifrada


                        if (expectedCertificateNameBox.Text != "") {

                            X509Certificate2 certificate = new X509Certificate2(certificateFilePath, passwordCertificateBox.Text);          //Si no se especifica contra que se hace aqui?
                            mainWindow = new MainWindow(endPoint, byte.Parse(fps), byte.Parse(colorDepth),
                                passwordBox.Text, encryptedConnectionCheckBox.Checked, expectedCertificateNameBox.Text, certificate);

                            mainWindow.ShowDialog();

                        }

                        else {
                            showWarningMessage("Nombre esperado del servidor no introducido", "No has introducido el nombre que esperas " +
                                "que tenga el servidor en su certificado");
                        }

                    }

                }

                else {
                    showWarningMessage("Contraseña no introducida", "No has introducido la contraseña de autenticación");
                }

            }


            catch (FormatException exception) {
                showWarningMessage("Extremo final inválido", "Has introducido incorrectamente la dirección IP y el puerto");
            }

            catch (Exception exception) {
                showWarningMessage("Error de entradas", "Has introducido un(s) parámetro(s) inválido(s)");
            }

        }


        private void showWarningMessage(string caption, string message) {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }



        private void showCertificateFileDialog(object sender, EventArgs e) {

            if (openCertificateFileDialog.ShowDialog() == DialogResult.OK) {

                certificateFilePath = openCertificateFileDialog.FileName;
                string[] folders = certificateFilePath.Split("\\");

                certificateNameLabel.Text = folders[folders.Length - 1];
                openCertificateFileDialog.FileName = "";

            }

        }


        private void webSiteClick(object sender, EventArgs e) {
            Process.Start("explorer.exe", "https://github.com/Tony450/VirtualLinkedDesk");
        }


        private void aboutButtonClick(object sender, EventArgs e) {

            string caption = "VirtualLinkedDesk";
            string message = "- Version: 1.0.1\n" +
                "- Commit: \n" +
                "- License: Copyright (C) 2021 Antonio Manuel Hernández De\n   León, <tony450.vld@gmail.com>. Licensed under the " +
                "GPL\n   license.";

            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void encryptedConnectionClick(object sender, MouseEventArgs e) {

            if (encryptedConnectionCheckBox.Checked) {                                                                                      //Si no estaba checkeado

                serverHostNameLabel.ForeColor = System.Drawing.Color.White;
                expectedCertificateNameBox.Enabled = true;
                certificateFileNameLabel.ForeColor = System.Drawing.Color.White;
                certificateNameLabel.ForeColor = System.Drawing.Color.White;
                selectCertificateButton.Enabled = true;
                passwordCertificateLabel.ForeColor = System.Drawing.Color.White;
                passwordCertificateBox.Enabled = true;

            }

            else {

                serverHostNameLabel.ForeColor = System.Drawing.Color.Gray;
                expectedCertificateNameBox.Enabled = false;
                certificateFileNameLabel.ForeColor = System.Drawing.Color.Gray;
                certificateNameLabel.ForeColor = System.Drawing.Color.Gray;
                selectCertificateButton.Enabled = false;
                passwordCertificateLabel.ForeColor = System.Drawing.Color.Gray;
                passwordCertificateBox.Enabled = false;

            }

        }

        private void DropDownMenuDownClick(object sender, EventArgs e) {

            pictureDropDownMenuDownBox.Enabled = false;
            pictureDropDownMenuDownBox.Visible = false;

            FPSLabel.Visible = true;
            FPSComboBox.Visible = true;
            FPSComboBox.Enabled = true;
            colorDepthLabel.Visible = true;
            colorDepthBox.Visible = true;
            colorDepthBox.Enabled = true;

            pictureDropDownMenuUpBox.Enabled = true;
            pictureDropDownMenuUpBox.Visible = true;

        }

        private void DropDownMenuUpClick(object sender, EventArgs e) {

            pictureDropDownMenuDownBox.Enabled = true;
            pictureDropDownMenuDownBox.Visible = true;

            FPSLabel.Visible = false;
            FPSComboBox.Visible = false;
            FPSComboBox.Enabled = false;
            colorDepthLabel.Visible = false;
            colorDepthBox.Visible = false;
            colorDepthBox.Enabled = false;

            pictureDropDownMenuUpBox.Enabled = false;
            pictureDropDownMenuUpBox.Visible = false;

        }
    }

}
