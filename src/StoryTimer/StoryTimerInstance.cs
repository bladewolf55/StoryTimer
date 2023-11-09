using System;
using System.Drawing;
using System.Windows.Forms;

namespace StoryTimer
{
    public class StoryTimerInstance
    {
        Color timerStoppedBackground = Color.FromArgb(64, 64, 64);
        Color timerStoppedForeground = Color.Orange;


        public event EventHandler<TimerEventArgs> TimerStarted;
        public event EventHandler<TimerEventArgs> TimerTicked;
        protected virtual void OnTimerStarted()
        {
            TimerEventArgs e = new TimerEventArgs() { Id = this.Id };
            EventHandler<TimerEventArgs> handler = TimerStarted;
            handler?.Invoke(this, e);
        }

        protected virtual void OnTimerTicked()
        {
            TimerEventArgs e = new TimerEventArgs() { Id = this.Id };
            EventHandler<TimerEventArgs> handler = TimerTicked;
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
            Title.TextChanged += Timer_TitleChanged;
            ElapsedTime.TextChanged += Timer_TimeChanged;
        }

        private void Timer_TitleChanged(object sender, EventArgs e)
        {
            OnTimerTicked();
        }

        //TODO: This doesn't fire if text is set during Main Form's ctor.
        private void Timer_TimeChanged(object sender, EventArgs e)
        {
            // may not be a valid time yet. Swallow errors
            try
            {
                TimeSpan ts = TimeSpan.Parse(ElapsedTime.Text);
                ElapsedSeconds = (int)ts.TotalSeconds;
            }
            catch { }
            OnTimerTicked();
        }

        //TODO: Encapsulate this with event
        public void SetElapsedTime(string time)
        {
            // may not be a valid time yet. Swallow errors
            ElapsedTime.Text = time;
            try
            {
                TimeSpan ts = TimeSpan.Parse(ElapsedTime.Text);
                ElapsedSeconds = (int)ts.TotalSeconds;
            }
            catch { }
            OnTimerTicked();

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
            UpdateStartButtonAndTime();
            OnTimerStarted();
        }

        /// <summary>
        /// Stops the timer and sets the button color. Use this instead of Timer.Stop().
        /// </summary>
        public void Stop()
        {
            Timer.Stop();
            UpdateStartButtonAndTime();
        }

        /// <summary>
        /// Stops and resets the timer to zero and sets the button color. Use this instead of Timer.Reset();
        /// </summary>
        public void StopAndReset()
        {
            Timer.Stop();
            ElapsedSeconds = 0;
            UpdateElapsedTime();
            UpdateStartButtonAndTime();
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
            elapsedTime.Anchor = ElapsedTime.Anchor;
            panel.Controls.Add(elapsedTime);

            StoryTimerInstance clone = new StoryTimerInstance(id, panel);
            clone.Timer.Tag = id;
            return clone;
        }

        public double GetElapsedTimeToQuarter()
        {
            var ts = new TimeSpan(0, 0, ElapsedSeconds);
            double hours = ts.Hours;
            double min = ts.Minutes;
            min = (Math.Round(min / 15) / 4);
            return hours + min;
        }

        public void UpdateStartButtonAndTime()
        {
            if (Timer.Enabled)
            {
                StartPause.BackColor = timerStoppedBackground;
                StartPause.ForeColor = timerStoppedForeground;
                ElapsedTime.BackColor = timerStoppedBackground;
                ElapsedTime.ForeColor = timerStoppedForeground;
            }
            else
            {
                StartPause.BackColor = Reset.BackColor;
                StartPause.ForeColor = Reset.ForeColor;
                ElapsedTime.BackColor = Reset.BackColor;
                ElapsedTime.ForeColor = Reset.ForeColor;
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Timer.Stop();
            ElapsedSeconds = 0;
            UpdateElapsedTime();
            UpdateStartButtonAndTime();
        }

        private void PlayPause_Click(object sender, EventArgs e)
        {
            SetElapsedSecondsToDisplayedTime();
            Timer.Enabled = !Timer.Enabled;
            UpdateElapsedTime();
            UpdateStartButtonAndTime();
            if (Timer.Enabled)
            {
                OnTimerStarted();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ElapsedSeconds += 1;
            UpdateElapsedTime();
            OnTimerTicked();
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
            ElapsedTime.Text = " " + TimeSpan.FromSeconds(ElapsedSeconds).ToString(MainForm.TimerFormat);
        }


    }
}
