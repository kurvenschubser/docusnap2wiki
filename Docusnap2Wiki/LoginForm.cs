using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Docusnap2Wiki
{
	public partial class LoginForm : Form
	{
		public delegate void LoginCredentialsProvidedEventHandler(object sender, LoginCredentialsProvidedEventArgs e);

		public event LoginCredentialsProvidedEventHandler LoginCredentialsProvided;


		public LoginForm() : this("http://artemis/MediaWiki")
		{

		}

		public LoginForm(string wikiurl)
		{
			InitializeComponent();

			this.textBox_wikiurl.Text = wikiurl;

			this.textBox_pw.KeyUp += new KeyEventHandler(OnTextboxPWKeyUp);
			this.textBox_username.KeyUp += new KeyEventHandler(OnTextboxUsernameKeyUp);
		}

		void OnTextboxUsernameKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
			{
				OnEnterKeyClickHandler();
			}
		}

		void OnTextboxPWKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
			{
				OnEnterKeyClickHandler();
			}
		}

		private void OnEnterKeyClickHandler()
		{
			Cursor.Current = Cursors.WaitCursor;
			this.button_login.FlatStyle = FlatStyle.Flat;
			this.Confirm();
			Cursor.Current = Cursors.Default;
		}


		private void OnButtonLoginClick(object sender, EventArgs e)
		{
			this.Confirm();
		}

		public void Confirm()
		{
			if (this.DoValidate())
			{
				string wiki_url = this.textBox_wikiurl.Text;
				string username = this.textBox_username.Text;
				string pw = this.textBox_pw.Text;

				LoginCredentialsProvidedEventArgs args =
					new LoginCredentialsProvidedEventArgs() {	WikiURL = wiki_url, 
															    Username = username, 
																Password = pw, 
																Cancel = false};
				this.LoginCredentialsProvided(this, args);
				if (args.Cancel)
				{
					MessageBox.Show("Die eingegebenen Daten konnten nicht bestätigt werden!", 
									"Bitte prüfen Sie Ihre Eingabe");
					return;
				}
				this.Close();
			}
		}

		public bool DoValidate()
		{
			return true;
		}
	}

	public class LoginCredentialsProvidedEventArgs : EventArgs
	{
		public string WikiURL { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public bool Cancel { get; set; }
	}
}
