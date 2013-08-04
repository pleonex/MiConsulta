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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MiConsulta
{
    public partial class ImageDialog : DataEditor
    {
        private const string DirName = "Images";

        private string tempPath = string.Empty;
        private string saveFile = string.Empty;
        
        public ImageDialog()
        {
            InitializeComponent();
            this.Text = "Añadir imagen";
            this.btnOk.Click += this.btnOk_Click;
            this.dateTimeBox.Value = DateTime.Now;
        }
        
        public ImageDialog(Photo photo)
            : base(photo)
        {
            InitializeComponent();
            this.Text = "Editar imagen";
            this.btnOk.Click += this.btnOk_Click;
        }

        protected override void LoadData(PatientData data)
        {
            Photo photo = (Photo)data;
            this.dateTimeBox.Value = photo.LastModification;
            this.txtTitle.Text = photo.Title;
            this.txtName.Text = Path.GetFileName(photo.Path);
        }
        
        public Photo Photo
        {
            get {
                if (string.IsNullOrEmpty(this.saveFile))
                    throw new Exception("Window hasn't been closed yet");
                
                return new Photo(this.txtTitle.Text, this.saveFile);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.CheckFileExists = true;
            o.CheckPathExists = true;
            o.Multiselect = false;
            o.Title = "Seleccione la imagen";
            if (o.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            this.txtName.Text = o.SafeFileName;
            this.tempPath = o.FileName;

            o.Dispose();
        }

        private void ImageDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != System.Windows.Forms.DialogResult.OK)
                return;

            // Save file to program directory
            string outDir = Path.Combine(Application.StartupPath, DirName);
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);

            string outFile = Path.Combine(outDir, this.txtName.Text);
            if (File.Exists(outFile))
                outFile = Path.Combine(outDir, Path.GetRandomFileName() + '_' + txtName.Text);

            File.Copy(this.tempPath, outFile);
            this.saveFile = outFile.Replace(Application.StartupPath, "");
        }
    }
}
