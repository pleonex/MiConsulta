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
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace MiConsulta
{
    /// <summary>
    /// Description of ListManagerControl.
    /// </summary>
    public partial class ListManagerControl : UserControl
    {
        public ListManagerControl()
        {
            InitializeComponent();
        }
        
        public ListManagerControl(string title, string imgPrefix)
        {
            InitializeComponent();
            this.CreateImageList(imgPrefix);
            this.lblTitle.Text = title;
        }
        
        private void CreateImageList(string prefix)
        {
            this.btnImgList.Images.Clear();
            ResourceManager resman = Properties.Resources.ResourceManager;

            // Fill list
            this.btnImgList.Images.Add("BtnView", Image.FromStream(resman.GetStream(prefix + "_go.png")));
            this.btnImgList.Images.Add("BtnAdd", Image.FromStream(resman.GetStream(prefix + "_add.png")));
            this.btnImgList.Images.Add("BtnEdit", Image.FromStream(resman.GetStream(prefix + "_edit.png")));
            this.btnImgList.Images.Add("BtnRem", Image.FromStream(resman.GetStream(prefix + "_delete.png")));

            // Set icons
            this.btnView.ImageKey = "BtnView";
            this.btnAdd.ImageKey = "BtnAdd";
            this.btnEdit.ImageKey = "BtnEdit";
            this.btnRemove.ImageKey = "BtnRem";
        }
    }
}
