using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGI
{


    public partial class FormTest : Form
    {

        TestGeniusIdiot test;
        TimerForTest timer;

        public FormTest()
        {
            InitializeComponent();
            timer = new TimerForTest(20, 50, 100);
            this.Controls.Add(timer);
            StartTest();
            timer.TimeCompleted += BreakTime;
        }

        void BreakTime(object sender, string message)
        {
            MessageBox.Show(message);
            NextQuestion();
        }

        void StartTest()
        {
            test = new TestGeniusIdiot();
            ShowQuestion();
        }

        void ShowQuestion()
        {
            labelQuestion.Text = test.NextQuestion();
            labelNumberOfQuestion.Text = "Вопрос №" + test.NumberQuestion();
            timer.Start();
        }

        public void NextQuestion()
        {
            int userAnswer = int.MinValue;
            try
            {
                userAnswer = Convert.ToInt32(textBoxUserAnswer.Text);
            }
            catch
            {
                if (textBoxUserAnswer.Text != "")
                    MessageBox.Show("В ответе может быть только число");
            }

            test.CheckAnswer(userAnswer);
            if (test.EndOfTest())
            {
                timer.Stop();
                MessageBox.Show(test.Diagnose());
                buttonNewStart.Visible = true;
            }
            else
            {
                ShowQuestion();
            }
        }

        private void buttonNextQuestion_Click(object sender, EventArgs e)
        {
            NextQuestion();
        }

        private void buttonNewStart_Click(object sender, EventArgs e)
        {
            StartTest();
        }


    }
}
