namespace Airforce_Project
{
    partial class frmReportAnalysis
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
            this.btnExit = new System.Windows.Forms.Button();
            this.Title6 = new System.Windows.Forms.Label();
            this.Title5 = new System.Windows.Forms.Label();
            this.Title4 = new System.Windows.Forms.Label();
            this.Title3 = new System.Windows.Forms.Label();
            this.Title2 = new System.Windows.Forms.Label();
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.Title0 = new System.Windows.Forms.Label();
            this.rtbDamageAnalysis = new System.Windows.Forms.RichTextBox();
            this.rtbObstacleDetected = new System.Windows.Forms.RichTextBox();
            this.rtbStatsBeforeFlight = new System.Windows.Forms.RichTextBox();
            this.rtbDescriptionOfStrike = new System.Windows.Forms.RichTextBox();
            this.rtbObstacleAvoided = new System.Windows.Forms.RichTextBox();
            this.rtbStatsAfterFlight = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Gray;
            this.btnExit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnExit.Location = new System.Drawing.Point(604, 642);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(116, 50);
            this.btnExit.TabIndex = 27;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Title6
            // 
            this.Title6.AutoSize = true;
            this.Title6.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title6.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.Title6.Location = new System.Drawing.Point(725, 478);
            this.Title6.Name = "Title6";
            this.Title6.Size = new System.Drawing.Size(292, 23);
            this.Title6.TabIndex = 25;
            this.Title6.Text = "Aircraft Stats After Flight:";
            // 
            // Title5
            // 
            this.Title5.AutoSize = true;
            this.Title5.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title5.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.Title5.Location = new System.Drawing.Point(65, 478);
            this.Title5.Name = "Title5";
            this.Title5.Size = new System.Drawing.Size(308, 23);
            this.Title5.TabIndex = 23;
            this.Title5.Text = "Aircraft Stats Before Flight:";
            // 
            // Title4
            // 
            this.Title4.AutoSize = true;
            this.Title4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title4.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.Title4.Location = new System.Drawing.Point(727, 300);
            this.Title4.Name = "Title4";
            this.Title4.Size = new System.Drawing.Size(215, 23);
            this.Title4.TabIndex = 21;
            this.Title4.Text = "Obstacles Avoided:";
            // 
            // Title3
            // 
            this.Title3.AutoSize = true;
            this.Title3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title3.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.Title3.Location = new System.Drawing.Point(65, 300);
            this.Title3.Name = "Title3";
            this.Title3.Size = new System.Drawing.Size(215, 23);
            this.Title3.TabIndex = 19;
            this.Title3.Text = "Obstacle Detected:";
            // 
            // Title2
            // 
            this.Title2.AutoSize = true;
            this.Title2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title2.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.Title2.Location = new System.Drawing.Point(727, 135);
            this.Title2.Name = "Title2";
            this.Title2.Size = new System.Drawing.Size(238, 23);
            this.Title2.TabIndex = 17;
            this.Title2.Text = "Description of strike:";
            // 
            // lblTitle1
            // 
            this.lblTitle1.AutoSize = true;
            this.lblTitle1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle1.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblTitle1.Location = new System.Drawing.Point(65, 135);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(337, 23);
            this.lblTitle1.TabIndex = 15;
            this.lblTitle1.Text = "Damage analysis and success:";
            // 
            // Title0
            // 
            this.Title0.AutoSize = true;
            this.Title0.Font = new System.Drawing.Font("Sitka Heading", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title0.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.Title0.Location = new System.Drawing.Point(539, 23);
            this.Title0.Name = "Title0";
            this.Title0.Size = new System.Drawing.Size(233, 92);
            this.Title0.TabIndex = 14;
            this.Title0.Text = "Report";
            // 
            // rtbDamageAnalysis
            // 
            this.rtbDamageAnalysis.BackColor = System.Drawing.Color.Gray;
            this.rtbDamageAnalysis.Location = new System.Drawing.Point(69, 174);
            this.rtbDamageAnalysis.Name = "rtbDamageAnalysis";
            this.rtbDamageAnalysis.Size = new System.Drawing.Size(525, 96);
            this.rtbDamageAnalysis.TabIndex = 29;
            this.rtbDamageAnalysis.Text = "";
            // 
            // rtbObstacleDetected
            // 
            this.rtbObstacleDetected.BackColor = System.Drawing.Color.Gray;
            this.rtbObstacleDetected.Location = new System.Drawing.Point(69, 339);
            this.rtbObstacleDetected.Name = "rtbObstacleDetected";
            this.rtbObstacleDetected.Size = new System.Drawing.Size(525, 96);
            this.rtbObstacleDetected.TabIndex = 30;
            this.rtbObstacleDetected.Text = "";
            // 
            // rtbStatsBeforeFlight
            // 
            this.rtbStatsBeforeFlight.BackColor = System.Drawing.Color.Gray;
            this.rtbStatsBeforeFlight.Location = new System.Drawing.Point(69, 522);
            this.rtbStatsBeforeFlight.Name = "rtbStatsBeforeFlight";
            this.rtbStatsBeforeFlight.Size = new System.Drawing.Size(525, 96);
            this.rtbStatsBeforeFlight.TabIndex = 31;
            this.rtbStatsBeforeFlight.Text = "";
            // 
            // rtbDescriptionOfStrike
            // 
            this.rtbDescriptionOfStrike.BackColor = System.Drawing.Color.Gray;
            this.rtbDescriptionOfStrike.Location = new System.Drawing.Point(729, 174);
            this.rtbDescriptionOfStrike.Name = "rtbDescriptionOfStrike";
            this.rtbDescriptionOfStrike.Size = new System.Drawing.Size(525, 96);
            this.rtbDescriptionOfStrike.TabIndex = 32;
            this.rtbDescriptionOfStrike.Text = "";
            // 
            // rtbObstacleAvoided
            // 
            this.rtbObstacleAvoided.BackColor = System.Drawing.Color.Gray;
            this.rtbObstacleAvoided.Location = new System.Drawing.Point(729, 339);
            this.rtbObstacleAvoided.Name = "rtbObstacleAvoided";
            this.rtbObstacleAvoided.Size = new System.Drawing.Size(525, 96);
            this.rtbObstacleAvoided.TabIndex = 33;
            this.rtbObstacleAvoided.Text = "";
            // 
            // rtbStatsAfterFlight
            // 
            this.rtbStatsAfterFlight.BackColor = System.Drawing.Color.Gray;
            this.rtbStatsAfterFlight.Location = new System.Drawing.Point(729, 522);
            this.rtbStatsAfterFlight.Name = "rtbStatsAfterFlight";
            this.rtbStatsAfterFlight.Size = new System.Drawing.Size(525, 96);
            this.rtbStatsAfterFlight.TabIndex = 34;
            this.rtbStatsAfterFlight.Text = "";
            // 
            // frmReportAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1318, 707);
            this.Controls.Add(this.rtbStatsAfterFlight);
            this.Controls.Add(this.rtbObstacleAvoided);
            this.Controls.Add(this.rtbDescriptionOfStrike);
            this.Controls.Add(this.rtbStatsBeforeFlight);
            this.Controls.Add(this.rtbObstacleDetected);
            this.Controls.Add(this.rtbDamageAnalysis);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.Title6);
            this.Controls.Add(this.Title5);
            this.Controls.Add(this.Title4);
            this.Controls.Add(this.Title3);
            this.Controls.Add(this.Title2);
            this.Controls.Add(this.lblTitle1);
            this.Controls.Add(this.Title0);
            this.Name = "frmReportAnalysis";
            this.Text = "ReportAnalysis";
            this.Load += new System.EventHandler(this.frmReportAnalysis_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label Title6;
        private System.Windows.Forms.Label Title5;
        private System.Windows.Forms.Label Title4;
        private System.Windows.Forms.Label Title3;
        private System.Windows.Forms.Label Title2;
        private System.Windows.Forms.Label lblTitle1;
        private System.Windows.Forms.Label Title0;
        private System.Windows.Forms.RichTextBox rtbDamageAnalysis;
        private System.Windows.Forms.RichTextBox rtbObstacleDetected;
        private System.Windows.Forms.RichTextBox rtbStatsBeforeFlight;
        private System.Windows.Forms.RichTextBox rtbDescriptionOfStrike;
        private System.Windows.Forms.RichTextBox rtbObstacleAvoided;
        private System.Windows.Forms.RichTextBox rtbStatsAfterFlight;
    }
}