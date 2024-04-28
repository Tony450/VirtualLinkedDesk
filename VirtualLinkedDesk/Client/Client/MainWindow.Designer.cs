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

namespace Client {
    partial class MainWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.connectionNotSecureLabel = new System.Windows.Forms.Label();
            this.disconnectPseudoButton = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // connectionNotSecureLabel
            // 
            this.connectionNotSecureLabel.BackColor = System.Drawing.Color.Red;
            this.connectionNotSecureLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.connectionNotSecureLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.connectionNotSecureLabel.Location = new System.Drawing.Point(0, 0);
            this.connectionNotSecureLabel.Name = "connectionNotSecureLabel";
            this.connectionNotSecureLabel.Size = new System.Drawing.Size(1264, 25);
            this.connectionNotSecureLabel.TabIndex = 6;
            this.connectionNotSecureLabel.Text = "Tu conexión no es segura";
            this.connectionNotSecureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.connectionNotSecureLabel.Visible = false;
            // 
            // disconnectPseudoButton
            // 
            this.disconnectPseudoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(255)))));
            this.disconnectPseudoButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.disconnectPseudoButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.disconnectPseudoButton.Location = new System.Drawing.Point(587, 25);
            this.disconnectPseudoButton.Name = "disconnectPseudoButton";
            this.disconnectPseudoButton.Size = new System.Drawing.Size(105, 32);
            this.disconnectPseudoButton.TabIndex = 7;
            this.disconnectPseudoButton.Text = "Desconectar";
            this.disconnectPseudoButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.disconnectPseudoButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.disconnectButtonClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            //this.Cursor = new System.Windows.Forms.Cursor("Cursor.ico");                  //Temporary
            this.Cursor = new System.Windows.Forms.Cursor("../../../Images/Cursor/Cursor.ico");     
            this.Controls.Add(this.disconnectPseudoButton);
            this.Controls.Add(this.connectionNotSecureLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(960, 540);
            this.Name = "MainWindow";
            this.Opacity = 0D;
            this.Text = "VirtualLinkedDesk Client";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.paintWindow);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.handleKeyDownEvent);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.handleKeyUpEvent);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.handleMouseDownEvent);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.handleMouseMoveEvent);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.handleMouseUpEvent);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.handleMouseWheelEvent);
            this.Resize += new System.EventHandler(this.handleResizeEvent);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label connectionNotSecureLabel;
        private System.Windows.Forms.Label disconnectPseudoButton;
    }
}