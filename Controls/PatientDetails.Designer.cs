// ----------------------------------------------------------------------
// <copyright file="PatientDetails.Designer.cs" company="none">

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
// <date>07/09/2012 2:05:15</date>
// -----------------------------------------------------------------------
namespace MiConsulta
{
    partial class PatientDetails
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupDetails = new System.Windows.Forms.GroupBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listPhotos = new MiConsulta.ListManagerControl();
            this.listNotes = new MiConsulta.ListManagerControl();
            this.dateTimeAppointment = new System.Windows.Forms.DateTimePicker();
            this.dateTimeNextAppoint = new System.Windows.Forms.DateTimePicker();
            this.btnRemoveVisit = new System.Windows.Forms.Button();
            this.btnEditVisit = new System.Windows.Forms.Button();
            this.btnAddVisit = new System.Windows.Forms.Button();
            this.listAppointment = new System.Windows.Forms.ListBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHistory = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.groupDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // groupDetails
            // 
            this.groupDetails.BackColor = System.Drawing.Color.Transparent;
            this.groupDetails.Controls.Add(this.txtCountry);
            this.groupDetails.Controls.Add(this.label3);
            this.groupDetails.Controls.Add(this.txtCity);
            this.groupDetails.Controls.Add(this.label2);
            this.groupDetails.Controls.Add(this.txtZipCode);
            this.groupDetails.Controls.Add(this.label1);
            this.groupDetails.Controls.Add(this.listPhotos);
            this.groupDetails.Controls.Add(this.listNotes);
            this.groupDetails.Controls.Add(this.dateTimeAppointment);
            this.groupDetails.Controls.Add(this.dateTimeNextAppoint);
            this.groupDetails.Controls.Add(this.btnRemoveVisit);
            this.groupDetails.Controls.Add(this.btnEditVisit);
            this.groupDetails.Controls.Add(this.btnAddVisit);
            this.groupDetails.Controls.Add(this.listAppointment);
            this.groupDetails.Controls.Add(this.txtMobile);
            this.groupDetails.Controls.Add(this.label14);
            this.groupDetails.Controls.Add(this.label12);
            this.groupDetails.Controls.Add(this.label9);
            this.groupDetails.Controls.Add(this.txtAddress);
            this.groupDetails.Controls.Add(this.label11);
            this.groupDetails.Controls.Add(this.txtEmail);
            this.groupDetails.Controls.Add(this.label10);
            this.groupDetails.Controls.Add(this.txtPhone);
            this.groupDetails.Controls.Add(this.label8);
            this.groupDetails.Controls.Add(this.txtName);
            this.groupDetails.Controls.Add(this.label7);
            this.groupDetails.Controls.Add(this.txtHistory);
            this.groupDetails.Controls.Add(this.label6);
            this.groupDetails.Controls.Add(this.picPhoto);
            this.groupDetails.Location = new System.Drawing.Point(0, 0);
            this.groupDetails.Name = "groupDetails";
            this.groupDetails.Size = new System.Drawing.Size(683, 382);
            this.groupDetails.TabIndex = 0;
            this.groupDetails.TabStop = false;
            this.groupDetails.Text = "Detalles del paciente";
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(519, 71);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(158, 20);
            this.txtCountry.TabIndex = 44;
            this.txtCountry.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(439, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "País:";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(519, 45);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(158, 20);
            this.txtCity.TabIndex = 42;
            this.txtCity.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(439, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Ciudad:";
            // 
            // txtZipCode
            // 
            this.txtZipCode.Location = new System.Drawing.Point(519, 19);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(158, 20);
            this.txtZipCode.TabIndex = 40;
            this.txtZipCode.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(439, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Código postal:";
            // 
            // listPhotos
            // 
            this.listPhotos.BackColor = System.Drawing.Color.Transparent;
            this.listPhotos.EditorType = "MiConsulta.PhotoDialog";
            this.listPhotos.ImagePrefix = "film";
            this.listPhotos.Location = new System.Drawing.Point(437, 200);
            this.listPhotos.Name = "listPhotos";
            this.listPhotos.Size = new System.Drawing.Size(242, 178);
            this.listPhotos.TabIndex = 38;
            this.listPhotos.Title = "Imágenes:";
            this.listPhotos.ViewerType = "MiConsulta.PhotoViewer";
            this.listPhotos.Changed += new MiConsulta.DataChangedEventHandler(this.ListPhotosChanged);
            // 
            // listNotes
            // 
            this.listNotes.BackColor = System.Drawing.Color.Transparent;
            this.listNotes.EditorType = "MiConsulta.NoteDialog";
            this.listNotes.ImagePrefix = "note";
            this.listNotes.Location = new System.Drawing.Point(191, 200);
            this.listNotes.Name = "listNotes";
            this.listNotes.Size = new System.Drawing.Size(242, 178);
            this.listNotes.TabIndex = 37;
            this.listNotes.Title = "Notas:";
            this.listNotes.ViewerType = "MiConsulta.NoteDialog";
            this.listNotes.Changed += new MiConsulta.DataChangedEventHandler(this.ListNotesChanged);
            // 
            // dateTimeAppointment
            // 
            this.dateTimeAppointment.CustomFormat = "dddd\' \'dd\'/\'MM\'/\'yyyy\' \'HH\':\'mm tt";
            this.dateTimeAppointment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeAppointment.Location = new System.Drawing.Point(10, 217);
            this.dateTimeAppointment.Name = "dateTimeAppointment";
            this.dateTimeAppointment.Size = new System.Drawing.Size(175, 20);
            this.dateTimeAppointment.TabIndex = 7;
            // 
            // dateTimeNextAppoint
            // 
            this.dateTimeNextAppoint.CustomFormat = "dddd\',\'dd\'/\'MM\'/\'yyyy \'-\' HH\':\'mm tt";
            this.dateTimeNextAppoint.Enabled = false;
            this.dateTimeNextAppoint.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeNextAppoint.Location = new System.Drawing.Point(143, 174);
            this.dateTimeNextAppoint.Name = "dateTimeNextAppoint";
            this.dateTimeNextAppoint.ShowCheckBox = true;
            this.dateTimeNextAppoint.Size = new System.Drawing.Size(290, 20);
            this.dateTimeNextAppoint.TabIndex = 6;
            this.dateTimeNextAppoint.Value = new System.DateTime(2012, 9, 7, 13, 14, 0, 0);
            this.dateTimeNextAppoint.Leave += new System.EventHandler(this.dateTimeNextAppoit_ValueChanged);
            // 
            // btnRemoveVisit
            // 
            this.btnRemoveVisit.Image = global::MiConsulta.Properties.Resources.calendar_delete;
            this.btnRemoveVisit.Location = new System.Drawing.Point(155, 301);
            this.btnRemoveVisit.Name = "btnRemoveVisit";
            this.btnRemoveVisit.Size = new System.Drawing.Size(30, 23);
            this.btnRemoveVisit.TabIndex = 10;
            this.toolTipHelp.SetToolTip(this.btnRemoveVisit, "Eliminar cita");
            this.btnRemoveVisit.UseVisualStyleBackColor = true;
            this.btnRemoveVisit.Click += new System.EventHandler(this.btnRemoveVisit_Click);
            // 
            // btnEditVisit
            // 
            this.btnEditVisit.Image = global::MiConsulta.Properties.Resources.calendar_edit;
            this.btnEditVisit.Location = new System.Drawing.Point(155, 272);
            this.btnEditVisit.Name = "btnEditVisit";
            this.btnEditVisit.Size = new System.Drawing.Size(30, 23);
            this.btnEditVisit.TabIndex = 9;
            this.toolTipHelp.SetToolTip(this.btnEditVisit, "Editar cita");
            this.btnEditVisit.UseVisualStyleBackColor = true;
            this.btnEditVisit.Click += new System.EventHandler(this.btnEditVisit_Click);
            // 
            // btnAddVisit
            // 
            this.btnAddVisit.Image = global::MiConsulta.Properties.Resources.calendar_add;
            this.btnAddVisit.Location = new System.Drawing.Point(155, 243);
            this.btnAddVisit.Name = "btnAddVisit";
            this.btnAddVisit.Size = new System.Drawing.Size(30, 23);
            this.btnAddVisit.TabIndex = 8;
            this.toolTipHelp.SetToolTip(this.btnAddVisit, "Añadir cita");
            this.btnAddVisit.UseVisualStyleBackColor = true;
            this.btnAddVisit.Click += new System.EventHandler(this.btnAddVisit_Click);
            // 
            // listAppointment
            // 
            this.listAppointment.FormattingEnabled = true;
            this.listAppointment.Location = new System.Drawing.Point(10, 243);
            this.listAppointment.Name = "listAppointment";
            this.listAppointment.Size = new System.Drawing.Size(137, 134);
            this.listAppointment.TabIndex = 11;
            this.listAppointment.SelectedIndexChanged += new System.EventHandler(this.listAppointment_SelectedIndexChanged);
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(231, 97);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(202, 20);
            this.txtMobile.TabIndex = 3;
            this.txtMobile.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(114, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(111, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "Nº de teléfono (móvil):";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 178);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(131, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "Fecha de la siguiente cita:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 201);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Otras citas:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(143, 149);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(290, 20);
            this.txtAddress.TabIndex = 5;
            this.txtAddress.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Dirección:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(143, 123);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(290, 20);
            this.txtEmail.TabIndex = 4;
            this.txtEmail.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "Email:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(231, 71);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(202, 20);
            this.txtPhone.TabIndex = 2;
            this.txtPhone.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(114, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Nº de teléfono (fijo):";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(231, 45);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(202, 20);
            this.txtName.TabIndex = 1;
            this.txtName.Tag = "0";
            this.txtName.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(114, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Nombre y apellidos:";
            // 
            // txtHistory
            // 
            this.txtHistory.Location = new System.Drawing.Point(231, 19);
            this.txtHistory.Name = "txtHistory";
            this.txtHistory.Size = new System.Drawing.Size(202, 20);
            this.txtHistory.TabIndex = 0;
            this.txtHistory.Tag = "1";
            this.txtHistory.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(115, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Número de historia:";
            // 
            // picPhoto
            // 
            this.picPhoto.BackColor = System.Drawing.Color.Gray;
            this.picPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPhoto.Image = global::MiConsulta.Properties.Resources.Unknown_profile;
            this.picPhoto.Location = new System.Drawing.Point(10, 19);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(100, 100);
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPhoto.TabIndex = 2;
            this.picPhoto.TabStop = false;
            this.toolTipHelp.SetToolTip(this.picPhoto, "Haga doble click para importar la fotografía");
            this.picPhoto.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.picPhoto_MouseDoubleClick);
            // 
            // toolTipHelp
            // 
            this.toolTipHelp.ToolTipTitle = "Acción:";
            // 
            // PatientDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupDetails);
            this.Name = "PatientDetails";
            this.Size = new System.Drawing.Size(683, 382);
            this.groupDetails.ResumeLayout(false);
            this.groupDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtZipCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCountry;
        private MiConsulta.ListManagerControl listNotes;
        private MiConsulta.ListManagerControl listPhotos;

        #endregion

        private System.Windows.Forms.GroupBox groupDetails;
        private System.Windows.Forms.DateTimePicker dateTimeAppointment;
        private System.Windows.Forms.DateTimePicker dateTimeNextAppoint;
        private System.Windows.Forms.Button btnRemoveVisit;
        private System.Windows.Forms.Button btnEditVisit;
        private System.Windows.Forms.Button btnAddVisit;
        private System.Windows.Forms.ListBox listAppointment;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHistory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.ToolTip toolTipHelp;
    }
}
