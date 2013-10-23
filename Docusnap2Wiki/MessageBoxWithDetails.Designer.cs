namespace Docusnap2Wiki
{
	partial class MessageBoxWithDetails
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageBoxWithDetails));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.button_close = new System.Windows.Forms.Button();
			this.textBox_msg = new System.Windows.Forms.TextBox();
			this.textBox_details = new System.Windows.Forms.TextBox();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.button_close);
			this.splitContainer1.Panel1.Controls.Add(this.textBox_msg);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.textBox_details);
			this.splitContainer1.Size = new System.Drawing.Size(435, 320);
			this.splitContainer1.SplitterDistance = 147;
			this.splitContainer1.TabIndex = 0;
			// 
			// button_close
			// 
			this.button_close.Location = new System.Drawing.Point(348, 121);
			this.button_close.Name = "button_close";
			this.button_close.Size = new System.Drawing.Size(75, 23);
			this.button_close.TabIndex = 1;
			this.button_close.Text = "Schließen";
			this.button_close.UseVisualStyleBackColor = true;
			this.button_close.Click += new System.EventHandler(this.OnButtonCloseClick);
			// 
			// textBox_msg
			// 
			this.textBox_msg.Enabled = false;
			this.textBox_msg.Location = new System.Drawing.Point(13, 13);
			this.textBox_msg.Multiline = true;
			this.textBox_msg.Name = "textBox_msg";
			this.textBox_msg.Size = new System.Drawing.Size(410, 102);
			this.textBox_msg.TabIndex = 0;
			// 
			// textBox_details
			// 
			this.textBox_details.Enabled = false;
			this.textBox_details.Location = new System.Drawing.Point(13, 15);
			this.textBox_details.Multiline = true;
			this.textBox_details.Name = "textBox_details";
			this.textBox_details.Size = new System.Drawing.Size(410, 142);
			this.textBox_details.TabIndex = 2;
			// 
			// MessageBoxWithDetails
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClientSize = new System.Drawing.Size(435, 320);
			this.Controls.Add(this.splitContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MessageBoxWithDetails";
			this.Text = "MessageBoxWithDetails";
			this.TopMost = true;
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button button_close;
		private System.Windows.Forms.TextBox textBox_msg;
		private System.Windows.Forms.TextBox textBox_details;

	}
}