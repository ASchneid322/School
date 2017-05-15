namespace CMPE2800_MultiDraw_JKrueckl_ASchneider
{
    partial class Form_Main
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
            this.UI_S_Info = new System.Windows.Forms.StatusStrip();
            this.UI_S_Lb_ConnectionState = new System.Windows.Forms.ToolStripStatusLabel();
            this.UI_S_Lb_Color = new System.Windows.Forms.ToolStripStatusLabel();
            this.UI_S_Lb_Thickness = new System.Windows.Forms.ToolStripStatusLabel();
            this.UI_S_Lb_Alpha = new System.Windows.Forms.ToolStripStatusLabel();
            this.UI_S_Lb_FramesRX = new System.Windows.Forms.ToolStripStatusLabel();
            this.UI_S_Lb_Fragments = new System.Windows.Forms.ToolStripStatusLabel();
            this.UI_S_Lb_DestackAVG = new System.Windows.Forms.ToolStripStatusLabel();
            this.UI_S_Lb_BytesRX = new System.Windows.Forms.ToolStripStatusLabel();
            this.DLG_Color = new System.Windows.Forms.ColorDialog();
            this.UI_S_Info.SuspendLayout();
            this.SuspendLayout();
            // 
            // UI_S_Info
            // 
            this.UI_S_Info.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.UI_S_Info.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UI_S_Lb_ConnectionState,
            this.UI_S_Lb_Color,
            this.UI_S_Lb_Thickness,
            this.UI_S_Lb_Alpha,
            this.UI_S_Lb_FramesRX,
            this.UI_S_Lb_Fragments,
            this.UI_S_Lb_DestackAVG,
            this.UI_S_Lb_BytesRX});
            this.UI_S_Info.Location = new System.Drawing.Point(0, 491);
            this.UI_S_Info.Name = "UI_S_Info";
            this.UI_S_Info.Size = new System.Drawing.Size(733, 22);
            this.UI_S_Info.TabIndex = 0;
            this.UI_S_Info.Text = "UI_S_Data";
            // 
            // UI_S_Lb_ConnectionState
            // 
            this.UI_S_Lb_ConnectionState.IsLink = true;
            this.UI_S_Lb_ConnectionState.Name = "UI_S_Lb_ConnectionState";
            this.UI_S_Lb_ConnectionState.Size = new System.Drawing.Size(52, 17);
            this.UI_S_Lb_ConnectionState.Text = "Connect";
            this.UI_S_Lb_ConnectionState.ToolTipText = "Click to connect / disconnect\r\n";
            this.UI_S_Lb_ConnectionState.Click += new System.EventHandler(this.UI_S_Lb_ConnectionState_Click);
            // 
            // UI_S_Lb_Color
            // 
            this.UI_S_Lb_Color.Name = "UI_S_Lb_Color";
            this.UI_S_Lb_Color.Size = new System.Drawing.Size(36, 17);
            this.UI_S_Lb_Color.Text = "Color";
            this.UI_S_Lb_Color.Click += new System.EventHandler(this.UI_S_Lb_Color_Click);
            // 
            // UI_S_Lb_Thickness
            // 
            this.UI_S_Lb_Thickness.Name = "UI_S_Lb_Thickness";
            this.UI_S_Lb_Thickness.Size = new System.Drawing.Size(74, 17);
            this.UI_S_Lb_Thickness.Text = "Thickness : 1";
            // 
            // UI_S_Lb_Alpha
            // 
            this.UI_S_Lb_Alpha.Name = "UI_S_Lb_Alpha";
            this.UI_S_Lb_Alpha.Size = new System.Drawing.Size(65, 17);
            this.UI_S_Lb_Alpha.Text = "Alpha : 255";
            // 
            // UI_S_Lb_FramesRX
            // 
            this.UI_S_Lb_FramesRX.Name = "UI_S_Lb_FramesRX";
            this.UI_S_Lb_FramesRX.Size = new System.Drawing.Size(91, 17);
            this.UI_S_Lb_FramesRX.Text = "Frames Rx\'ed : 0";
            // 
            // UI_S_Lb_Fragments
            // 
            this.UI_S_Lb_Fragments.Name = "UI_S_Lb_Fragments";
            this.UI_S_Lb_Fragments.Size = new System.Drawing.Size(78, 17);
            this.UI_S_Lb_Fragments.Text = "Fragments : 0";
            // 
            // UI_S_Lb_DestackAVG
            // 
            this.UI_S_Lb_DestackAVG.Name = "UI_S_Lb_DestackAVG";
            this.UI_S_Lb_DestackAVG.Size = new System.Drawing.Size(102, 17);
            this.UI_S_Lb_DestackAVG.Text = "Destack Avg : 0.00";
            // 
            // UI_S_Lb_BytesRX
            // 
            this.UI_S_Lb_BytesRX.Name = "UI_S_Lb_BytesRX";
            this.UI_S_Lb_BytesRX.Size = new System.Drawing.Size(98, 17);
            this.UI_S_Lb_BytesRX.Text = "Bytes RX\'ed : 0.00";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 513);
            this.Controls.Add(this.UI_S_Info);
            this.Name = "Form_Main";
            this.Text = "MultiDraw";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_Main_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_Main_KeyUp);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_Main_MouseMove);
            this.UI_S_Info.ResumeLayout(false);
            this.UI_S_Info.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip UI_S_Info;
        private System.Windows.Forms.ToolStripStatusLabel UI_S_Lb_ConnectionState;
        private System.Windows.Forms.ToolStripStatusLabel UI_S_Lb_Color;
        private System.Windows.Forms.ToolStripStatusLabel UI_S_Lb_Thickness;
        private System.Windows.Forms.ToolStripStatusLabel UI_S_Lb_FramesRX;
        private System.Windows.Forms.ToolStripStatusLabel UI_S_Lb_Fragments;
        private System.Windows.Forms.ToolStripStatusLabel UI_S_Lb_DestackAVG;
        private System.Windows.Forms.ToolStripStatusLabel UI_S_Lb_BytesRX;
        private System.Windows.Forms.ColorDialog DLG_Color;
        private System.Windows.Forms.ToolStripStatusLabel UI_S_Lb_Alpha;
    }
}

