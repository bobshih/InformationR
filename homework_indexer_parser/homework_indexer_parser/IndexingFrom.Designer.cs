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
            this.fileAndDirectoryPanel = new HTMLparserLibDotNet20.FileAndDirectoryPanel();
            this.SuspendLayout();
            // 
            // label_currentState
            // 
            this.label_currentState.AutoSize = true;
            this.label_currentState.Location = new System.Drawing.Point(505, 23);
            this.label_currentState.Name = "label_currentState";
            this.label_currentState.Size = new System.Drawing.Size(78, 15);
            this.label_currentState.TabIndex = 4;
            this.label_currentState.Text = "CurrentState";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(508, 45);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(407, 304);
            this.listBox1.TabIndex = 3;
            // 
            // fileAndDirectoryPanel
            // 
            this.fileAndDirectoryPanel.AutoSize = true;
            this.fileAndDirectoryPanel.Location = new System.Drawing.Point(12, 12);
            this.fileAndDirectoryPanel.Name = "fileAndDirectoryPanel";
            this.fileAndDirectoryPanel.Size = new System.Drawing.Size(406, 326);
            this.fileAndDirectoryPanel.TabIndex = 5;
            // 
            // IndexingFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 361);
            this.Controls.Add(this.fileAndDirectoryPanel);
            this.Controls.Add(this.label_currentState);
            this.Controls.Add(this.listBox1);
            this.Name = "IndexingFrom";
            this.Text = "IndexingFrom";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IndexingFrom_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label_currentState;
        private HTMLparserLibDotNet20.FileAndDirectoryPanel fileAndDirectoryPanel;
    }
}