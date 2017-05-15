namespace Lab2Ballz
{
    partial class Score
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
            this.UI_Lt = new System.Windows.Forms.Label();
            this.UI_Lscore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UI_Lt
            // 
            this.UI_Lt.AutoSize = true;
            this.UI_Lt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_Lt.Location = new System.Drawing.Point(2, 9);
            this.UI_Lt.Name = "UI_Lt";
            this.UI_Lt.Size = new System.Drawing.Size(82, 29);
            this.UI_Lt.TabIndex = 0;
            this.UI_Lt.Text = "Score";
            // 
            // UI_Lscore
            // 
            this.UI_Lscore.AutoSize = true;
            this.UI_Lscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_Lscore.Location = new System.Drawing.Point(90, 12);
            this.UI_Lscore.Name = "UI_Lscore";
            this.UI_Lscore.Size = new System.Drawing.Size(156, 25);
            this.UI_Lscore.TabIndex = 1;
            this.UI_Lscore.Text = "000000000000";
            // 
            // Score
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 51);
            this.Controls.Add(this.UI_Lscore);
            this.Controls.Add(this.UI_Lt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Score";
            this.Text = "Score";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Score_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UI_Lt;
        private System.Windows.Forms.Label UI_Lscore;
    }
}