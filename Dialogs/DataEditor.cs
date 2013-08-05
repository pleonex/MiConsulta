//-----------------------------------------------------------------------
// <copyright file="DataEditor.cs" company="none">
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
// <author>Benito Palacios (pleoNeX)</author>
// <email>benito356@gmail.com</email>
// <date>04/08/2013</date>
//-----------------------------------------------------------------------
using System;
using System.Windows.Forms;

namespace MiConsulta
{
    /// <summary>
    /// Description of IDataEditor.
    /// </summary>
    public abstract class DataEditor : DataForm
    {        
        private string dataType;
        
        protected DataEditor()
        { }
        
        protected DataEditor(string dataType)
        {
            this.dataType = dataType.ToLower();
            this.Text = "Añadir " + this.dataType;
        }
        
        protected DataEditor(string dataType, PatientData data)
            : base(data)
        {
            this.dataType = dataType.ToLower();
            this.Text = "Editar " + this.dataType;
        }
          
        public bool Modified {
            get;
            private set;
        }
        
        public abstract PatientData Data {
            get;
        }
        
        protected void DataChanged(object sender, EventArgs e)
        {
            if (this.Loading)
                return;
            
            if (!this.Modified)
                this.Text += " *(modificada)";
            this.Modified = true;
        }
        
        protected virtual void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Modified && !this.AskExit()) {
                e.Cancel = true;
                this.DialogResult = DialogResult.None;
            }
        }
        
        protected virtual void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        protected bool AskExit()
        {
            DialogResult result = MessageBox.Show("La " + this.dataType + " ha sido modificada.\n" +
                                                  "¿Estás seguro de que quieres salir?\n" +
                                                  "Los cambios se perderán.", this.dataType + " modificada",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning,
                                                  MessageBoxDefaultButton.Button1);
            
            if (result == DialogResult.No)
                return false;
            else
                return true;
        }
        
        protected virtual void btnOk_Click(object sender, EventArgs e)
        {
            if (!this.CheckData()) {
                return;
            }
            
            this.DialogResult = DialogResult.OK;
            this.Modified = false;  // Changes saved
            this.Close();
        }
      
        protected abstract bool CheckData();
        
        protected void ShowError(Control control, string msg)
        {
            control.BackColor = System.Drawing.Color.IndianRed;
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
