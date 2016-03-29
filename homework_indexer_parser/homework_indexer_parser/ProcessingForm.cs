using homework_indexer_parser.DictionaryFolder;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

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
        }

        #endregion

        private void ProcessingForm_Load(object sender, EventArgs e)
        {
            pclass.Start();
            _pause = false;
        }


    }
}
