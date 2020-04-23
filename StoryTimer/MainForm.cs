using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace StoryTimer
{
    public partial class MainForm : Form
    {
        List<StoryTimerInstance> _storyTimers = new List<StoryTimerInstance>();
        System.Timers.Timer _statusTimer = new System.Timers.Timer();
        Size _defaultSize;
        Settings _settings;

        public MainForm()
        {
            InitializeComponent();
            InitializeSettings();
            InitializeTimers();
            InitializeStatusTimer();
            SetStatusToHelpText();
        }

        // Do this after the form is loaded so its size is available.
        private void InitializeSettings()
        {
            _settings = new SettingsManager().Settings;
        }

        private void InitializeTimers()
        {
            _defaultSize = this.Size;
            StartPosition = FormStartPosition.Manual;
            Left = _settings.WindowPosX;
            Top = _settings.WindowPosY;
            panel.Visible = false;
            Width = _settings.WindowWidth;
            Height = Height - panel.Height;
            checkBox1.Checked = true;
            StoryTimerInstance storyTimer = new StoryTimerInstance(_storyTimers.Count, panel);
            storyTimer.TimerStarted += StoryTimer_TimerStarted;
            storyTimer.TimerTicked += StoryTimer_TimerTicked;
            _storyTimers.Add(storyTimer);

        }

        private void InitializeStatusTimer()
        {
            _statusTimer.Interval = 5000;
            _statusTimer.Elapsed += StatusTimer_Elapsed;
        }

        private void ResetAll()
        {
            //remove timers
            foreach (var timer in _storyTimers.Where(a => a.Id > 0).ToList())
            {
                var remove = timer;
                remove.StopAndReset();
                remove.Timer.Dispose();
                _storyTimers.Remove(remove);
            }
            List<Panel> panelsToRemove = new List<Panel>();
            foreach (Control control in this.Controls)
            {
                if (control is Panel && control.Name != "panel")
                {
                    panelsToRemove.Add(control as Panel);
                }
            }
            panelsToRemove.ForEach(panel => Controls.Remove(panel));

            panel.Visible = false;
            checkBox1.Checked = true;
            _storyTimers.First().StopAndReset();
            Size = _defaultSize;
            this.Height = this.Height - panel.Height;
        }

        private StoryTimerInstance AddNewTimer(string title, string elapsedTime = " 0:00:00", bool doNotStart = false)
        {
            StoryTimerInstance lastTimer = _storyTimers.Last();
            Panel lastPanel = lastTimer.Panel;
            StoryTimerInstance newTimer = null;
            if (!lastPanel.Visible)
            {
                //use the hidden first panel
                newTimer = lastTimer;
                this.Height = this.Height + newTimer.Panel.Height;
                lastPanel.Visible = true;
            }
            else
            {
                //new
                int id = _storyTimers.Count;
                int top = lastPanel.Bottom + 10;
                newTimer = lastTimer.Clone(id, top);
                _storyTimers.Add(newTimer);
                this.Height = this.Height + lastTimer.Panel.Height + 10;
                this.Controls.Add(newTimer.Panel);
                newTimer.TimerStarted += StoryTimer_TimerStarted;
                newTimer.TimerTicked += StoryTimer_TimerTicked;
            }
            //Prevents all timers showing as started when pasting a list into 
            //a new StoryTimer instance.
            newTimer.StopAndReset();
            newTimer.Title.Text = title;
            newTimer.ElapsedTime.Text = elapsedTime;
            if (!doNotStart) { newTimer.Start(); }
            return newTimer;
        }

        private void CopyAll()
        {
            string info = GetTimersInfo();
            Clipboard.SetText(info, TextDataFormat.Text);
            WriteStatus("All timers saved to clipboard");
        }

        private string GetTimersInfo()
        {
            string info = "";
            foreach (var timer in _storyTimers)
            {
                info += $"{timer.ElapsedTime.Text.Trim()}  {timer.Title.Text.Trim()}{Environment.NewLine}";
            }
            return info;
        }

        private void PasteAll()
        {
            string text = Clipboard.GetText(TextDataFormat.Text);
            if (String.IsNullOrWhiteSpace(text))
            {
                WriteStatus("No timer text in clipboard");
            }
            string[] lines = text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var timers = lines.Select(a =>
            {
                try
                {
                    var timer = a.Trim();
                    int index = timer.IndexOf(" ");
                    string elapsedTime = timer.Substring(0, index);
                    string title = timer.Substring(index + 1);
                    return new { elapsedTime, title };
                }
                catch { return new { elapsedTime = "", title = "" }; }
            });
            foreach (var timer in timers.Where(a => !String.IsNullOrWhiteSpace(a.elapsedTime)))
            {
                try
                {
                    AddNewTimer(timer.title, timer.elapsedTime, true);
                }
                catch { }
            }
            WriteStatus("All possible timers restored");
        }

        private void SetStatusToHelpText()
        {
            toolStripStatusLabel1.Text = "Ctrl+? = Help";
        }

        private void WriteStatus(string msg)
        {
            toolStripStatusLabel1.Text = msg;
            _statusTimer.Start();
        }

        #region "Controls"
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Shift | Keys.C))
            {
                CopyAll();
                return true;
            }
            if (keyData == (Keys.Control | Keys.Shift | Keys.V))
            {
                PasteAll();
                return true;
            }
            if (keyData == (Keys.Control | Keys.OemQuestion))
            {
                string help = @"Exclusive unchecked = allow simultaneous timing.

Ctrl+Shift+C to copy all timers
Ctrl+Shift+V to add timers from text

Timer text must be in form [time] [title], e.g. 
1:23:45 My First Timer
0:01:03 My Second Timer
";
                MessageBox.Show(help, "Story Timer - " + Application.ProductVersion);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region "Events"

        private void ButtonResetAll_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void StatusTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _statusTimer.Stop();
            SetStatusToHelpText();
        }

        private void StoryTimer_TimerStarted(object sender, TimerEventArgs e)
        {
            if (!checkBox1.Checked) return;
            //Loop through and stop timers except the one started
            foreach (var storyTimer in _storyTimers)
            {
                if (storyTimer.Id != e.Id)
                {
                    storyTimer.Stop();
                }
            }
        }

        private void StoryTimer_TimerTicked(object sender, TimerEventArgs e)
        {
            File.WriteAllText(_settings.SaveFolderPath, GetTimersInfo());
        }

        private void TextBoxNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddNewTimer(textBoxNew.Text);
                textBoxNew.Text = "";
                // remove "ding"
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        #endregion
    }

}
