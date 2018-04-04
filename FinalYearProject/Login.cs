using FinalYearProject.PatientView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FinalYearProject
{
    public partial class Login : Form
    {
        public static string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Uni\\Final Year\\Final Year Project\\Final Year Project\\Visual Studio\\FinalYearProject\\LoginDB.mdf;Integrated Security=True;Connect Timeout=30";

        public static string username;

        public Login()
        {
            InitializeComponent();
            this.Text = "StegoMed";

            this.CenterToScreen();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void loginDoctor()
        {
            //Query database for credentials
            SqlConnection sqlConn = new SqlConnection(ConnectionString);
            SqlCommand sqlCmd = new SqlCommand("SELECT PASSWORD from DoctorTable where USER_ID='" + txtUsername.Text + "'", sqlConn);
            sqlCmd.Parameters.AddWithValue("@USER_ID", txtUsername.Text);
            sqlConn.Open();
            SqlDataReader reader = sqlCmd.ExecuteReader();
            reader.Read();

            if (reader.HasRows == true)
            {
                if (reader[0].ToString() == txtPassword.Text)
                {
                    //Redirtect user to the doctor menu
                    this.Hide();
                    DoctorMenu DocMenu = new DoctorMenu();
                    DocMenu.Show();
                }
                else
                {
                    MessageBox.Show("Password is incorrect", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("User does not exist", "Invalid Credentials!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            sqlConn.Close();
        }

        private void loginPatient()
        {
            //Query database for credentials
            SqlConnection sqlConn = new SqlConnection(ConnectionString);
            SqlCommand sqlCmd = new SqlCommand("SELECT PASSWORD from PatientTable where USER_ID='" + txtUsername.Text + "'", sqlConn);
            sqlCmd.Parameters.AddWithValue("@USER_ID", txtUsername.Text);
            sqlConn.Open();
            SqlDataReader reader = sqlCmd.ExecuteReader();
            reader.Read();

            if (reader.HasRows == true)
            {
                if (reader[0].ToString() == txtPassword.Text)
                {
                    //Redirtect user to the patient menu
                    this.Hide();
                    PatientMenu PatientMenu = new PatientMenu();
                    PatientMenu.Show();
                }
                else
                {
                    MessageBox.Show("Password is incorrect", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("User does not exist", "Invalid Credentials!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            sqlConn.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtUsername.Text == "" && txtPassword.Text == "") //Error when textboxes are empty
            {
                MessageBox.Show("Please enter a Username and Password", "Error Message!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtUsername.Text == "") //Error when username is not entered
            {
                MessageBox.Show("Please enter a Username", "Error Message!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPassword.Text == "") //Error when password is not entered
            {
                MessageBox.Show("Please enter a Password", "Error Message!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtUsername.Text.Contains("DR"))
            {
                loginDoctor();
            }
            else if (txtUsername.Text.Contains("PA"))
            {
                loginPatient();
            }
            else
            {
                MessageBox.Show("Please enter a valid username", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            username = txtUsername.Text;
        }
    }
}
