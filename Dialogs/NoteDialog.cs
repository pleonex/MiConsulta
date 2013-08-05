// ----------------------------------------------------------------------
// <copyright file="NoteDialog.cs" company="none">
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
    public partial class NoteDialog : DataEditor
    {       
        public NoteDialog()
            : base("nota")
        {
            Initialize();
        }

        public NoteDialog(Note note)
            : base("nota", note)
        {
            Initialize();
            this.LoadData();
        }

        private void Initialize()
        {
            InitializeComponent();
            this.txtNoteMsg.TextChanged += this.DataChanged;
            this.txtNoteTitle.TextChanged += this.DataChanged;
            this.btnOk.Click += this.btnOk_Click;
            this.btnCancel.Click += this.btnExit_Click;
            this.FormClosing += this.OnFormClosing;
        }
        
        protected override void LoadData(PatientData data)
        {
            Note note = (Note)data;
            this.txtNoteMsg.Text = note.Message;
            this.txtNoteTitle.Text = note.Title;
        }
        
        public override PatientData Data {
            get { return new Note(this.txtNoteTitle.Text, this.txtNoteMsg.Text); }
        }

        protected override bool CheckData()
        {
            this.txtNoteTitle.BackColor = Color.White;
            this.txtNoteMsg.BackColor = Color.White;
            
            if (string.IsNullOrEmpty(this.txtNoteMsg.Text)) {
                this.ShowError(this.txtNoteMsg, "El mensaje no puede estar vacío.");
                return false;
            }
            
            if (string.IsNullOrEmpty(this.txtNoteTitle.Text)) {
                this.ShowError(this.txtNoteTitle, "El título no puede estar vacío.");
                return false;
            }
            
            return true;
        }
        
        private void NoteDialog_Resize(object sender, EventArgs e)
        {
            this.txtNoteTitle.Width = this.Width  - 22;
            this.txtNoteMsg.Width   = this.Width  - 22;
            this.txtNoteMsg.Height  = this.Height - 139;
            this.btnCancel.Location = new Point(this.btnCancel.Location.X, this.Height - 69);
            this.btnOk.Location     = new Point(this.Width - 90, this.Height - 69);
        } 
    }
}
