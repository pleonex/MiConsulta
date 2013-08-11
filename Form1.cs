// ----------------------------------------------------------------------
// <copyright file="Form1.cs" company="none">

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
// <date>06/09/2012 13:33:21</date>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MiConsulta
{
    public partial class Form1 : Form
    {
        private StringBuilder sb;

        private Database db;
        private static string DbPath = Path.Combine(Application.StartupPath, "Database.xml");
        private static string BackupDbPath = Path.Combine(Application.StartupPath, "backup_database.xml");
        private int currId;

        public Form1()
        {
            InitializeComponent();
            this.lblTitle.Text = "¡Bienvenido a MiConsulta! ~ " + DateTime.Now.ToString();
            this.timerTime.Tag = 0;

            // Initialize debug messages
            sb = new StringBuilder();
            System.IO.TextWriter tw = new System.IO.StringWriter(sb);
            Console.SetOut(tw);

            Create_BackUp();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Read (or create) database
            db = new Database(DbPath);
            currId = -1;
            this.radioSHistory.Checked = true;
            this.lblNumPatient.Text = "Número de pacientes registrados: " + db.PatientLength.ToString();

            backIntrenet.RunWorkerAsync();
            Update_Debug();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (patientDetails1.Patient.IsEdited)
            {
                DialogResult ask = MessageBox.Show(
                    "Los datos del paciente han sido modificados pero no guardados.\n¿Desea guardarlos antes de salir?",
                    "Datos no guardados",
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
                
                if (ask == System.Windows.Forms.DialogResult.Yes)
                    db.Modify(currId, patientDetails1.Patient);
            }

            Save_DB();
        }

        private void Update_Debug()
        {
            txtDebug.AppendText(sb.ToString());
            sb.Length = 0;
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            lblTitle.Text = "¡Bienvenido a MiConsulta! ~ " + DateTime.Now.ToString();
            timerTime.Tag = (int)timerTime.Tag + 1;

            if ((int)timerTime.Tag % 300 == 0)
                Save_DB();

            Update_Debug();
        }
        private void Save_DB()
        {
            db.Write(DbPath);
            Update_Debug();
        }
        private void Create_BackUp()
        {
            FileInfo db_file = new FileInfo(DbPath);
            if (db_file.Exists) {
                FileInfo backup = new FileInfo(BackupDbPath);

                if (backup.Exists && backup.Attributes == FileAttributes.Hidden)
                    backup.Attributes = FileAttributes.Normal;
                db_file.CopyTo(BackupDbPath, true);
                backup.Attributes = FileAttributes.Hidden;
            }
        }

        private int Get_Type()
        {
            foreach (Control c in groupSearch.Controls)
                if (c is RadioButton && ((RadioButton)c).Checked)
                    return Convert.ToInt32(c.Tag);
            return 0;
        }
        private void radioSearch_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection completion = txtDebug.AutoCompleteCustomSource;
            completion.Clear();
            completion.AddRange(db.Get_List(Get_Type()));
            txtSearch.AutoCompleteCustomSource = completion;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (patientDetails1.Patient.IsEdited)
            {
                DialogResult ask = MessageBox.Show(
                    "Los datos del paciente han sido modificados pero no guardados.\n¿Desea continuar con la búsqueda?",
                    "Datos no guardados",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (ask == System.Windows.Forms.DialogResult.No)
                    return;
            }

            currId = db.Search(Get_Type(), txtSearch.Text);
            if (currId == -1)
            {
                MessageBox.Show("No se ha encontrado ningún paciente.");
                btnRemovePerson.Enabled = false;
                btnSavePerson.Enabled = false;
            }
            else
            {
                patientDetails1.Load_Patient(db.Get_Patient(currId));
                btnRemovePerson.Enabled = true;
                btnSavePerson.Enabled = true;
            }

            Update_Debug();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            if (patientDetails1.Patient.IsNull)
            {
                MessageBox.Show(
                    "Por favor rellene al menos los campos de nº de historia y nombre.",
                    "Paciente vacío",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            currId = db.Add(patientDetails1.Patient);
            patientDetails1.Patient.IsEdited = false;
            Save_DB();

            btnRemovePerson.Enabled = true;
            btnSavePerson.Enabled = true;
            radioSearch_CheckedChanged(null, null);
            this.lblNumPatient.Text = "Número de pacientes registrados: " + db.PatientLength.ToString();
        }
        private void btnSavePerson_Click(object sender, EventArgs e)
        {
            if (patientDetails1.Patient.IsNull)
            {
                MessageBox.Show(
                    "Por favor rellene al menos los campos de nº de historia y nombre.",
                    "Paciente vacío",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            db.Modify(currId, patientDetails1.Patient);
            patientDetails1.Patient.IsEdited = false;
            Save_DB();
        }
        private void btnRemovePerson_Click(object sender, EventArgs e)
        {
            DialogResult ask = MessageBox.Show(
                "¿Estás seguro de que quieres borrar el paciente actual?",
                "Borrar paciente",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (ask != System.Windows.Forms.DialogResult.Yes)
                return;

            db.Remove(currId);
            currId = -1;
            Save_DB();
            patientDetails1.Reset();

            btnRemovePerson.Enabled = false;
            btnSavePerson.Enabled = false;
            this.lblNumPatient.Text = "Número de pacientes registrados: " + db.PatientLength.ToString();
        }
        private void btnCleanFields_Click(object sender, EventArgs e)
        {
            if (patientDetails1.Patient.IsEdited)
            {
                DialogResult ask = MessageBox.Show(
                    "Los datos del paciente han sido modificados pero no guardados.\n¿Está seguro de limpiar los campos?",
                    "Datos no guardados",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (ask == System.Windows.Forms.DialogResult.No)
                    return;
            }

            patientDetails1.Reset();
            btnRemovePerson.Enabled = false;
            btnSavePerson.Enabled = false;
        }

        private void picInternet_Click(object sender, EventArgs e)
        {
            if (!backIntrenet.IsBusy)
                backIntrenet.RunWorkerAsync();
        }
        private void backIntrenet_DoWork(object sender, DoWorkEventArgs e)
        {
            bool[] results = new bool[2] { Updater.Check_Internet(), false };
            if (results[0])
                results[1] = Updater.Check_Update();
            e.Result = results;
        }
        private void backIntrenet_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled || e.Error != null)
            {
                MessageBox.Show("Error comprobando conexión a internet y actualizaciones.\n" + e.Error.Message);
                return;
            }

            bool isInternet = ((bool[])e.Result)[0];
            bool isUpdated = ((bool[])e.Result)[1];

            if (isInternet)
                picInternet.Image = Properties.Resources.world;
            else
                picInternet.Image = Properties.Resources.world_disabled;

            if (isUpdated)
            {
                if (patientDetails1.Patient.IsEdited)
                {
                    DialogResult ask = MessageBox.Show("Los datos del paciente han sido modificados pero no guardados.\n" +
                        "¿Desea continuar con la actualización?", "Datos no guardados", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (ask == System.Windows.Forms.DialogResult.No)
                        return;
                }

                UpdateDialog ud = new UpdateDialog();
                ud.ShowDialog();
            }
        }

    }
}
