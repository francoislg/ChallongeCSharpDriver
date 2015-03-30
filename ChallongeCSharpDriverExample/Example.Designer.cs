namespace ChallongeCSharpDriverExample {
    partial class Example {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.sendQueryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sendQueryButton
            // 
            this.sendQueryButton.Location = new System.Drawing.Point(13, 13);
            this.sendQueryButton.Name = "sendQueryButton";
            this.sendQueryButton.Size = new System.Drawing.Size(75, 23);
            this.sendQueryButton.TabIndex = 0;
            this.sendQueryButton.Text = "Send Query";
            this.sendQueryButton.UseVisualStyleBackColor = true;
            this.sendQueryButton.Click += new System.EventHandler(this.sendQueryButton_Click);
            // 
            // Example
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.sendQueryButton);
            this.Name = "Example";
            this.Text = "ChallongeCSharpDriverExample";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button sendQueryButton;
    }
}

