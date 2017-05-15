namespace Lab2Ballz
{
    partial class HighScore
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
            this.UI_TBname = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.UI_Bok = new System.Windows.Forms.Button();
            this.UI_Bcan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UI_TBname
            // 
            this.UI_TBname.Location = new System.Drawing.Point(85, 12);
            this.UI_TBname.Name = "UI_TBname";
            this.UI_TBname.Size = new System.Drawing.Size(195, 20);
            this.UI_TBname.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Player Name";
            // 
            // UI_Bok
            // 
            this.UI_Bok.Location = new System.Drawing.Point(12, 38);
            this.UI_Bok.Name = "UI_Bok";
            this.UI_Bok.Size = new System.Drawing.Size(75, 23);
            this.UI_Bok.TabIndex = 3;
            this.UI_Bok.Text = "OK";
            this.UI_Bok.UseVisualStyleBackColor = true;
            this.UI_Bok.Click += new System.EventHandler(this.UI_Bok_Click);
            // 
            // UI_Bcan
            // 
            this.UI_Bcan.Location = new System.Drawing.Point(205, 38);
            this.UI_Bcan.Name = "UI_Bcan";
            this.UI_Bcan.Size = new System.Drawing.Size(75, 23);
            this.UI_Bcan.TabIndex = 4;
            this.UI_Bcan.Text = "Cancel";
            this.UI_Bcan.UseVisualStyleBackColor = true;
            this.UI_Bcan.Click += new System.EventHandler(this.UI_Bcan_Click);
            // 
            // HighScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 67);
            this.Controls.Add(this.UI_Bcan);
            this.Controls.Add(this.UI_Bok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UI_TBname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "HighScore";
            this.Text = "High Score";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UI_TBname;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UI_Bok;
        private System.Windows.Forms.Button UI_Bcan;
    }
}