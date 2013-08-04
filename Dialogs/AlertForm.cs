// ----------------------------------------------------------------------
// <copyright file="AlertForm.cs" company="none">

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
// <date>07/09/2012 14:31:16</date>
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
    public partial class AlertForm : Form
    {
        public AlertForm()
        {
            InitializeComponent();
        }
        public AlertForm(string msg)
        {
            InitializeComponent();

            lblMsg.Text = msg;
            this.Location = new Point(
                Screen.PrimaryScreen.Bounds.Width - this.Width,
                Screen.PrimaryScreen.Bounds.Height - this.Height);
        }


    }
}
