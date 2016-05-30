using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classifiers;
using System.IO;

namespace homework_knn
{
    public partial class KnnForm : Form
    {
        private string folder = "";
        private string testData = "";
        private KNN<int, List<double>> knn = new KNN<int, List<double>>();

        public KnnForm()
        {
            InitializeComponent();
        }

        private async void button_folder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();

            folder = folderBrowserDialog.SelectedPath;
            label_folder.Text = folder;

            panel1.Enabled = false;
            try
            {
                progressBar_Training.Maximum = 19 * 6 * 60;
                progressBar_Training.Value = 0;
                for (int i = 1; i <= 19; i++)
                {
                    string sport = "a" + i.ToString("D2");
                    for (int j = 1; j <= 6; j++)
                    {
                        string player = "p" + j.ToString();
                        for (int k = 1; k <= 60; k++)
                        {
                            string path = folder + "\\" + sport + "\\" + player + "\\s" + k.ToString("D2") + ".txt";
                            if (!File.Exists(path))
                            {
                                throw new Exception("there is no file existing");
                            }
                            knn.AddTrainingData(await AsyncGetFileNumbers(path), i);
                            progressBar_Training.Value++;
                        }
                    }
                }
                MessageBox.Show("Training Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show("there is an exception, Message: " + ex.Message);
                label_folder.Text = "Empty";
            }
            panel1.Enabled = true;
        }

        private void button_test_data_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            testData = openFileDialog.FileName;
            if (testData == "openFileDialog1")
            {
                testData = "Empty";
            }
            label_test_data.Text = testData;
        }

        private async void button_KNN_result_Click(object sender, EventArgs e)
        {
            if (folder == string.Empty || testData == string.Empty)
            {
                MessageBox.Show("缺乏訓練資料，或是沒有測試資料");
                return;
            }
            try
            {
                label_result.Text = "Running";
                button_KNN_result.Enabled = false;
                List<double> nums = await AsyncGetFileNumbers(testData);
                int result = -1;
                int tick = trackBar_K.Value;
                await Task.Run(new Action(() =>
                {
                    result = knn.FindCategory<double>(nums, tick, DistanceFunction.EuclideanDistanceSquare);
                }));
                button_KNN_result.Enabled = true;
                label_result.Text = result.ToString("D2");
            }
            catch (Exception)
            {
                MessageBox.Show("there is a problem");
            }

        }

        private async Task<List<double>> AsyncGetFileNumbers(string path)
        {
            List<double> nums = null;
            await Task.Run(new Action(() =>
            {
                nums = File.ReadAllText(path)
                   .Split(new char[] { '\n', ',' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(Convert.ToDouble)
                   .ToList();
            }));

            return nums;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label_K.Text = "K : " + trackBar_K.Value.ToString();
        }

        private async void button_evaluation_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            progressBar_evaluation.Maximum = 19 * 2 * 60;
            progressBar_evaluation.Value = 0;
            int[,] answer = new int[19,3];
            for (int i = 1; i <= 19; i++)
            {
                string sport = "a" + i.ToString("D2");
                for (int j = 7; j <= 8; j++)
                {
                    string player = "p" + j.ToString();
                    for (int k = 1; k <= 60; k++)
                    {
                        string path = folder + "\\" + sport + "\\" + player + "\\s" + k.ToString("D2") + ".txt";
                        if (!File.Exists(path))
                        {
                            throw new Exception("there is no file existing");
                        }
                        List<double> nums = await AsyncGetFileNumbers(path);
                        int result = -1;
                        int tick = trackBar_K.Value;
                        await Task.Run(new Action(() =>
                        {
                            result = knn.FindCategory<double>(nums, tick, DistanceFunction.EuclideanDistanceSquare);
                        }));
                        if (result == i)
                        {
                            answer[i-1, 0]++;
                        }
                        else
                        {
                            answer[i - 1, 1]++;
                            //answer[result - 1, 2]++;
                        }
                        ++progressBar_evaluation.Value;
                    }
                }
            }
            
            // evaluation
            double macro_p = 0;
            for (int i = 0; i < 19; i++)
            {
                macro_p += (double)answer[i, 0] / (answer[i, 0] + answer[i, 1]);
            }
            macro_p /= 19;
            double micro_p_up = 0;
            double micro_p_down = 0;
            for (int i = 0; i < 19; i++)
            {
                micro_p_up += answer[i, 0];
                micro_p_down += answer[i, 1];
            }
            label_micro_p.Text = (micro_p_up / (micro_p_down+micro_p_up)).ToString();
            label_macro_p.Text = macro_p.ToString();
            MessageBox.Show("DONE");
            panel1.Enabled = true;
        }

        private void KnnForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }
    }
}
