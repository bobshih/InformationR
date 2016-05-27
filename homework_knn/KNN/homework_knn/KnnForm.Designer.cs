namespace homework_knn
{
    partial class KnnForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_KNN_result = new System.Windows.Forms.Button();
            this.button_folder = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label_folder = new System.Windows.Forms.Label();
            this.button_test_data = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label_test_data = new System.Windows.Forms.Label();
            this.label_result = new System.Windows.Forms.Label();
            this.progressBar_Training = new System.Windows.Forms.ProgressBar();
            this.trackBar_K = new System.Windows.Forms.TrackBar();
            this.label_K = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_K)).BeginInit();
            this.SuspendLayout();
            // 
            // button_KNN_result
            // 
            this.button_KNN_result.Location = new System.Drawing.Point(12, 151);
            this.button_KNN_result.Name = "button_KNN_result";
            this.button_KNN_result.Size = new System.Drawing.Size(75, 23);
            this.button_KNN_result.TabIndex = 5;
            this.button_KNN_result.Text = "KNN Result";
            this.button_KNN_result.UseVisualStyleBackColor = true;
            this.button_KNN_result.Click += new System.EventHandler(this.button_KNN_result_Click);
            // 
            // button_folder
            // 
            this.button_folder.AllowDrop = true;
            this.button_folder.Location = new System.Drawing.Point(13, 13);
            this.button_folder.Name = "button_folder";
            this.button_folder.Size = new System.Drawing.Size(75, 23);
            this.button_folder.TabIndex = 0;
            this.button_folder.Text = "Folder";
            this.button_folder.UseVisualStyleBackColor = true;
            this.button_folder.Click += new System.EventHandler(this.button_folder_Click);
            // 
            // label_folder
            // 
            this.label_folder.AutoSize = true;
            this.label_folder.Location = new System.Drawing.Point(94, 18);
            this.label_folder.Name = "label_folder";
            this.label_folder.Size = new System.Drawing.Size(36, 12);
            this.label_folder.TabIndex = 2;
            this.label_folder.Text = "Empty";
            // 
            // button_test_data
            // 
            this.button_test_data.Location = new System.Drawing.Point(12, 71);
            this.button_test_data.Name = "button_test_data";
            this.button_test_data.Size = new System.Drawing.Size(75, 23);
            this.button_test_data.TabIndex = 3;
            this.button_test_data.Text = "Test Data";
            this.button_test_data.UseVisualStyleBackColor = true;
            this.button_test_data.Click += new System.EventHandler(this.button_test_data_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // label_test_data
            // 
            this.label_test_data.AutoSize = true;
            this.label_test_data.Location = new System.Drawing.Point(93, 76);
            this.label_test_data.Name = "label_test_data";
            this.label_test_data.Size = new System.Drawing.Size(36, 12);
            this.label_test_data.TabIndex = 4;
            this.label_test_data.Text = "Empty";
            // 
            // label_result
            // 
            this.label_result.AutoSize = true;
            this.label_result.Location = new System.Drawing.Point(93, 156);
            this.label_result.Name = "label_result";
            this.label_result.Size = new System.Drawing.Size(30, 12);
            this.label_result.TabIndex = 6;
            this.label_result.Text = "None";
            // 
            // progressBar_Training
            // 
            this.progressBar_Training.Location = new System.Drawing.Point(13, 42);
            this.progressBar_Training.Name = "progressBar_Training";
            this.progressBar_Training.Size = new System.Drawing.Size(509, 23);
            this.progressBar_Training.TabIndex = 7;
            // 
            // trackBar_K
            // 
            this.trackBar_K.Location = new System.Drawing.Point(55, 100);
            this.trackBar_K.Maximum = 100;
            this.trackBar_K.Minimum = 1;
            this.trackBar_K.Name = "trackBar_K";
            this.trackBar_K.Size = new System.Drawing.Size(467, 45);
            this.trackBar_K.TabIndex = 8;
            this.trackBar_K.Value = 1;
            this.trackBar_K.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label_K
            // 
            this.label_K.AutoSize = true;
            this.label_K.Location = new System.Drawing.Point(12, 110);
            this.label_K.Name = "label_K";
            this.label_K.Size = new System.Drawing.Size(28, 12);
            this.label_K.TabIndex = 9;
            this.label_K.Text = "K : 1";
            // 
            // KnnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 186);
            this.Controls.Add(this.label_K);
            this.Controls.Add(this.trackBar_K);
            this.Controls.Add(this.progressBar_Training);
            this.Controls.Add(this.label_result);
            this.Controls.Add(this.button_KNN_result);
            this.Controls.Add(this.label_test_data);
            this.Controls.Add(this.button_test_data);
            this.Controls.Add(this.label_folder);
            this.Controls.Add(this.button_folder);
            this.MinimumSize = new System.Drawing.Size(550, 225);
            this.Name = "KnnForm";
            this.Text = "KnnForm";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_K)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_folder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label_folder;
        private System.Windows.Forms.Button button_test_data;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label_test_data;
        private System.Windows.Forms.Label label_result;
        private System.Windows.Forms.ProgressBar progressBar_Training;
        private System.Windows.Forms.Button button_KNN_result;
        private System.Windows.Forms.TrackBar trackBar_K;
        private System.Windows.Forms.Label label_K;
    }
}