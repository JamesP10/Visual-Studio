using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalYearProject.DoctorView
{
    public partial class Completion : Form
    {
        public Completion()
        {
            InitializeComponent();

            this.CenterToScreen();
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            //TODO push image to database with patient ID and Dr. ID to allow it to be viewed by both

            //then close the form and return to the Dr. landing screen

            this.Hide();
            DoctorMenu docMenu = new DoctorMenu();
            docMenu.Show();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.FileName = EmebedForm.patient_id + "_" + DateTime.Today.ToShortDateString();
            sfd.Filter = "Image Files (*.jpg; *.jpeg; *.bmp; *.png) | *.jpg; *.jpeg; *.bmp; *.png";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Confirmation.stegoImg.Save(sfd.FileName);
            }
        }
    }
}
