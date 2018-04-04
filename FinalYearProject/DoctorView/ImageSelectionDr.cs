using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalYearProject
{
    public partial class ImageSelectionDr : Form
    {
        public static String image = "";

        public ImageSelectionDr()
        {
            InitializeComponent();

            this.CenterToScreen();
        }

        private void buttonSelectImage_Click(object sender, EventArgs e)
        {
            //open file dialog to allow a user to select an image
            OpenFileDialog selectImgFile = new OpenFileDialog();
            //filter files shown
            selectImgFile.Filter = "Image Files (*.jpg; *.jpeg; *.bmp; *.png) | *.jpg; *.jpeg; *.bmp; *.png";

            if (selectImgFile.ShowDialog() == DialogResult.OK)
            {
                //display the image within the picture box
                pictureBox1.Image = new Bitmap(selectImgFile.FileName);
                //display file path
                txtFilePath.Text = selectImgFile.FileName;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            image = txtFilePath.Text;

            this.Hide();
            DoctorView.Confirmation confirmation = new DoctorView.Confirmation();
            confirmation.Show();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmebedForm embedForm = new EmebedForm();
            embedForm.Show();
        }
    }
}
