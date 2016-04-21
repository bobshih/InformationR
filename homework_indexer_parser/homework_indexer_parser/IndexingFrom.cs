using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformationRetrieval
{
    public partial class IndexingFrom : Form
    {
        public IndexingFrom()
        {
            InitializeComponent();
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            label_filepath.Text = "file: " + openFileDialog.FileName;
        }

        private void button_openDir_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            label_directory.Text = "dir: " + folderBrowserDialog.SelectedPath;
        }

        ProcessingClass pc;
        private void button_next_Click(object sender, EventArgs e)
        {
            button_next.Enabled = false;
            string path = folderBrowserDialog.SelectedPath;
            string warc = openFileDialog.FileName;
            pc = new ProcessingClass(warc, new DirectoryOrganizer(path));
            pc.MessageHandler += (msg, str) =>
            {
                Invoke(new Action(() => listBox1.Items.Add(str)));
                Invoke(new Action(() => label_currentState.Text = str));
            };
            pc.ProcessEndHandler += (b) => Invoke(new Action(() => button_next.Enabled = true));
            pc.Start();
        }

        private void IndexingFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
