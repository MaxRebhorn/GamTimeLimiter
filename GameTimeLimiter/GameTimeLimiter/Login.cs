using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Configuration;

namespace GameTimeLimiter
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            string role = (string)comboBox1.SelectedItem; // Use your actual ComboBox's name
            string password = password_input.Text; // Updated here to match your TextBox's name

            var usersData = JsonConvert.DeserializeObject<UserData>(
                File.ReadAllText(ConfigurationManager.AppSettings["UserDataPath"]));

            LoginUser user = role == "admin" ? usersData.User : usersData.Admin;
            if (user.Password == password)
            {
                this.Hide();
                Home homeForm = new Home();
                homeForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid login attempt.");
            }
        }
    }


    public class LoginUser
    {
        public string Password { get; set; }
        public string DailyTimeLimit { get; set; } // Only applicable for 'user'
    }

    public class UserData
    {
        public LoginUser Admin { get; set; }
        public LoginUser User { get; set; }
    }
}