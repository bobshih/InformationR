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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            this.ProgressBar_TotalPrograss = new System.Windows.Forms.ProgressBar();
            this.ProgressBar_CurrentProgress = new System.Windows.Forms.ProgressBar();
            this.Label_CurrentTimeComsumed = new System.Windows.Forms.Label();
            this.Label_TotalTime = new System.Windows.Forms.Label();
            this.Label_CurrentProgress = new System.Windows.Forms.Label();
            this.Label_CurrentFile = new System.Windows.Forms.Label();
            this.Button_CancelOrOK = new System.Windows.Forms.Button();
            this.Button_OK = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(16, 24);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(82, 12);
            label2.TabIndex = 1;
            label2.Text = "Total Time Used";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(16, 82);
            label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(61, 12);
            label4.TabIndex = 3;
            label4.Text = "Current File";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(16, 99);
            label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(66, 12);
            label5.TabIndex = 4;
            label5.Text = "Current State";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(16, 124);
            label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(55, 12);
            label6.TabIndex = 5;
            label6.Text = "Time Used";
            // 
            // ProgressBar_TotalPrograss
            // 
            this.ProgressBar_TotalPrograss.Location = new System.Drawing.Point(19, 46);
            this.ProgressBar_TotalPrograss.Margin = new System.Windows.Forms.Padding(2);
            this.ProgressBar_TotalPrograss.Name = "ProgressBar_TotalPrograss";
            this.ProgressBar_TotalPrograss.Size = new System.Drawing.Size(172, 16);
            this.ProgressBar_TotalPrograss.TabIndex = 0;
            // 
            // ProgressBar_CurrentProgress
            // 
            this.ProgressBar_CurrentProgress.Location = new System.Drawing.Point(19, 138);
            this.ProgressBar_CurrentProgress.Margin = new System.Windows.Forms.Padding(2);
            this.ProgressBar_CurrentProgress.Name = "ProgressBar_CurrentProgress";
            this.ProgressBar_CurrentProgress.Size = new System.Drawing.Size(172, 16);
            this.ProgressBar_CurrentProgress.TabIndex = 0;
            // 
            // Label_CurrentTimeComsumed
            // 
            this.Label_CurrentTimeComsumed.AutoSize = true;
            this.Label_CurrentTimeComsumed.Location = new System.Drawing.Point(158, 124);
            this.Label_CurrentTimeComsumed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_CurrentTimeComsumed.Name = "Label_CurrentTimeComsumed";
            this.Label_CurrentTimeComsumed.Size = new System.Drawing.Size(36, 12);
            this.Label_CurrentTimeComsumed.TabIndex = 1;
            this.Label_CurrentTimeComsumed.Text = "00.00s";
            // 
            // Label_TotalTime
            // 
            this.Label_TotalTime.AutoSize = true;
            this.Label_TotalTime.Location = new System.Drawing.Point(158, 24);
            this.Label_TotalTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_TotalTime.Name = "Label_TotalTime";
            this.Label_TotalTime.Size = new System.Drawing.Size(36, 12);
            this.Label_TotalTime.TabIndex = 2;
            this.Label_TotalTime.Text = "00:00s";
            // 
            // Label_CurrentProgress
            // 
            this.Label_CurrentProgress.AutoSize = true;
            this.Label_CurrentProgress.Location = new System.Drawing.Point(119, 99);
            this.Label_CurrentProgress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_CurrentProgress.Name = "Label_CurrentProgress";
            this.Label_CurrentProgress.Size = new System.Drawing.Size(78, 12);
            this.Label_CurrentProgress.TabIndex = 6;
            this.Label_CurrentProgress.Text = "Current Porcess";
            // 
            // Label_CurrentFile
            // 
            this.Label_CurrentFile.AutoSize = true;
            this.Label_CurrentFile.Location = new System.Drawing.Point(134, 82);
            this.Label_CurrentFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_CurrentFile.Name = "Label_CurrentFile";
            this.Label_CurrentFile.Size = new System.Drawing.Size(61, 12);
            this.Label_CurrentFile.TabIndex = 7;
            this.Label_CurrentFile.Text = "Current File";
            // 
            // Button_CancelOrOK
            // 
            this.Button_CancelOrOK.Location = new System.Drawing.Point(19, 170);
            this.Button_CancelOrOK.Margin = new System.Windows.Forms.Padding(2);
            this.Button_CancelOrOK.Name = "Button_CancelOrOK";
            this.Button_CancelOrOK.Size = new System.Drawing.Size(172, 23);
            this.Button_CancelOrOK.TabIndex = 8;
            this.Button_CancelOrOK.Text = "Cancel";
            this.Button_CancelOrOK.UseVisualStyleBackColor = true;
            // 
            // Button_OK
            // 
            this.Button_OK.Location = new System.Drawing.Point(19, 170);
            this.Button_OK.Margin = new System.Windows.Forms.Padding(2);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(172, 23);
            this.Button_OK.TabIndex = 9;
            this.Button_OK.Text = "OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // ProcessingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 202);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.Button_CancelOrOK);
            this.Controls.Add(this.Label_CurrentFile);
            this.Controls.Add(this.Label_CurrentProgress);
            this.Controls.Add(label6);
            this.Controls.Add(label5);
            this.Controls.Add(label4);
            this.Controls.Add(this.Label_TotalTime);
            this.Controls.Add(label2);
            this.Controls.Add(this.Label_CurrentTimeComsumed);
            this.Controls.Add(this.ProgressBar_CurrentProgress);
            this.Controls.Add(this.ProgressBar_TotalPrograss);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProcessingForm";
            this.Text = "Processing";
            this.Load += new System.EventHandler(this.ProcessingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar ProgressBar_TotalPrograss;
        private System.Windows.Forms.ProgressBar ProgressBar_CurrentProgress;
        private System.Windows.Forms.Label Label_CurrentTimeComsumed;
        private System.Windows.Forms.Label Label_TotalTime;
        private System.Windows.Forms.Label Label_CurrentProgress;
        private System.Windows.Forms.Label Label_CurrentFile;
        private System.Windows.Forms.Button Button_CancelOrOK;
        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Timer timer;
    }
}