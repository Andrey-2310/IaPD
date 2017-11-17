using System.Windows.Forms;

namespace Emulating_Device_Manager
{
    partial class Form1
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
            this.DevicesListBox = new System.Windows.Forms.ListView();
            this.DeviceInfoTextBox = new System.Windows.Forms.TextBox();
            this.statusButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DevicesListBox
            // 
            this.DevicesListBox.FullRowSelect = true;
            this.DevicesListBox.Location = new System.Drawing.Point(12, 8);
            this.DevicesListBox.MultiSelect = false;
            this.DevicesListBox.Name = "DevicesListBox";
            this.DevicesListBox.Size = new System.Drawing.Size(337, 266);
            this.DevicesListBox.TabIndex = 4;
            this.DevicesListBox.UseCompatibleStateImageBehavior = false;
            this.DevicesListBox.View = System.Windows.Forms.View.List;
            this.DevicesListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DevicesListBox_MouseClick);
            // 
            // DeviceInfoTextBox
            // 
            this.DeviceInfoTextBox.Location = new System.Drawing.Point(378, 8);
            this.DeviceInfoTextBox.Multiline = true;
            this.DeviceInfoTextBox.Name = "DeviceInfoTextBox";
            this.DeviceInfoTextBox.Size = new System.Drawing.Size(335, 228);
            this.DeviceInfoTextBox.TabIndex = 1;
            // 
            // statusButton
            // 
            this.statusButton.Location = new System.Drawing.Point(478, 251);
            this.statusButton.Name = "statusButton";
            this.statusButton.Size = new System.Drawing.Size(165, 23);
            this.statusButton.TabIndex = 5;
            this.statusButton.Text = "statusButton";
            this.statusButton.UseVisualStyleBackColor = true;
            this.statusButton.Click += new System.EventHandler(this.statusButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 301);
            this.Controls.Add(this.statusButton);
            this.Controls.Add(this.DeviceInfoTextBox);
            this.Controls.Add(this.DevicesListBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView DevicesListBox;
        private TextBox DeviceInfoTextBox;
        private Button statusButton;
    }
}

