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
    public partial class ImageDialog : Form
    {
        sImage img;
        string app_dir = Application.StartupPath + Path.DirectorySeparatorChar;
        string folder_name = "Images" + Path.DirectorySeparatorChar;

        public ImageDialog()
        {
            InitializeComponent();
            this.Text = "Añadir imagen";

            img = new sImage();
            dateTimeBox.Value = DateTime.Now;
        }
        public ImageDialog(sImage img)
        {
            InitializeComponent();
            this.Text = "Editar imagen";

            this.img = img;
            dateTimeBox.Value = img.date;
            txtTitle.Text = img.title;
            txtName.Text = System.IO.Path.GetFileName(img.relative_path);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public sImage Image
        {
            get
            {
                img.title = txtTitle.Text;
                img.date = dateTimeBox.Value;
                return img;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.CheckFileExists = true;
            o.CheckPathExists = true;
            o.Multiselect = false;
            o.Title = "Seleccione la imagen";
            if (o.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            txtName.Text = o.SafeFileName;
            img.relative_path = o.FileName;

            o.Dispose();
            o = null;
        }

        private void ImageDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != System.Windows.Forms.DialogResult.OK)
                return;

            string outp = app_dir + folder_name;
            if (!Directory.Exists(outp))
                Directory.CreateDirectory(outp);

            if (File.Exists(outp + txtName.Text))
                outp += Path.GetRandomFileName() + '_' + txtName.Text;
            else
                outp += txtName.Text;

            File.Copy(img.relative_path, outp);
            img.relative_path = outp.Replace(app_dir, "");
        }
    }
}
