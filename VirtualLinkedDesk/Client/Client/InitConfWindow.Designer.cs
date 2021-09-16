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

namespace Client
{
    partial class InitConfWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitConfWindow));
            this.connectButton = new System.Windows.Forms.Button();
            this.endPointBox = new System.Windows.Forms.TextBox();
            this.endPointLabel = new System.Windows.Forms.Label();
            this.colorDepthLabel = new System.Windows.Forms.Label();
            this.colorDepthBox = new System.Windows.Forms.ComboBox();
            this.FPSLabel = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.FPSComboBox = new System.Windows.Forms.ComboBox();
            this.encryptedConnectionCheckBox = new System.Windows.Forms.CheckBox();
            this.serverHostNameLabel = new System.Windows.Forms.Label();
            this.openCertificateFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.selectCertificateButton = new System.Windows.Forms.Button();
            this.certificateNameLabel = new System.Windows.Forms.Label();
            this.expectedCertificateNameBox = new System.Windows.Forms.TextBox();
            this.certificateFileNameLabel = new System.Windows.Forms.Label();
            this.passwordCertificateLabel = new System.Windows.Forms.Label();
            this.passwordCertificateBox = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spanishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VirtualLinkedDeskWebSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutVirtualLinkedDeskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureDropDownMenuDownBox = new System.Windows.Forms.PictureBox();
            this.advancedOptionsLabel = new System.Windows.Forms.Label();
            this.pictureDropDownMenuUpBox = new System.Windows.Forms.PictureBox();
            this.programNameLabel = new System.Windows.Forms.Label();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDropDownMenuDownBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDropDownMenuUpBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(255)))));
            this.connectButton.FlatAppearance.BorderSize = 0;
            this.connectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.connectButton.ForeColor = System.Drawing.Color.White;
            this.connectButton.Location = new System.Drawing.Point(803, 446);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(80, 32);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Conectar";
            this.connectButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.connectButton.UseVisualStyleBackColor = false;
            this.connectButton.Click += new System.EventHandler(this.connectButtonClick);
            // 
            // endPointBox
            // 
            this.endPointBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.endPointBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.endPointBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.endPointBox.ForeColor = System.Drawing.Color.White;
            this.endPointBox.Location = new System.Drawing.Point(144, 120);
            this.endPointBox.Name = "endPointBox";
            this.endPointBox.Size = new System.Drawing.Size(184, 29);
            this.endPointBox.TabIndex = 1;
            // 
            // endPointLabel
            // 
            this.endPointLabel.AutoSize = true;
            this.endPointLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.endPointLabel.ForeColor = System.Drawing.Color.White;
            this.endPointLabel.Location = new System.Drawing.Point(100, 63);
            this.endPointLabel.Name = "endPointLabel";
            this.endPointLabel.Size = new System.Drawing.Size(244, 42);
            this.endPointLabel.TabIndex = 2;
            this.endPointLabel.Text = "Dirección IP y puerto a conectarse\rEjemplo: \"192.168.1.12:6001\"";
            // 
            // colorDepthLabel
            // 
            this.colorDepthLabel.AutoSize = true;
            this.colorDepthLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.colorDepthLabel.ForeColor = System.Drawing.Color.White;
            this.colorDepthLabel.Location = new System.Drawing.Point(710, 310);
            this.colorDepthLabel.Name = "colorDepthLabel";
            this.colorDepthLabel.Size = new System.Drawing.Size(156, 21);
            this.colorDepthLabel.TabIndex = 6;
            this.colorDepthLabel.Text = "Profundidad de color";
            this.colorDepthLabel.Visible = false;
            // 
            // colorDepthBox
            // 
            this.colorDepthBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.colorDepthBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorDepthBox.Enabled = false;
            this.colorDepthBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorDepthBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.colorDepthBox.ForeColor = System.Drawing.Color.White;
            this.colorDepthBox.FormattingEnabled = true;
            this.colorDepthBox.Items.AddRange(new object[] {
            "",
            "1",
            "4",
            "8",
            "16",
            "24",
            "32"});
            this.colorDepthBox.Location = new System.Drawing.Point(728, 345);
            this.colorDepthBox.Name = "colorDepthBox";
            this.colorDepthBox.Size = new System.Drawing.Size(121, 29);
            this.colorDepthBox.TabIndex = 7;
            this.colorDepthBox.Visible = false;
            // 
            // FPSLabel
            // 
            this.FPSLabel.AutoSize = true;
            this.FPSLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FPSLabel.ForeColor = System.Drawing.Color.White;
            this.FPSLabel.Location = new System.Drawing.Point(609, 310);
            this.FPSLabel.Name = "FPSLabel";
            this.FPSLabel.Size = new System.Drawing.Size(36, 21);
            this.FPSLabel.TabIndex = 8;
            this.FPSLabel.Text = "FPS";
            this.FPSLabel.Visible = false;
            // 
            // passwordBox
            // 
            this.passwordBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.passwordBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordBox.ForeColor = System.Drawing.Color.White;
            this.passwordBox.Location = new System.Drawing.Point(616, 180);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(184, 29);
            this.passwordBox.TabIndex = 10;
            this.passwordBox.UseSystemPasswordChar = true;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordLabel.ForeColor = System.Drawing.Color.White;
            this.passwordLabel.Location = new System.Drawing.Point(605, 144);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(206, 21);
            this.passwordLabel.TabIndex = 11;
            this.passwordLabel.Text = "Contraseña de autenticación";
            // 
            // FPSComboBox
            // 
            this.FPSComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.FPSComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FPSComboBox.Enabled = false;
            this.FPSComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FPSComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FPSComboBox.ForeColor = System.Drawing.Color.White;
            this.FPSComboBox.FormattingEnabled = true;
            this.FPSComboBox.Items.AddRange(new object[] {
            "",
            "5",
            "10",
            "15",
            "20",
            "25"});
            this.FPSComboBox.Location = new System.Drawing.Point(567, 345);
            this.FPSComboBox.Name = "FPSComboBox";
            this.FPSComboBox.Size = new System.Drawing.Size(121, 29);
            this.FPSComboBox.TabIndex = 12;
            this.FPSComboBox.Visible = false;
            // 
            // encryptedConnectionCheckBox
            // 
            this.encryptedConnectionCheckBox.AutoSize = true;
            this.encryptedConnectionCheckBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.encryptedConnectionCheckBox.ForeColor = System.Drawing.Color.White;
            this.encryptedConnectionCheckBox.Location = new System.Drawing.Point(163, 185);
            this.encryptedConnectionCheckBox.Name = "encryptedConnectionCheckBox";
            this.encryptedConnectionCheckBox.Size = new System.Drawing.Size(145, 25);
            this.encryptedConnectionCheckBox.TabIndex = 13;
            this.encryptedConnectionCheckBox.Text = "Conexión cifrada";
            this.encryptedConnectionCheckBox.UseVisualStyleBackColor = true;
            this.encryptedConnectionCheckBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.encryptedConnectionClick);
            // 
            // serverHostNameLabel
            // 
            this.serverHostNameLabel.AutoSize = true;
            this.serverHostNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.serverHostNameLabel.ForeColor = System.Drawing.Color.Gray;
            this.serverHostNameLabel.Location = new System.Drawing.Point(100, 223);
            this.serverHostNameLabel.Name = "serverHostNameLabel";
            this.serverHostNameLabel.Size = new System.Drawing.Size(271, 21);
            this.serverHostNameLabel.TabIndex = 13;
            this.serverHostNameLabel.Text = "Nombre del servidor en su certificado";
            // 
            // openCertificateFileDialog
            // 
            this.openCertificateFileDialog.Filter = "Archivos PKCS #12 (*.pfx; *.p12)|*.pfx; *.p12";
            // 
            // selectCertificateButton
            // 
            this.selectCertificateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(255)))));
            this.selectCertificateButton.Enabled = false;
            this.selectCertificateButton.FlatAppearance.BorderSize = 0;
            this.selectCertificateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.selectCertificateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectCertificateButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectCertificateButton.ForeColor = System.Drawing.Color.White;
            this.selectCertificateButton.Location = new System.Drawing.Point(122, 336);
            this.selectCertificateButton.Name = "selectCertificateButton";
            this.selectCertificateButton.Size = new System.Drawing.Size(98, 32);
            this.selectCertificateButton.TabIndex = 14;
            this.selectCertificateButton.Text = "Seleccionar";
            this.selectCertificateButton.UseVisualStyleBackColor = false;
            this.selectCertificateButton.Click += new System.EventHandler(this.showCertificateFileDialog);
            // 
            // certificateNameLabel
            // 
            this.certificateNameLabel.AutoSize = true;
            this.certificateNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.certificateNameLabel.ForeColor = System.Drawing.Color.White;
            this.certificateNameLabel.Location = new System.Drawing.Point(241, 342);
            this.certificateNameLabel.Name = "certificateNameLabel";
            this.certificateNameLabel.Size = new System.Drawing.Size(0, 21);
            this.certificateNameLabel.TabIndex = 15;
            // 
            // expectedCertificateNameBox
            // 
            this.expectedCertificateNameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.expectedCertificateNameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.expectedCertificateNameBox.Enabled = false;
            this.expectedCertificateNameBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.expectedCertificateNameBox.ForeColor = System.Drawing.Color.White;
            this.expectedCertificateNameBox.Location = new System.Drawing.Point(144, 260);
            this.expectedCertificateNameBox.Name = "expectedCertificateNameBox";
            this.expectedCertificateNameBox.Size = new System.Drawing.Size(184, 29);
            this.expectedCertificateNameBox.TabIndex = 16;
            // 
            // certificateFileNameLabel
            // 
            this.certificateFileNameLabel.AutoSize = true;
            this.certificateFileNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.certificateFileNameLabel.ForeColor = System.Drawing.Color.Gray;
            this.certificateFileNameLabel.Location = new System.Drawing.Point(100, 303);
            this.certificateFileNameLabel.Name = "certificateFileNameLabel";
            this.certificateFileNameLabel.Size = new System.Drawing.Size(85, 21);
            this.certificateFileNameLabel.TabIndex = 17;
            this.certificateFileNameLabel.Text = "Certificado";
            // 
            // passwordCertificateLabel
            // 
            this.passwordCertificateLabel.AutoSize = true;
            this.passwordCertificateLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordCertificateLabel.ForeColor = System.Drawing.Color.Gray;
            this.passwordCertificateLabel.Location = new System.Drawing.Point(100, 385);
            this.passwordCertificateLabel.Name = "passwordCertificateLabel";
            this.passwordCertificateLabel.Size = new System.Drawing.Size(253, 21);
            this.passwordCertificateLabel.TabIndex = 18;
            this.passwordCertificateLabel.Text = "Contraseña del certificado (si tiene)";
            // 
            // passwordCertificateBox
            // 
            this.passwordCertificateBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.passwordCertificateBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordCertificateBox.Enabled = false;
            this.passwordCertificateBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordCertificateBox.ForeColor = System.Drawing.SystemColors.Window;
            this.passwordCertificateBox.Location = new System.Drawing.Point(144, 422);
            this.passwordCertificateBox.Name = "passwordCertificateBox";
            this.passwordCertificateBox.Size = new System.Drawing.Size(184, 29);
            this.passwordCertificateBox.TabIndex = 19;
            this.passwordCertificateBox.UseSystemPasswordChar = true;
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(944, 27);
            this.menuStrip.TabIndex = 20;
            this.menuStrip.Text = "menuStrip";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem,
            this.themeToolStripMenuItem});
            this.optionsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.optionsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(78, 23);
            this.optionsToolStripMenuItem.Text = "Opciones";
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spanishToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.languageToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.languageToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.languageToolStripMenuItem.Text = "Idioma";
            // 
            // spanishToolStripMenuItem
            // 
            this.spanishToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.spanishToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.spanishToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.spanishToolStripMenuItem.Name = "spanishToolStripMenuItem";
            this.spanishToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.spanishToolStripMenuItem.Text = "Español";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.englishToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.englishToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.englishToolStripMenuItem.Text = "Inglés";
            // 
            // themeToolStripMenuItem
            // 
            this.themeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.themeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.darkToolStripMenuItem});
            this.themeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.themeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.themeToolStripMenuItem.Text = "Tema";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.clearToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clearToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.clearToolStripMenuItem.Text = "Claro";
            // 
            // darkToolStripMenuItem
            // 
            this.darkToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.darkToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.darkToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.darkToolStripMenuItem.Name = "darkToolStripMenuItem";
            this.darkToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.darkToolStripMenuItem.Text = "Oscuro";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VirtualLinkedDeskWebSiteToolStripMenuItem,
            this.aboutVirtualLinkedDeskToolStripMenuItem});
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(60, 23);
            this.helpToolStripMenuItem.Text = "Ayuda";
            // 
            // VirtualLinkedDeskWebSiteToolStripMenuItem
            // 
            this.VirtualLinkedDeskWebSiteToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.VirtualLinkedDeskWebSiteToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.VirtualLinkedDeskWebSiteToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.VirtualLinkedDeskWebSiteToolStripMenuItem.Name = "VirtualLinkedDeskWebSiteToolStripMenuItem";
            this.VirtualLinkedDeskWebSiteToolStripMenuItem.Size = new System.Drawing.Size(281, 24);
            this.VirtualLinkedDeskWebSiteToolStripMenuItem.Text = "Página web de VirtualLinkedDesk";
            this.VirtualLinkedDeskWebSiteToolStripMenuItem.Click += new System.EventHandler(this.webSiteClick);
            // 
            // aboutVirtualLinkedDeskToolStripMenuItem
            // 
            this.aboutVirtualLinkedDeskToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.aboutVirtualLinkedDeskToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.aboutVirtualLinkedDeskToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.aboutVirtualLinkedDeskToolStripMenuItem.Name = "aboutVirtualLinkedDeskToolStripMenuItem";
            this.aboutVirtualLinkedDeskToolStripMenuItem.Size = new System.Drawing.Size(281, 24);
            this.aboutVirtualLinkedDeskToolStripMenuItem.Text = "A cerca de VirtualLinkedDesk";
            this.aboutVirtualLinkedDeskToolStripMenuItem.Click += new System.EventHandler(this.aboutButtonClick);
            // 
            // pictureDropDownMenuDownBox
            // 
            this.pictureDropDownMenuDownBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureDropDownMenuDownBox.Image")));
            this.pictureDropDownMenuDownBox.Location = new System.Drawing.Point(559, 245);
            this.pictureDropDownMenuDownBox.Name = "pictureDropDownMenuDownBox";
            this.pictureDropDownMenuDownBox.Size = new System.Drawing.Size(30, 30);
            this.pictureDropDownMenuDownBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureDropDownMenuDownBox.TabIndex = 23;
            this.pictureDropDownMenuDownBox.TabStop = false;
            this.pictureDropDownMenuDownBox.Click += new System.EventHandler(this.DropDownMenuDownClick);
            // 
            // advancedOptionsLabel
            // 
            this.advancedOptionsLabel.AutoSize = true;
            this.advancedOptionsLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.advancedOptionsLabel.ForeColor = System.Drawing.Color.White;
            this.advancedOptionsLabel.Location = new System.Drawing.Point(595, 250);
            this.advancedOptionsLabel.Name = "advancedOptionsLabel";
            this.advancedOptionsLabel.Size = new System.Drawing.Size(265, 21);
            this.advancedOptionsLabel.TabIndex = 22;
            this.advancedOptionsLabel.Text = "Mostrar/ ocultar opciones avanzadas";
            // 
            // pictureDropDownMenuUpBox
            // 
            this.pictureDropDownMenuUpBox.Enabled = false;
            this.pictureDropDownMenuUpBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureDropDownMenuUpBox.Image")));
            this.pictureDropDownMenuUpBox.Location = new System.Drawing.Point(559, 245);
            this.pictureDropDownMenuUpBox.Name = "pictureDropDownMenuUpBox";
            this.pictureDropDownMenuUpBox.Size = new System.Drawing.Size(30, 30);
            this.pictureDropDownMenuUpBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureDropDownMenuUpBox.TabIndex = 21;
            this.pictureDropDownMenuUpBox.TabStop = false;
            this.pictureDropDownMenuUpBox.Visible = false;
            this.pictureDropDownMenuUpBox.Click += new System.EventHandler(this.DropDownMenuUpClick);
            // 
            // programNameLabel
            // 
            this.programNameLabel.AutoSize = true;
            this.programNameLabel.Font = new System.Drawing.Font("Segoe UI", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.programNameLabel.ForeColor = System.Drawing.Color.White;
            this.programNameLabel.Location = new System.Drawing.Point(699, 38);
            this.programNameLabel.Name = "programNameLabel";
            this.programNameLabel.Size = new System.Drawing.Size(220, 32);
            this.programNameLabel.TabIndex = 21;
            this.programNameLabel.Text = "VirtualLinkedDesk";
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(633, 26);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(60, 60);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 24;
            this.logoPictureBox.TabStop = false;
            // 
            // InitConfWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.programNameLabel);
            this.Controls.Add(this.pictureDropDownMenuUpBox);
            this.Controls.Add(this.advancedOptionsLabel);
            this.Controls.Add(this.pictureDropDownMenuDownBox);
            this.Controls.Add(this.passwordCertificateBox);
            this.Controls.Add(this.passwordCertificateLabel);
            this.Controls.Add(this.certificateFileNameLabel);
            this.Controls.Add(this.expectedCertificateNameBox);
            this.Controls.Add(this.certificateNameLabel);
            this.Controls.Add(this.selectCertificateButton);
            this.Controls.Add(this.encryptedConnectionCheckBox);
            this.Controls.Add(this.FPSComboBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.FPSLabel);
            this.Controls.Add(this.colorDepthBox);
            this.Controls.Add(this.colorDepthLabel);
            this.Controls.Add(this.endPointLabel);
            this.Controls.Add(this.endPointBox);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.serverHostNameLabel);
            this.Controls.Add(this.menuStrip);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximumSize = new System.Drawing.Size(960, 540);
            this.MinimumSize = new System.Drawing.Size(960, 540);
            this.Name = "InitConfWindow";
            this.Text = "VirtualLinkedDesk Client";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDropDownMenuDownBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDropDownMenuUpBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox endPointBox;
        private System.Windows.Forms.Label endPointLabel;
        private System.Windows.Forms.Label colorDepthLabel;
        private System.Windows.Forms.Label FPSLabel;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.ComboBox colorDepthBox;
        private System.Windows.Forms.ComboBox FPSComboBox;
        private System.Windows.Forms.CheckBox encryptedConnectionCheckBox;
        private System.Windows.Forms.Label serverHostNameLabel;
        private System.Windows.Forms.OpenFileDialog openCertificateFileDialog;
        private System.Windows.Forms.Button selectCertificateButton;
        private System.Windows.Forms.Label certificateNameLabel;
        private System.Windows.Forms.TextBox expectedCertificateNameBox;
        private System.Windows.Forms.Label certificateFileNameLabel;
        private System.Windows.Forms.Label passwordCertificateLabel;
        private System.Windows.Forms.TextBox passwordCertificateBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutVirtualLinkedDeskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VirtualLinkedDeskWebSiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spanishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureDropDownMenuDownBox;
        private System.Windows.Forms.Label advancedOptionsLabel;
        private System.Windows.Forms.PictureBox pictureDropDownMenuUpBox;
        private System.Windows.Forms.Label programNameLabel;
        private System.Windows.Forms.PictureBox logoPictureBox;
    }
}

