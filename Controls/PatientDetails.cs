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
        bool noUpdate;

        public PatientDetails()
        {
            InitializeComponent();
            Reset();
        }
        
        public void Load_Patient(Patient patient)
        {
            Reset();
            
            this.Patient = patient;
            FillFields();
        }

        public void Reset()
        {
            noUpdate = true;
            this.Patient = new Patient();

            txtHistory.Text = "";
            txtName.Text    = "";
            txtPhone.Text   = "";
            txtMobile.Text  = "";
            txtEmail.Text   = "";
            txtAddress.Text = "";
            txtZipCode.Text = "";
            txtCity.Text    = "";
            txtCountry.Text = "";

            dateTimeNextAppoint.Value = DateTime.Now;
            dateTimeNextAppoint.Checked = false;
            dateTimeAppointment.Value = DateTime.Now;
            listAppointment.Items.Clear();
            btnEditVisit.Enabled = false;
            btnRemoveVisit.Enabled = false;

            this.listNotes.Clear();
            this.listPhotos.Clear();
            
            picPhoto.Image = Properties.Resources.Unknown_profile;

            noUpdate = false;
        }
        
        private void FillFields()
        {
            noUpdate = true;

            txtHistory.Text = this.Patient.History;
            txtName.Text    = this.Patient.Name;
            txtEmail.Text   = this.Patient.Email;
            txtAddress.Text = this.Patient.Address;
            txtPhone.Text   = this.Patient.Get_Phone(Phone_Type.Landline).number;
            txtMobile.Text  = this.Patient.Get_Phone(Phone_Type.Mobile).number;
            txtZipCode.Text = this.Patient.ZipCode;
            txtCity.Text    = this.Patient.City;
            txtCountry.Text = this.Patient.Country;

            DateTime dt = this.Patient.Get_NextAppointment();
            if (dt.Year == 1) {
                dateTimeNextAppoint.Value = DateTime.Now.AddDays(1);
                dateTimeNextAppoint.Checked = false;
            } else {
                dateTimeNextAppoint.Value = dt;
                dateTimeNextAppoint.Checked = true;
            }

            for (int i = 0; i < this.Patient.AppointmentsLength; i++)
                listAppointment.Items.Add(this.Patient.Get_Appointment(i).ToString());

            this.listNotes.SetElements(this.Patient.GetNotes());
            this.listPhotos.SetElements(this.Patient.GetPhotos());
            
            if (System.IO.File.Exists(this.Patient.Icon))
                picPhoto.Image = Image.FromFile(this.Patient.Icon);
            else
                picPhoto.Image = Properties.Resources.Unknown_profile;

            noUpdate = false;
        }

        public Patient Patient
        {
            get;
            private set;
        }

        private void picPhoto_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.CheckFileExists = true;
            o.CheckPathExists = true;
            o.Multiselect = false;
            if (o.ShowDialog() != DialogResult.OK)
                return;

            this.Patient.Icon = o.FileName;
            picPhoto.Image = Image.FromFile(this.Patient.Icon);

            o.Dispose();
            o = null;
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            if (noUpdate)
                return;
            noUpdate = true;

            this.Patient.History = txtHistory.Text;
            this.Patient.Name    = txtName.Text;
            this.Patient.Email   = txtEmail.Text;
            this.Patient.Address = txtAddress.Text;
            this.Patient.ZipCode = txtZipCode.Text;
            this.Patient.City    = txtCity.Text;
            this.Patient.Country = txtCountry.Text;
            this.Patient.Set_Phone(Phone_Type.Landline, txtPhone.Text);
            this.Patient.Set_Phone(Phone_Type.Mobile, txtMobile.Text);

            noUpdate = false;
        }

        private void Update_Appointment()
        {
            int index = listAppointment.SelectedIndex;

            listAppointment.Items.Clear();
            for (int i = 0; i < this.Patient.AppointmentsLength; i++)
                listAppointment.Items.Add(this.Patient.Get_Appointment(i).ToString());

            if (index != -1)
                listAppointment.SelectedIndex = index;

            DateTime dt = this.Patient.Get_NextAppointment();
            if (dt.Year == 1) {
                dateTimeNextAppoint.Value = DateTime.Now.AddDays(1);
                dateTimeNextAppoint.Checked = false;
            } else {
                dateTimeNextAppoint.Value = dt;
                dateTimeNextAppoint.Checked = true;
            }
        }
        private void dateTimeNextAppoit_ValueChanged(object sender, EventArgs e)
        {
            if (noUpdate)
                return;

            if (!dateTimeNextAppoint.Checked)
                this.Patient.Remove_NextAppointment();
            else
                this.Patient.Set_NextAppointment(dateTimeNextAppoint.Value);
        }
        private void btnAddVisit_Click(object sender, EventArgs e)
        {
            noUpdate = true;
            int index = this.Patient.Add_Appointment(dateTimeAppointment.Value);
            Update_Appointment();
            listAppointment.SelectedIndex = index;
            btnEditVisit.Enabled = true;
            btnRemoveVisit.Enabled = true;
            noUpdate = false;
        }
        private void btnEditVisit_Click(object sender, EventArgs e)
        {
            noUpdate = true;
            int index = this.Patient.Set_Appointment(listAppointment.SelectedIndex, dateTimeAppointment.Value);
            Update_Appointment();
            listAppointment.SelectedIndex = index;
            noUpdate = false;
        }
        private void btnRemoveVisit_Click(object sender, EventArgs e)
        {
            noUpdate = true;
            int i = listAppointment.SelectedIndex;
            this.Patient.Remove_Appointment(i);
            listAppointment.Items.RemoveAt(i);
            if (i > -1)
                listAppointment.SelectedIndex = i - 1;
            if (i == 0 && this.Patient.AppointmentsLength > 0)
                listAppointment.SelectedIndex = 0;

            if (this.Patient.AppointmentsLength == 0) {
                btnEditVisit.Enabled = false;
                btnRemoveVisit.Enabled = false;
            }
            this.Update_Appointment();
            noUpdate = false;
        }
        private void listAppointment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (noUpdate)
                return;

            noUpdate = true;
            btnEditVisit.Enabled = true;
            btnRemoveVisit.Enabled = true;
            dateTimeAppointment.Value = this.Patient.Get_Appointment(listAppointment.SelectedIndex);
            noUpdate = false;
        }
        
        private void ListNotesChanged()
        {
            this.Patient.SetNotes(this.listNotes.GetElements());
        }        
        private void ListPhotosChanged()
        {
            this.Patient.SetPhotos(this.listPhotos.GetElements());
        }
    }
}
