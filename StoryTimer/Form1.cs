using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoryTimer
{
    public partial class Form1 : Form
    {
        List<StoryTimerInstance> _storyTimers = new List<StoryTimerInstance>();
        Size _defaultSize;

        public Form1()
        {
            InitializeComponent();
            _defaultSize = this.Size;
            // temporary initial position where I like it
            // top right
            StartPosition = FormStartPosition.Manual;
            Left = Screen.PrimaryScreen.Bounds.Width - Width + 5;
            Top = 0;
            panel.Visible = false;
            this.Height = this.Height - panel.Height;
            checkBox1.Checked = true;
            StoryTimerInstance storyTimer = new StoryTimerInstance(_storyTimers.Count, panel);
            storyTimer.TimerStarted += StoryTimer_TimerStarted;
            _storyTimers.Add(storyTimer);
        }

        private void ResetAll()
        {
            Size = _defaultSize;
            //remove timers
            
            foreach (var timer in _storyTimers.Where(a => a.Id > 0).ToList())
            {
                var remove = timer;
                remove.StopAndReset();
                remove.Timer.Dispose();
                _storyTimers.Remove(remove);
            }
            foreach (Control control in this.Controls)
            {
                if (control is Panel && control.Name != "panel")
                {
                    Controls.Remove(control);
                }
            }

            panel.Visible = false;
            this.Height = this.Height - panel.Height;
            checkBox1.Checked = true;
            _storyTimers.First().StopAndReset();
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

        private void TextBoxNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StoryTimerInstance storyTimer = _storyTimers.Last();
                if (_storyTimers.Count == 1 && !storyTimer.Panel.Visible)
                {

                    storyTimer.Title.Text = textBoxNew.Text;
                    storyTimer.Panel.Visible = true;
                    this.Height = this.Height + storyTimer.Panel.Height;
                    storyTimer.Start();
                }
                else
                {
                    CreateNewTimer(textBoxNew.Text);
                }
                textBoxNew.Text = "";
            }
        }

        private void CreateNewTimer(string title)
        {
            StoryTimerInstance lastTimer = _storyTimers.Last();
            Panel lastPanel = lastTimer.Panel;
            int id = _storyTimers.Count;
            int top = lastPanel.Bottom + 10;
            StoryTimerInstance newTimer = lastTimer.Clone(id, top);
            _storyTimers.Add(newTimer);
            newTimer.TimerStarted += StoryTimer_TimerStarted;
            newTimer.Title.Text = title;
            this.Height = this.Height + lastTimer.Panel.Height + 10;
            this.Controls.Add(newTimer.Panel);
            newTimer.Start();
        }

        private void ButtonResetAll_Click(object sender, EventArgs e)
        {
            ResetAll();
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
            {
                CopyAll();
            }
        }

        private void CopyAll()
        {
            string info = "";
            foreach (var timer in _storyTimers)
            {
                info += $"{timer.ElapsedTime.Text.Trim()}  {timer.Title.Text.Trim()}{Environment.NewLine}";
            }
            Clipboard.SetText(info);
            MessageBox.Show("All timers saved to clipboard", "Story Timer");
        }


    }

    public class TimerEventArgs : EventArgs
    {
        public int Id { get; set; }
    }


}
