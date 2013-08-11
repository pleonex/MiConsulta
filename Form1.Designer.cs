// ----------------------------------------------------------------------
// <copyright file="Form1.Designer.cs" company="none">

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
// <date>06/09/2012 13:33:26</date>
// -----------------------------------------------------------------------
namespace MiConsulta
{
    partial class Form1
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSavePerson = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupSearch = new System.Windows.Forms.GroupBox();
            this.radioSNextVisit = new System.Windows.Forms.RadioButton();
            this.radioSName = new System.Windows.Forms.RadioButton();
            this.radioSPhone = new System.Windows.Forms.RadioButton();
            this.radioSAddress = new System.Windows.Forms.RadioButton();
            this.radioSLastVisit = new System.Windows.Forms.RadioButton();
            this.radioSEmail = new System.Windows.Forms.RadioButton();
            this.radioSTratamientos = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioSHistory = new System.Windows.Forms.RadioButton();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnRemovePerson = new System.Windows.Forms.Button();
            this.btnCleanFields = new System.Windows.Forms.Button();
            this.txtDebug = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.timerTime = new System.Windows.Forms.Timer(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.picInternet = new System.Windows.Forms.PictureBox();
            this.lblNumPatient = new System.Windows.Forms.Label();
            this.backIntrenet = new System.ComponentModel.BackgroundWorker();
            this.patientDetails1 = new MiConsulta.PatientDetails();
            this.groupSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInternet)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(417, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "¡Buscar!";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSavePerson
            // 
            this.btnSavePerson.BackColor = System.Drawing.Color.Purple;
            this.btnSavePerson.Enabled = false;
            this.btnSavePerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePerson.ForeColor = System.Drawing.Color.Khaki;
            this.btnSavePerson.Location = new System.Drawing.Point(600, 87);
            this.btnSavePerson.Name = "btnSavePerson";
            this.btnSavePerson.Size = new System.Drawing.Size(80, 50);
            this.btnSavePerson.TabIndex = 1;
            this.btnSavePerson.Text = "Guardar modificación";
            this.btnSavePerson.UseVisualStyleBackColor = false;
            this.btnSavePerson.Click += new System.EventHandler(this.btnSavePerson_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearch.Location = new System.Drawing.Point(56, 19);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(355, 20);
            this.txtSearch.TabIndex = 0;
            // 
            // groupSearch
            // 
            this.groupSearch.Controls.Add(this.radioSNextVisit);
            this.groupSearch.Controls.Add(this.radioSName);
            this.groupSearch.Controls.Add(this.radioSPhone);
            this.groupSearch.Controls.Add(this.radioSAddress);
            this.groupSearch.Controls.Add(this.radioSLastVisit);
            this.groupSearch.Controls.Add(this.radioSEmail);
            this.groupSearch.Controls.Add(this.radioSTratamientos);
            this.groupSearch.Controls.Add(this.label3);
            this.groupSearch.Controls.Add(this.label1);
            this.groupSearch.Controls.Add(this.radioSHistory);
            this.groupSearch.Controls.Add(this.btnSearch);
            this.groupSearch.Controls.Add(this.txtSearch);
            this.groupSearch.Location = new System.Drawing.Point(5, 25);
            this.groupSearch.Name = "groupSearch";
            this.groupSearch.Size = new System.Drawing.Size(503, 112);
            this.groupSearch.TabIndex = 0;
            this.groupSearch.TabStop = false;
            this.groupSearch.Text = "Opciones de búsqueda";
            // 
            // radioSNextVisit
            // 
            this.radioSNextVisit.AutoSize = true;
            this.radioSNextVisit.Location = new System.Drawing.Point(347, 89);
            this.radioSNextVisit.Name = "radioSNextVisit";
            this.radioSNextVisit.Size = new System.Drawing.Size(146, 17);
            this.radioSNextVisit.TabIndex = 8;
            this.radioSNextVisit.Tag = "7";
            this.radioSNextVisit.Text = "Fecha de la siguiente cita";
            this.radioSNextVisit.UseVisualStyleBackColor = true;
            this.radioSNextVisit.CheckedChanged += new System.EventHandler(this.radioSearch_CheckedChanged);
            // 
            // radioSName
            // 
            this.radioSName.AutoSize = true;
            this.radioSName.Location = new System.Drawing.Point(8, 89);
            this.radioSName.Name = "radioSName";
            this.radioSName.Size = new System.Drawing.Size(114, 17);
            this.radioSName.TabIndex = 2;
            this.radioSName.Tag = "1";
            this.radioSName.Text = "Nombre y apellidos";
            this.radioSName.UseVisualStyleBackColor = true;
            this.radioSName.CheckedChanged += new System.EventHandler(this.radioSearch_CheckedChanged);
            // 
            // radioSPhone
            // 
            this.radioSPhone.AutoSize = true;
            this.radioSPhone.Location = new System.Drawing.Point(128, 66);
            this.radioSPhone.Name = "radioSPhone";
            this.radioSPhone.Size = new System.Drawing.Size(93, 17);
            this.radioSPhone.TabIndex = 3;
            this.radioSPhone.Tag = "2";
            this.radioSPhone.Text = "Nº de teléfono";
            this.radioSPhone.UseVisualStyleBackColor = true;
            this.radioSPhone.CheckedChanged += new System.EventHandler(this.radioSearch_CheckedChanged);
            // 
            // radioSAddress
            // 
            this.radioSAddress.AutoSize = true;
            this.radioSAddress.Location = new System.Drawing.Point(128, 89);
            this.radioSAddress.Name = "radioSAddress";
            this.radioSAddress.Size = new System.Drawing.Size(70, 17);
            this.radioSAddress.TabIndex = 4;
            this.radioSAddress.Tag = "3";
            this.radioSAddress.Text = "Dirección";
            this.radioSAddress.UseVisualStyleBackColor = true;
            this.radioSAddress.CheckedChanged += new System.EventHandler(this.radioSearch_CheckedChanged);
            // 
            // radioSLastVisit
            // 
            this.radioSLastVisit.AutoSize = true;
            this.radioSLastVisit.Location = new System.Drawing.Point(347, 66);
            this.radioSLastVisit.Name = "radioSLastVisit";
            this.radioSLastVisit.Size = new System.Drawing.Size(131, 17);
            this.radioSLastVisit.TabIndex = 7;
            this.radioSLastVisit.Tag = "6";
            this.radioSLastVisit.Text = "Fecha de la última cita";
            this.radioSLastVisit.UseVisualStyleBackColor = true;
            this.radioSLastVisit.CheckedChanged += new System.EventHandler(this.radioSearch_CheckedChanged);
            // 
            // radioSEmail
            // 
            this.radioSEmail.AutoSize = true;
            this.radioSEmail.Location = new System.Drawing.Point(227, 66);
            this.radioSEmail.Name = "radioSEmail";
            this.radioSEmail.Size = new System.Drawing.Size(53, 17);
            this.radioSEmail.TabIndex = 5;
            this.radioSEmail.Tag = "4";
            this.radioSEmail.Text = "E-mail";
            this.radioSEmail.UseVisualStyleBackColor = true;
            this.radioSEmail.CheckedChanged += new System.EventHandler(this.radioSearch_CheckedChanged);
            // 
            // radioSTratamientos
            // 
            this.radioSTratamientos.AutoSize = true;
            this.radioSTratamientos.Location = new System.Drawing.Point(227, 89);
            this.radioSTratamientos.Name = "radioSTratamientos";
            this.radioSTratamientos.Size = new System.Drawing.Size(86, 17);
            this.radioSTratamientos.TabIndex = 6;
            this.radioSTratamientos.Tag = "5";
            this.radioSTratamientos.Text = "Notas (título)";
            this.radioSTratamientos.UseVisualStyleBackColor = true;
            this.radioSTratamientos.CheckedChanged += new System.EventHandler(this.radioSearch_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tipo de búsqueda:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Buscar:";
            // 
            // radioSHistory
            // 
            this.radioSHistory.AutoSize = true;
            this.radioSHistory.Location = new System.Drawing.Point(8, 66);
            this.radioSHistory.Name = "radioSHistory";
            this.radioSHistory.Size = new System.Drawing.Size(88, 17);
            this.radioSHistory.TabIndex = 1;
            this.radioSHistory.Tag = "0";
            this.radioSHistory.Text = "Nº de historia";
            this.radioSHistory.UseVisualStyleBackColor = true;
            this.radioSHistory.CheckedChanged += new System.EventHandler(this.radioSearch_CheckedChanged);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.BackColor = System.Drawing.Color.Purple;
            this.btnAddPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPerson.ForeColor = System.Drawing.Color.Khaki;
            this.btnAddPerson.Location = new System.Drawing.Point(514, 25);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(80, 50);
            this.btnAddPerson.TabIndex = 3;
            this.btnAddPerson.Text = "Añadir paciente";
            this.btnAddPerson.UseVisualStyleBackColor = false;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnRemovePerson
            // 
            this.btnRemovePerson.BackColor = System.Drawing.Color.Purple;
            this.btnRemovePerson.Enabled = false;
            this.btnRemovePerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemovePerson.ForeColor = System.Drawing.Color.Khaki;
            this.btnRemovePerson.Location = new System.Drawing.Point(600, 25);
            this.btnRemovePerson.Name = "btnRemovePerson";
            this.btnRemovePerson.Size = new System.Drawing.Size(80, 50);
            this.btnRemovePerson.TabIndex = 4;
            this.btnRemovePerson.Text = "Eliminar paciente";
            this.btnRemovePerson.UseVisualStyleBackColor = false;
            this.btnRemovePerson.Click += new System.EventHandler(this.btnRemovePerson_Click);
            // 
            // btnCleanFields
            // 
            this.btnCleanFields.BackColor = System.Drawing.Color.Purple;
            this.btnCleanFields.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCleanFields.ForeColor = System.Drawing.Color.Khaki;
            this.btnCleanFields.Location = new System.Drawing.Point(514, 87);
            this.btnCleanFields.Name = "btnCleanFields";
            this.btnCleanFields.Size = new System.Drawing.Size(80, 50);
            this.btnCleanFields.TabIndex = 2;
            this.btnCleanFields.Text = "Limpiar campos";
            this.btnCleanFields.UseVisualStyleBackColor = false;
            this.btnCleanFields.Click += new System.EventHandler(this.btnCleanFields_Click);
            // 
            // txtDebug
            // 
            this.txtDebug.Location = new System.Drawing.Point(690, 25);
            this.txtDebug.Multiline = true;
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.ReadOnly = true;
            this.txtDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDebug.Size = new System.Drawing.Size(275, 501);
            this.txtDebug.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Brown;
            this.label5.Location = new System.Drawing.Point(787, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "DEBUG:";
            // 
            // timerTime
            // 
            this.timerTime.Enabled = true;
            this.timerTime.Interval = 1000;
            this.timerTime.Tick += new System.EventHandler(this.timerTime_Tick);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(2, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(384, 17);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "¡Bienvenido a MiConsulta! ~ 07/09/2012 16:43:05";
            // 
            // picInternet
            // 
            this.picInternet.Image = global::MiConsulta.Properties.Resources.world_disabled;
            this.picInternet.InitialImage = null;
            this.picInternet.Location = new System.Drawing.Point(664, 5);
            this.picInternet.Name = "picInternet";
            this.picInternet.Size = new System.Drawing.Size(16, 16);
            this.picInternet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picInternet.TabIndex = 9;
            this.picInternet.TabStop = false;
            this.picInternet.Click += new System.EventHandler(this.picInternet_Click);
            // 
            // lblNumPatient
            // 
            this.lblNumPatient.AutoSize = true;
            this.lblNumPatient.Location = new System.Drawing.Point(443, 4);
            this.lblNumPatient.Name = "lblNumPatient";
            this.lblNumPatient.Size = new System.Drawing.Size(168, 13);
            this.lblNumPatient.TabIndex = 10;
            this.lblNumPatient.Text = "Número de pacientes registrados: ";
            // 
            // backIntrenet
            // 
            this.backIntrenet.WorkerSupportsCancellation = true;
            this.backIntrenet.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backIntrenet_DoWork);
            this.backIntrenet.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backIntrenet_RunWorkerCompleted);
            // 
            // patientDetails1
            // 
            this.patientDetails1.BackColor = System.Drawing.Color.Transparent;
            this.patientDetails1.Location = new System.Drawing.Point(5, 143);
            this.patientDetails1.Name = "patientDetails1";
            this.patientDetails1.Size = new System.Drawing.Size(679, 383);
            this.patientDetails1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Plum;
            this.ClientSize = new System.Drawing.Size(968, 527);
            this.Controls.Add(this.lblNumPatient);
            this.Controls.Add(this.picInternet);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.patientDetails1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDebug);
            this.Controls.Add(this.btnCleanFields);
            this.Controls.Add(this.btnRemovePerson);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.groupSearch);
            this.Controls.Add(this.btnSavePerson);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MiConsulta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupSearch.ResumeLayout(false);
            this.groupSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInternet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSavePerson;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox groupSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioSHistory;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.RadioButton radioSNextVisit;
        private System.Windows.Forms.RadioButton radioSName;
        private System.Windows.Forms.RadioButton radioSPhone;
        private System.Windows.Forms.RadioButton radioSAddress;
        private System.Windows.Forms.RadioButton radioSLastVisit;
        private System.Windows.Forms.RadioButton radioSEmail;
        private System.Windows.Forms.RadioButton radioSTratamientos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRemovePerson;
        private System.Windows.Forms.Button btnCleanFields;
        private System.Windows.Forms.TextBox txtDebug;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timerTime;
        private PatientDetails patientDetails1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox picInternet;
        private System.Windows.Forms.Label lblNumPatient;
        private System.ComponentModel.BackgroundWorker backIntrenet;
    }
}

