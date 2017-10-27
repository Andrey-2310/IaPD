namespace ManagingBatteryInfo
{
    partial class ManageBatteryForm
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
            this.timeLeftLabel = new System.Windows.Forms.Label();
            this.stateLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timeLeftTextBox = new System.Windows.Forms.TextBox();
            this.statTextBox = new System.Windows.Forms.TextBox();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.timeOutBox = new System.Windows.Forms.ComboBox();
            this.percentageProgressBar = new System.Windows.Forms.ProgressBar();
            this.percentageDescriptionLabel = new System.Windows.Forms.Label();
            this.percentageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timeLeftLabel
            // 
            this.timeLeftLabel.AutoSize = true;
            this.timeLeftLabel.Location = new System.Drawing.Point(52, 71);
            this.timeLeftLabel.Name = "timeLeftLabel";
            this.timeLeftLabel.Size = new System.Drawing.Size(57, 13);
            this.timeLeftLabel.TabIndex = 2;
            this.timeLeftLabel.Text = "Time Left: ";
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(52, 101);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(43, 13);
            this.stateLabel.TabIndex = 3;
            this.stateLabel.Text = "Status: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Display off time, min: ";
            // 
            // timeLeftTextBox
            // 
            this.timeLeftTextBox.Location = new System.Drawing.Point(158, 67);
            this.timeLeftTextBox.Name = "timeLeftTextBox";
            this.timeLeftTextBox.Size = new System.Drawing.Size(100, 20);
            this.timeLeftTextBox.TabIndex = 7;
            this.timeLeftTextBox.Text = "Time Left: ";
            // 
            // statTextBox
            // 
            this.statTextBox.Location = new System.Drawing.Point(158, 99);
            this.statTextBox.Name = "statTextBox";
            this.statTextBox.Size = new System.Drawing.Size(100, 20);
            this.statTextBox.TabIndex = 8;
            // 
            // timeOutBox
            // 
            this.timeOutBox.DisplayMember = "1";
            this.timeOutBox.FormattingEnabled = true;
            this.timeOutBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "5",
            "10",
            "15"});
            this.timeOutBox.Location = new System.Drawing.Point(158, 129);
            this.timeOutBox.Name = "timeOutBox";
            this.timeOutBox.Size = new System.Drawing.Size(100, 21);
            this.timeOutBox.TabIndex = 11;
            this.timeOutBox.SelectedIndexChanged += new System.EventHandler(this.timeOutBox_SelectedIndexChanged);
            // 
            // percentageProgressBar
            // 
            this.percentageProgressBar.Location = new System.Drawing.Point(158, 31);
            this.percentageProgressBar.Name = "percentageProgressBar";
            this.percentageProgressBar.Size = new System.Drawing.Size(100, 23);
            this.percentageProgressBar.TabIndex = 12;
            // 
            // percentageDescriptionLabel
            // 
            this.percentageDescriptionLabel.AutoSize = true;
            this.percentageDescriptionLabel.Location = new System.Drawing.Point(52, 37);
            this.percentageDescriptionLabel.Name = "percentageDescriptionLabel";
            this.percentageDescriptionLabel.Size = new System.Drawing.Size(68, 13);
            this.percentageDescriptionLabel.TabIndex = 13;
            this.percentageDescriptionLabel.Text = "Procentage: ";
            // 
            // percentageLabel
            // 
            this.percentageLabel.AutoSize = true;
            this.percentageLabel.Location = new System.Drawing.Point(230, 36);
            this.percentageLabel.Name = "percentageLabel";
            this.percentageLabel.Size = new System.Drawing.Size(0, 13);
            this.percentageLabel.TabIndex = 14;
            // 
            // ManageBatteryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 171);
            this.Controls.Add(this.percentageLabel);
            this.Controls.Add(this.percentageDescriptionLabel);
            this.Controls.Add(this.percentageProgressBar);
            this.Controls.Add(this.timeOutBox);
            this.Controls.Add(this.statTextBox);
            this.Controls.Add(this.timeLeftTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.timeLeftLabel);
            this.Name = "ManageBatteryForm";
            this.Text = "ManageBatteryForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppClosing);
            this.Load += new System.EventHandler(this.BatteryLoading);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    
        private System.Windows.Forms.Label timeLeftLabel;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox timeLeftTextBox;
        private System.Windows.Forms.TextBox statTextBox;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.ComboBox timeOutBox;
        private System.Windows.Forms.ProgressBar percentageProgressBar;
        private System.Windows.Forms.Label percentageDescriptionLabel;
        private System.Windows.Forms.Label percentageLabel;
    }
}

