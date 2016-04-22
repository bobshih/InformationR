using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HTMLparserLibDotNet20
{
    public partial class FileAndDirectoryPanel : UserControl
    {
        public new bool Enabled
        {
            get
            {
                return button_next.Enabled;
            }
            set
            {
                button_next.Enabled = value;
                button_openDir.Enabled = value;
                button_openFile.Enabled = value;
            }
        }

        public event Action NextButtonClicked;
        public string Directory
        {
            get
            {
                return label_dir.Text;
            }
            private set
            {
                label_dir.Text = value;
            }
        }
        public string File
        {
            get
            {
                return label_file.Text;
            }
            private set
            {
                label_file.Text = value;
            }
        }

        public FileAndDirectoryPanel()
        {
            InitializeComponent();
            label_dir.Text = "";
            label_file.Text = "";
        }

        private void button_openDir_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Directory = folderBrowserDialog.SelectedPath;
            }
        }
        private void button_openFile_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                File = openFileDialog.FileName;
            }
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            if (NextButtonClicked != null)
            {
                NextButtonClicked();
            }
        }


    }
}
