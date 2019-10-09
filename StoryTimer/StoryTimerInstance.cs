using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoryTimer
{
    public class StoryTimerInstance
    {
        public event EventHandler<TimerEventArgs> TimerStarted;
        protected virtual void OnTimerStarted()
        {
            TimerEventArgs e = new TimerEventArgs() { Id = this.Id };
            EventHandler<TimerEventArgs> handler = TimerStarted;
            handler?.Invoke(this, e);
        }

        public int Id { get; set; }
        public Panel Panel { get; set; } = new Panel();
        public TextBox Title { get { return GetPanelControl("textBoxTitle") as TextBox; } }
        public Button StartPause { get { return GetPanelControl("buttonStartPause") as Button; } }
        public Button Reset { get { return GetPanelControl("buttonReset") as Button; } }
        public RichTextBox ElapsedTime { get { return GetPanelControl("richTextBoxElapsedTime") as RichTextBox; } }
        public System.Windows.Forms.Timer Timer { get; set; } = new System.Windows.Forms.Timer();
        public int ElapsedSeconds { get; set; }

        public StoryTimerInstance(int id, Panel panel)
        {
            Id = id;
            Panel = panel;
            Timer.Interval = 1000;
            Timer.Tick += Timer_Tick;
            StartPause.Click += PlayPause_Click;
            Reset.Click += Reset_Click;
        }

        private object GetPanelControl(string key)
        {
            try
            {
                return Panel.Controls[key];
            }
            catch { return null; }
        }

        /// <summary>
        /// Starts the timer and sets the button color. Use this instead
        /// of Timer.Start
        /// </summary>
        public void Start()
        {
            Timer.Start();
            SetElapsedSecondsToDisplayedTime();
            UpdateStartButton();
            OnTimerStarted();
        }

        /// <summary>
        /// Stops the timer and sets the button color. Use this instead of Timer.Stop().
        /// </summary>
        public void Stop()
        {
            Timer.Stop();
            UpdateStartButton();
        }

        /// <summary>
        /// Stops and resets the timer to zero and sets the button color. Use this instead of Timer.Reset();
        /// </summary>
        public void StopAndReset()
        {
            Timer.Stop();
            ElapsedSeconds = 0;
            UpdateElapsedTime();
            UpdateStartButton();
        }

        public void UpdateStartButton()
        {
            if (Timer.Enabled)
            {
                StartPause.BackColor = ElapsedTime.BackColor;
                StartPause.ForeColor = ElapsedTime.ForeColor;
            }
            else
            {
                StartPause.BackColor = Reset.BackColor;
                StartPause.ForeColor = Reset.ForeColor;
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Timer.Stop();
            ElapsedSeconds = 0;
            UpdateElapsedTime();
            UpdateStartButton();
        }

        private void PlayPause_Click(object sender, EventArgs e)
        {
            SetElapsedSecondsToDisplayedTime();
            Timer.Enabled = !Timer.Enabled;
            UpdateElapsedTime();
            UpdateStartButton();
            if (Timer.Enabled)
            {
                OnTimerStarted();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ElapsedSeconds += 1;
            UpdateElapsedTime();
        }

        private void SetElapsedSecondsToDisplayedTime()
        {
            //Set calling timer's ElapsedSeconds to its displayed time
            TimeSpan time;
            if (TimeSpan.TryParse(ElapsedTime.Text, out time))
            {
                ElapsedSeconds = (int)time.TotalSeconds;
            }
        }
        private void UpdateElapsedTime()
        {
            ElapsedTime.Text = " " + TimeSpan.FromSeconds(ElapsedSeconds).ToString(@"h\:mm\:ss");
        }

        public StoryTimerInstance Clone(int id, int top)
        {
            Panel panel = new Panel();
            panel.Name = "panel" + id;
            panel.Top = top;
            panel.Width = Panel.Width;
            panel.Height = Panel.Height;
            panel.Left = Panel.Left;
            panel.Anchor = Panel.Anchor;

            TextBox title = new TextBox();
            title.Name = Title.Name;
            title.Location = Title.Location;
            title.Width = Title.Width;
            title.Height = Title.Height;
            title.Anchor = Title.Anchor;
            panel.Controls.Add(title);

            Button startPause = new Button();
            startPause.Name = StartPause.Name;
            startPause.Location = StartPause.Location;
            startPause.Width = StartPause.Width;
            startPause.Height = StartPause.Height;
            startPause.Font = StartPause.Font;
            startPause.Text = StartPause.Text;
            panel.Controls.Add(startPause);

            Button reset = new Button();
            reset.Name = Reset.Name;
            reset.Location = Reset.Location;
            reset.Width = Reset.Width;
            reset.Height = Reset.Height;
            reset.Font = Reset.Font;
            reset.Text = Reset.Text;
            panel.Controls.Add(reset);

            RichTextBox elapsedTime = new RichTextBox();
            elapsedTime.Name = ElapsedTime.Name;
            elapsedTime.Location = ElapsedTime.Location;
            elapsedTime.Width = ElapsedTime.Width;
            elapsedTime.Height = ElapsedTime.Height;
            elapsedTime.Font = ElapsedTime.Font;
            elapsedTime.ScrollBars = ElapsedTime.ScrollBars;
            elapsedTime.BorderStyle = ElapsedTime.BorderStyle;
            elapsedTime.BackColor = ElapsedTime.BackColor;
            elapsedTime.ForeColor = ElapsedTime.ForeColor;
            elapsedTime.Text = " 0:00:00";
            panel.Controls.Add(elapsedTime);

            StoryTimerInstance clone = new StoryTimerInstance(id, panel);
            clone.Timer.Tag = id;
            return clone;
        }

    }
}
