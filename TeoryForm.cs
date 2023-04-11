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
    public partial class TeoryForm : Form
    {
       
        public TeoryForm( )
        {
            InitializeComponent();
                 }
       

        private void TeoryForm_Load(object sender, EventArgs e)
        {
           
            this.BackColor = ColorTranslator.FromHtml("#F1E0D6");
            infoRichTextBox.LoadFile("intro.rtf", RichTextBoxStreamType.RichText);
            introButton.BackColor = ColorTranslator.FromHtml("#ABA6BF");
            firstFormButton.BackColor = ColorTranslator.FromHtml("#ABA6BF");
            secondFormButton.BackColor = ColorTranslator.FromHtml("#ABA6BF");
            thirdFormButton.BackColor = ColorTranslator.FromHtml("#ABA6BF");
            bknfFormButton.BackColor = ColorTranslator.FromHtml("#ABA6BF");
            fourthFormButton.BackColor = ColorTranslator.FromHtml("#ABA6BF");
            fifthFormButton.BackColor = ColorTranslator.FromHtml("#ABA6BF");
            dknfButton.BackColor = ColorTranslator.FromHtml("#ABA6BF");
            sixthFormButton.BackColor = ColorTranslator.FromHtml("#ABA6BF");
            testingButton.BackColor = ColorTranslator.FromHtml("#ABA6BF");
            backButton.BackColor = ColorTranslator.FromHtml("#ABA6BF");
        }

        private void introButton_Click(object sender, EventArgs e)
        {
            infoRichTextBox.LoadFile("intro.rtf", RichTextBoxStreamType.RichText);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MenuForm menu = new MenuForm();
            menu.Show();
            this.Hide();
        }

        private void firstFormButton_Click(object sender, EventArgs e)
        {
            infoRichTextBox.LoadFile("1nf.rtf", RichTextBoxStreamType.RichText);
        }

        private void secondFormButton_Click(object sender, EventArgs e)
        {
            infoRichTextBox.LoadFile("2nf.rtf", RichTextBoxStreamType.RichText);

        }

        private void thirdFormButton_Click(object sender, EventArgs e)
        {
            infoRichTextBox.LoadFile("3nf.rtf", RichTextBoxStreamType.RichText);

        }

        private void bknfFormButton_Click(object sender, EventArgs e)
        {
            infoRichTextBox.LoadFile("bknf.rtf", RichTextBoxStreamType.RichText);

        }

        private void fourthFormButton_Click(object sender, EventArgs e)
        {
            infoRichTextBox.LoadFile("4nf.rtf", RichTextBoxStreamType.RichText);

        }

        private void fifthFormButton_Click(object sender, EventArgs e)
        {
            infoRichTextBox.LoadFile("5nf.rtf", RichTextBoxStreamType.RichText);

        }

        private void sixthFormButton_Click(object sender, EventArgs e)
        {
            infoRichTextBox.LoadFile("6nf.rtf", RichTextBoxStreamType.RichText);

        }

        private void testingButton_Click(object sender, EventArgs e)
        {
            ChoiceTestForm choiceTestForm = new ChoiceTestForm();
            choiceTestForm.Show();
            this.Hide();
        }

        private void dknfButton_Click(object sender, EventArgs e)
        {
            infoRichTextBox.LoadFile("dknf.rtf", RichTextBoxStreamType.RichText);
        }

        private void TeoryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuForm menu = new MenuForm();
            menu.Show();
        }
    }
}
