﻿using SKU_Manager.MainForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SKU_Manager
{
    /*
     * The main entry of the application -> login board
     */
    public partial class Login : Form
    {
        // boolean flag that determine if the program need to remember user input
        private bool remember = Properties.Settings.Default.Remember;

        public Login()
        {
            InitializeComponent();

            if (!remember) return;

            usernameTextbox.Text = Properties.Settings.Default.Username;
            passwordTextbox.Text = Properties.Settings.Default.Password;
            rememberCheckbox.Checked = true;
        }

        /* sign in button event that check if the user put in right credentials */
        private void signInButton_Click(object sender, EventArgs e)
        {
            // set invalid log on indicator to invisible
            invalidLabel.Visible = false;

            // get username and password
            string userName = usernameTextbox.Text.Trim();
            string password = passwordTextbox.Text;

            // error check
            if (userName == "" || password == "")
            {
                MessageBox.Show("Please enter Username and Password please", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // initialize connection string
            string[] connectionString = 
            {
                "Data Source=kpjvpp867r.database.windows.net;Initial Catalog=Design_Database;Integrated Security=False;User ID=" + userName + ";Password=" + password + ";Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;MultipleActiveResultSets=true;",
                "Data Source=kpjvpp867r.database.windows.net;Initial Catalog=ChannelPartner_Database;Integrated Security=False;User ID=" + userName + ";Password=" + password + ";Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;"
            };

            SqlConnection[] connection ={ new SqlConnection(connectionString[0]), new SqlConnection(connectionString[1]) };

            // if connections are true -> open sku manager
            if (IsConnected(connection[0]) && IsConnected(connection[1]))
            {
                // properties saving
                Properties.Settings.Default.Designcs = connectionString[0];
                Properties.Settings.Default.ASCMcs = connectionString[1];
                Properties.Settings.Default.Username = userName;
                Properties.Settings.Default.Password = password;

                Hide();
                new dashboard(this).Show();
            }
            else
                invalidLabel.Visible = true;

            Properties.Settings.Default.Remember = remember;
        }

        /* a supporting method that see if the connection is valid or not */
        private static bool IsConnected(IDbConnection connection)
        {
            try
            {
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /* rememeber me checkbox event that determine if the program has to remember the credentials */
        private void rememberCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            remember = rememberCheckbox.Checked;
        }
    }
}
