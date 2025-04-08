using System.Drawing;
using System.Windows.Forms;

namespace TestGI
{
    public class TimerForTest : Label
    {
        int timeTotal;
        int timeCurrent;
        Timer timer;

        public TimerForTest(int time, int x, int y)
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
