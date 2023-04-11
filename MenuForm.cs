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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#F1E0D6");
            teoryButton.BackColor = ColorTranslator.FromHtml("#ABA6BF");
            testingButton.BackColor = ColorTranslator.FromHtml("#ABA6BF");
            infoButton.BackColor = ColorTranslator.FromHtml("#ABA6BF");
            marksButton.BackColor = ColorTranslator.FromHtml("#ABA6BF");
           
        }

        private void teoryButton_Click(object sender, EventArgs e)
        {
            TeoryForm teoryForm= new TeoryForm();
            teoryForm.Show();
            this.Hide();
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            AboutProgramForm aboutProgramForm= new AboutProgramForm();
            aboutProgramForm.Show();
            this.Hide();
        }

        private void testingButton_Click(object sender, EventArgs e)
        {
            ChoiceTestForm choiceTestForm = new ChoiceTestForm();
            choiceTestForm.Show();
            this.Hide();
        }

        private void marksButton_Click(object sender, EventArgs e)
        {
            AutorizationForm autorizationForm = new AutorizationForm();
            autorizationForm.Show();
            this.Hide();
        }

        private void MenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
