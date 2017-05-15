namespace Lab3___PolyRel
{
    partial class PolyRel
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
            this.UI_Tshapes = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // UI_Tshapes
            // 
            this.UI_Tshapes.Enabled = true;
            this.UI_Tshapes.Interval = 25;
            this.UI_Tshapes.Tick += new System.EventHandler(this.UI_Tshapes_Tick);
            // 
            // PolyRel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "PolyRel";
            this.Text = "Lab 01-PolyRel";
            this.Load += new System.EventHandler(this.PolyRel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer UI_Tshapes;
    }
}

