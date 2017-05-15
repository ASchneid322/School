namespace PropProp
{
    partial class PropProp
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
            this.UI_Btimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // UI_Btimer
            // 
            this.UI_Btimer.Enabled = true;
            this.UI_Btimer.Interval = 50;
            this.UI_Btimer.Tick += new System.EventHandler(this.UI_Btimer_Tick);
            // 
            // PropProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "PropProp";
            this.Text = "PropProp";
            this.Load += new System.EventHandler(this.PropProp_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer UI_Btimer;
    }
}

