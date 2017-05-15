namespace CMPE2800_MultiDraw_JKrueckl_ASchneider
{
    partial class DLG_Connect
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
            this.label1 = new System.Windows.Forms.Label();
            this.UI_TB_Address = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UI_TB_Port = new System.Windows.Forms.TextBox();
            this.UI_L_Status = new System.Windows.Forms.Label();
            this.UI_B_Connect = new System.Windows.Forms.Button();
            this.UI_B_Cancel = new System.Windows.Forms.Button();
            this.UI_Tim_Timout = new System.Windows.Forms.Timer(this.components);
            this.UI_PB_Connecting = new System.Windows.Forms.ProgressBar();
            this.UI_L_Timeout = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address: ";
            // 
            // UI_TB_Address
            // 
            this.UI_TB_Address.Location = new System.Drawing.Point(70, 10);
            this.UI_TB_Address.Name = "UI_TB_Address";
            this.UI_TB_Address.Size = new System.Drawing.Size(100, 20);
            this.UI_TB_Address.TabIndex = 1;
            this.UI_TB_Address.Text = "bits.net.nait.ca";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // UI_TB_Port
            // 
            this.UI_TB_Port.Location = new System.Drawing.Point(255, 11);
            this.UI_TB_Port.Name = "UI_TB_Port";
            this.UI_TB_Port.Size = new System.Drawing.Size(100, 20);
            this.UI_TB_Port.TabIndex = 3;
            this.UI_TB_Port.Text = "1666";
            // 
            // UI_L_Status
            // 
            this.UI_L_Status.AutoSize = true;
            this.UI_L_Status.Location = new System.Drawing.Point(179, 52);
            this.UI_L_Status.Name = "UI_L_Status";
            this.UI_L_Status.Size = new System.Drawing.Size(37, 13);
            this.UI_L_Status.TabIndex = 4;
            this.UI_L_Status.Text = "Status";
            // 
            // UI_B_Connect
            // 
            this.UI_B_Connect.Location = new System.Drawing.Point(235, 158);
            this.UI_B_Connect.Name = "UI_B_Connect";
            this.UI_B_Connect.Size = new System.Drawing.Size(75, 23);
            this.UI_B_Connect.TabIndex = 5;
            this.UI_B_Connect.Text = "Connect";
            this.UI_B_Connect.UseVisualStyleBackColor = true;
            this.UI_B_Connect.Click += new System.EventHandler(this.UI_B_Connect_Click);
            // 
            // UI_B_Cancel
            // 
            this.UI_B_Cancel.Location = new System.Drawing.Point(337, 158);
            this.UI_B_Cancel.Name = "UI_B_Cancel";
            this.UI_B_Cancel.Size = new System.Drawing.Size(75, 23);
            this.UI_B_Cancel.TabIndex = 6;
            this.UI_B_Cancel.Text = "Cancel";
            this.UI_B_Cancel.UseVisualStyleBackColor = true;
            this.UI_B_Cancel.Click += new System.EventHandler(this.UI_B_Cancel_Click);
            // 
            // UI_Tim_Timout
            // 
            this.UI_Tim_Timout.Tick += new System.EventHandler(this.UI_Tim_Timout_Tick);
            // 
            // UI_PB_Connecting
            // 
            this.UI_PB_Connecting.Enabled = false;
            this.UI_PB_Connecting.Location = new System.Drawing.Point(67, 107);
            this.UI_PB_Connecting.Maximum = 180;
            this.UI_PB_Connecting.Name = "UI_PB_Connecting";
            this.UI_PB_Connecting.Size = new System.Drawing.Size(224, 20);
            this.UI_PB_Connecting.Step = 1;
            this.UI_PB_Connecting.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.UI_PB_Connecting.TabIndex = 16;
            // 
            // UI_L_Timeout
            // 
            this.UI_L_Timeout.AutoSize = true;
            this.UI_L_Timeout.BackColor = System.Drawing.Color.Transparent;
            this.UI_L_Timeout.Location = new System.Drawing.Point(13, 114);
            this.UI_L_Timeout.Name = "UI_L_Timeout";
            this.UI_L_Timeout.Size = new System.Drawing.Size(48, 13);
            this.UI_L_Timeout.TabIndex = 17;
            this.UI_L_Timeout.Text = "Timeout:";
            // 
            // DLG_Connect
            // 
            this.AcceptButton = this.UI_B_Connect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 206);
            this.Controls.Add(this.UI_L_Timeout);
            this.Controls.Add(this.UI_PB_Connecting);
            this.Controls.Add(this.UI_B_Cancel);
            this.Controls.Add(this.UI_B_Connect);
            this.Controls.Add(this.UI_L_Status);
            this.Controls.Add(this.UI_TB_Port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UI_TB_Address);
            this.Controls.Add(this.label1);
            this.Name = "DLG_Connect";
            this.Text = "Connect To Server";
            this.Load += new System.EventHandler(this.DLG_Connect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UI_TB_Address;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UI_TB_Port;
        private System.Windows.Forms.Label UI_L_Status;
        private System.Windows.Forms.Button UI_B_Connect;
        private System.Windows.Forms.Button UI_B_Cancel;
        private System.Windows.Forms.Timer UI_Tim_Timout;
        private System.Windows.Forms.ProgressBar UI_PB_Connecting;
        private System.Windows.Forms.Label UI_L_Timeout;
    }
}