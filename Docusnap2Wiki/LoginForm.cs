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
		public delegate void LoginSuccessEventHandler(object sender, LoginSuccessEventArgs e);

		public event LoginSuccessEventHandler LoginSuccess;


		public LoginForm()
		{
			InitializeComponent();

			this.textBox_pw.KeyUp += new KeyEventHandler(OnTextboxPWKeyUp);
			this.textBox_username.KeyUp += new KeyEventHandler(OnTextboxUsernameKeyUp);
		}

		void OnTextboxUsernameKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
			{
				Cursor.Current = Cursors.WaitCursor;
				this.button_login.FlatStyle = FlatStyle.Flat;
				this.Confirm();
				Cursor.Current = Cursors.Default;
			}
		}

		void OnTextboxPWKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
			{
				Cursor.Current = Cursors.WaitCursor;
				this.button_login.FlatStyle = FlatStyle.Flat;
				this.Confirm();
				Cursor.Current = Cursors.Default;
			}
		}


		private void OnButtonLoginClick(object sender, EventArgs e)
		{
			this.Confirm();
		}

		public void Confirm()
		{
			if (this.DoValidate())
			{
				string username = this.textBox_username.Text;
				string pw = this.textBox_pw.Text;
				this.LoginSuccess(this, new LoginSuccessEventArgs() { Username = username, Password = pw });
				this.Close();
			}
		}

		public bool DoValidate()
		{
			return true;
		}
	}

	public class LoginSuccessEventArgs : EventArgs
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}
}
