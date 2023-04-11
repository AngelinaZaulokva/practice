using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPoject
{
    public partial class AutorizationForm : Form
    {
        public string role;
        public string login;
        public string password;
        public AutorizationForm()
        {
            InitializeComponent();
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            if (loginTextBox.Text == "" || passwordTextBox.Text == "")
            {
                MessageBox.Show("Введите корректные данные");
            }
            else
            {

                DB db = new DB();
                db.openConnection();
                MySqlConnection conn = db.getConnection();
                MySqlCommand command = new MySqlCommand("Select login,password,idRole from User  where login=@Login  and password=@Password", conn);
                command.Parameters.Add("@Login", MySqlDbType.VarChar).Value = loginTextBox.Text;
                command.Parameters.Add("@Password", MySqlDbType.VarChar).Value = passwordTextBox.Text;

                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {

                    login = reader.GetString(0);
                    password = reader.GetString(1);
                    role = reader.GetString(2);
                    if (role == "1")
                    {
                        MarksForm form = new MarksForm();
                        form.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Недостаточно прав доступа");
                }
                db.closeConnection();

            }
        }

        private void AutorizationForm_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#F1E0D6");
            enterButton.BackColor = ColorTranslator.FromHtml("#ABA6BF");
            passwordTextBox.UseSystemPasswordChar = true;
        }

        private void AutorizationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuForm menu = new MenuForm();
            menu.Show();
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                passwordTextBox.UseSystemPasswordChar =false;
            }
            else
            {
                passwordTextBox.UseSystemPasswordChar=true;
            }
        }
    }
}

