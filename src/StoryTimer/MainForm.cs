﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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
        private IOptionsMonitor<AppOptions> _appOptions;
        private List<StoryTimerInstance> _storyTimers = new List<StoryTimerInstance>();
        private System.Timers.Timer _statusTimer = new System.Timers.Timer();
        private Size _defaultSize;
        public const string TimerFormat = @"h\:mm\:ss";
        private SettingsUI _settingsUI;
        private SnippetSelector _snippetSelector;

        public MainForm(IOptionsMonitor<AppOptions> appOptions = null)
        {
            InitializeComponent();
            _appOptions = appOptions;
            _settingsUI = Program.Services.GetService<SettingsUI>();
            _settingsUI.FormClosing += _settingsUI_FormClosing;
            _snippetSelector = Program.Services.GetService<SnippetSelector>();
            _snippetSelector.FormClosing += _snippetSelector_FormClosing;
        }

        private void _settingsUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                ((Form)sender).Hide();
                e.Cancel = true;
                if (_settingsUI.CurrentTimesFileChanged)
                {
                    var file = _appOptions.CurrentValue.SaveCurrentTimesFilePath;
                    var text = File.ReadAllText(file);
                    ResetAllTimers();
                    LoadTimerText(text);
                }
            }
        }

        private void _snippetSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                ((Form)sender).Hide();
                e.Cancel = true;

                if (_snippetSelector.SnippetSelected)
                {
                    Clipboard.SetText(_snippetSelector.Snippet);
                    WriteStatus("Snippet copied to clipboard");
                    if (this.ActiveControl is TextBox)
                    {
                        var textBox = ((TextBox)this.ActiveControl);
                        var start = textBox.SelectionStart;
                        var text = textBox.Text;
                        var newText = text.Substring(0, start) + _snippetSelector.Snippet + text.Substring(start);
                        textBox.Text = newText;
                        textBox.SelectionStart = textBox.TextLength;
                    }
                }
            }
        }

        // Do this after the form is loaded so its size is available.
        private void InitializeSettings()
        {
            string currentVersion = Application.ProductVersion;
            AppOptions options = _appOptions.CurrentValue;

            // defaults
            string saveCurrentTimesFileName = "current-times.txt";
            string savePreviousTimesFileName = "previous-times.txt";
            string saveSnippetsFileName = "snippets.txt";
            string exeFolderPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

            // always use CurrentValue
            if (String.IsNullOrWhiteSpace(_appOptions.CurrentValue.Version))
            {
                int mainFormWidth = 214;
                // Important: Do not reinitialize options, otherwise OptionsMonitor doesn't fire correctly
                // So, don't do options = new AppOptions.
                options.Version = currentVersion;
                options.SaveCurrentTimesFilePath = Path.Combine(exeFolderPath, saveCurrentTimesFileName);
                options.SavePreviousTimesFilePath = Path.Combine(exeFolderPath, savePreviousTimesFileName);
                options.SaveSnippetsFilePath = Path.Combine(exeFolderPath, saveSnippetsFileName);
                options.WindowPosX = Screen.PrimaryScreen.Bounds.Width - mainFormWidth + 5;
                options.WindowPosY = 0;
                options.WindowWidth = mainFormWidth;
            }
            // Version-related changes
            if (options.SettingsVersionLessThan("2.0.0"))
            {
                options.SaveSnippetsFilePath = Path.Combine(exeFolderPath, saveSnippetsFileName);
            }

            // always set version
            options.Version = currentVersion;

            // Save
            new SettingsManager().SaveAppOptions(options);
        }

        private void InitializeTimers()
        {
            _defaultSize = this.Size;
            StartPosition = FormStartPosition.Manual;
            Left = _appOptions.CurrentValue.WindowPosX;
            Top = _appOptions.CurrentValue.WindowPosY;
            panel.Visible = false;
            Width = _appOptions.CurrentValue.WindowWidth;
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

        private void ResetAllTimers()
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
            var currentSize = Size;
            Size = _defaultSize;
            this.Height = this.Height - panel.Height;
            this.Width = currentSize.Width;            
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
            // setting ElapsedTime.Text doesn't fire the event
            // while in ctor.
            newTimer.SetElapsedTime(elapsedTime);
            if (!doNotStart) { newTimer.Start(); }
            return newTimer;
        }

        private void CopyAll(bool roundToQuarter, bool includeTotal, bool markdownCompatible)
        {
            string info = GetTimersInfo(roundToQuarter, includeTotal, markdownCompatible);
            Clipboard.SetText(info, TextDataFormat.Text);
            WriteStatus("All timers saved to clipboard");
        }

        private string GetTimersInfo(bool roundToQuarter, bool includeTotal, bool markdownCompatible)
        {
            string info = "";
            double totalTime = 0;
            string softReturn = markdownCompatible ? "  " : "";
            foreach (var timer in _storyTimers)
            {
                if (roundToQuarter)
                {
                    info += $"{timer.GetElapsedTimeToQuarter().ToString("00.00")} {timer.Title.Text.Trim()}{softReturn}{Environment.NewLine}";
                    totalTime += timer.GetElapsedTimeToQuarter();
                }
                else
                {
                    info += $"{timer.ElapsedTime.Text.Trim()} {timer.Title.Text.Trim()}{softReturn}{Environment.NewLine}";
                    totalTime += timer.ElapsedSeconds;

                }
            }
            if (includeTotal)
            {
                if (roundToQuarter)
                {
                    info += Environment.NewLine + $"{totalTime.ToString("00.00")} TOTAL{softReturn}{Environment.NewLine}";
                }
                else
                {
                    info += Environment.NewLine + $"{(new TimeSpan(0, 0, (int)totalTime).ToString(TimerFormat))} TOTAL{softReturn}{Environment.NewLine}";
                }
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
            else
            {
                LoadTimerText(text);
            }
        }

        private void LoadTimerText(string text)
        {
            if (String.IsNullOrWhiteSpace(text)) return;
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

        private void ClearCurrentTimerText()
        {
            var options = _appOptions.CurrentValue;
            File.WriteAllText(options.SaveCurrentTimesFilePath, "");
        }

        private void WriteCurrentTimerText()
        {
            var options = _appOptions.CurrentValue;
            File.WriteAllText(options.SaveCurrentTimesFilePath, GetTimersInfo(false, false, true));
        }

        private void WritePreviousTimerText(bool append = true)
        {
            var options = _appOptions.CurrentValue;
            var filePath = options.SavePreviousTimesFilePath;
            string header = $"## {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}{Environment.NewLine}";
            var timersInfo = header + GetTimersInfo(false, true, true) + Environment.NewLine;

            if (append)
            { File.AppendAllText(filePath, timersInfo); }
            else
            { File.WriteAllText(filePath, timersInfo); }

        }

        private string ReadCurrentTimerText()
        {
            var options = _appOptions.CurrentValue;
            if (File.Exists(options.SaveCurrentTimesFilePath)) return File.ReadAllText(options.SaveCurrentTimesFilePath);
            else return "";
        }

        private void SetTimerTotal()
        {
            int totalSeconds = _storyTimers
                .Sum(a => a.ElapsedSeconds);

            TimeSpan ts = new TimeSpan(0, 0, totalSeconds);
            string totalTime = ts.ToString(TimerFormat);
            this.Text = totalTime;
        }

        #region "Controls"
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Copy full times
            if (keyData == (Keys.Control | Keys.Shift | Keys.C))
            {
                CopyAll(false, true, true);
                return true;
            }
            // Copy time rounded to quarter hour

            if (keyData == (Keys.Control | Keys.Alt | Keys.C))
            {
                CopyAll(true, true, true);
                return true;
            }

            if (keyData == (Keys.Control | Keys.Shift | Keys.V))
            {
                PasteAll();
                return true;
            }

            // Paste clipboard stripping linefeeds
            if (keyData == (Keys.Control | Keys.V))
            {
                var text = Clipboard.GetText().Replace(Environment.NewLine, " ");
                Clipboard.SetText(text);
                return base.ProcessCmdKey(ref msg, keyData);
            }

            // Start timer from clipboard stripping linefeeds
            if (keyData == (Keys.Alt | Keys.V))
            {
                var text = Clipboard.GetText().Replace(Environment.NewLine, " ");
                AddNewTimer(text);
                return true;
            }


            if (keyData == (Keys.Alt | Keys.S))
            {
                ShowSettings();
                return true;
            }

            if (keyData == (Keys.Control | Keys.I))
            {
                ShowSnippets();
                return true;
            }

            if (keyData == (Keys.Control | Keys.OemQuestion))
            {
                string help = @"Exclusive unchecked = allow simultaneous timing.

Ctrl+Shift+C to copy all timers to the second, e.g. 0:12:34
Ctrl+Alt+C to copy all timers rounded to quarter hour, e.g. 09.75
Ctrl+Shift+V to add timers from text
Ctrl+V replaces linefeeds with spaces
Alt+V to start new timer from clipboard
Ctrl+I to insert a snippet
Alt+S to show Settings

To paste, timer text must be in form [time] [title], e.g. 
1:23:45 My First Timer
0:01:03 My Second Timer
";
                MessageBox.Show(help, "Story Timer - " + Application.ProductVersion);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void ShowSettings()
        {
            _settingsUI.StartPosition = FormStartPosition.CenterScreen;
            _settingsUI.Show();
            _settingsUI.BringToFront();
        }
        private void ShowSnippets()
        {
            _snippetSelector.SetSnippetList(GetSnippets());
            // tiled position from timer
            _snippetSelector.StartPosition = this.StartPosition;
            _snippetSelector.Top = this.Top + 10;
            _snippetSelector.Left = this.Left + 10;
            _snippetSelector.Show();
            _snippetSelector.BringToFront();
        }

        private string[] GetSnippets()
        {
            var file = _appOptions.CurrentValue.SaveSnippetsFilePath;
            var snippets = File.ReadAllLines(file);
            return snippets;
        }

        #endregion

        #region "Events"

        private void ButtonResetAll_Click(object sender, EventArgs e)
        {
            WritePreviousTimerText();
            ResetAllTimers();
            ClearCurrentTimerText();
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
            SetTimerTotal();
            WriteCurrentTimerText();
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeSettings();

            InitializeTimers();
            InitializeStatusTimer();
            SetTimerTotal();
            SetStatusToHelpText();
            // loading from text happens in MainForm_Load event so that form is visible.
            LoadTimerText(ReadCurrentTimerText());
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            var options = _appOptions.CurrentValue;
            options.WindowPosX = Left;
            options.WindowPosY = Top;
            options.WindowWidth = Width;
            new SettingsManager().SaveAppOptions(options);
        }

        #endregion

    }
}
