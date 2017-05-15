namespace Lab2Ballz
{
    partial class Select
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
            this.UI_Reasy = new System.Windows.Forms.RadioButton();
            this.UI_Rmed = new System.Windows.Forms.RadioButton();
            this.UI_Rhard = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UI_Bok = new System.Windows.Forms.Button();
            this.UI_Bcancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UI_Reasy
            // 
            this.UI_Reasy.AutoSize = true;
            this.UI_Reasy.Checked = true;
            this.UI_Reasy.Location = new System.Drawing.Point(9, 22);
            this.UI_Reasy.Name = "UI_Reasy";
            this.UI_Reasy.Size = new System.Drawing.Size(48, 17);
            this.UI_Reasy.TabIndex = 0;
            this.UI_Reasy.TabStop = true;
            this.UI_Reasy.Text = "Easy";
            this.UI_Reasy.UseVisualStyleBackColor = true;
            // 
            // UI_Rmed
            // 
            this.UI_Rmed.AutoSize = true;
            this.UI_Rmed.Location = new System.Drawing.Point(9, 45);
            this.UI_Rmed.Name = "UI_Rmed";
            this.UI_Rmed.Size = new System.Drawing.Size(62, 17);
            this.UI_Rmed.TabIndex = 1;
            this.UI_Rmed.TabStop = true;
            this.UI_Rmed.Text = "Medium";
            this.UI_Rmed.UseVisualStyleBackColor = true;
            // 
            // UI_Rhard
            // 
            this.UI_Rhard.AutoSize = true;
            this.UI_Rhard.Location = new System.Drawing.Point(9, 68);
            this.UI_Rhard.Name = "UI_Rhard";
            this.UI_Rhard.Size = new System.Drawing.Size(48, 17);
            this.UI_Rhard.TabIndex = 2;
            this.UI_Rhard.TabStop = true;
            this.UI_Rhard.Text = "Hard";
            this.UI_Rhard.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UI_Rhard);
            this.groupBox1.Controls.Add(this.UI_Rmed);
            this.groupBox1.Controls.Add(this.UI_Reasy);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 91);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Difficulty";
            // 
            // UI_Bok
            // 
            this.UI_Bok.Location = new System.Drawing.Point(12, 109);
            this.UI_Bok.Name = "UI_Bok";
            this.UI_Bok.Size = new System.Drawing.Size(75, 23);
            this.UI_Bok.TabIndex = 4;
            this.UI_Bok.Text = "OK";
            this.UI_Bok.UseVisualStyleBackColor = true;
            this.UI_Bok.Click += new System.EventHandler(this.UI_Bok_Click);
            // 
            // UI_Bcancel
            // 
            this.UI_Bcancel.Location = new System.Drawing.Point(93, 109);
            this.UI_Bcancel.Name = "UI_Bcancel";
            this.UI_Bcancel.Size = new System.Drawing.Size(75, 23);
            this.UI_Bcancel.TabIndex = 5;
            this.UI_Bcancel.Text = "Cancel";
            this.UI_Bcancel.UseVisualStyleBackColor = true;
            this.UI_Bcancel.Click += new System.EventHandler(this.UI_Bcancel_Click);
            // 
            // Select
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(182, 139);
            this.Controls.Add(this.UI_Bcancel);
            this.Controls.Add(this.UI_Bok);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Select";
            this.Text = "Select Difficulty";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton UI_Reasy;
        private System.Windows.Forms.RadioButton UI_Rmed;
        private System.Windows.Forms.RadioButton UI_Rhard;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button UI_Bok;
        private System.Windows.Forms.Button UI_Bcancel;
    }
}