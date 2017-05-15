namespace CMPE2800_MultiDraw_Server
{
    partial class MDClient
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
            this.LB_ClientInfo = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // LB_ClientInfo
            // 
            this.LB_ClientInfo.FormattingEnabled = true;
            this.LB_ClientInfo.Location = new System.Drawing.Point(13, 13);
            this.LB_ClientInfo.Name = "LB_ClientInfo";
            this.LB_ClientInfo.Size = new System.Drawing.Size(674, 394);
            this.LB_ClientInfo.TabIndex = 0;
            // 
            // MDClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 427);
            this.Controls.Add(this.LB_ClientInfo);
            this.Name = "MDClient";
            this.Text = "MultiDraw Client";
            this.Load += new System.EventHandler(this.MDClient_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LB_ClientInfo;
    }
}

