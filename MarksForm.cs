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
    public partial class MarksForm : Form
    {
        public DataTable table = new DataTable();
        DataTable themas = new DataTable();
        public MarksForm()
        {
            InitializeComponent();
        }

        private void MarksForm_Load(object sender, EventArgs e)
        {

            this.BackColor = ColorTranslator.FromHtml("#F1E0D6");
            backButton.BackColor = ColorTranslator.FromHtml("#ABA6BF");


            DB db = new DB();
            db.openConnection();
            MySqlConnection conn = db.getConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT User.FullName, Mark.Mark, Test.TestName " +
                "FROM User " +
                "LEFT JOIN Mark On User.IdUser = Mark.IdUser" +
                " LEFT JOIN Test ON Mark.IdTest = Test.IdTest ; ", conn);           

            adapter.Fill(table);
            grid.DataSource = table;

            db.closeConnection();
           
            db.openConnection();

            MySqlConnection conn1 = db.getConnection();
            MySqlDataAdapter adapterComboBox = new MySqlDataAdapter(" Select DISTINCT Test.TestName from Test", conn1);




            adapterComboBox.Fill(themas);
            comboBox.DataSource = themas; 
         //   comboBox.ValueMember = "IdTest";//столбец с id
           comboBox.DisplayMember = "TestName";// столбец для отображения
         
           comboBox.SelectedIndex = -1;



            db.closeConnection();

           
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
          
            DB db = new DB();
            db.openConnection();
            MySqlConnection conn = db.getConnection();
            MySqlDataAdapter command = new MySqlDataAdapter("SELECT DISTINCT User.FullName, Mark.Mark, Test.TestName FROM User" +
                                                            " LEFT JOIN Mark On User.IdUser = Mark.IdUser" +
                                                             " LEFT JOIN Test ON Mark.IdTest = Test.IdTest  " +
                                                             " where User.FullName like '" +nameTextBox.Text+"%'", conn);

            DataTable table2 = new DataTable();
            table2.Clear();
            command.Fill(table2);
            grid.DataSource = table2;

        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            DB db = new DB();
            //указание определенной команд
            MySqlConnection conn = db.getConnection();
            MySqlCommand command2 = new MySqlCommand("SELECT  User.FullName, Mark.Mark, Test.TestName FROM User" +
                                                            " LEFT JOIN Mark On User.IdUser = Mark.IdUser" +
                                                             " LEFT JOIN Test ON Mark.IdTest = Test.IdTest  " +
                                                             " where Test.TestName like '" +  comboBox.Text + "%'" , conn);
            MySqlDataAdapter adapter2 = new MySqlDataAdapter();
            DataTable table3 = new DataTable();
            adapter2.SelectCommand = command2;
            table3.Clear();
            adapter2.Fill(table3);
            grid.DataSource = table3;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MenuForm menu = new MenuForm();
            menu.Show();
            this.Hide();
        }

        private void MarksForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuForm menu = new MenuForm();
            menu.Show();
        }
    }
}
