namespace BasicPuzzle {
    partial class Form1 {
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
            this.draggablePanel = new System.Windows.Forms.Panel();
            this.resultPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // draggablePanel
            // 
            this.draggablePanel.AutoSize = true;
            this.draggablePanel.Location = new System.Drawing.Point(13, 13);
            this.draggablePanel.Name = "draggablePanel";
            this.draggablePanel.Size = new System.Drawing.Size(200, 100);
            this.draggablePanel.TabIndex = 0;
            // 
            // resultPanel
            // 
            this.resultPanel.AllowDrop = true;
            this.resultPanel.AutoSize = true;
            this.resultPanel.Location = new System.Drawing.Point(417, 13);
            this.resultPanel.Name = "resultPanel";
            this.resultPanel.Size = new System.Drawing.Size(353, 327);
            this.resultPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(414, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Húzza a képeket ebbe a felső dobozba";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resultPanel);
            this.Controls.Add(this.draggablePanel);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Puzzle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel draggablePanel;
        private System.Windows.Forms.Panel resultPanel;
        private System.Windows.Forms.Label label1;
    }
}

