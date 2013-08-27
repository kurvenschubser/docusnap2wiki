
namespace Docusnap2Wiki
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;

	using DotNetWikiBot;


	public partial class MainForm : Form
	{
		List<string[]> rows;


		public MainForm()
		{
			InitializeComponent();

			this.textBox_pagetitle.TextChanged += new EventHandler(OnPageTitleTextChanged);
			this.textBox_template.KeyUp += new KeyEventHandler(OnTextboxTemplateKeyUp);

		}

		private List<string[]> Rows
		{
			get
			{
				if (this.rows == null)
				{
					this.rows = new List<string[]>();
				}
				return this.rows;
			}
			set
			{
				this.rows = value;
			}
		}

		void OnTextboxTemplateKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
			{
				Cursor.Current = Cursors.WaitCursor;

				Page p = new Page(this.Site, this.textBox_template.Text);
				p.Load();
				if (!p.IsEmpty())
				{
					this.FillFormFromPage(p);
				}
				else
				{
					MessageBox.Show("Diese Seite ist nicht-existent.", "Vorlage nicht gefunden");
				}

				Cursor.Current = Cursors.Default;
			}

		}

		private void OnPageTitleTextChanged(object sender, EventArgs e)
		{
			this.timer_template.Start();
		}

		private void OnBrowseInputFileClick(object sender, EventArgs e)
		{
			FileDialog dlg = new OpenFileDialog();
			dlg.Title = "CSV Datei wählen";
			dlg.Filter = "Csv Dateien (*.csv)|*.csv|Alle Dateien (*.*)|*.*";
			if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.ReadCSV(dlg.FileName, this.checkBox_csv_has_column_titles.Checked);
				this.textBox_input_path.Text = dlg.FileName;
			}
		}

		void ReadCSV(string filepath, bool has_column_titles)
		{
			Microsoft.VisualBasic.FileIO.TextFieldParser p = new Microsoft.VisualBasic.FileIO.TextFieldParser(filepath);
			p.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
			p.Delimiters = new String[] {";"};
			
			string[] currentRow;
			List<string[]> rows = new List<string[]>();

			this.treeView_columns.BeginUpdate();
			this.treeView_columns.Nodes.Clear();

			// Loop through all of the fields in the file.  
			//If any lines are corrupt, report an error and continue parsing.  
			long i = 1;
			while (!p.EndOfData)
			{
				try
				{
					currentRow = p.ReadFields();
					if (i == 1)
					{
						if (has_column_titles)
						{
							foreach (string val in currentRow)
							{
								TreeNode n = new TreeNode(val);
								n.Checked = true;
								this.treeView_columns.Nodes.Add(n);
							}
						}
						else
						{
							for (int j = 1; j <= currentRow.Length; j++)
							{
								TreeNode n = new TreeNode(string.Format("Spalte {0}", j.ToString()));
								n.Checked = true;
								this.treeView_columns.Nodes.Add(n);
							}
							rows.Add(currentRow);
						}
					}
					else
					{
						rows.Add(currentRow);
					}
				}
				catch (Microsoft.VisualBasic.FileIO.MalformedLineException ex)
				{
					MessageBox.Show(string.Format("Line {0}: '{1}' is invalid. Skipping", i, ex.Message ));
				}
				i++;
			}

			this.treeView_columns.EndUpdate();

			this.Rows = rows;
		}

		private void OnUploadClick(object sender, EventArgs e)
		{
			System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(@"\[\[Kategorie:.*\]\]");
			System.Text.RegularExpressions.Match m = re.Match(this.richTextBox_pagetext.Text);
			if (!m.Success)
			{
				DialogResult answer = MessageBox.Show("Die Seite ist keiner Kategorie ([[Kategoriename]]) zugeordnet. Wollen Sie dennoch fortfahren?"
					, "Fehlende Kategorie", MessageBoxButtons.YesNo);
				if (answer == System.Windows.Forms.DialogResult.No)
				{
					return;
				}
			}

			if (this.Rows.Count == 0)
			{
				DialogResult answer = MessageBox.Show("Es ist keine CSV Datei geladen. Wollen Sie die Seite so, wie sie ist, erstellen?", 
					"Keine Kontext-Informationen", MessageBoxButtons.YesNo);
				if (answer == System.Windows.Forms.DialogResult.Yes)
				{
					string pagetext = this.FormatWithContext(this.richTextBox_pagetext.Text, new Dictionary<string, string>(), 1, 1);
					string pagetitle = this.FormatWithContext(this.textBox_pagetitle.Text, new Dictionary<string, string>(), 1, 1);
					if (string.IsNullOrEmpty(pagetitle))
					{
						MessageBox.Show("Es muss ein Seitentitel angegeben werden.", "Leerer Seitentitel");
						return;
					}
					Page p = new Page(this.Site, pagetitle);
					p.Load();
					if (!p.IsEmpty())
					{
						if (MessageBox.Show("Die Seite gibt es bereits. Wollen Sie sie überschreiben?", "Existierende Seite", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
						{
							return;
						}
					}
					p.text = pagetext;
					p.Save(this.textBox_comment.Text, false);
					return;
				}
				else
				{
					return;
				}
			}

			List<Tuple<bool, string, string>> generated_contents = new List<Tuple<bool, string, string>>();
			
			int current_row_no = 1;
			foreach (string[] row in this.Rows)
			{
				Dictionary<string, string> context = this.MakeContext(row);
				string pagetext = this.FormatWithContext(this.richTextBox_pagetext.Text, context, current_row_no, this.Rows.Count);
				string pagetitle = this.FormatWithContext(this.textBox_pagetitle.Text, context, current_row_no, this.Rows.Count);
				bool do_generate = true;
				Page p = null;

				if (string.IsNullOrEmpty(pagetitle))
				{
					MessageBox.Show("Zeile " + current_row_no.ToString() + ": Der Seitentitel ist leer. Die Seite kann nicht angelegt werden.", "Leerer Seitentitel");
					do_generate = false;
				}
				else
				{
					p = new Page(this.Site, pagetitle);
					p.Load();
					if (!p.IsEmpty())
					{
						DialogResult answer = MessageBox.Show("Die Seite gibt es bereits. Wollen Sie sie überschreiben?", "Existierende Seite", MessageBoxButtons.YesNo);
						if (answer == System.Windows.Forms.DialogResult.No)
						{
							do_generate = false;
						}
					}
				}

				Tuple<bool, string, string> tup = new Tuple<bool, string, string>(
					do_generate
					, pagetitle
					, pagetext
				);

				if (do_generate)
				{
					p.text = pagetext;
					p.Save(this.textBox_comment.Text, false);
				}
				generated_contents.Add(tup);

				current_row_no++;
			}

			MessageBox.Show(string.Join("\n", generated_contents.Select(o => o.Item1 ? "Angelegt: " : "Nicht angelegt: " + string.Join(" | ", new string[]{ o.Item2, o.Item3})).ToArray()));
		}

		public string FormatWithContext(string fmt, Dictionary<string, string> context, int row_no, int rows_count)
		{
			string rv = fmt.Replace("{index}", row_no.ToString()).Replace("{row_count}", rows_count.ToString());
			foreach (KeyValuePair<string, string> kv in context)
			{
				rv = rv.Replace("{{{" + kv.Key + "}}}", kv.Value);
			}
			return rv;
		}

		public Dictionary<string, string> MakeContext(string[] row)
		{
			Dictionary<string, string> context = new Dictionary<string, string>();
			int i = 0;
			foreach (TreeNode n in this.treeView_columns.Nodes)
			{
				if (n.Checked)
				{
					context[n.Text] = row[i];
				}

				i++;
			}
			return context;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			
		}

		private void OnSaveCategoryClick(object sender, EventArgs e)
		{

		}

		private Site site;
		public Site Site
		{
			get
			{
				if (this.site == null)
				{
#if DEBUG
					this.site = new Site("http://artemis/MediaWiki", "Mengelhardt", "uiaenrtd12!\"");
#else
					LoginForm f = new LoginForm();
					f.LoginSuccess += new LoginForm.LoginSuccessEventHandler(OnLoginSuccess);
					f.ShowDialog();
#endif
				}
				return this.site;
			}
		}

		void OnLoginSuccess(object sender, LoginSuccessEventArgs e)
		{
			this.site = new Site("http://artemis/MediaWiki", e.Username, e.Password);
		}

		public void FillFormFromPage(Page p)
		{
			this.textBox_comment.Text = p.comment;
			this.richTextBox_pagetext.Text = p.text;
		}

		private void OnCheckBoxCsvHasColumnTitles_CheckedChanged(object sender, EventArgs e)
		{
			if (!(string.IsNullOrEmpty(this.textBox_input_path.Text)))
			{
				ReadCSV(this.textBox_input_path.Text, this.checkBox_csv_has_column_titles.Checked);
			}
		}

		private void OnButtonHelpClick(object sender, EventArgs e)
		{
			System.Windows.Forms.Help.ShowHelp(this, System.IO.Path.Combine(Application.StartupPath, "helpfile.txt"));
		}
	}


	public class Tuple<T1, T2, T3>
	{
		private T1 item1;
		private T2 item2;
		private T3 item3;

		public Tuple(T1 item1, T2 item2, T3 item3)
		{
			this.item1 = item1;
			this.item2 = item2;
			this.item3 = item3;
		}


		public T1 Item1
		{
			get
			{
				return this.item1;
			}
		}
		
		public T2 Item2
		{
			get
			{
				return this.item2;
			}
		}

		public T3 Item3
		{
			get
			{
				return this.item3;
			}
		}
	}
}
