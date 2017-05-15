namespace ICA6_FunLine
{
    partial class FunLineForm
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
            this.UI_Bpopulate = new System.Windows.Forms.Button();
            this.UI_BsortLenA = new System.Windows.Forms.Button();
            this.UI_BsortLenD = new System.Windows.Forms.Button();
            this.UI_BsortWA = new System.Windows.Forms.Button();
            this.UI_sortWidthHeight = new System.Windows.Forms.Button();
            this.UI_TBlinehighlight = new System.Windows.Forms.TrackBar();
            this.UI_BRemoveLongLine = new System.Windows.Forms.Button();
            this.UI_Rstubbyline = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UI_TBlinehighlight)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_Bpopulate
            // 
            this.UI_Bpopulate.Location = new System.Drawing.Point(12, 12);
            this.UI_Bpopulate.Name = "UI_Bpopulate";
            this.UI_Bpopulate.Size = new System.Drawing.Size(75, 23);
            this.UI_Bpopulate.TabIndex = 0;
            this.UI_Bpopulate.Text = "Populate";
            this.UI_Bpopulate.UseVisualStyleBackColor = true;
            this.UI_Bpopulate.Click += new System.EventHandler(this.UI_Bpopulate_Click);
            // 
            // UI_BsortLenA
            // 
            this.UI_BsortLenA.Location = new System.Drawing.Point(93, 12);
            this.UI_BsortLenA.Name = "UI_BsortLenA";
            this.UI_BsortLenA.Size = new System.Drawing.Size(140, 23);
            this.UI_BsortLenA.TabIndex = 1;
            this.UI_BsortLenA.Text = "Sort Length Ascending";
            this.UI_BsortLenA.UseVisualStyleBackColor = true;
            this.UI_BsortLenA.Click += new System.EventHandler(this.UI_BsortLenA_Click);
            // 
            // UI_BsortLenD
            // 
            this.UI_BsortLenD.Location = new System.Drawing.Point(93, 41);
            this.UI_BsortLenD.Name = "UI_BsortLenD";
            this.UI_BsortLenD.Size = new System.Drawing.Size(140, 23);
            this.UI_BsortLenD.TabIndex = 2;
            this.UI_BsortLenD.Text = "Sort Length Descending";
            this.UI_BsortLenD.UseVisualStyleBackColor = true;
            this.UI_BsortLenD.Click += new System.EventHandler(this.UI_BsortLenD_Click);
            // 
            // UI_BsortWA
            // 
            this.UI_BsortWA.Location = new System.Drawing.Point(93, 70);
            this.UI_BsortWA.Name = "UI_BsortWA";
            this.UI_BsortWA.Size = new System.Drawing.Size(140, 23);
            this.UI_BsortWA.TabIndex = 3;
            this.UI_BsortWA.Text = "Sort Width Ascending";
            this.UI_BsortWA.UseVisualStyleBackColor = true;
            this.UI_BsortWA.Click += new System.EventHandler(this.UI_BsortWA_Click);
            // 
            // UI_sortWidthHeight
            // 
            this.UI_sortWidthHeight.Location = new System.Drawing.Point(93, 99);
            this.UI_sortWidthHeight.Name = "UI_sortWidthHeight";
            this.UI_sortWidthHeight.Size = new System.Drawing.Size(140, 23);
            this.UI_sortWidthHeight.TabIndex = 4;
            this.UI_sortWidthHeight.Text = "Sort by Width and Height";
            this.UI_sortWidthHeight.UseVisualStyleBackColor = true;
            this.UI_sortWidthHeight.Click += new System.EventHandler(this.UI_sortWidthHeight_Click);
            // 
            // UI_TBlinehighlight
            // 
            this.UI_TBlinehighlight.Location = new System.Drawing.Point(12, 128);
            this.UI_TBlinehighlight.Name = "UI_TBlinehighlight";
            this.UI_TBlinehighlight.Size = new System.Drawing.Size(348, 45);
            this.UI_TBlinehighlight.TabIndex = 5;
            this.UI_TBlinehighlight.TickFrequency = 0;
            this.UI_TBlinehighlight.Scroll += new System.EventHandler(this.UI_TBlinehighlight_Scroll);
            // 
            // UI_BRemoveLongLine
            // 
            this.UI_BRemoveLongLine.Location = new System.Drawing.Point(239, 41);
            this.UI_BRemoveLongLine.Name = "UI_BRemoveLongLine";
            this.UI_BRemoveLongLine.Size = new System.Drawing.Size(123, 23);
            this.UI_BRemoveLongLine.TabIndex = 6;
            this.UI_BRemoveLongLine.Text = "Remove Long Lines";
            this.UI_BRemoveLongLine.UseVisualStyleBackColor = true;
            this.UI_BRemoveLongLine.Click += new System.EventHandler(this.UI_BRemoveLongLine_Click);
            // 
            // UI_Rstubbyline
            // 
            this.UI_Rstubbyline.Location = new System.Drawing.Point(239, 12);
            this.UI_Rstubbyline.Name = "UI_Rstubbyline";
            this.UI_Rstubbyline.Size = new System.Drawing.Size(123, 23);
            this.UI_Rstubbyline.TabIndex = 7;
            this.UI_Rstubbyline.Text = "Remove Stubby Lines";
            this.UI_Rstubbyline.UseVisualStyleBackColor = true;
            this.UI_Rstubbyline.Click += new System.EventHandler(this.UI_Rstubbyline_Click);
            // 
            // FunLineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 172);
            this.Controls.Add(this.UI_Rstubbyline);
            this.Controls.Add(this.UI_BRemoveLongLine);
            this.Controls.Add(this.UI_TBlinehighlight);
            this.Controls.Add(this.UI_sortWidthHeight);
            this.Controls.Add(this.UI_BsortWA);
            this.Controls.Add(this.UI_BsortLenD);
            this.Controls.Add(this.UI_BsortLenA);
            this.Controls.Add(this.UI_Bpopulate);
            this.Name = "FunLineForm";
            this.Text = "ICA6-FunLine";
            ((System.ComponentModel.ISupportInitialize)(this.UI_TBlinehighlight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UI_Bpopulate;
        private System.Windows.Forms.Button UI_BsortLenA;
        private System.Windows.Forms.Button UI_BsortLenD;
        private System.Windows.Forms.Button UI_BsortWA;
        private System.Windows.Forms.Button UI_sortWidthHeight;
        private System.Windows.Forms.TrackBar UI_TBlinehighlight;
        private System.Windows.Forms.Button UI_BRemoveLongLine;
        private System.Windows.Forms.Button UI_Rstubbyline;
    }
}

