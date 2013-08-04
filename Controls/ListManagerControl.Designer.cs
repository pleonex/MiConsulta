//-----------------------------------------------------------------------
// <copyright file="ListManagerControl.cs" company="none">
// Copyright (C) 2013
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
//   along with this program.  If not, see "http://www.gnu.org/licenses/". 
// </copyright>
// <author>pleoNeX</author>
// <email>benito356@gmail.com</email>
// <date>30/03/2013</date>
//-----------------------------------------------------------------------
namespace MiConsulta
{
    partial class ListManagerControl
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the control.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.listObjs = new System.Windows.Forms.ListBox();
            this.btnImgList = new System.Windows.Forms.ImageList(this.components);
            this.btnView = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(30, 13);
            this.lblTitle.TabIndex = 45;
            this.lblTitle.Text = "Title:";
            // 
            // listObjs
            // 
            this.listObjs.FormattingEnabled = true;
            this.listObjs.Location = new System.Drawing.Point(0, 16);
            this.listObjs.Name = "listObjs";
            this.listObjs.Size = new System.Drawing.Size(205, 160);
            this.listObjs.TabIndex = 44;
            // 
            // btnImgList
            // 
            this.btnImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.btnImgList.ImageSize = new System.Drawing.Size(16, 16);
            this.btnImgList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnView
            // 
            this.btnView.ImageList = this.btnImgList;
            this.btnView.Location = new System.Drawing.Point(211, 3);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(30, 23);
            this.btnView.TabIndex = 39;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnViewClick);
            // 
            // btnRemove
            // 
            this.btnRemove.ImageList = this.btnImgList;
            this.btnRemove.Location = new System.Drawing.Point(211, 95);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(30, 23);
            this.btnRemove.TabIndex = 41;
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.ImageList = this.btnImgList;
            this.btnEdit.Location = new System.Drawing.Point(211, 66);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(30, 23);
            this.btnEdit.TabIndex = 40;
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.ImageList = this.btnImgList;
            this.btnAdd.Location = new System.Drawing.Point(211, 37);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(30, 23);
            this.btnAdd.TabIndex = 38;
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnDown
            // 
            this.btnDown.Image = global::MiConsulta.Properties.Resources.arrow_down;
            this.btnDown.Location = new System.Drawing.Point(211, 153);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(30, 23);
            this.btnDown.TabIndex = 43;
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // btnUp
            // 
            this.btnUp.Image = global::MiConsulta.Properties.Resources.arrow_up;
            this.btnUp.Location = new System.Drawing.Point(211, 124);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(30, 23);
            this.btnUp.TabIndex = 42;
            this.btnUp.UseVisualStyleBackColor = true;
            // 
            // ListManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.listObjs);
            this.Name = "ListManagerControl";
            this.Size = new System.Drawing.Size(242, 178);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.ImageList btnImgList;
        private System.Windows.Forms.ListBox listObjs;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnView;
    }
}
