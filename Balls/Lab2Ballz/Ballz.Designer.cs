namespace Lab2Ballz
{
    partial class Ballz
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
            this.UI_Sscore = new System.Windows.Forms.CheckBox();
            this.UI_Sanispeed = new System.Windows.Forms.CheckBox();
            this.UI_Bplay = new System.Windows.Forms.Button();
            this.UI_timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // UI_Sscore
            // 
            this.UI_Sscore.AutoSize = true;
            this.UI_Sscore.Location = new System.Drawing.Point(12, 12);
            this.UI_Sscore.Name = "UI_Sscore";
            this.UI_Sscore.Size = new System.Drawing.Size(84, 17);
            this.UI_Sscore.TabIndex = 0;
            this.UI_Sscore.Text = "Show Score";
            this.UI_Sscore.UseVisualStyleBackColor = true;
            this.UI_Sscore.CheckedChanged += new System.EventHandler(this.UI_Sscore_CheckedChanged);
            // 
            // UI_Sanispeed
            // 
            this.UI_Sanispeed.AutoSize = true;
            this.UI_Sanispeed.Location = new System.Drawing.Point(12, 35);
            this.UI_Sanispeed.Name = "UI_Sanispeed";
            this.UI_Sanispeed.Size = new System.Drawing.Size(136, 17);
            this.UI_Sanispeed.TabIndex = 1;
            this.UI_Sanispeed.Text = "Show Animation Speed";
            this.UI_Sanispeed.UseVisualStyleBackColor = true;
            this.UI_Sanispeed.CheckedChanged += new System.EventHandler(this.UI_Sanispeed_CheckedChanged);
            // 
            // UI_Bplay
            // 
            this.UI_Bplay.Location = new System.Drawing.Point(91, 58);
            this.UI_Bplay.Name = "UI_Bplay";
            this.UI_Bplay.Size = new System.Drawing.Size(75, 23);
            this.UI_Bplay.TabIndex = 2;
            this.UI_Bplay.Text = "Play";
            this.UI_Bplay.UseVisualStyleBackColor = true;
            this.UI_Bplay.Click += new System.EventHandler(this.UI_Bplay_Click);
            // 
            // UI_timer
            // 
            this.UI_timer.Tick += new System.EventHandler(this.UI_timer_Tick);
            // 
            // Ballz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 93);
            this.Controls.Add(this.UI_Bplay);
            this.Controls.Add(this.UI_Sanispeed);
            this.Controls.Add(this.UI_Sscore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Ballz";
            this.Text = "CMPE1600 Lab2 - Ballz";
            this.Load += new System.EventHandler(this.Ballz_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox UI_Sscore;
        private System.Windows.Forms.CheckBox UI_Sanispeed;
        private System.Windows.Forms.Button UI_Bplay;
        private System.Windows.Forms.Timer UI_timer;
    }
}

