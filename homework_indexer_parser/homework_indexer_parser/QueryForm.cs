using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformationRetrieval
{
    public partial class QueryForm : Form
    {
        private string _currentDirectory ="";
        private String CurrentDirectory
        {
            get
            {
                return _currentDirectory;
            }
            set
            {
                _currentDirectory = value;
                label_directory.Text = "directory : " + value;
            }
        }

        public QueryForm()
        {
            InitializeComponent();
        }

        private void button_query_Click(object sender, EventArgs e)
        {
            string query = input_querytext
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            CurrentDirectory = folderBrowserDialog.SelectedPath;
        }
    }
}
