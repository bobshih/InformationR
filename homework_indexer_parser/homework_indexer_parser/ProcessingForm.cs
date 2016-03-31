using homework_indexer_parser.SimpleParser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;

namespace homework_indexer_parser
{
    public partial class ProcessingForm : Form
    {
        private ProcessingClass pclass;

        private List<String> files = new List<string>();
        private int currentFile;
        private Stopwatch stopwatch_Total = new Stopwatch();
        private Stopwatch stopwatch_current = new Stopwatch();
        private bool _pause = false;
        private bool Pause
        {
            get
            {
                return _pause;
            }
            set
            {
                _pause = value;
                Button_CancelOrOK.Text = value ? "Pause" : "Resume";
            }
        }

        #region Constructors

        private ProcessingForm()
        {
            InitializeComponent();
        }

        public ProcessingForm(List<string> fileNames, PostProcessingChoice choice)
            : this()
        {
            files = new List<string>(fileNames);
            currentFile = 0;
            pclass = new ProcessingClass(fileNames, choice);
            InitializeTimer();

            pclass.ProcessEndHandler += (dictionary) =>
            {
                dictionary.OutputDictionary();
                dictionary.OutputFile();
                AfterProcess();
            };

            pclass.MessageHandler += HandleProcessMessage;
        }

        #endregion

        /// <summary>
        /// 初始化計時器
        /// </summary>
        private void InitializeTimer()
        {
            timer.Interval = 10;
            timer.Enabled = true;
            // start stopwatch
            stopwatch_current.Stop();
            stopwatch_current.Reset();
            stopwatch_current.Start();
            stopwatch_Total = new Stopwatch();
            stopwatch_Total.Reset();
            stopwatch_Total.Start();

            timer.Tick += new EventHandler(CheckProgress);
        }

        /// <summary>
        /// 計時器事件
        /// </summary>
        private void CheckProgress(object obj, EventArgs e)
        {
            // 設定porgress bar
            if (obj != null)
            {
                ProgressBar_TotalPrograss.Value = (pclass.DoneFIlesCount != files.Count) ? (pclass.DoneFIlesCount * 100 + pclass.Progress) / (files.Count) : 100;
                ProgressBar_CurrentProgress.Value = pclass.Progress;
                // 顯示目前檔案
                if (pclass.CurrentFile != null)
                {
                    String[] filePath = pclass.CurrentFile.Split(new char[] { '\\' });
                    Label_CurrentFile.Text = filePath.Last();
                }
            }
            else
            {
                ProgressBar_TotalPrograss.Value = 100;
                ProgressBar_CurrentProgress.Value = 100;
                Label_CurrentFile.Text = "Done";
            }
            // 顯示經過時間
            ShowTime();
        }

        private void ShowTime()
        {

            Label_TotalTime.Text = String.Format("{0:00}:{1:00}:{2:00}", stopwatch_Total.Elapsed.Hours,
                stopwatch_Total.Elapsed.Minutes, stopwatch_Total.Elapsed.Seconds);
            if (pclass.DoneFIlesCount != currentFile)
            {
                currentFile = pclass.DoneFIlesCount;
                stopwatch_current.Stop();
                stopwatch_current.Reset();
                stopwatch_current.Start();
            }
            Label_CurrentTimeComsumed.Text = String.Format("{0:00}:{1:00}:{2:00}", stopwatch_current.Elapsed.Hours,
                stopwatch_current.Elapsed.Minutes, stopwatch_current.Elapsed.Seconds);
        }

        void HandleProcessMessage(ProcessingClass.MessageType messageType, string message)
        {
            switch (messageType)
            {
                case ProcessingClass.MessageType.ERROR:
                    ListBox_Errors.Items.Add("<ERROR> : " + message);
                    break;
                case ProcessingClass.MessageType.WARNNING:
                    ListBox_Errors.Items.Add("<Warning> : " + message);
                    break;
                case ProcessingClass.MessageType.NOTICE:
                    ListBox_Errors.Items.Add("<Notice> : " + message);
                    break;
                default:
                    break;
            }
        }

        private void AfterProcess()
        {
            if (InvokeRequired)
            {
                Invoke((Action)AfterProcess);
                return;
            }
            ShowTime();
            stopwatch_current.Stop();
            stopwatch_Total.Stop();
            timer.Stop();
            CheckProgress(null, null);
            Button_OK.Show();
            Button_CancelOrOK.Hide();
        }

        private void ProcessingForm_Load(object sender, EventArgs e)
        {
            pclass.Start();
            _pause = false;
            Button_OK.Visible = false;
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
