namespace Docusnap2Wiki
{
	partial class LoginForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
			this.textBox_username = new System.Windows.Forms.TextBox();
			this.textBox_pw = new System.Windows.Forms.TextBox();
			this.label_username = new System.Windows.Forms.Label();
			this.label_pw = new System.Windows.Forms.Label();
			this.button_login = new System.Windows.Forms.Button();
			this.textBox_wikiurl = new System.Windows.Forms.TextBox();
			this.label_wikiurl = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBox_username
			// 
			this.textBox_username.Location = new System.Drawing.Point(93, 36);
			this.textBox_username.Name = "textBox_username";
			this.textBox_username.Size = new System.Drawing.Size(174, 20);
			this.textBox_username.TabIndex = 0;
			// 
			// textBox_pw
			// 
			this.textBox_pw.Location = new System.Drawing.Point(93, 63);
			this.textBox_pw.Name = "textBox_pw";
			this.textBox_pw.PasswordChar = '*';
			this.textBox_pw.Size = new System.Drawing.Size(174, 20);
			this.textBox_pw.TabIndex = 1;
			// 
			// label_username
			// 
			this.label_username.AutoSize = true;
			this.label_username.Location = new System.Drawing.Point(12, 39);
			this.label_username.Name = "label_username";
			this.label_username.Size = new System.Drawing.Size(75, 13);
			this.label_username.TabIndex = 2;
			this.label_username.Text = "Benutzername";
			// 
			// label_pw
			// 
			this.label_pw.AutoSize = true;
			this.label_pw.Location = new System.Drawing.Point(12, 66);
			this.label_pw.Name = "label_pw";
			this.label_pw.Size = new System.Drawing.Size(50, 13);
			this.label_pw.TabIndex = 3;
			this.label_pw.Text = "Passwort";
			// 
			// button_login
			// 
			this.button_login.Location = new System.Drawing.Point(7, 89);
			this.button_login.Name = "button_login";
			this.button_login.Size = new System.Drawing.Size(259, 23);
			this.button_login.TabIndex = 4;
			this.button_login.Text = "Anmelden";
			this.button_login.UseVisualStyleBackColor = true;
			this.button_login.Click += new System.EventHandler(this.OnButtonLoginClick);
			// 
			// textBox_wikiurl
			// 
			this.textBox_wikiurl.Location = new System.Drawing.Point(93, 10);
			this.textBox_wikiurl.Name = "textBox_wikiurl";
			this.textBox_wikiurl.Size = new System.Drawing.Size(174, 20);
			this.textBox_wikiurl.TabIndex = 5;
			// 
			// label_wikiurl
			// 
			this.label_wikiurl.AutoSize = true;
			this.label_wikiurl.Location = new System.Drawing.Point(12, 13);
			this.label_wikiurl.Name = "label_wikiurl";
			this.label_wikiurl.Size = new System.Drawing.Size(53, 13);
			this.label_wikiurl.TabIndex = 6;
			this.label_wikiurl.Text = "Wiki URL";
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(273, 116);
			this.Controls.Add(this.label_wikiurl);
			this.Controls.Add(this.textBox_wikiurl);
			this.Controls.Add(this.button_login);
			this.Controls.Add(this.label_pw);
			this.Controls.Add(this.label_username);
			this.Controls.Add(this.textBox_pw);
			this.Controls.Add(this.textBox_username);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "LoginForm";
			this.Text = "Anmeldung MediaWiki";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox_username;
		private System.Windows.Forms.TextBox textBox_pw;
		private System.Windows.Forms.Label label_username;
		private System.Windows.Forms.Label label_pw;
		private System.Windows.Forms.Button button_login;
		private System.Windows.Forms.TextBox textBox_wikiurl;
		private System.Windows.Forms.Label label_wikiurl;
	}
}