// ----------------------------------------------------------------------
// <copyright file="PatientDetails.cs" company="none">
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
// <date>07/09/2012 2:05:24</date>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MiConsulta
{
    public partial class PatientDetails : UserControl
    {
        Patient p;
        bool noUpdate;

        public PatientDetails()
        {
            InitializeComponent();
            CleanFields();

            p = new Patient();
        }
        public PatientDetails(Patient p)
        {
            InitializeComponent();
            CleanFields();

            this.p = p;
            FillFields();
        }
        public void Load_Patient(Patient p)
        {
            CleanFields();
            this.p = p;
            FillFields();
        }

        private void FillFields()
        {
            noUpdate = true;

            txtHistory.Text = p.History;
            txtName.Text = p.Name;
            txtPhone.Text = p.Get_Phone(Phone_Type.Landline).number;
            txtMobile.Text = p.Get_Phone(Phone_Type.Mobile).number;
            txtEmail.Text = p.Email;
            txtAddress.Text = p.Address;

            DateTime dt = p.Get_NextAppointment();
            if (dt.Year == 1)
            {
                dateTimeNextAppoint.Value = DateTime.Now.AddDays(1);
                dateTimeNextAppoint.Checked = false;
            }
            else
            {
                dateTimeNextAppoint.Value = dt;
                dateTimeNextAppoint.Checked = true;
            }

            for (int i = 0; i < p.AppointmentsLength; i++)
                listAppointment.Items.Add(p.Get_Appointment(i).ToString());

            for (int i = 0; i < p.NotesLength; i++)
            {
                Note note = p.Get_Note(i);
                listNotes.Items.Add(note.LastModification.ToShortDateString() + ' ' + note.Title);
            }

            for (int i = 0; i < p.ImagesLength; i++)
            {
                Photo img = p.Get_Image(i);
                //TODO listImgs.Items.Add(img.LastModification.ToShortDateString() + ' ' + img.Title);
            }

            if (System.IO.File.Exists(p.Icon))
                picPhoto.Image = Image.FromFile(p.Icon);
            else
                picPhoto.Image = Properties.Resources.Unknown_profile;

            noUpdate = false;
        }
        public void CleanFields()
        {
            noUpdate = true;
            p = new Patient();

            txtHistory.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";

            dateTimeNextAppoint.Value = DateTime.Now;
            dateTimeNextAppoint.Checked = false;
            dateTimeAppointment.Value = DateTime.Now;
            listAppointment.Items.Clear();
            btnEditVisit.Enabled = false;
            btnRemoveVisit.Enabled = false;

            listNotes.Items.Clear();
            btnEditNote.Enabled = false;
            btnRemoveNote.Enabled = false;
            btnUpNote.Enabled = false;
            btnDownNote.Enabled = false;

            // TODO 
            /*
            listImgs.Items.Clear();
            btnViewImg.Enabled = false;
            btnEditImg.Enabled = false;
            btnRemoveImg.Enabled = false;
            btnDownImg.Enabled = false;
            btnUpImg.Enabled = false;*/

            picPhoto.Image = Properties.Resources.Unknown_profile;

            noUpdate = false;
        }

        public Patient Patient
        {
            get { return p; }
        }

        private void picPhoto_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.CheckFileExists = true;
            o.CheckPathExists = true;
            o.Multiselect = false;
            if (o.ShowDialog() != DialogResult.OK)
                return;

            p.Icon = o.FileName;
            picPhoto.Image = Image.FromFile(p.Icon);

            o.Dispose();
            o = null;
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            if (noUpdate)
                return;
            noUpdate = true;

            p.History = txtHistory.Text;
            p.Name = txtName.Text;
            p.Email = txtEmail.Text;
            p.Address = txtAddress.Text;
            p.Set_Phone(Phone_Type.Landline, txtPhone.Text);
            p.Set_Phone(Phone_Type.Mobile, txtMobile.Text);

            noUpdate = false;
        }

        private void Update_Appointment()
        {
            int index = listAppointment.SelectedIndex;

            listAppointment.Items.Clear();
            for (int i = 0; i < p.AppointmentsLength; i++)
                listAppointment.Items.Add(p.Get_Appointment(i).ToString());

            if (index != -1)
                listAppointment.SelectedIndex = index;

            DateTime dt = p.Get_NextAppointment();
            if (dt.Year == 1)
            {
                dateTimeNextAppoint.Value = DateTime.Now.AddDays(1);
                dateTimeNextAppoint.Checked = false;
            }
            else
            {
                dateTimeNextAppoint.Value = dt;
                dateTimeNextAppoint.Checked = true;
            }
        }
        private void dateTimeNextAppoit_ValueChanged(object sender, EventArgs e)
        {
            if (noUpdate)
                return;

            if (!dateTimeNextAppoint.Checked)
                p.Remove_NextAppointment();
            else
                p.Set_NextAppointment(dateTimeNextAppoint.Value);
        }
        private void btnAddVisit_Click(object sender, EventArgs e)
        {
            noUpdate = true;
            int index = p.Add_Appointment(dateTimeAppointment.Value);
            Update_Appointment();
            listAppointment.SelectedIndex = index;
            btnEditVisit.Enabled = true;
            btnRemoveVisit.Enabled = true;
            noUpdate = false;
        }
        private void btnEditVisit_Click(object sender, EventArgs e)
        {
            noUpdate = true;
            int index = p.Set_Appointment(listAppointment.SelectedIndex, dateTimeAppointment.Value);
            Update_Appointment();
            listAppointment.SelectedIndex = index;
            noUpdate = false;
        }
        private void btnRemoveVisit_Click(object sender, EventArgs e)
        {
            noUpdate = true;
            int i = listAppointment.SelectedIndex;
            p.Remove_Appointment(i);
            listAppointment.Items.RemoveAt(i);
            if (i > -1)
                listAppointment.SelectedIndex = i - 1;
            if (i == 0 && p.AppointmentsLength > 0)
                listAppointment.SelectedIndex = 0;

            if (p.AppointmentsLength == 0)
            {
                btnEditVisit.Enabled = false;
                btnRemoveVisit.Enabled = false;
            }
            noUpdate = false;
        }
        private void listAppointment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (noUpdate)
                return;

            noUpdate = true;
            btnEditVisit.Enabled = true;
            btnRemoveVisit.Enabled = true;
            dateTimeAppointment.Value = p.Get_Appointment(listAppointment.SelectedIndex);
            noUpdate = false;
        }

        private void Update_Notes()
        {
            int s = listNotes.SelectedIndex;
            listNotes.Items.Clear();
            for (int i = 0; i < p.NotesLength; i++)
                listNotes.Items.Add(p.Get_Note(i).LastModification.ToShortDateString() + ' ' + p.Get_Note(i).Title);
            listNotes.SelectedIndex = s;

            int l = p.NotesLength;

            btnUpNote.Enabled = false;
            btnDownNote.Enabled = false;

            if (l > 1 && (s >= 0 && s < l - 1))
                btnDownNote.Enabled = true;
            if (l > 1 && (s > 0 && s < l))
                btnUpNote.Enabled = true;
        }
        private void btnAddNote_Click(object sender, EventArgs e)
        {
            // TODO
            /*
            NoteDialog nd = new NoteDialog();
            noUpdate = true;
            sNote note = new sNote();
            note.title = txtNoteTitle.Text;
            note.msg = txtNoteMsg.Text;
            note.date = DateTime.Now;
            p.Add_Note(note);

            btnEditNote.Enabled = true;
            btnRemoveNote.Enabled = true;
            Update_Notes();
            noUpdate = false;
            listNotes.SelectedIndex = p.NotesLength - 1;
            */
        }
        private void btnEditNote_Click(object sender, EventArgs e)
        {
            // TODO
            /*
            int i = listNotes.SelectedIndex;

            sNote note = p.Get_Note(i);
            note.title = txtNoteTitle.Text;
            note.msg = txtNoteMsg.Text;
            p.Set_Note(i, note);

            listNotes.Items[i] = note.date.ToShortDateString() + ' ' + note.title;
            */
        }
        private void btnRemoveNote_Click(object sender, EventArgs e)
        {
            noUpdate = true;
            int i = listNotes.SelectedIndex;
            p.Remove_Note(i);
            if (i > -1)
                listNotes.SelectedIndex = i - 1;
            if (i == 0 && p.NotesLength > 0)
                listNotes.SelectedIndex = 0;
            Update_Notes();
            noUpdate = false;

            if (i != -1)
                listNotes_SelectedIndexChanged(null, null);

            if (p.NotesLength == 0)
            {
                btnRemoveNote.Enabled = false;
                btnEditNote.Enabled = false;
            }
        }
        private void btnUpNote_Click(object sender, EventArgs e)
        {
            noUpdate = true;
            p.Note_Up(listNotes.SelectedIndex);
            Update_Notes();
            noUpdate = false;
            listNotes.SelectedIndex -= 1;
        }
        private void btnDownNote_Click(object sender, EventArgs e)
        {
            noUpdate = true;
            p.Note_Down(listNotes.SelectedIndex);
            Update_Notes();
            noUpdate = false;
            listNotes.SelectedIndex += 1;
        }
        private void listNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO:
            /*
            if (noUpdate)
                return;
            noUpdate = true;
            sNote note = p.Get_Note(listNotes.SelectedIndex);
            txtNoteTitle.Text = note.title;
            txtNoteMsg.Text = note.msg;
            Update_Notes();
            noUpdate = false;

            btnEditNote.Enabled = true;
            btnRemoveNote.Enabled = true;
            */
        }

        private void Update_Image()
        {
            // TODO:
            /*
            int s = listImgs.SelectedIndex;
            int l = p.ImagesLength;

            listImgs.Items.Clear();
            for (int i = 0; i < l; i++)
                listImgs.Items.Add(p.Get_Image(i).date.ToShortDateString() + ' ' + p.Get_Image(i).title);
            listImgs.SelectedIndex = s;

            btnUpImg.Enabled = false;
            btnDownImg.Enabled = false;

            if (l > 1 && (s >= 0 && s < l - 1))
                btnDownImg.Enabled = true;
            if (l > 1 && (s > 0 && s < l))
                btnUpImg.Enabled = true;
                */
        }
        private void btnViewImg_Click(object sender, EventArgs e)
        {
            // TODO
            /*
            ImageViewer iv = new ImageViewer(p.Get_Image(listImgs.SelectedIndex));
            iv.ShowDialog();
            iv.Dispose();
            iv = null;
            */
        }
        private void btnAddImg_Click(object sender, EventArgs e)
        {
            // TODO:
            /*
            ImageDialog id = new ImageDialog();
            if (id.ShowDialog() != DialogResult.OK)
                return;

            p.Add_Image(id.Image);

            btnEditImg.Enabled = true;
            btnRemoveImg.Enabled = true;
            btnViewImg.Enabled = true;
            Update_Image();
            noUpdate = false;
            listImgs.SelectedIndex = p.ImagesLength - 1;
            */
        }
        private void btnEditImg_Click(object sender, EventArgs e)
        {
            // TODO
            /*
            ImageDialog id = new ImageDialog(p.Get_Image(listImgs.SelectedIndex));
            if (id.ShowDialog() != DialogResult.OK)
                return;

            p.Set_Image(listImgs.SelectedIndex, id.Image);
            listImgs.Items[listImgs.SelectedIndex] = id.Image.date.ToShortDateString() + ' ' + id.Image.title;

            id.Dispose();
            id = null;
            */
        }
        private void btnRemoveImg_Click(object sender, EventArgs e)
        {
            // TODO:
            /*
            noUpdate = true;
            int i = listImgs.SelectedIndex;
            p.Remove_Image(i);
            if (i > -1)
                listImgs.SelectedIndex = i - 1;
            if (i == 0 && p.ImagesLength > 0)
                listImgs.SelectedIndex = 0;
            Update_Image();
            noUpdate = false;

            if (p.ImagesLength == 0)
            {
                btnRemoveImg.Enabled = false;
                btnEditImg.Enabled = false;
                btnViewImg.Enabled = false;
            }
            */
        }
        private void btnUpImg_Click(object sender, EventArgs e)
        {
            // TODO:
            /*
            noUpdate = true;
            p.Image_Up(listImgs.SelectedIndex);
            listImgs.SelectedIndex -= 1;
            Update_Image();
            noUpdate = false;
            */
        }
        private void btnDownImg_Click(object sender, EventArgs e)
        {
            // TODO:
            /*
            noUpdate = true;
            p.Image_Down(listImgs.SelectedIndex);
            listImgs.SelectedIndex += 1;
            Update_Image();
            noUpdate = false;
            */
        }
        private void listImgs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO
            /*
            if (noUpdate)
                return;
            noUpdate = true;
            Update_Image();
            noUpdate = false;

            btnEditImg.Enabled = true;
            btnRemoveImg.Enabled = true;
            */
        }
        
        void Button1Click(object sender, EventArgs e)
        {
            new ImageDialog().ShowDialog();
        }
    }
}
