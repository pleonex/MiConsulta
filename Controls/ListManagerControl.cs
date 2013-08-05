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
        private List<PatientData> elements = new List<PatientData>();
        private Type editor;
        private Type viewer;
        private string title;
        private string imagePrefix;
                
        public ListManagerControl()
        {
            InitializeComponent();
            this.Clear();
        }
        
        
        public string Title {
            get { return this.title; }
            set { this.title = this.lblTitle.Text = value; }
        }
        
        public string ImagePrefix {
            get { return this.imagePrefix; }
            set { this.imagePrefix = value; this.CreateImageList(); }
        }
        
        public string EditorType {
            get { return (this.editor == null) ? string.Empty : this.editor.FullName; }
            set { this.editor = this.StringToType(value, typeof(DataEditor)); }
        }
                
        public string ViewerType {
            get { return (this.viewer == null) ? string.Empty : this.viewer.FullName; }
            set { this.viewer = this.StringToType(value, typeof(DataForm)); }
        }
        
        private Type StringToType(string s, Type baseClass) {
            if (string.IsNullOrEmpty(s))
                return null;
            
            Type type = Type.GetType(s, true, false);
            if (!type.IsSubclassOf(baseClass))
                throw new TypeLoadException("Must heridate from " + baseClass.Name);
            
            return type;
        }
        
        public PatientData[] GetElements()
        {
            return this.elements.ToArray();
        }
        
        
        public void Clear()
        {
            this.listObjs.Items.Clear();
            this.elements.Clear();
            this.btnView.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnDown.Enabled = false;
            this.btnUp.Enabled   = false;
            this.btnRemove.Enabled = false;
        }
        
        private void CreateImageList()
        {
            if (string.IsNullOrEmpty(this.ImagePrefix))
                return;
            
            this.btnImgList.Images.Clear();
            ResourceManager resman = Properties.Resources.ResourceManager;

            // Fill list
            this.btnImgList.Images.Add("BtnView", (Bitmap)resman.GetObject(this.ImagePrefix + "_go"));
            this.btnImgList.Images.Add("BtnAdd",  (Bitmap)resman.GetObject(this.ImagePrefix + "_add"));
            this.btnImgList.Images.Add("BtnEdit", (Bitmap)resman.GetObject(this.ImagePrefix + "_edit"));
            this.btnImgList.Images.Add("BtnRem",  (Bitmap)resman.GetObject(this.ImagePrefix + "_delete"));

            // Set icons
            this.btnView.ImageKey   = "BtnView";
            this.btnAdd.ImageKey    = "BtnAdd";
            this.btnEdit.ImageKey   = "BtnEdit";
            this.btnRemove.ImageKey = "BtnRem";
        }

        private void UpdateList()
        {
            int selected = this.listObjs.SelectedIndex;
            this.listObjs.Items.Clear();
            
            foreach (PatientData el in this.elements)
                this.listObjs.Items.Add(el);
            
            if (selected >= 0 && selected < this.elements.Count)
                this.listObjs.SelectedIndex = selected;
            else
                this.listObjs.SelectedIndex = -1;
            this.ListObjsSelectedIndexChanged(this.listObjs, null);
                
            this.UpdateArrows();
        }
        
        private void UpdateArrows()
        {
            int selected = this.listObjs.SelectedIndex;
            int length   = this.elements.Count;
            
            this.btnUp.Enabled   = false;
            this.btnDown.Enabled = false;
            
            if (length <= 1)
                return;
            
            if (selected >= 0 && selected < length - 1)
                this.btnDown.Enabled = true;
            if (selected >= 1 && selected < length)
                this.btnUp.Enabled = true;
        }
        
        
        public void AddElements(PatientData[] elements)
        {
            this.elements.AddRange(elements);
            this.UpdateList();
        }
        
        private void ListObjsSelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateArrows();
            
            if (this.listObjs.SelectedIndex != -1) {
                this.btnView.Enabled = true;
                this.btnEdit.Enabled = true;
                this.btnRemove.Enabled = true;
            } else {
                this.btnView.Enabled = false;
                this.btnEdit.Enabled = false;
                this.btnRemove.Enabled = false;
            }
        }
        
        private void BtnViewClick(object sender, EventArgs e)
        {
            PatientData el = (PatientData)this.listObjs.SelectedItem;
            if (el == null)
                throw new IndexOutOfRangeException("No element selected");
            
            DataForm dialog = (DataForm)Activator.CreateInstance(this.viewer, el);
            dialog.ShowDialog();
            dialog.Dispose();
        }
        
        private void BtnAddClick(object sender, EventArgs e)
        {
            DataEditor dialog = (DataEditor)Activator.CreateInstance(this.editor);
            
            if (dialog.ShowDialog() == DialogResult.OK) {
                PatientData newData = dialog.Data;
                this.elements.Add(newData);
                
                this.UpdateList();
                this.listObjs.SelectedItem = newData;
            }
            
            dialog.Dispose();
        }
        
        private void BtnEditClick(object sender, EventArgs e)
        {
            int index = this.listObjs.SelectedIndex;
            if (index == -1)
                throw new IndexOutOfRangeException("No element selected");
            
            DataEditor dialog = (DataEditor)Activator.CreateInstance(this.editor, this.elements[index]);
            
            if (dialog.ShowDialog() == DialogResult.OK) {
                this.elements[index] = dialog.Data;
                this.listObjs.Items[index] = this.elements[index];
            }
            
            dialog.Dispose();
        }
        
        private void BtnRemoveClick(object sender, EventArgs e)
        {
            int index = this.listObjs.SelectedIndex;
            if (index == -1)
                throw new Exception("No element selected");
            
            this.elements.RemoveAt(index);
            this.UpdateList();
            if (this.elements.Count > 0 && index > 0)
                this.listObjs.SelectedIndex = index - 1;
        }
        
        private void BtnUpClick(object sender, EventArgs e)
        {
            int index = this.listObjs.SelectedIndex;
            
            PatientData prev = this.elements[index - 1];
            this.elements[index - 1] = this.elements[index];
            this.elements[index] = prev;
            
            this.UpdateList();
            this.listObjs.SelectedIndex--;
        }
        
        private void BtnDownClick(object sender, EventArgs e)
        {
            int index = this.listObjs.SelectedIndex;
            
            PatientData next = this.elements[index + 1];
            this.elements[index + 1] = this.elements[index];
            this.elements[index] = next;
            
            this.UpdateList();
            this.listObjs.SelectedIndex++;
        }
    }
}
