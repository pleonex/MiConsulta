// ----------------------------------------------------------------------
// <copyright file="NoteDialog.Designer.cs" company="none">

// Copyright (C) 2012
//
//   This program is free software: you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by 
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//
//   This program is distributed in the hope that it will be useful, 
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU General Public License for more details. 
//
//   You should have received a copy of the GNU General Public License
//   along with this program.  If not, see <http://www.gnu.org/licenses/>. 
//
// </copyright>

// <author>pleoNeX</author>
// <email>benito356@gmail.com</email>
// <date>19/09/2012 21:40:21</date>
// -----------------------------------------------------------------------
namespace MiConsulta
{
    partial class NoteDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteDialog));
            this.txtNoteTitle = new System.Windows.Forms.TextBox();
            this.txtNoteMsg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNoteTitle
            // 
            this.txtNoteTitle.Location = new System.Drawing.Point(12, 25);
            this.txtNoteTitle.Name = "txtNoteTitle";
            this.txtNoteTitle.Size = new System.Drawing.Size(398, 20);
            this.txtNoteTitle.TabIndex = 0;
            // 
            // txtNoteMsg
            // 
            this.txtNoteMsg.Location = new System.Drawing.Point(12, 64);
            this.txtNoteMsg.Multiline = true;
            this.txtNoteMsg.Name = "txtNoteMsg";
            this.txtNoteMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNoteMsg.Size = new System.Drawing.Size(398, 236);
            this.txtNoteMsg.TabIndex = 1;
            this.txtNoteMsg.Tag = "5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Título:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mensaje:";
            // 
            // btnOk
            // 
            this.btnOk.Image = global::MiConsulta.Properties.Resources.accept;
            this.btnOk.Location = new System.Drawing.Point(330, 306);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 36);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Guardar";
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::MiConsulta.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 306);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 36);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // NoteDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(414, 347);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNoteTitle);
            this.Controls.Add(this.txtNoteMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(700, 550);
            this.MinimumSize = new System.Drawing.Size(190, 205);
            this.Name = "NoteDialog";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Resize += new System.EventHandler(this.NoteDialog_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtNoteTitle;
        private System.Windows.Forms.TextBox txtNoteMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}