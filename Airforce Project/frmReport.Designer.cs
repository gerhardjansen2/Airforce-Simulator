namespace ProjectFormReport
{
    partial class frmReport
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
            this.Title0 = new System.Windows.Forms.Label();
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.lvDamageAnalysis = new System.Windows.Forms.ListView();
            this.Title2 = new System.Windows.Forms.Label();
            this.lvDescriptionOfStrike = new System.Windows.Forms.ListView();
            this.Title3 = new System.Windows.Forms.Label();
            this.lvObstaclesDetected = new System.Windows.Forms.ListView();
            this.Title4 = new System.Windows.Forms.Label();
            this.lvObstaclesAvoided = new System.Windows.Forms.ListView();
            this.Title5 = new System.Windows.Forms.Label();
            this.lvStatsBeforeFlight = new System.Windows.Forms.ListView();
            this.lvStatsAfterFlight = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Title0
            // 
            this.Title0.AutoSize = true;
            this.Title0.Font = new System.Drawing.Font("Sitka Heading", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title0.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.Title0.Location = new System.Drawing.Point(522, 9);
            this.Title0.Name = "Title0";
            this.Title0.Size = new System.Drawing.Size(233, 92);
            this.Title0.TabIndex = 0;
            this.Title0.Text = "Report";
            // 
            // lblTitle1
            // 
            this.lblTitle1.AutoSize = true;
            this.lblTitle1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle1.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblTitle1.Location = new System.Drawing.Point(63, 129);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(337, 23);
            this.lblTitle1.TabIndex = 1;
            this.lblTitle1.Text = "Damage analysis and success:";
            // 
            // lvDamageAnalysis
            // 
            this.lvDamageAnalysis.BackColor = System.Drawing.Color.Gray;
            this.lvDamageAnalysis.HideSelection = false;
            this.lvDamageAnalysis.Location = new System.Drawing.Point(67, 168);
            this.lvDamageAnalysis.Name = "lvDamageAnalysis";
            this.lvDamageAnalysis.Size = new System.Drawing.Size(525, 97);
            this.lvDamageAnalysis.TabIndex = 2;
            this.lvDamageAnalysis.UseCompatibleStateImageBehavior = false;
            // 
            // Title2
            // 
            this.Title2.AutoSize = true;
            this.Title2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title2.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.Title2.Location = new System.Drawing.Point(725, 129);
            this.Title2.Name = "Title2";
            this.Title2.Size = new System.Drawing.Size(238, 23);
            this.Title2.TabIndex = 3;
            this.Title2.Text = "Description of strike:";
            // 
            // lvDescriptionOfStrike
            // 
            this.lvDescriptionOfStrike.BackColor = System.Drawing.Color.Gray;
            this.lvDescriptionOfStrike.HideSelection = false;
            this.lvDescriptionOfStrike.Location = new System.Drawing.Point(729, 168);
            this.lvDescriptionOfStrike.Name = "lvDescriptionOfStrike";
            this.lvDescriptionOfStrike.Size = new System.Drawing.Size(523, 97);
            this.lvDescriptionOfStrike.TabIndex = 4;
            this.lvDescriptionOfStrike.UseCompatibleStateImageBehavior = false;
            // 
            // Title3
            // 
            this.Title3.AutoSize = true;
            this.Title3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title3.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.Title3.Location = new System.Drawing.Point(63, 294);
            this.Title3.Name = "Title3";
            this.Title3.Size = new System.Drawing.Size(215, 23);
            this.Title3.TabIndex = 5;
            this.Title3.Text = "Obstacle Detected:";
            // 
            // lvObstaclesDetected
            // 
            this.lvObstaclesDetected.BackColor = System.Drawing.Color.Gray;
            this.lvObstaclesDetected.HideSelection = false;
            this.lvObstaclesDetected.Location = new System.Drawing.Point(67, 333);
            this.lvObstaclesDetected.Name = "lvObstaclesDetected";
            this.lvObstaclesDetected.Size = new System.Drawing.Size(525, 107);
            this.lvObstaclesDetected.TabIndex = 6;
            this.lvObstaclesDetected.UseCompatibleStateImageBehavior = false;
            // 
            // Title4
            // 
            this.Title4.AutoSize = true;
            this.Title4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title4.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.Title4.Location = new System.Drawing.Point(725, 294);
            this.Title4.Name = "Title4";
            this.Title4.Size = new System.Drawing.Size(215, 23);
            this.Title4.TabIndex = 7;
            this.Title4.Text = "Obstacles Avoided:";
            // 
            // lvObstaclesAvoided
            // 
            this.lvObstaclesAvoided.BackColor = System.Drawing.Color.Gray;
            this.lvObstaclesAvoided.HideSelection = false;
            this.lvObstaclesAvoided.Location = new System.Drawing.Point(729, 333);
            this.lvObstaclesAvoided.Name = "lvObstaclesAvoided";
            this.lvObstaclesAvoided.Size = new System.Drawing.Size(523, 107);
            this.lvObstaclesAvoided.TabIndex = 8;
            this.lvObstaclesAvoided.UseCompatibleStateImageBehavior = false;
            // 
            // Title5
            // 
            this.Title5.AutoSize = true;
            this.Title5.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title5.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.Title5.Location = new System.Drawing.Point(63, 472);
            this.Title5.Name = "Title5";
            this.Title5.Size = new System.Drawing.Size(308, 23);
            this.Title5.TabIndex = 9;
            this.Title5.Text = "Aircraft Stats Before Flight:";
            // 
            // lvStatsBeforeFlight
            // 
            this.lvStatsBeforeFlight.BackColor = System.Drawing.Color.Gray;
            this.lvStatsBeforeFlight.HideSelection = false;
            this.lvStatsBeforeFlight.Location = new System.Drawing.Point(67, 516);
            this.lvStatsBeforeFlight.Name = "lvStatsBeforeFlight";
            this.lvStatsBeforeFlight.Size = new System.Drawing.Size(525, 107);
            this.lvStatsBeforeFlight.TabIndex = 10;
            this.lvStatsBeforeFlight.UseCompatibleStateImageBehavior = false;
            // 
            // lvStatsAfterFlight
            // 
            this.lvStatsAfterFlight.BackColor = System.Drawing.Color.Gray;
            this.lvStatsAfterFlight.HideSelection = false;
            this.lvStatsAfterFlight.Location = new System.Drawing.Point(727, 516);
            this.lvStatsAfterFlight.Name = "lvStatsAfterFlight";
            this.lvStatsAfterFlight.Size = new System.Drawing.Size(525, 107);
            this.lvStatsAfterFlight.TabIndex = 12;
            this.lvStatsAfterFlight.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label1.Location = new System.Drawing.Point(723, 472);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "Aircraft Stats After Flight:";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Gray;
            this.btnExit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnExit.Location = new System.Drawing.Point(602, 636);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(116, 50);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1318, 707);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lvStatsAfterFlight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvStatsBeforeFlight);
            this.Controls.Add(this.Title5);
            this.Controls.Add(this.lvObstaclesAvoided);
            this.Controls.Add(this.Title4);
            this.Controls.Add(this.lvObstaclesDetected);
            this.Controls.Add(this.Title3);
            this.Controls.Add(this.lvDescriptionOfStrike);
            this.Controls.Add(this.Title2);
            this.Controls.Add(this.lvDamageAnalysis);
            this.Controls.Add(this.lblTitle1);
            this.Controls.Add(this.Title0);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmReport";
            this.Text = "Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title0;
        private System.Windows.Forms.Label lblTitle1;
        private System.Windows.Forms.ListView lvDamageAnalysis;
        private System.Windows.Forms.Label Title2;
        private System.Windows.Forms.ListView lvDescriptionOfStrike;
        private System.Windows.Forms.Label Title3;
        private System.Windows.Forms.ListView lvObstaclesDetected;
        private System.Windows.Forms.Label Title4;
        private System.Windows.Forms.ListView lvObstaclesAvoided;
        private System.Windows.Forms.Label Title5;
        private System.Windows.Forms.ListView lvStatsBeforeFlight;
        private System.Windows.Forms.ListView lvStatsAfterFlight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
    }
}

