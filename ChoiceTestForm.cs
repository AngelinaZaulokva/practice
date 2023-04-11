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
    public partial class ChoiceTestForm : Form
    {
       
        public ChoiceTestForm()
        {

            InitializeComponent();
            startButton.BackColor = ColorTranslator.FromHtml("#ABA6BF");
            backButton.BackColor = ColorTranslator.FromHtml("#ABA6BF");
            comboBox1.SelectedIndex = 0;
        }



        private void startButton_Click_1(object sender, EventArgs e)
        {
            DB db = new DB();
            db.openConnection();
            MySqlConnection conn = db.getConnection();
            //////////////////////////////////////////////////////////////////
            ///
            MySqlCommand search = new MySqlCommand("Select User.FullName from User  where User.FullName=@name", conn);
            search.Parameters.Add("@name", MySqlDbType.VarChar).Value = fullNameTextBox.Text;
            MySqlDataReader reader = search.ExecuteReader();
            reader.Read();
            if (fullNameTextBox.Text != "")
            {

                if (reader.HasRows == true)
                {
                    string name = reader.GetString(0);
                    db.closeConnection();
                    if (fullNameTextBox.Text == name)
                    {
                        Properties.Settings.Default.currentUser = fullNameTextBox.Text;
                        Properties.Settings.Default.Save();
                        TestForm testF = new TestForm(comboBox1.SelectedItem.ToString());
                        testF.Show();
                        this.Hide();
                    }

                }
                else
                {

                    int role = 2;
                    string query = "INSERT INTO User ( ";
                    if (!String.IsNullOrEmpty(fullNameTextBox.Text))
                    {
                        query += "FullName,";
                    }
                    query += "IdRole";

                    query += ") VALUES(";
                    if (!String.IsNullOrEmpty(fullNameTextBox.Text))
                    {
                        query += "@FullName,";
                    }
                    query += "@IdRole)";

                    db.closeConnection();
                    db.openConnection();
                    MySqlCommand command = new MySqlCommand(query, conn);

                    command.Parameters.Add("@FullName", MySqlDbType.VarChar).Value = fullNameTextBox.Text;
                    command.Parameters.Add("@IdRole", MySqlDbType.Int32).Value = role;

                    if (command.ExecuteNonQuery() == 1)
                    {
                        Properties.Settings.Default.currentUser = fullNameTextBox.Text;
                        Properties.Settings.Default.Save();
                        TestForm testF = new TestForm(comboBox1.SelectedItem.ToString());
                        testF.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка");
                    }

                }
                db.closeConnection();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите ваши данные");
            }
        }

        private void ChoiceTestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuForm menu = new MenuForm();
            menu.Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MenuForm menu = new MenuForm();
            menu.Show();
            this.Hide();
        }

        private void ChoiceTestForm_Load(object sender, EventArgs e)
        {

        }
    }
}
