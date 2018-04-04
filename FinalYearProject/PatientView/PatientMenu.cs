using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalYearProject.PatientView
{
    public partial class PatientMenu : Form
    {
        public PatientMenu()
        {
            InitializeComponent();
            this.Text = "StegoMed";

            this.CenterToScreen();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            this.Hide();

            ImageSelectionPatient selectImage = new ImageSelectionPatient();
            selectImage.Show();
        }
    }
}