
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
	using System.Net;
	using System.Xml;
	using System.Text.RegularExpressions;

	using DotNetWikiBot;


	public enum GenerationState
	{
		None = 0,
		New = 1,
		Overwrite = 2
	}


	public partial class MainForm : Form
	{
		List<string[]> rows;
		AutoCompleteStringCollection autocomplete_templates;


		public MainForm(IController controller)
		{
			InitializeComponent();

            this.Controller = controller;
            this.Controller.CategoriesChanged += OnCategoriesChanged;
            this.Controller.CSVColumnsChanged += OnCSVColumnsChanged;

			this.textBox_pagetitle.TextChanged += OnPageTitleTextChanged;
			this.textBox_template.KeyUp += OnTextboxTemplateKeyUp;
			this.textBox_template.LostFocus += OnTextboxTemplateLostFocus;
			this.treeView_categories.AfterCheck += OnTreeViewCategoriesAfterCheck;
            this.treeView_columns.AfterCheck += OnTreeViewColumnsAfterCheck;
			this.richTextBox_pagetext.TextChanged += OnRichTextBoxPagetextTextChanged;
		}

        void OnTreeViewColumnsAfterCheck(object sender, TreeViewEventArgs e)
        {
            int i = this.Controller.AllCSVColumns.ToList().IndexOf(e.Node.Text);
            if (e.Node.Checked)
            {
                this.Controller.SelectedCSVColumns = this.Controller.SelectedCSVColumns.Union(
                    new HashSet<int>(new int[] { i }));
            }
            else
            {
                this.Controller.SelectedCSVColumns = this.Controller.SelectedCSVColumns.Except(
                    new HashSet<int>(new int[] { i }));
            }
        }

        void OnCategoriesChanged(object sender, CategoriesChangedEventArgs e)
        {
            this.UpdateTreeView(this.treeView_categories, e.AllCategories,
				e.SelectedCategories);
        }

        void OnCSVColumnsChanged(object sender, CSVColumnsChangedEventArgs e)
        {
            string[] all_columns = e.AllCSVColumns.ToArray();
            this.UpdateTreeView(this.treeView_columns, e.AllCSVColumns,
				e.SelectedCSVColumns.Select(o => all_columns[o]));
        }

        void UpdateTreeView(TreeView tv, 
							IEnumerable<string> all_nodes, 
							IEnumerable<string> selected_nodes)
        {
            tv.BeginUpdate();
            tv.Nodes.Clear();

            List<TreeNode> nodes = new List<TreeNode>();
            foreach (string nodetext in all_nodes)
            {
                TreeNode n = new TreeNode(nodetext);
                n.Checked = selected_nodes.Contains(nodetext);
                nodes.Add(n);
            }
            tv.Nodes.AddRange(nodes.ToArray());
            tv.EndUpdate();
        }

		void OnRichTextBoxPagetextTextChanged(object sender, EventArgs e)
		{
            this.UpdateCategories();
		}

		void OnRichTextBoxPagetextModifiedChanged(object sender, EventArgs e)
		{
            this.UpdateCategories();
		}

        private void UpdateCategories()
        {
            int selection_start = this.richTextBox_pagetext.SelectionStart;
            this.Controller.SetSelectedCategories(
                this.Controller.ExtractCategories(this.richTextBox_pagetext.Text
                    , this.richTextBox_pagetext.SelectionStart));
            this.richTextBox_pagetext.SelectionStart = selection_start;
			this.UpdateTreeView(this.treeView_categories, 
								this.Controller.AllCategories, 
								this.Controller.SelectedCategories);
        }

		void OnTreeViewCategoriesAfterCheck(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Checked)
			{
                this.Controller.SetSelectedCategories(
                    this.Controller.SelectedCategories.Union(
                        new HashSet<string>(new string[] { e.Node.Text })));

				this.AddCategoryToPage(e.Node.Text);
			}
			else
			{
                this.Controller.SetSelectedCategories(
                    this.Controller.SelectedCategories.Except(
                        new HashSet<string>(new string[] { e.Node.Text })));

				StripCategoryFromPage(e.Node.Text);
			}
		}

		private void AddCategoryToPage(string cat)
		{
			string txt = this.richTextBox_pagetext.Text;

			var catstr = "[[Kategorie:" + cat + "]]";

			if (!txt.Contains(catstr))
			{
				txt = catstr + "\n" + txt;
			}

			this.richTextBox_pagetext.Text = txt;
		}

		private void StripCategoryFromPage(string cat)
		{
			this.richTextBox_pagetext.Text = this.richTextBox_pagetext.Text
												.Replace("[[Kategorie:" + cat + "]]", "")
												.TrimStart();
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
				LoadTemplatePage(this.textBox_template.Text);
				Cursor.Current = Cursors.Default;
			}
		}

		void OnTextboxTemplateLostFocus(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			LoadTemplatePage(this.textBox_template.Text);
			Cursor.Current = Cursors.Default;
		}

		void LoadTemplatePage(string pagetitle)
		{
			Page p = new Page(this.Controller.Site, pagetitle);
			p.Load();
			if (!p.IsEmpty())
			{
				this.FillFormFromPage(p);
			}
			else
			{
				MessageBox.Show("Diese Seite gibt es nicht.", "Vorlage nicht gefunden");
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
            dlg.Filter = "CSV Dateien (*.csv)|*.csv|Alle Dateien (*.*)|*.*";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.textBox_input_path.Text = dlg.FileName;
                this.Controller.OpenCSVFile(dlg.FileName);
            }
		}

		private void OnButtonUploadClick(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			Page p = null;
			DialogResult answer = DialogResult.Retry;		// default value corresponding to 'null'
            IEnumerable<string[]> input_rows;

			if (!this.Controller.SelectedCategories.Any())
			{
				answer = MessageBox.Show("Die Seite ist keiner Kategorie "
					+ "([[Kategoriename]]) zugeordnet. Wollen Sie dennoch fortfahren?"
					, "Fehlende Kategorie"
					, MessageBoxButtons.YesNo);

				if (answer == System.Windows.Forms.DialogResult.No)
				{
					return;
				}
			}

            if (!this.Controller.CSVRows.Any())
            {
                answer = MessageBox.Show("Es ist keine CSV Datei geladen. Wollen Sie die Seite so, wie sie ist, erstellen?",
                    "Keine Kontext-Informationen", MessageBoxButtons.YesNo);
                if (answer == System.Windows.Forms.DialogResult.Yes)
                {
                    List<string[]> L = new List<string[]>();
                    L.Add(Enumerable.Range(0, this.Controller.AllCSVColumns.Count()).Select(o => string.Empty).ToArray());
                    input_rows = L;
                }
                else
                {
                    return;
                }
            }
            else
            {
                input_rows = this.Controller.CSVRows;
            }

			MessageBoxPermaChoice msgbox = new MessageBoxPermaChoice(
				title: "Existierende Seite"
				, button_defs: new ButtonDef[] 
					{   new ButtonDef {   Answer = DialogResult.Cancel
						                , Button = new Button { Text = "Abbruch", AutoSize = true }
										, Callbacks = new Func<Form, Button, bool>[]{}
										, Index = 0  } 
					  , new ButtonDef {   Answer = DialogResult.No
						                , Button = new Button { Text = "Nicht überschreiben", AutoSize = true }
										, Callbacks = new Func<Form, Button, bool>[]{}
										, Index = 1  }
					  , new ButtonDef {   Answer = DialogResult.Yes
						                , Button = new Button { Text = "Überschreiben", AutoSize = true }
										, Callbacks = new Func<Form, Button, bool>[]{}
										, Index = 2  } }
			);

			bool is_permanent = false;
			msgbox.Choice += (s, args) => { is_permanent = args.IsPermanent; answer = args.Answer; };

            List<Tuple<GenerationState, string, string>> generated_contents = new List<Tuple<GenerationState, string, string>>();

			int current_row_no = 1;
			foreach (string[] row in input_rows)
			{
				Dictionary<string, object> context = this.Controller.MakeContext(row, this.Controller.AllCSVColumns, this.Controller.SelectedCSVColumns);
				string pagetext = this.Controller.FormatWithContext(this.richTextBox_pagetext.Text, context, current_row_no, this.Controller.CSVRows.Count());
				string pagetitle = this.Controller.FormatWithContext(this.textBox_pagetitle.Text, context, current_row_no, this.Controller.CSVRows.Count());
				GenerationState write_status = GenerationState.New;
				
				if (string.IsNullOrEmpty(pagetitle))
				{
					MessageBox.Show("Zeile " + current_row_no.ToString() + ": Der Seitentitel ist leer. Die Seite kann nicht angelegt werden.", "Leerer Seitentitel");
					return;
				}
				else
				{
					p = new Page(this.Controller.Site, pagetitle);
					p.Load();
					if (!p.IsEmpty())
					{
						if (!is_permanent)
						{
							msgbox.Message = string.Format("Die Seite {0} gibt es bereits. Wollen Sie sie überschreiben?", pagetitle);
							msgbox.ShowDialog();
						}
						if (answer == DialogResult.No)
						{
							write_status = GenerationState.None;
						}
						else if (answer == DialogResult.Yes)
						{
							write_status = GenerationState.Overwrite;
						}
						else if (answer == DialogResult.Cancel || answer == DialogResult.Abort)
						{
							return;
						}
					}
					else
					{
						msgbox.Hide();
					}
				}

				Tuple<GenerationState, string, string> tup = new Tuple<GenerationState, string, string>(
					write_status
					, pagetitle
					, pagetext
				);

				generated_contents.Add(tup);
				current_row_no++;
			}

			foreach (Tuple<GenerationState, string, string> tup in generated_contents)
			{
				if (tup.Item1 != GenerationState.None)
				{
					p = new Page(this.Controller.Site, tup.Item2);
					p.Load();
					p.text = tup.Item3;
					p.Save(this.textBox_comment.Text, false);
				}
			}

			Cursor.Current = Cursors.Default;

            this.ReportUploadDetails(generated_contents);
		}

        private void ReportUploadDetails(IEnumerable<Tuple<GenerationState, string, string>> contents)
        {
            string siteurl = System.IO.Path.Combine(this.Controller.Site.site, this.Controller.Site.indexPath);
            string[] gen_state_desc = new string[] { "Ignoriert", "Neu", "Überschrieben" };

            new MessageBoxWithDetails(
                  "Zusammenfassung"
                , string.Format("Neue Seiten: {0}." + Environment.NewLine
                                + "Überschriebene Seiten: {1}" + Environment.NewLine
                                + "Ignorierte Einträge: {2}" + Environment.NewLine
                                + "Einträge insgesamt: {3}"
                                , contents.Count(o => o.Item1 == GenerationState.New)
                                , contents.Count(o => o.Item1 == GenerationState.Overwrite)
                                , contents.Count(o => o.Item1 == GenerationState.None)
                                , contents.Count())
                , string.Join(
                      Environment.NewLine
                    , contents.Select(
                        o => string.Format(
                            "{0}: {1}"
                            , gen_state_desc[(int)o.Item1]
                            , System.IO.Path.Combine(siteurl, o.Item2)
                        )
                    ).ToArray()
                )
            ).ShowDialog();
        }


		private void OnMainFormLoad(object sender, EventArgs e)
		{
			this.SetupTemplates();
			this.Controller.SetupCategories();
		}

		private void SetupTemplates()
		{
			this.autocomplete_templates = new AutoCompleteStringCollection();
			this.textBox_template.AutoCompleteSource = AutoCompleteSource.CustomSource;
			this.autocomplete_templates.AddRange(this.Controller.GetAllTemplates().ToArray());
			this.textBox_template.AutoCompleteCustomSource = this.autocomplete_templates;
			this.textBox_template.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		}


		void OnLoginSuccess(object sender, LoginCredentialsProvidedEventArgs e)
		{
			this.Controller.Site = new Site(e.WikiURL, e.Username, e.Password);
		}

		public void FillFormFromPage(Page p)
		{
			this.textBox_comment.Text = p.comment;
			this.richTextBox_pagetext.Text = p.text;
		}

		private void OnCheckBoxCsvHasColumnTitlesCheckedChanged(object sender, EventArgs e)
		{
            this.Controller.CSVHasColumnTitles = (sender as CheckBox).Checked;
		}

		
		private void OnEditorButtonItalicClick(object sender, EventArgs e)
		{
			this.WrapTextInSelectionHelper("''");
		}

		

		private void WrapTextInSelectionHelper(string token)
		{
			this.richTextBox_pagetext.Text = 
				this.Controller.WrapTextInSelection(
					this.richTextBox_pagetext.Text, 
					this.richTextBox_pagetext.SelectionStart, 
					this.richTextBox_pagetext.SelectionStart 
						+ this.richTextBox_pagetext.SelectionLength, 
					token);
		}

		private void WrapTextInSelectionWithTagHelper(string token)
		{
			this.richTextBox_pagetext.Text = 
				this.Controller.WrapTextInSelectionWithTag(
					this.richTextBox_pagetext.Text, 
					this.richTextBox_pagetext.SelectionStart,
					this.richTextBox_pagetext.SelectionStart
						+ this.richTextBox_pagetext.SelectionLength, 
					token);
		}

		private void ChangeListLevelHelper(string pointsign, int direction)
		{
			int start = this.richTextBox_pagetext.SelectionStart;
			string oldtext = this.richTextBox_pagetext.Text;
			string newtext = this.Controller.ChangeListLevel(
				oldtext, start, pointsign, direction);

			if (newtext != oldtext)
			{
				this.richTextBox_pagetext.Text = newtext;
				this.richTextBox_pagetext.SelectionStart = 
					Math.Max((direction < 0 ? start - 1 : start), 0);
			}
		}

		private void OnButtonEditorBoldClick(object sender, EventArgs e)
		{
			this.WrapTextInSelectionHelper("'''");
		}

		private void OnButtonEditorItalicBoldClick(object sender, EventArgs e)
		{
			this.WrapTextInSelectionHelper("'''''");
		}

		private void OnButtonEditorStrikeClick(object sender, EventArgs e)
		{
			this.WrapTextInSelectionWithTagHelper("strike");
		}

		private void OnButtonEditorNowikiClick(object sender, EventArgs e)
		{
			this.WrapTextInSelectionWithTagHelper("nowiki");
		}

		private void OnButtonEditorHeading2Click(object sender, EventArgs e)
		{
			this.WrapTextInSelectionHelper(" == ");
		}

		private void OnButtonEditorHeading3Click(object sender, EventArgs e)
		{
			this.WrapTextInSelectionHelper(" === ");
		}

		private void OnButtonEditorHeading4Click(object sender, EventArgs e)
		{
			this.WrapTextInSelectionHelper(" ==== ");
		}

		private void OnButtonEditorHeading5Click(object sender, EventArgs e)
		{
			this.WrapTextInSelectionHelper(" ===== ");
		}

		private void OnButtonEditorHeading6Click(object sender, EventArgs e)
		{
			this.WrapTextInSelectionHelper(" ====== ");
		}

		private void OnButtonEditorLinkClick(object sender, EventArgs e)
		{
			this.richTextBox_pagetext.Text = 
				this.Controller.WrapTextInSelectionWithLink(
					this.richTextBox_pagetext.Text, 
					this.richTextBox_pagetext.SelectionStart, 
					this.richTextBox_pagetext.SelectionStart
						+ this.richTextBox_pagetext.SelectionLength);
		}

		private void OnButtonEditorCodeClick(object sender, EventArgs e)
		{
			this.WrapTextInSelectionWithTagHelper("code");
		}

		private void OnButtonEditorQuoteClick(object sender, EventArgs e)
		{
			this.WrapTextInSelectionWithTagHelper("blockquote");
		}

		private void OnButtonEditorCategoryAddClick(object sender, EventArgs e)
		{
			this.AddCategoryToPage("Kategoriename");
		}

		private void OnButtonEditorListsNumberedLeftClick(object sender, EventArgs e)
		{
			this.ChangeListLevelHelper("#", -1);
		}


		private void OnButtonEditorListsNumberedRightClick(object sender, EventArgs e)
		{
			ChangeListLevelHelper("#", 1);
		}

		private void OnButtonEditorListsBulletsLeftClick(object sender, EventArgs e)
		{
			ChangeListLevelHelper("*", -1);
		}

		private void OnButtonEditorListsBulletsRightClick(object sender, EventArgs e)
		{
			ChangeListLevelHelper("*", 1);
		}

		private void OnCheckBoxCompactCheckedChanged(object sender, EventArgs e)
		{
            this.Controller.CompactCSVRows = (sender as CheckBox).Checked;
		}

		private void OnToolStripMenuItemHelpClick(object sender, EventArgs e)
		{
            this.Controller.DisplayHelp();
		}

		private void OnToolStripMenuItemPagetextCutClick(object sender, EventArgs e)
		{
			string txt = this.richTextBox_pagetext.Text;
			int selection_begin = this.richTextBox_pagetext.SelectionStart;
			int selection_len = this.richTextBox_pagetext.SelectionLength;
			System.Windows.Forms.Clipboard.SetText(this.richTextBox_pagetext.SelectedText);
			this.richTextBox_pagetext.Text = txt.Substring(0, selection_begin) 
				+ txt.Substring(selection_begin + selection_len);
			this.richTextBox_pagetext.SelectionStart = selection_begin;
		}

		private void OnToolStripMenuItemPagetextCopyClick(object sender, EventArgs e)
		{
			System.Windows.Forms.Clipboard.SetText(this.richTextBox_pagetext.SelectedText);
		}

		private void OnToolStripMenuItemPagetextPasteClick(object sender, EventArgs e)
		{
			string txt = this.richTextBox_pagetext.Text;
			int selection_begin = this.richTextBox_pagetext.SelectionStart;
			int selection_len = this.richTextBox_pagetext.SelectionLength;
			this.richTextBox_pagetext.Text = txt.Substring(0, selection_begin)
				+ System.Windows.Forms.Clipboard.GetText()
				+ txt.Substring(selection_begin + selection_len);
			this.richTextBox_pagetext.SelectionStart = selection_begin;
		}

		private void OnButtonShowDataClick(object sender, EventArgs e)
		{
            if (this.Controller.CSVRows.Any())
            {
                new DataView(this.Controller.AllCSVColumns, this.Controller.CSVRows).ShowDialog();
            }
		}

        IController Controller { get; set; }
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
