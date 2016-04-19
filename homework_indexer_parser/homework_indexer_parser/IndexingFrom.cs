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

        private void button_next_Click(object sender, EventArgs e)
        {
            button_next.Enabled = false;
            string path = folderBrowserDialog.SelectedPath;
            string warc = openFileDialog.FileName;
            ProcessingClass pc = new ProcessingClass(warc, new DirectoryOrganizer(path));
            pc.MessageHandler += (msg, str) =>
            {
                Invoke(new Action(() =>
                listBox1.Items.Add(str)));
            };
            pc.Start();
        }
    }
}
