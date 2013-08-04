// ----------------------------------------------------------------------
// <copyright file="ImageViewer.cs" company="none">

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
// <date>07/09/2012 14:30:41</date>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MiConsulta
{
    public partial class ImageViewer : Form
    {
        public ImageViewer()
        {
            InitializeComponent();
        }
        public ImageViewer(sImage image)
        {
            InitializeComponent();

            picImg.Image = Image.FromFile(Application.StartupPath + System.IO.Path.DirectorySeparatorChar + image.relative_path);
            lblTitle.Text = image.title + " - " + image.date.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkHere_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (picImg.SizeMode == PictureBoxSizeMode.AutoSize)
            {
                picImg.SizeMode = PictureBoxSizeMode.StretchImage;
                linkHere.Text = "Pulse aquí para ver la imagen a tamaño real.";
            }
            else
            {
                picImg.SizeMode = PictureBoxSizeMode.AutoSize;
                linkHere.Text = "Pulse aquí para ajustar la imagen a la ventana.";
            }
        }
    }
}
