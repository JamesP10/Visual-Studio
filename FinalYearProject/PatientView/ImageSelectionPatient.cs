using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalYearProject.PatientView
{
    public partial class ImageSelectionPatient : Form
    {
        public static string image;
        public static Image stegoImg;

        public ImageSelectionPatient()
        {
            InitializeComponent();
            this.Text = "StegoMed";

            this.CenterToScreen();
        }

        private void ImageSelectionPatient_Load(object sender, EventArgs e)
        {
            fillImageList();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            //save select image to variable 'image' + perform extraction of details
            //and output to a separate file to be saved by the user??

            //redirect to completion page
            this.Hide();
            CompletionPatient completionPatient = new CompletionPatient();
            completionPatient.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //close this form and redirect to patient landing screen
            this.Hide();
            PatientMenu patientMenu = new PatientMenu();
            patientMenu.Show();
        }

        public void fillImageList()
        {
            // Initalise ImgList
            List<string> ImgList = new List<string>();

            // Connect to database
            SqlConnection sqlConn = new SqlConnection(Login.ConnectionString);
            SqlCommand sqlCmd = new SqlCommand("SELECT Filename from ImageTable where PA_ID = '" + Login.username + "'", sqlConn);
            sqlConn.Open();
            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                int i = 0;
                ImgList.Add(reader[i].ToString());
                i++;
            }

            foreach (string img in ImgList)
            {
                listView1.Items.Add(img);
            }
        }

        //TODO implement below code
        public void fillPictureBox()
        {
            byte[] imgData = { };

            SqlConnection sqlConn = new SqlConnection(Login.ConnectionString);
            SqlCommand sqlCmd = new SqlCommand("SELECT Image from ImageTable where PA_ID = '" + Login.username + "' and Filename = '" + listView1.FocusedItem.Text + "'", sqlConn);
            sqlConn.Open();
            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                int i = 0;
                imgData = (byte[])reader[i];

                //fill picturebox with image
                //pictureBox1 = new Bitmap(imgData);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.FocusedItem != null)
            {
                Bitmap ImgBmp = new Bitmap(listView1.FocusedItem.Text);
                pictureBox1.Image = ImgBmp;
                image = listView1.FocusedItem.Text;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.jpg; *.jpeg; *.bmp; *.png) | *.jpg; *.jpeg; *.bmp; *.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //display the image within the picture box
                pictureBox1.Image = new Bitmap(ofd.FileName);

                stegoImg = pictureBox1.Image;
            }
        }
    }
}
