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
	public partial class MessageBoxPermaChoice : Form
	{
		public class ChoiceEventArgs : EventArgs
		{
			public bool IsPermanent {get;set;}
			public DialogResult Answer;
		}

		public delegate void ChoiceEventHandler(object sender, ChoiceEventArgs e);
		public event ChoiceEventHandler Choice;

		private ButtonDef[] button_defs;


		public MessageBoxPermaChoice(string message = "", string title = "", ButtonDef[] button_defs = null)
		{
			InitializeComponent();

			this.Message = message;
			this.Title = title;
			this.ButtonDefs = button_defs;

			this.FormClosed += new FormClosedEventHandler(OnFormClosed);
		}

		void OnFormClosed(object sender, FormClosedEventArgs e)
		{
			this.Choice(
				this,
				new ChoiceEventArgs
				{
					 IsPermanent = this.checkBox_donotaskagain.Checked
				   , Answer = DialogResult.Abort
				}
			);
		}

		public string Message
		{
			get
			{
				return this.textBox_msg.Text;
			}
			set
			{
				this.textBox_msg.Text = value;
			}
		}

		public string Title
		{
			get
			{
				return this.Text;
			}
			set
			{
				this.Text = value;
			}
		}

		public Button[] Buttons
		{
			get
			{
				return this.button_defs.Select(o => o.Button).ToArray();
			}
		}

		public ButtonDef[] ButtonDefs
		{
			get
			{
				if (this.button_defs == null)
				{
					this.button_defs = new ButtonDef[] { };
				}
				return button_defs;
			}
			set
			{
				if (value == null)
				{
					foreach (Button b in this.Buttons)
					{
						this.Controls.Remove(b);
					}
				}
				else
				{
					foreach (ButtonDef def in value)
					{
						if (!this.ButtonDefs.Contains(def))
						{
							this.AddButton(def.Button);
							def.Button.Click += new EventHandler(OnButtonClick);
						}
					}
					foreach (ButtonDef def in this.ButtonDefs)
					{
						if (!value.Contains(def))
						{
							this.RemoveButton(def.Button);
						}
					}
				}
				button_defs = value;
			}
		}

		private void AddButton(Button b)
		{
			this.flowLayoutPanel.Controls.Add(b);	
		}

		private void RemoveButton(Button b)
		{
			this.flowLayoutPanel.Controls.Remove(b);
		}

		private void OnButtonClick(object sender, EventArgs e)
		{
			this.Close();
			Button b = (sender as Button);

			ButtonDef def = this.ButtonDefs.First(o => o.Button == b);
			foreach (Func<Form, Button, bool> cb in def.Callbacks)
			{
				bool do_continue = cb(this, b);
				if (!do_continue)
				{
					break;
				}
			}
			this.Choice(
				this, 
				new ChoiceEventArgs
					{    IsPermanent = this.checkBox_donotaskagain.Checked
					   , Answer = def.Answer  });
		}
	}


	public class ButtonDef
	{
		public Button Button { get; set; }
		public DialogResult Answer { get; set; }
		public IEnumerable<Func<Form, Button, bool>> Callbacks { get; set; }
		public uint Index { get; set; }
	}
}
