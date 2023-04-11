using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace KPoject
{
    public partial class TestForm : Form
    {

       
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        private void TextBoxGotFocus()
        {
            HideCaret(richTextBox1.Handle);
        }
        

        int i = 0;
        int time = 0;
        int idTheme = 0;
        Tests tests2 = LoadTests("test.xml");
        string answer;
        float rightAnswer = 0;
        string currentAnswer;
        int count = 10;

        [XmlRoot("root")]
        public class Tests
        {
            [XmlArray("tests")]
            [XmlArrayItem("test")]
            public Test[] Data { get; set; }
        }

        public class Test
        {
            [XmlAttribute("name")]
            public string Name { get; set; }
            [XmlArray("questions")]
            [XmlArrayItem("question")]
            public Question[] Questions { get; set; }
        }

        public void Check()
        {
            Test currentTest = tests2.Data[idTheme];
            Question currentQuestion = currentTest.Questions[i];
            if (currentQuestion.TypeQuestion == "1")
            {
                foreach (RadioButton rb in richTextBox1.Controls)
                {
                    if (rb.Checked)
                    {
                        answer = rb.Text;
                    }
                }
                if (answer == currentQuestion.CorrectAnswer.ToString())
                {
                    rightAnswer++;
                }
                answer = "";
            }
            else if (currentQuestion.TypeQuestion == "2")
            {
                currentAnswer = currentQuestion.CorrectAnswer.ToString();
                foreach (CheckBox chbd in richTextBox1.Controls)
                {
                    if (chbd.Checked)
                    {
                        try
                        {
                            currentAnswer = currentAnswer.Replace(chbd.Text, "");

                        }
                        catch
                        {
                            Exception ex;
                        }
                    }
                }
                if (currentAnswer == "")
                {
                    rightAnswer++;
                }
                currentAnswer = "";
            }
            else if (currentQuestion.TypeQuestion == "3")
            {
                foreach (TextBox tb in richTextBox1.Controls)
                {
                    
                    if (tb.Text.ToLower() == currentQuestion.CorrectAnswer.ToLower().ToString())
                    {
                        rightAnswer++;
                    }
                }
            }
        }


        public void Mark(float rightAnswer, int count)
        {
            timer2.Stop();
            timer2.Dispose();
            float mark = rightAnswer / count * 100;
            string message;
            int m;
            if (mark > 86)
            {
                message = "Ваша оценка 5";
                m = 5;
            }
            else if (76 <= mark && mark <= 85)
            {
                message = "Ваша оценка 4";
                m = 4;

            }
            else if (61 <= mark && mark <= 75)
            {
                message = "Ваша оценка 3";
                m = 3;
            }
            else
            {
                message = "Оценка: 2 \n Тест провален!";
                m = 2;
            }

            ////////////////////////////////////////////////////////////////////////////
            DB db = new DB();
            db.openConnection();
            MySqlConnection conn = db.getConnection();

            MySqlCommand commandId = new MySqlCommand("Select IdUser from User  where (FullName=@FullName)", conn);
            commandId.Parameters.Add("@FullName", MySqlDbType.VarChar).Value = Properties.Settings.Default.currentUser;
            MySqlDataReader reader = commandId.ExecuteReader();
            reader.Read();
            string userId = reader.GetString(0);

            int currentTheme = idTheme + 1;

            string query = $"INSERT INTO Mark (IdUser,IdTest,Mark) VALUES({userId},{currentTheme},{m}) ";
            db.closeConnection();
            db.openConnection();


            MySqlCommand commandInsert = new MySqlCommand(query, conn);       
           
            if (commandInsert.ExecuteNonQuery() == 1)
            {
                MessageBox.Show(message);
                
            }
            db.closeConnection();

            //////////////////////////////////////////////////////////////////////////////////////////////

            this.Close();
        }

        public class Question
        {
            [XmlElement("text")]
            public string Text { get; set; }
            [XmlArray("answers")]
            [XmlArrayItem("answer")]
            public string[] Answers { get; set; }
            [XmlAttribute("correct_answer")]
            public string CorrectAnswer { get; set; }
            [XmlAttribute("type_question")]
            public string TypeQuestion { get; set; }
        }

        public static void Shuffle<T>(T[] arr)
        {
            Random random = new Random();
            for (int i = arr.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                T tmp = arr[j];
                arr[j] = arr[i];
                arr[i] = tmp;
            }
        }
  
        private static Tests LoadTests(string fileName)
        {        
            StreamReader sr = new StreamReader(fileName);
            XmlSerializer serializer = new XmlSerializer(typeof(Tests));
            return (Tests)serializer.Deserialize(sr);
        }


        private void timerTick(object sender, EventArgs e)
        {
            if (time == 0)
            {
                timer2.Stop();
                timer2.Dispose();
                Check();
                nextQuestions();
            }
            else
            {
                timer.Text = " Осталось " + time.ToString() + " сек";
                time--;
            }
        }

        public TestForm( string selected)
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#F1E0D6");
            nextButton.BackColor = ColorTranslator.FromHtml("#ABA6BF");
           
            XmlDocument xml = new XmlDocument();
            xml.Load(@"test.xml");
            switch (selected)
            {
                case "Нормализация базы данных.Основные понятия.":
                    idTheme = 0;
                    break;
                case "Нормализация базы данных.Работа с нормальными формами.":
                    idTheme = 1;
                    break;
            }
        }

        private void nextQuestions()
        {
            i++;
            timer.Text = "";
            Test currentTest = tests2.Data[idTheme];
            if (i < 9)
            {
                GenerationQuestions(i, currentTest);
            }
            else
            {
                Mark(rightAnswer, count);
            }

        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            Test currentTest = tests2.Data[idTheme];
            Shuffle(currentTest.Questions);
            GenerationQuestions(0, currentTest);
        }

        private void nextQuestionButtonOnClick(object sender, EventArgs e)
        {
          
            if (i == 8)
                nextButton.Text = "Завершить тест";

            if (i == 9)
            {
                Check();
                Mark(rightAnswer, count);
            }
            else
            {
                timer.Text = "";
                timer2.Stop();
                timer2.Dispose();

                Test currentTest = tests2.Data[idTheme];
                Question currentQuestion = currentTest.Questions[i];
                Check();
                i++;
                GenerationQuestions(i, currentTest);
            }
        }

        private void GenerationQuestions(int i, Test currentTest)
        {
            Question currentQuestion = currentTest.Questions[i];


            richTextBox1.Controls.Clear();
            string text = currentQuestion.Text;
            label3.Font = new Font("Times New Roman", 14F);
            label3.Text = "Вопрос: " + (i + 1) + " из 10 " + "\n" + text;
            if (currentQuestion.TypeQuestion == "1")
            {
                time = 30;
                string[] answers = currentQuestion.Answers ?? Array.Empty<string>();
                Shuffle(answers);
                for (int j = 0; j < currentQuestion.Answers.Length; j++)
                {
                    RadioButton radioButton = new RadioButton();
                    radioButton.Font = new System.Drawing.Font("Times New Roman", 14F);
                    radioButton.Name = $"radioButton " + j;
                    radioButton.AutoSize = true;
                    radioButton.Location = new Point(10, 25 + j * 100);
                    radioButton.Text = currentQuestion.Answers[j];
                    richTextBox1.Controls.Add(radioButton);
                }
            }
            else if (currentQuestion.TypeQuestion == "2")
            {
                time = 60;
                string[] answers = currentQuestion.Answers ?? Array.Empty<string>();
                Shuffle(answers);
                for (int j = 0; j < currentQuestion.Answers.Length; j++)
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.Font = new System.Drawing.Font("Times New Roman", 14F);
                    checkBox.Name = $"checkBox " + j;
                    checkBox.AutoSize = true;
                    checkBox.Location = new Point(10, 15 + j * 65);
                    checkBox.Text = currentQuestion.Answers[j];
                    richTextBox1.Controls.Add(checkBox);
                }
            }
            else if (currentQuestion.TypeQuestion == "3")
            {
                time = 90;
                string[] answers = currentQuestion.Answers ?? Array.Empty<string>();
                Shuffle(answers);
                TextBox textBox = new TextBox();                
                textBox.Font = new System.Drawing.Font("Times New Roman", 14F);                
                textBox.Name = "textbox1";
                textBox.Location = new Point(10, 10);
                textBox.Width = 550;
                richTextBox1.Controls.Add(textBox);
            }
            timer2 = new Timer();
            timer2.Interval = 1000;
            timer2.Tick += new EventHandler(timerTick);
            timer2.Enabled = true;
        }


        private void CheckOnEmpty(object sender, EventArgs e)
        {
            TextBoxGotFocus();
            int a = 0;
            {
                Test currentTest = tests2.Data[idTheme];
                Question currentQuestion = currentTest.Questions[i];
                if (currentQuestion.TypeQuestion == "1")
                {
                    foreach (RadioButton rb in richTextBox1.Controls)
                    {
                        if (rb.Checked)
                        {
                            a++;
                        }
                        if (a != 0)
                        {
                            nextButton.Enabled = true;
                        }
                        else
                        {
                            nextButton.Enabled = false;
                        }

                    }
                }
                else if (currentQuestion.TypeQuestion == "2")
                {
                    currentAnswer = currentQuestion.CorrectAnswer.ToString();
                    foreach (CheckBox chbd in richTextBox1.Controls)
                    {
                        if (chbd.Checked)
                        {
                            a++;
                        }
                        if (a > 0)
                        {
                            nextButton.Enabled = true;
                        }
                        else
                        {
                            nextButton.Enabled = false;
                        }
                    }
                }
                else if (currentQuestion.TypeQuestion == "3")
                {
                    foreach (TextBox tb in richTextBox1.Controls)
                    {
                        if (tb.Text != "")
                        {
                            nextButton.Enabled = true;
                        }
                        else
                        {
                            nextButton.Enabled = false;
                        }
                    }
                }
            }
        }

        private void TestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ChoiceTestForm ctf = new ChoiceTestForm();
            ctf.Show();
        }
    }
}
