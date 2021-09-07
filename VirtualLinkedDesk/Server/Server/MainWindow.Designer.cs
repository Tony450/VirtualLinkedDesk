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

namespace Server
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.connectedClientsLabel = new System.Windows.Forms.Label();
            this.connectedClientsBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.connectionNotSecureLabel = new System.Windows.Forms.Label();
            this.allowControlLabel = new System.Windows.Forms.Label();
            this.pictureAllowControlButtonNoBox = new System.Windows.Forms.PictureBox();
            this.pictureAllowControlButtonYesBox = new System.Windows.Forms.PictureBox();
            this.programNameLabel = new System.Windows.Forms.Label();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.disconnectButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAllowControlButtonNoBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAllowControlButtonYesBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // connectedClientsLabel
            // 
            this.connectedClientsLabel.AutoSize = true;
            this.connectedClientsLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.connectedClientsLabel.ForeColor = System.Drawing.Color.White;
            this.connectedClientsLabel.Location = new System.Drawing.Point(162, 280);
            this.connectedClientsLabel.Name = "connectedClientsLabel";
            this.connectedClientsLabel.Size = new System.Drawing.Size(147, 21);
            this.connectedClientsLabel.TabIndex = 0;
            this.connectedClientsLabel.Text = "Clientes conectados";
            // 
            // connectedClientsBox
            // 
            this.connectedClientsBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.connectedClientsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.connectedClientsBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.connectedClientsBox.ForeColor = System.Drawing.Color.White;
            this.connectedClientsBox.Location = new System.Drawing.Point(144, 317);
            this.connectedClientsBox.Multiline = true;
            this.connectedClientsBox.Name = "connectedClientsBox";
            this.connectedClientsBox.ReadOnly = true;
            this.connectedClientsBox.Size = new System.Drawing.Size(184, 96);
            this.connectedClientsBox.TabIndex = 1;
            // 
            // passwordBox
            // 
            this.passwordBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.passwordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordBox.ForeColor = System.Drawing.SystemColors.Window;
            this.passwordBox.Location = new System.Drawing.Point(144, 157);
            this.passwordBox.Multiline = true;
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.ReadOnly = true;
            this.passwordBox.Size = new System.Drawing.Size(184, 23);
            this.passwordBox.TabIndex = 2;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordLabel.ForeColor = System.Drawing.Color.White;
            this.passwordLabel.Location = new System.Drawing.Point(195, 120);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(89, 21);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "Contraseña";
            // 
            // connectionNotSecureLabel
            // 
            this.connectionNotSecureLabel.BackColor = System.Drawing.Color.Red;
            this.connectionNotSecureLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.connectionNotSecureLabel.Location = new System.Drawing.Point(0, 0);
            this.connectionNotSecureLabel.Name = "connectionNotSecureLabel";
            this.connectionNotSecureLabel.Size = new System.Drawing.Size(944, 25);
            this.connectionNotSecureLabel.TabIndex = 6;
            this.connectionNotSecureLabel.Text = "Tu conexión no es segura";
            this.connectionNotSecureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.connectionNotSecureLabel.Visible = false;
            // 
            // allowControlLabel
            // 
            this.allowControlLabel.AutoSize = true;
            this.allowControlLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.allowControlLabel.ForeColor = System.Drawing.Color.White;
            this.allowControlLabel.Location = new System.Drawing.Point(624, 225);
            this.allowControlLabel.Name = "allowControlLabel";
            this.allowControlLabel.Size = new System.Drawing.Size(206, 21);
            this.allowControlLabel.TabIndex = 7;
            this.allowControlLabel.Text = "Permitir/ no permitir control";
            // 
            // pictureAllowControlButtonNoBox
            // 
            this.pictureAllowControlButtonNoBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureAllowControlButtonNoBox.Image")));
            this.pictureAllowControlButtonNoBox.Location = new System.Drawing.Point(588, 220);
            this.pictureAllowControlButtonNoBox.Name = "pictureAllowControlButtonNoBox";
            this.pictureAllowControlButtonNoBox.Size = new System.Drawing.Size(30, 30);
            this.pictureAllowControlButtonNoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureAllowControlButtonNoBox.TabIndex = 8;
            this.pictureAllowControlButtonNoBox.TabStop = false;
            this.pictureAllowControlButtonNoBox.Click += new System.EventHandler(this.allowControlButtonNoClick);
            // 
            // pictureAllowControlButtonYesBox
            // 
            this.pictureAllowControlButtonYesBox.Enabled = false;
            this.pictureAllowControlButtonYesBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureAllowControlButtonYesBox.Image")));
            this.pictureAllowControlButtonYesBox.Location = new System.Drawing.Point(588, 220);
            this.pictureAllowControlButtonYesBox.Name = "pictureAllowControlButtonYesBox";
            this.pictureAllowControlButtonYesBox.Size = new System.Drawing.Size(30, 30);
            this.pictureAllowControlButtonYesBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureAllowControlButtonYesBox.TabIndex = 9;
            this.pictureAllowControlButtonYesBox.TabStop = false;
            this.pictureAllowControlButtonYesBox.Visible = false;
            this.pictureAllowControlButtonYesBox.Click += new System.EventHandler(this.allowControlButtonYesClick);
            // 
            // programNameLabel
            // 
            this.programNameLabel.AutoSize = true;
            this.programNameLabel.Font = new System.Drawing.Font("Segoe UI", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.programNameLabel.ForeColor = System.Drawing.Color.White;
            this.programNameLabel.Location = new System.Drawing.Point(699, 38);
            this.programNameLabel.Name = "programNameLabel";
            this.programNameLabel.Size = new System.Drawing.Size(220, 32);
            this.programNameLabel.TabIndex = 10;
            this.programNameLabel.Text = "VirtualLinkedDesk";
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(633, 26);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(60, 60);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 11;
            this.logoPictureBox.TabStop = false;
            // 
            // disconnectButton
            // 
            this.disconnectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(255)))));
            this.disconnectButton.FlatAppearance.BorderSize = 0;
            this.disconnectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.disconnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disconnectButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.disconnectButton.ForeColor = System.Drawing.Color.White;
            this.disconnectButton.Location = new System.Drawing.Point(655, 349);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(105, 32);
            this.disconnectButton.TabIndex = 12;
            this.disconnectButton.Text = "Desconectar";
            this.disconnectButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.disconnectButton.UseVisualStyleBackColor = false;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButtonClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.programNameLabel);
            this.Controls.Add(this.pictureAllowControlButtonYesBox);
            this.Controls.Add(this.pictureAllowControlButtonNoBox);
            this.Controls.Add(this.allowControlLabel);
            this.Controls.Add(this.connectionNotSecureLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.connectedClientsBox);
            this.Controls.Add(this.connectedClientsLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(960, 540);
            this.MinimumSize = new System.Drawing.Size(960, 540);
            this.Name = "MainWindow";
            this.Text = "VirtualLinkedDesk Server";
            ((System.ComponentModel.ISupportInitialize)(this.pictureAllowControlButtonNoBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAllowControlButtonYesBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox connectedClientsBox;
        private System.Windows.Forms.Label connectedClientsLabel;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label connectionNotSecureLabel;
        private System.Windows.Forms.Label allowControlLabel;
        private System.Windows.Forms.PictureBox pictureAllowControlButtonNoBox;
        private System.Windows.Forms.PictureBox pictureAllowControlButtonYesBox;
        private System.Windows.Forms.Label programNameLabel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Button disconnectButton;
    }
}

