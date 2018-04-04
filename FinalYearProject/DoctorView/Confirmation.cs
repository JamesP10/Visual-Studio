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

namespace FinalYearProject.DoctorView
{
    public partial class Confirmation : Form
    {
        public static Bitmap stegoImg;

        public Confirmation()
        {
            InitializeComponent();

            this.CenterToScreen();

            //GET details and image and populate respective objects
            textBox1.Text = EmebedForm.details;

            pictureBox1.Image = new Bitmap(ImageSelectionDr.image);
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            //TODO stego algorithm to be applied here

            Bitmap imgbmp = new Bitmap(pictureBox1.Image);

            stegoImg = StegoHelper.embedText(EmebedForm.details, imgbmp);

            byte[] image = imageToByte(stegoImg);

            //ImageSelectionDr.image = EmebedForm.patient_id + "_" + DateTime.Today.ToShortDateString();

            SaveImageToDatabase(EmebedForm.patient_id, ImageSelectionDr.image, image);

            MessageBox.Show(StegoHelper.extractText(stegoImg));

            this.Hide();
            Completion completeScreen = new Completion();
            completeScreen.Show();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            ImageSelectionDr selectImage = new ImageSelectionDr();
            selectImage.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void SaveImageToDatabase(string patientID, string filename, byte[] image)
        {
            SqlConnection sqlConn = new SqlConnection(Login.ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter();

            using (SqlConnection con = new SqlConnection(Login.ConnectionString))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("INSERT INTO ImageTable (PA_ID, Filename, Image) VALUES ('" + patientID + "', '" + filename + "', '" + image + "')", con))
                {
                    com.Parameters.AddWithValue("@PA_ID", "PA001");
                    com.Parameters.AddWithValue("@Filename", filename);
                    com.Parameters.AddWithValue("@Image", image);
                    com.ExecuteNonQuery();
                }
            }
        }

        public byte[] imageToByte(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
