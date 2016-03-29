namespace homework_indexer_parser
{
    partial class ProcessingForm
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            this.ProgressBar_TotalPrograss = new System.Windows.Forms.ProgressBar();
            this.ProgressBar_CurrentProgress = new System.Windows.Forms.ProgressBar();
            this.Labal_CurrentTimeComsumed = new System.Windows.Forms.Label();
            this.Lable_TotalTime = new System.Windows.Forms.Label();
            this.Labal_CurrentProgress = new System.Windows.Forms.Label();
            this.Labal_CurrentFile = new System.Windows.Forms.Label();
            this.Button_CancelOrOK = new System.Windows.Forms.Button();
            this.Button_OK = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(22, 30);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(103, 15);
            label2.TabIndex = 1;
            label2.Text = "Total Time Used";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(22, 102);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(76, 15);
            label4.TabIndex = 3;
            label4.Text = "Current File";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(22, 124);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(96, 15);
            label5.TabIndex = 4;
            label5.Text = "Current Porcess";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(22, 155);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(69, 15);
            label6.TabIndex = 5;
            label6.Text = "Time Used";
            // 
            // ProgressBar_TotalPrograss
            // 
            this.ProgressBar_TotalPrograss.Location = new System.Drawing.Point(25, 58);
            this.ProgressBar_TotalPrograss.Name = "ProgressBar_TotalPrograss";
            this.ProgressBar_TotalPrograss.Size = new System.Drawing.Size(230, 20);
            this.ProgressBar_TotalPrograss.TabIndex = 0;
            // 
            // ProgressBar_CurrentProgress
            // 
            this.ProgressBar_CurrentProgress.Location = new System.Drawing.Point(25, 173);
            this.ProgressBar_CurrentProgress.Name = "ProgressBar_CurrentProgress";
            this.ProgressBar_CurrentProgress.Size = new System.Drawing.Size(230, 20);
            this.ProgressBar_CurrentProgress.TabIndex = 0;
            // 
            // Labal_CurrentTimeComsumed
            // 
            this.Labal_CurrentTimeComsumed.AutoSize = true;
            this.Labal_CurrentTimeComsumed.Location = new System.Drawing.Point(211, 155);
            this.Labal_CurrentTimeComsumed.Name = "Labal_CurrentTimeComsumed";
            this.Labal_CurrentTimeComsumed.Size = new System.Drawing.Size(44, 15);
            this.Labal_CurrentTimeComsumed.TabIndex = 1;
            this.Labal_CurrentTimeComsumed.Text = "0.00%";
            // 
            // Lable_TotalTime
            // 
            this.Lable_TotalTime.AutoSize = true;
            this.Lable_TotalTime.Location = new System.Drawing.Point(211, 30);
            this.Lable_TotalTime.Name = "Lable_TotalTime";
            this.Lable_TotalTime.Size = new System.Drawing.Size(44, 15);
            this.Lable_TotalTime.TabIndex = 2;
            this.Lable_TotalTime.Text = "00:00s";
            // 
            // Labal_CurrentProgress
            // 
            this.Labal_CurrentProgress.AutoSize = true;
            this.Labal_CurrentProgress.Location = new System.Drawing.Point(159, 124);
            this.Labal_CurrentProgress.Name = "Labal_CurrentProgress";
            this.Labal_CurrentProgress.Size = new System.Drawing.Size(96, 15);
            this.Labal_CurrentProgress.TabIndex = 6;
            this.Labal_CurrentProgress.Text = "Current Porcess";
            // 
            // Labal_CurrentFile
            // 
            this.Labal_CurrentFile.AutoSize = true;
            this.Labal_CurrentFile.Location = new System.Drawing.Point(179, 102);
            this.Labal_CurrentFile.Name = "Labal_CurrentFile";
            this.Labal_CurrentFile.Size = new System.Drawing.Size(76, 15);
            this.Labal_CurrentFile.TabIndex = 7;
            this.Labal_CurrentFile.Text = "Current File";
            // 
            // Button_CancelOrOK
            // 
            this.Button_CancelOrOK.Location = new System.Drawing.Point(25, 212);
            this.Button_CancelOrOK.Name = "Button_CancelOrOK";
            this.Button_CancelOrOK.Size = new System.Drawing.Size(230, 29);
            this.Button_CancelOrOK.TabIndex = 8;
            this.Button_CancelOrOK.Text = "Cancel";
            this.Button_CancelOrOK.UseVisualStyleBackColor = true;
            // 
            // Button_OK
            // 
            this.Button_OK.Location = new System.Drawing.Point(25, 212);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(230, 29);
            this.Button_OK.TabIndex = 9;
            this.Button_OK.Text = "OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // ProcessingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.Button_CancelOrOK);
            this.Controls.Add(this.Labal_CurrentFile);
            this.Controls.Add(this.Labal_CurrentProgress);
            this.Controls.Add(label6);
            this.Controls.Add(label5);
            this.Controls.Add(label4);
            this.Controls.Add(this.Lable_TotalTime);
            this.Controls.Add(label2);
            this.Controls.Add(this.Labal_CurrentTimeComsumed);
            this.Controls.Add(this.ProgressBar_CurrentProgress);
            this.Controls.Add(this.ProgressBar_TotalPrograss);
            this.Name = "ProcessingForm";
            this.Text = "Processing";
            this.Load += new System.EventHandler(this.ProcessingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar ProgressBar_TotalPrograss;
        private System.Windows.Forms.ProgressBar ProgressBar_CurrentProgress;
        private System.Windows.Forms.Label Labal_CurrentTimeComsumed;
        private System.Windows.Forms.Label Lable_TotalTime;
        private System.Windows.Forms.Label Labal_CurrentProgress;
        private System.Windows.Forms.Label Labal_CurrentFile;
        private System.Windows.Forms.Button Button_CancelOrOK;
        private System.Windows.Forms.Button Button_OK;
    }
}