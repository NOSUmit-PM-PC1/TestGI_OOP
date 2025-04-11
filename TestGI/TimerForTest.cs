using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestGI
{
    public class TimerForTest : Label
    {
        int timeTotal;
        int timeCurrent;
        Timer timer;
        FormTest f;
        //public event EventHandler<string> WorkCompleted;

        public TimerForTest(int time, int x, int y, FormTest f)
        {
            this.timeTotal = time;
            this.Text = time.ToString();
            this.Font = new System.Drawing.Font("Arial", 20);
            this.BackColor = SystemColors.ActiveCaption;
            this.Width = timeTotal.ToString().Length * 40;
            this.Height = 50;
            this.Top = y;
            this.Left = x;
            this.TextAlign = ContentAlignment.MiddleCenter;
            timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 1000;
            this.f = f;
        }

        public void Start()
        {
            timeCurrent = timeTotal;
            timer.Enabled = true;
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            if (timeCurrent == 0)
            {
                timer.Enabled = false;
                //WorkCompleted?.Invoke(this, "Время закончилось!");
                MessageBox.Show("Время закончилось!");
                f.NextQuestion(); 
                return;
            }
            Tick();
        }

        private void Tick()
        {
            this.Text = timeCurrent.ToString();
            timeCurrent--;
        }
    }
}
