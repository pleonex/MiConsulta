// ----------------------------------------------------------------------
// <copyright file="UpdateDialog.cs" company="none">

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
// <date>11/09/2012 19:01:11</date>
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
using System.Net;

namespace MiConsulta
{
    public partial class UpdateDialog : Form
    {
        string[,] files;

        public UpdateDialog()
        {
            InitializeComponent();

            string log;
            Version ver;
            Updater.Get_UpdateParam(out log, out ver, out files);

            this.txtVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.txtNextVersion.Text = ver.ToString();
            this.txtLog.Text = log.Replace("\n", "\r\n");
            for (int i = 0; i < files.Length / 2; i++)
                this.listFiles.Items.Add(System.IO.Path.GetFileName(files[i, 0]) + " (" + files[i, 1] + ')');
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string folder = Application.StartupPath + Path.DirectorySeparatorChar + "Updater" + Path.DirectorySeparatorChar;
            if (Directory.Exists(folder))
                Directory.Delete(folder, true);
            Directory.CreateDirectory(folder);

            this.btnUpdate.Enabled = false;
            this.btnCancel.Enabled = false;
            this.ControlBox = false;
            object[] param = { folder, files };
            backDownload.RunWorkerAsync(param);
        }

        private void backDownload_DoWork(object sender, DoWorkEventArgs e)
        {
            string folder = (string)((object[])e.Argument)[0];
            string[,] files = (string[,])((object[])e.Argument)[1];

            for (int i = 0; i < files.Length / 2; i++)
            {
                Console.WriteLine("Downloading file {0} ({1})", files[i, 0], i.ToString());
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(files[i, 0]);

                request.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Console.WriteLine("Content length is {0}", response.ContentLength);
                Console.WriteLine("Content type is {0}", response.ContentType);

                // Get the stream associated with the response.
                Stream stream = response.GetResponseStream();
                Console.WriteLine("Response stream received.");

                files[i, 0] = folder + Path.GetFileName(request.RequestUri.LocalPath);
                if (File.Exists(files[i, 0]))
                    files[i, 0] = folder + Path.GetRandomFileName() + '_' + Path.GetFileName(request.RequestUri.LocalPath);

                BinaryWriter bw = new BinaryWriter(File.OpenWrite(files[i, 0]));
                int count = 0;
                int BUFFER_SIZE = 512;
                byte[] buffer = new byte[BUFFER_SIZE];
                do
                {
                    count = stream.Read(buffer, 0, BUFFER_SIZE);
                    bw.Write(buffer, 0, count);
                } while (count != 0);
                Console.WriteLine("Response stream written.");

                bw.Flush();
                bw.Close();
                response.Close();
                stream.Close();
                bw = null;
                response = null;
                stream = null;
                request = null;

                backDownload.ReportProgress(i / (files.Length / 2));
            }

            backDownload.ReportProgress(100);
            e.Result = files;
        }
        private void backDownload_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressFiles.Value = e.ProgressPercentage;
        }
        private void backDownload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled || e.Error != null)
            {
                MessageBox.Show("Error durante la descarga:\n" + e.Error.Message);
                this.btnUpdate.Enabled = true;
                this.btnCancel.Enabled = true;
                this.ControlBox = true;
                return;
            }

            MessageBox.Show("Ahora se ejecutará el actualizador.", "Descarga completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            files = (string[,])e.Result;

            for (int i = 0; i < files.Length / 2; i++)
            {
                if (files[i, 1] != "true")
                    continue;

                System.Diagnostics.Process.Start(files[i, 0]);
            }

            Application.Exit();
        }

    }
}
