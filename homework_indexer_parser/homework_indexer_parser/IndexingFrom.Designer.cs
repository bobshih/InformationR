namespace InformationRetrieval
{
    partial class IndexingFrom
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
            this.label_currentState = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.fileAndDirectoryPanel = new FileAndDirectoryPanel();
            this.SuspendLayout();
            // 
            // label_currentState
            // 
            this.label_currentState.AutoSize = true;
            this.label_currentState.Location = new System.Drawing.Point(379, 18);
            this.label_currentState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_currentState.Name = "label_currentState";
            this.label_currentState.Size = new System.Drawing.Size(63, 12);
            this.label_currentState.TabIndex = 4;
            this.label_currentState.Text = "CurrentState";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(381, 36);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(306, 244);
            this.listBox1.TabIndex = 3;
            // 
            // fileAndDirectoryPanel
            // 
            this.fileAndDirectoryPanel.AutoSize = true;
            this.fileAndDirectoryPanel.Location = new System.Drawing.Point(11, 17);
            this.fileAndDirectoryPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fileAndDirectoryPanel.Name = "fileAndDirectoryPanel";
            this.fileAndDirectoryPanel.Size = new System.Drawing.Size(304, 261);
            this.fileAndDirectoryPanel.TabIndex = 5;
            // 
            // IndexingFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 289);
            this.Controls.Add(this.fileAndDirectoryPanel);
            this.Controls.Add(this.label_currentState);
            this.Controls.Add(this.listBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "IndexingFrom";
            this.Text = "IndexingFrom";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IndexingFrom_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label_currentState;
        private FileAndDirectoryPanel fileAndDirectoryPanel;
    }
}