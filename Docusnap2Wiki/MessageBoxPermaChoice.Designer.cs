namespace Docusnap2Wiki
{
	partial class MessageBoxPermaChoice
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageBoxPermaChoice));
			this.textBox_msg = new System.Windows.Forms.TextBox();
			this.checkBox_donotaskagain = new System.Windows.Forms.CheckBox();
			this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// textBox_msg
			// 
			this.textBox_msg.Dock = System.Windows.Forms.DockStyle.Top;
			this.textBox_msg.Location = new System.Drawing.Point(0, 0);
			this.textBox_msg.Multiline = true;
			this.textBox_msg.Name = "textBox_msg";
			this.textBox_msg.ReadOnly = true;
			this.textBox_msg.Size = new System.Drawing.Size(485, 105);
			this.textBox_msg.TabIndex = 0;
			// 
			// checkBox_donotaskagain
			// 
			this.checkBox_donotaskagain.AutoSize = true;
			this.checkBox_donotaskagain.Location = new System.Drawing.Point(6, 114);
			this.checkBox_donotaskagain.Name = "checkBox_donotaskagain";
			this.checkBox_donotaskagain.Size = new System.Drawing.Size(104, 17);
			this.checkBox_donotaskagain.TabIndex = 4;
			this.checkBox_donotaskagain.Text = "Auswahl merken";
			this.checkBox_donotaskagain.UseVisualStyleBackColor = true;
			// 
			// flowLayoutPanel
			// 
			this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel.Location = new System.Drawing.Point(123, 111);
			this.flowLayoutPanel.Name = "flowLayoutPanel";
			this.flowLayoutPanel.Size = new System.Drawing.Size(362, 32);
			this.flowLayoutPanel.TabIndex = 5;
			// 
			// MessageBoxPermaChoice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(485, 150);
			this.Controls.Add(this.flowLayoutPanel);
			this.Controls.Add(this.checkBox_donotaskagain);
			this.Controls.Add(this.textBox_msg);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MessageBoxPermaChoice";
			this.Text = "MessageBoxPermaChoice";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox_msg;
		private System.Windows.Forms.CheckBox checkBox_donotaskagain;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
	}
}