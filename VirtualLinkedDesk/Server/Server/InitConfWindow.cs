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

namespace Server {
    public partial class InitConfWindow : Form {

        private string certificateFilePath;

        public InitConfWindow() {
            InitializeComponent();
        }

        private void startButtonClick(object sender, EventArgs e) {

            MainWindow mainWindow;

            try {

                IPEndPoint endPoint = IPEndPoint.Parse(endPointBox.Text);

                if (ownIPAddr(endPointBox.Text)) {

                    if (!encryptedConnectionCheckBox.Checked) {
                        mainWindow = new MainWindow(IPEndPoint.Parse(endPointBox.Text), encryptedConnectionCheckBox.Checked);
                    }

                    else {

                        X509Certificate2 certificate = new X509Certificate2(certificateFilePath, passwordCertificateBox.Text);
                        mainWindow = new MainWindow(IPEndPoint.Parse(endPointBox.Text), encryptedConnectionCheckBox.Checked,
                            certificate);

                    }

                    mainWindow.ShowDialog();

                }

                else {
                    showWarningMessage("Dirección IP inválida", "Has introducido una dirección IP que no coincide con ninguna de " +
                        "las de tus tarjetas de red");
                }

            }

            catch (FormatException exception) {
                showWarningMessage("Extremo final inválido", "Has introducido incorrectamente la dirección IP y el puerto");
            }

            catch (Exception exception) {
                showWarningMessage("Error de entradas", "Has introducido un(s) parámetro(s) inválido(s)");
            }

        }


        private bool ownIPAddr(string endPoint) {

            IPHostEntry IPEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] IPAddressList = IPEntry.AddressList;

            string[] IPAddr = endPoint.Split(":");

            for (int i = 0; i < IPAddressList.Length; i++) {

                if (IPAddr[0] == IPAddressList[i].ToString()) {
                    return true;
                }

            }

            return false;

        }


        private void showWarningMessage(string caption, string message) {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        private void showCertificateFileDialog(object sender, EventArgs e) {

            if (openCertificateFileDialog.ShowDialog() == DialogResult.OK) {

                certificateFilePath = openCertificateFileDialog.FileName;
                string[] folders = certificateFilePath.Split("\\");

                certificateFileNameLabel.Text = folders[folders.Length - 1];
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

            if (encryptedConnectionCheckBox.Checked) {                                                                                  //If it was not checked

                certificateFileLabel.ForeColor = System.Drawing.Color.White;
                selectCertificateButton.Enabled = true;
                certificateFileNameLabel.ForeColor = System.Drawing.Color.White;
                passwordCertificateLabel.ForeColor = System.Drawing.Color.White;
                passwordCertificateBox.Enabled = true;

            }

            else {

                certificateFileLabel.ForeColor = System.Drawing.Color.Gray;
                selectCertificateButton.Enabled = false;
                certificateFileNameLabel.ForeColor = System.Drawing.Color.Gray;
                passwordCertificateLabel.ForeColor = System.Drawing.Color.Gray;
                passwordCertificateBox.Enabled = false;

            }

        }
    }
}
