using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalYearProject.DoctorView;

namespace FinalYearProject
{
    public partial class EmebedForm : Form
    {
        //initalise variables
        public static string name;
        public static DateTime dob;
        public static string notes;
        public static string patient_id;
        public static string status;

        public static string details;

        public EmebedForm()
        {
            InitializeComponent();

            this.CenterToScreen();

            populateComboBox();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            name = txtName.Text;
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            notes = txtNotes.Text;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dob = this.dateTimePicker1.Value.Date;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //TODO Apply stego algorithm??

            if (validateInput())
            {
                AddToDetails();
                MessageBox.Show(details);

                this.Hide();
                ImageSelectionDr ImgSelect = new ImageSelectionDr();
                ImgSelect.Show();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorMenu docMenu = new DoctorMenu();
            docMenu.Show();
        }

        private void txtPatientId_TextChanged(object sender, EventArgs e)
        {
            patient_id = txtPatientId.Text;
        }

        public void AddToDetails()
        {
            details = "Name:\t" + name + "\r\nD.O.B.:\t" + dob.Date.ToShortDateString() + "\r\nNotes:\t" + notes + "\r\nStatus:\t" + status;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            status = comboBox1.SelectedItem.ToString();
        }

        private void populateComboBox()
        {
            comboBox1.Items.Add("Satisfactory");
            comboBox1.Items.Add("Follow-Up Required");
            comboBox1.Items.Add("Urgent: Contact GP");
        }

        public bool validateInput()
        {
            bool complete;

            if (notes == null || patient_id == null || status == null)
            {
                MessageBox.Show("Please complete all required fields", "Fields Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                complete = false;
            }
            else
            {
                complete = true;
            }

            return complete;
        }
    }
}
