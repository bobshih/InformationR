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
            Dictionary<string, List<int>> maindic;
            DictionaryAndPostingSerializer.Load(out maindic, dirorg.GetMainDictionaryPath());
            Dictionary<string, double> idf;
            DictionaryAndPostingSerializer.Load(out idf, dirorg.GetInverseDocumentFrequencyPath());
            var querys = input_querytext.Text.Split(' ', '\t').Where(s => maindic.ContainsKey(s));

            var tfidfv = indexing.normalize_tfidf(indexing.tfidf(indexing.weighted_tf(indexing.fetch_tf(indexing.genetrateInvertedIndex(querys.AsEnumerable()))), idf));

            Dictionary<int, double> queryResault = new Dictionary<int, double>();
            foreach (var t in tfidfv)
            {
                List<int> posting;
                if (!maindic.TryGetValue(t.Key, out posting))
                    continue;
                foreach (int docID in posting)
                {
                    if (queryResault.ContainsKey(docID))
                        continue;

                    Dictionary<string, double> docw;
                    DictionaryAndPostingSerializer.Load(out docw, dirorg.GetNormalizedWeightVectorPath(docID));
                    double similarity = 0;
                    foreach (var tw in tfidfv)
                    {
                        double weight;
                        if (docw.TryGetValue(tw.Key, out weight))
                        {
                            similarity += tw.Value * weight;
                        }
                    }
                    queryResault.Add(docID, similarity);
                }
            }
            queryResultListBox.Items.Clear();
            queryResultListBox.Items.AddRange(queryResault.OrderByDescending(x => x.Value).Select(x => x.Key.ToString() + " " + x.Value.ToString()).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            CurrentDirectory = folderBrowserDialog.SelectedPath;
        }
    }
}
