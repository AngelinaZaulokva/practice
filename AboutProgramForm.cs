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
    public partial class AboutProgramForm : Form
    {
      
        public AboutProgramForm()
        {
            InitializeComponent();
        }

        private void AboutProgramForm_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#F1E0D6");
            backButton.BackColor = ColorTranslator.FromHtml("#ABA6BF");

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MenuForm menu = new MenuForm();
            menu.Show();
            this.Close();
        }
    }
}
