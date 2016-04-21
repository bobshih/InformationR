using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace InformationRetrieval
{
    public partial class QueryForm : Form
    {
        private string _currentDirectory = "";
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
            var dirorg = new DirectoryOrganizer(CurrentDirectory);
            string query = input_querytext.Text;
            string[] querys = query.Split(' ', '\t');
            indexing.genetrateInvertedIndex(querys.AsEnumerable());

            Dictionary<string, double> idf;
            DictionaryAndPostingSerializer.Load(out idf, dirorg.GetInverseDocumentFrequencyPath());
            indexing.tfidf(indexing.weighted_tf(), idf);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            CurrentDirectory = folderBrowserDialog.SelectedPath;
        }
    }
}
