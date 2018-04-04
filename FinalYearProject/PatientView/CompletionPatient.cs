using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalYearProject.PatientView
{
    public partial class CompletionPatient : Form
    {
        public CompletionPatient()
        {
            InitializeComponent();

            this.CenterToScreen();

            //Image image = byteToImage(getImageBytes());
            Image stegoimg = ImageSelectionPatient.stegoImg;

            MessageBox.Show(StegoHelper.extractText(new Bitmap(stegoimg)));
            textBox1.Text = StegoHelper.extractText(new Bitmap(stegoimg));

            pictureBox1.Image = new Bitmap(ImageSelectionPatient.stegoImg);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //compress both files to zip folder and save
            SaveFileDialog saveFile = new SaveFileDialog();
            
            if (saveFile.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            //redirect user to patient landing screen
            this.Close();
            PatientMenu patientMenu = new PatientMenu();
            patientMenu.Show();
        }

        private Image byteToImage(byte[] bytes)
        {
            Stream ms = new MemoryStream(bytes, 0, bytes.Length);
            ms.Write(bytes, 0, bytes.Length);
            Image returnImage = Image.FromStream(ms, true);

            return returnImage;
        }

        public byte[] getImageBytes()
        {
            byte[] image = new byte[] { };

            // Connect to database
            SqlConnection sqlConn = new SqlConnection(Login.ConnectionString);
            SqlCommand sqlCmd = new SqlCommand("SELECT Image from ImageTable where PA_ID = '" + Login.username + "' AND Filename = '" + ImageSelectionPatient.image + "'", sqlConn);
            sqlConn.Open();
            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                int i = 0;
                image = (byte[])reader[0];
                MessageBox.Show(image.ToString());
                i++;
            }

            return image;
        }
    }
}
