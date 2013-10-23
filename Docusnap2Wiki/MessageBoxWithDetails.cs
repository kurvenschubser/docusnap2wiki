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
	public partial class MessageBoxWithDetails : Form
	{
		public MessageBoxWithDetails() : this("", "", "")
		{
			
		}

		public MessageBoxWithDetails(string title, string msg, string details)
		{
			InitializeComponent();

			this.Text = title;
			this.textBox_details.Lines = details.Split(System.Environment.NewLine.ToArray());
			this.textBox_msg.Text = msg;
		}

		private void OnButtonCloseClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
