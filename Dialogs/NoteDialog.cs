// ----------------------------------------------------------------------
// <copyright file="NoteDialog.cs" company="none">
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
// <date>19/09/2012 21:40:30</date>
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
    public partial class NoteDialog : Form
    {
        private bool loading  = false;
        private bool modified = false;
        
        public NoteDialog()
        {
            InitializeComponent();
            this.Text = "Añadir nota";
        }

        public NoteDialog(sNote note)
        {
            InitializeComponent();
            this.Text = "Editar nota";
            this.LoadNote(note);
        }

        private void LoadNote(sNote note)
        {
            this.loading = true;
            this.txtNoteMsg.Text = note.msg;
            this.txtNoteTitle.Text = note.title;
            this.loading = false;
        }
        
        public sNote Note
        {
            get { return new sNote(this.txtNoteTitle.Text, this.txtNoteMsg.Text); }
        }

        private void NoteDialog_Resize(object sender, EventArgs e)
        {
            this.txtNoteTitle.Width   = this.Width  - 22;
            this.txtNoteMsg.Width     = this.Width  - 22;
            this.txtNoteMsg.Height    = this.Height - 139;
            this.btnCancel.Location.Y = this.Height - 69;
            this.btnOk.Location.Y     = this.Height - 69;
            this.btnOk.Location.X     = this.Width  - 90;
        } 
        
        private void TxtTextChanged(object sender, EventArgs e)
        {
            this.modified = true;
            this.Text += " (modificada)";
        }
        
        private void BtnCancelClick(object sender, EventArgs e)
        {
            if (this.modified) {
                DialogResult result = MessageBox.Show("La nota ha sido modificada.\n" +
                                                      "¿Estás seguro de que quieres salir?\n" +
                                                      "Los cambios se perderán.", "Nota modificada",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning,
                                                      MessageBoxDefaultButton.Button1);
                
                if (result == DialogResult.No)
                    return;
            }
            
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        private void BtnOkClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
