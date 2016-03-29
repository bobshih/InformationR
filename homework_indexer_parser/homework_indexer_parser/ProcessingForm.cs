using homework_indexer_parser.DictionaryFolder;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
///
///Contributor : 101820307
///

namespace homework_indexer_parser
{
    public partial class ProcessingForm : Form
    {
        private ProcessingClass pclass;

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

        public ProcessingForm(List<string> fileNames)
            : this()
        {
            pclass = new ProcessingClass(fileNames);
            pclass.ProcessEndHandler += (dictionary) =>
            {
                dictionary.OutputDictionary();
                dictionary.OutputFile();
                AfterProcess();
            };
        }

        #endregion

        private void AfterProcess()
        {
            if (InvokeRequired)
            {
                Invoke((Action)AfterProcess);
                return;
            }
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
