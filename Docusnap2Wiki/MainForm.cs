
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
		string[] categories;
		AutoCompleteStringCollection autocomplete_templates;

		Regex RE_CATEGORY = new Regex(@"\[\[Kategorie:.*\]\]");
		Regex RE_FORLOOP = new Regex(
			@".*?(?<loop_begin>[{])\s?for\s?"
				+ @"(?<loop_var>[a-zA-Z_]+[a-zA-Z0-9]*) in "
				+ @"(?<loop_iterable>[a-zA-Z_]+[a-zA-Z0-9]*)\s?}(?<loop_body>.*)"
				+ @"(?<loop_end>{\s?endfor\s?}).*"
			, RegexOptions.Singleline);

		public MainForm()
		{
			InitializeComponent();

			this.textBox_pagetitle.TextChanged += new EventHandler(OnPageTitleTextChanged);
			this.textBox_template.KeyUp += new KeyEventHandler(OnTextboxTemplateKeyUp);
			this.textBox_template.LostFocus += new EventHandler(OnTextboxTemplateLostFocus);
			
			this.treeView_categories.AfterCheck += new TreeViewEventHandler(OnTreeViewCategoriesAfterCheck);

			//this.richTextBox_pagetext.ModifiedChanged += new EventHandler(OnRichTextBoxPagetextModifiedChanged);

			this.richTextBox_pagetext.TextChanged += new EventHandler(OnRichTextBoxPagetextTextChanged);
		}

		void OnRichTextBoxPagetextTextChanged(object sender, EventArgs e)
		{
			this.HandlePageTextModified();
		}

		void OnRichTextBoxPagetextModifiedChanged(object sender, EventArgs e)
		{
			this.HandlePageTextModified();
		}

		void HandlePageTextModified()
		{
			string txt = this.richTextBox_pagetext.Text;

			Regex re = new Regex(@"\[\[Kategorie:(.*?)\]\]");
			MatchCollection matches = re.Matches(txt);

			List<string> cats = new List<string>();

			int caret_pos = this.richTextBox_pagetext.SelectionStart;

			foreach (Match m in matches)
			{
				if (m.Groups[1].Index <= caret_pos && caret_pos <= m.Groups[1].Index + m.Groups[1].Length)
				{
					continue;
				}
				cats.Add(m.Groups[1].Value);
			}

			HashSet<string> cats_union = new HashSet<string>(this.CurrentlySelectedCategories.Union(cats));
			if (cats_union.Count == this.CurrentlySelectedCategories.Count())
			{
				return;
			}

			this.Categories = this.Categories.Union(cats).ToArray();
			this.CurrentlySelectedCategories = cats_union;

			this.SetupCategories(this.Categories, this.CurrentlySelectedCategories);
		}

		void OnTreeViewCategoriesAfterCheck(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Checked)
			{
				AddCategoryToPage(e.Node.Text);
			}
			else
			{
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
			Page p = new Page(this.Site, pagetitle);
			p.Load();
			if (!p.IsEmpty())
			{
				this.FillFormFromPage(p);
			}
			else
			{
				MessageBox.Show("Diese Seite ist nicht-existent.", "Vorlage nicht gefunden");
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
				IEnumerator<string[]> rows_enumerator = this.ReadCSV(dlg.FileName).GetEnumerator();
				if (!rows_enumerator.MoveNext())
				{
					MessageBox.Show("Datei enthält keine Einträge");
					return;
				}

				if (this.checkBox_csv_has_column_titles.Checked)
				{
					try
					{
						this.UpdateColumnNodes(rows_enumerator.Current);
					}
					catch (Microsoft.VisualBasic.FileIO.MalformedLineException ex)
					{
						MessageBox.Show(ex.Message);
						return;
					}
				}
				else
				{
					this.UpdateColumnNodes(
						Enumerable.Range(1, rows_enumerator.Current.Length).Select(
							o => string.Format("Spalte {0}", o)
						).ToArray()
					);
				}

				this.UpdateCSVInput(rows_enumerator);			
			}
		}

		private void UpdateCSVInput(IEnumerator<string[]> rows_enumerator)
		{
			List<string[]> new_rows = new List<string[]>();
			try
			{
				while (rows_enumerator.MoveNext())
				{
					new_rows.Add(rows_enumerator.Current);
				}
			}
			catch (Microsoft.VisualBasic.FileIO.MalformedLineException ex)
			{
				MessageBox.Show(ex.Message);
			}

			if (this.checkBox_compact.Checked)
			{
				List<int> selected_columns = new List<int>(this.SelectedCSVColumns);
				if (selected_columns.Count == 0)
				{
					MessageBox.Show("Keine Spalten ausgewählt");
				}
				else
				{
					new_rows = this.CompactRows(new_rows, selected_columns[0]);
				}
			}

			this.Rows = new_rows;	
		}

		void UpdateColumnNodes(string[] colnames)
		{
			this.treeView_columns.BeginUpdate();
			this.treeView_columns.Nodes.Clear();
			TreeNode n = null;
			foreach (string colname in colnames)
			{
				n = new TreeNode(colname);
				n.Checked = true;
				this.treeView_columns.Nodes.Add(n);
			}
			this.treeView_columns.EndUpdate();
		}

		IEnumerable<string[]> ReadCSV(string filepath)
		{
			Microsoft.VisualBasic.FileIO.TextFieldParser p = new Microsoft.VisualBasic.FileIO.TextFieldParser(filepath);
			p.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
			p.Delimiters = new String[] {";"};

			while (!p.EndOfData)
			{
				yield return p.ReadFields();
			}
		}

		private void OnButtonUploadClick(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			Page p = null;
			DialogResult answer = DialogResult.Retry;		// default value corresponding to 'null'

			if (!RE_CATEGORY.Match(this.richTextBox_pagetext.Text).Success)
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
			
			if (this.Rows.Count == 0)
			{
				answer = MessageBox.Show("Es ist keine CSV Datei geladen. Wollen Sie die Seite so, wie sie ist, erstellen?", 
					"Keine Kontext-Informationen", MessageBoxButtons.YesNo);
				if (answer == System.Windows.Forms.DialogResult.Yes)
				{
					string pagetext = this.FormatWithContext(this.richTextBox_pagetext.Text, new Dictionary<string, object>(), 1, 1);
					string pagetitle = this.FormatWithContext(this.textBox_pagetitle.Text, new Dictionary<string, object>(), 1, 1);
					if (string.IsNullOrEmpty(pagetitle))
					{
						MessageBox.Show("Es muss ein Seitentitel angegeben werden.", "Leerer Seitentitel");
						return;
					}
					p = new Page(this.Site, pagetitle);
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

			List<Tuple<GenerationState, string, string>> generated_contents = new List<Tuple<GenerationState, string, string>>();
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

			int current_row_no = 1;
			foreach (string[] row in this.Rows)
			{
				Dictionary<string, object> context = this.MakeContext(row);
				string pagetext = this.FormatWithContext(this.richTextBox_pagetext.Text, context, current_row_no, this.Rows.Count);
				string pagetitle = this.FormatWithContext(this.textBox_pagetitle.Text, context, current_row_no, this.Rows.Count);
				GenerationState write_status = GenerationState.New;
				
				if (string.IsNullOrEmpty(pagetitle))
				{
					MessageBox.Show("Zeile " + current_row_no.ToString() + ": Der Seitentitel ist leer. Die Seite kann nicht angelegt werden.", "Leerer Seitentitel");
					return;
				}
				else
				{
					p = new Page(this.Site, pagetitle);
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
					p = new Page(this.Site, tup.Item2);
					p.Load();
					p.text = tup.Item3;
					p.Save(this.textBox_comment.Text, false);
				}
			}

			Cursor.Current = Cursors.Default;

			string siteurl = System.IO.Path.Combine(Site.site, Site.indexPath);
			string[] gen_state_desc = new string[] {"Ignoriert", "Neu", "Überschrieben"};

			new MessageBoxWithDetails(
				  "Zusammenfassung"
				, string.Format("Neue Seiten: {0}." + Environment.NewLine 
								+ "Überschriebene Seiten: {1}" + Environment.NewLine 
								+ "Ignorierte Einträge: {2}"
								+ "Einträge insgesamt: {3}"
								, generated_contents.Count(o => o.Item1 == GenerationState.New)
								, generated_contents.Count(o => o.Item1 == GenerationState.Overwrite)
								, generated_contents.Count(o => o.Item1 == GenerationState.None)
								, generated_contents.Count())
				, string.Join(
					  Environment.NewLine
					, generated_contents.Select(
						o => string.Format(
							"{0}: {1}"
							, gen_state_desc[(int)o.Item1]
							, System.IO.Path.Combine(siteurl, o.Item2)
						)
					).ToArray()
				)
			).ShowDialog();
		}

		public string FormatWithContext(string fmt, Dictionary<string, object> context, int row_no, int rows_count)
		{
			string rv = fmt.Replace("{index}", row_no.ToString()).Replace("{row_count}", rows_count.ToString());
			
			Match match_forloop = null;
			do
			{
				match_forloop = RE_FORLOOP.Match(rv);
				if (match_forloop.Success)
				{
					int loop_begin = match_forloop.Groups["loop_begin"].Index;
					int loop_end = match_forloop.Groups["loop_end"].Index + match_forloop.Groups["loop_end"].Length;
					string loop_iterable = match_forloop.Groups["loop_iterable"].Value;
					string loop_var = match_forloop.Groups["loop_var"].Value;
					string loop_body = match_forloop.Groups["loop_body"].Value;
					
					IEnumerable<string> iterable = ConvertToEnumerable(context[loop_iterable].ToString());

					string rvcopy = rv;
					rv = rvcopy.Substring(0, loop_begin);
					foreach (object o in iterable)
					{
						Dictionary<string, object> loop_context = new Dictionary<string, object>(context);
						loop_context.Add(loop_var, o.ToString());

						rv += FormatWithContext(loop_body, 
								                loop_context, 
									            row_no, 
												rows_count);
					}
					rv += rvcopy.Substring(loop_end);
				}
			} while(match_forloop.Success);

			foreach (KeyValuePair<string, object> kv in context)
			{
				rv = rv.Replace("{{{" + kv.Key + "}}}", kv.Value.ToString());
			}
			return rv;
		}

		public IEnumerable<string> ConvertToEnumerable(string input)
		{
			try
			{
				return input.Split(',').Select(o => o.Trim());
			}
			catch(Exception)
			{
				return new string[]{};
			}
		}

		public Dictionary<string, object> MakeContext(string[] row)
		{
			Dictionary<string, object> context = new Dictionary<string, object>();
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

		private void OnMainFormLoad(object sender, EventArgs e)
		{
			this.SetupTemplates();
			this.SetupCategories();
		}

		private void SetupTemplates()
		{
			this.autocomplete_templates = new AutoCompleteStringCollection();
			this.textBox_template.AutoCompleteSource = AutoCompleteSource.CustomSource;
			this.autocomplete_templates.AddRange(this.GetAllTemplates());
			this.textBox_template.AutoCompleteCustomSource = this.autocomplete_templates;
			this.textBox_template.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
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

		void SetupCategories()
		{
			this.SetupCategories(this.GetAllCategories(), this.CurrentlySelectedCategories);
		}

		void SetupCategories(IEnumerable<string> cats, IEnumerable<string> checked_cats)
		{
			List<string> checked_cats_ = checked_cats.ToList();

			this.treeView_categories.BeginUpdate();
			this.treeView_categories.Nodes.Clear();

			List<TreeNode> nodes = new List<TreeNode>();
			foreach (string cat in cats)
			{
				TreeNode n = new TreeNode(cat);
				nodes.Add(n);
			}

			this.treeView_categories.Nodes.AddRange(nodes.ToArray());

			this.CurrentlySelectedCategories = checked_cats;

			this.treeView_categories.EndUpdate();
		}

		void OnLoginSuccess(object sender, LoginSuccessEventArgs e)
		{
			this.site = new Site(e.WikiURL, e.Username, e.Password);
		}

		public void FillFormFromPage(Page p)
		{
			this.textBox_comment.Text = p.comment;
			this.richTextBox_pagetext.Text = p.text;

			List<string> cats_in_page = p.GetAllCategories().ToList();

			this.CurrentlySelectedCategories = cats_in_page;
		}

		private void OnCheckBoxCsvHasColumnTitlesCheckedChanged(object sender, EventArgs e)
		{
			IEnumerator<string[]> rows_enumerator = 
				this.ReadCSV(this.textBox_input_path.Text).GetEnumerator();

			if (!rows_enumerator.MoveNext())
			{
				MessageBox.Show("Datei enthält keine Einträge");
				return;
			}

			if (this.checkBox_csv_has_column_titles.Checked)
			{
				try
				{
					this.UpdateColumnNodes(rows_enumerator.Current);
				}
				catch (Microsoft.VisualBasic.FileIO.MalformedLineException ex)
				{
					MessageBox.Show(ex.Message);
					return;
				}
			}
			else
			{
				this.UpdateColumnNodes(
					Enumerable.Range(1, rows_enumerator.Current.Length).Select(
						o => string.Format("Spalte {0}", o)
					).ToArray()
				);
			}
		}

		private void DisplayHelp()
		{
			System.Windows.Forms.Help.ShowHelp(this, System.IO.Path.Combine(Application.StartupPath, "helpfile.txt"));
		}

		private void OnEditorButtonItalicClick(object sender, EventArgs e)
		{
			this.WrapTextInSelection("''");
		}

		private void WrapTextIn(int start, int end, string before, string after)
		{
			string txt = this.richTextBox_pagetext.Text;
			this.richTextBox_pagetext.Text = txt.Substring(0, start) + before + txt.Substring(start, end - start) + after + txt.Substring(end);
		}

		private void WrapTextInSelection(string with_)
		{
			this.WrapTextIn(this.richTextBox_pagetext.SelectionStart, this.richTextBox_pagetext.SelectionStart + this.richTextBox_pagetext.SelectionLength, with_, with_);
		}

		private void WrapTextInSelectionWithTag(string tag)
		{
			this.WrapTextIn(this.richTextBox_pagetext.SelectionStart, this.richTextBox_pagetext.SelectionStart + this.richTextBox_pagetext.SelectionLength, "<" + tag + ">", "</" + tag + ">");
		}

		private void WrapTextInSelectionWithLink()
		{
			string txt = this.richTextBox_pagetext.Text;
			int start = this.richTextBox_pagetext.SelectionStart;
			int end = this.richTextBox_pagetext.SelectionStart + this.richTextBox_pagetext.SelectionLength;
			string before = "[[";
			string after = "]]";
			this.richTextBox_pagetext.Text = txt.Substring(0, start) + before + txt.Substring(start, end-start).Replace(' ', '_') + "|" + txt.Substring(start, end - start) + after + txt.Substring(end);
		}

		private void OnButtonEditorBoldClick(object sender, EventArgs e)
		{
			this.WrapTextInSelection("'''");
		}

		private void OnButtonEditorItalicBoldClick(object sender, EventArgs e)
		{
			this.WrapTextInSelection("'''''");
		}

		private void OnButtonEditorStrikeClick(object sender, EventArgs e)
		{
			this.WrapTextInSelectionWithTag("strike");
		}

		private void OnButtonEditorNowikiClick(object sender, EventArgs e)
		{
			this.WrapTextInSelectionWithTag("nowiki");
		}

		private void OnButtonEditorHeading2Click(object sender, EventArgs e)
		{
			this.WrapTextInSelection(" == ");
		}

		private void OnButtonEditorHeading3Click(object sender, EventArgs e)
		{
			this.WrapTextInSelection(" === ");
		}

		private void OnButtonEditorHeading4Click(object sender, EventArgs e)
		{
			this.WrapTextInSelection(" ==== ");
		}

		private void OnButtonEditorHeading5Click(object sender, EventArgs e)
		{
			this.WrapTextInSelection(" ===== ");
		}

		private void OnButtonEditorHeading6Click(object sender, EventArgs e)
		{
			this.WrapTextInSelection(" ====== ");
		}

		private void OnButtonEditorLinkClick(object sender, EventArgs e)
		{
			this.WrapTextInSelectionWithLink();
		}

		private void OnButtonEditorCodeClick(object sender, EventArgs e)
		{
			this.WrapTextInSelectionWithTag("code");
		}

		private void OnButtonEditorQuoteClick(object sender, EventArgs e)
		{
			this.WrapTextInSelectionWithTag("blockquote");
		}

		private void OnButtonEditorCategoryAddClick(object sender, EventArgs e)
		{
			this.AddCategoryToPage("Kategoriename");
		}

		private void ChangeListLevel(string pointsign, int direction)
		{
			if (direction == 0)
			{
				throw new ArgumentException("direction must not be greater or less than 0.");
			}

			string newline = "\n";

			string txt = this.richTextBox_pagetext.Text;
			int start = this.richTextBox_pagetext.SelectionStart;

			List<string> lines = txt.Split(new string[] { newline },StringSplitOptions.None).ToList();
			List<string> res = new List<string>();

			int line_index = 0;
			int count = 0;
			foreach (string line in lines)
			{
				count += line.Length + 1;
				if (start < count)
				{
					break;
				}
				line_index++;
			}

			int i = 0;
			while (i < line_index)
			{
				res.Add(lines[i++]);
			}

			// get index of pointsign and add another pointsign or strip it, according to *direction*
			string ln = lines[line_index];
			if (ln.IndexOf(pointsign) == -1)
			{
				res.Add((direction < 0 ? string.Empty : pointsign) + ln);
			}
			else
			{
				for (int j = 0; j < ln.Length; j++)
				{
					if (ln.Substring(j, 1) == pointsign)
					{
						if (direction < 0)
						{
							res.Add(ln.Substring(0, j) + ln.Substring(j + 1));
						}
						else
						{
							res.Add(ln.Substring(0, j) + pointsign + ln.Substring(j));
						}
						break;
					}
				}
			}

			while (++i < lines.Count)
			{
				res.Add(lines[i]);
			}

			string newtext =string.Join(newline, res.ToArray());
			

			if (newtext != txt)
			{
				this.richTextBox_pagetext.Text = newtext;
				this.richTextBox_pagetext.SelectionStart = Math.Max((direction < 0 ? start - 1 : start), 0);
			}
		}

		private void OnButtonEditorListsNumberedLeftClick(object sender, EventArgs e)
		{
			this.ChangeListLevel("#", -1);
		}


		private void OnButtonEditorListsNumberedRightClick(object sender, EventArgs e)
		{
			ChangeListLevel("#", 1);
		}

		private void OnButtonEditorListsBulletsLeftClick(object sender, EventArgs e)
		{
			ChangeListLevel("*", -1);
		}

		private void OnButtonEditorListsBulletsRightClick(object sender, EventArgs e)
		{
			ChangeListLevel("*", 1);
		}

		public bool IsPageProtected(string pagetitle)
		{
			string[] bits = { Site.site, Site.indexPath, "index.php?title=", 
									System.Uri.EscapeUriString(pagetitle) };
			string src = Site.GetPageHTM(string.Join("", bits));
			return !src.Contains("...");
		}

		private string[] GetAllCategories()
		{
			List<string> cats = new List<string>();
			string[] bits = { Site.site, Site.indexPath, 
								"api.php?format=xml&action=query&list=allcategories" };
			string src = Site.GetPageHTM(string.Join("", bits));

			XmlDocument doc = new XmlDocument();
			doc.LoadXml(src);
			XmlNode node = doc.SelectSingleNode("/api/query/allcategories");
			foreach (XmlNode n in node)
			{
				cats.Add(n.InnerText.Trim());
			}
			return cats.ToArray();
		}

		private string[] GetAllTemplates()
		{
			List<string> templates = new List<string>();
			string[] bits = { Site.site, Site.indexPath, 
								"api.php?action=query&format=xml&list=allpages&aplimit=5000&apnamespace=10" };
			string url = string.Join("", bits);
			string src = Site.GetPageHTM(url);

			XmlDocument doc = new XmlDocument();
			doc.LoadXml(src);
			XmlNodeList nodes = doc.SelectNodes("/api/query/allpages/p");
			foreach (XmlNode n in nodes)
			{
				templates.Add(n.Attributes["title"].InnerText.Trim());
			}

			return templates.ToArray();
		}

		public string[] Categories
		{
			get
			{
				if (this.categories == null)
				{
					this.categories = this.GetAllCategories();
				}
				return this.categories;
			}
			set
			{
				this.categories = value;
			}
		}

		List<string> currently_selected_categories;
		public IEnumerable<string> CurrentlySelectedCategories
		{
			get
			{
				if (this.currently_selected_categories == null)
				{
					this.currently_selected_categories = new List<string>();			

					foreach (TreeNode n in this.treeView_categories.Nodes)
					{
						if (n.Checked)
						{
							currently_selected_categories.Add(n.Text);
						}
					}
				}
				return this.currently_selected_categories;
			}
			set
			{
				List<string> cats = (this.currently_selected_categories == null)
					? new List<string>(value)
					: value.Union(this.currently_selected_categories).ToList();
				this.currently_selected_categories = null;
				
				foreach (TreeNode n in this.treeView_categories.Nodes)
				{
					n.Checked = cats.Contains(n.Text);
				}
			}
		}

		private void OnCheckBoxCompactCheckedChanged(object sender, EventArgs e)
		{
			this.UpdateCSVInput(this.CopyRows(this.Rows).GetEnumerator());
		}

		IEnumerable<string[]> CopyRows(List<string[]> rows_)
		{
			// deep copy 'Rows'
			foreach (string[] row in rows)
			{
				List<string> row_copy = new List<string>();
				foreach (string s in row)
				{
					row_copy.Add(string.Copy(s));
				}
				yield return row_copy.ToArray();
			}
		}

		List<string[]> CompactRows(List<string[]> rows, int groupby_column)
		{
			if (rows.Count == 0)
			{
				return rows;
			}
			
			int n_row_fields = rows[0].Length;

			if (groupby_column >= n_row_fields)
			{
				throw new IndexOutOfRangeException(
					"groupby_column >= n_row_fields");
			}

			List<string[]> compacted = new List<string[]>();

			IEnumerable<IGrouping<string, string[]>> groupings = 
				rows.GroupBy(arr => arr[groupby_column]);

			List<HashSet<string>> row = null;
			foreach(IGrouping<string, string[]> grouping in groupings)
			{
				row = new List<HashSet<string>>();
				
				// generate lists for compacting values
				for(int i = 0; i < n_row_fields; ++i)
				{
					row.Add(new HashSet<string>());
				}

				// there's only one value in this list
				row[groupby_column].Add(grouping.Key);
					
				foreach(string[] r in grouping)
				{
					int j = 0;
					foreach(string v in r)
					{
						if (j != groupby_column)
						{
							row[j].Add(v);
						}
						++j;
					}
				}

				compacted.Add(row.Select(
					o => string.Join(", ", o.ToArray())).ToArray());
			}

			return compacted;
		}

		IEnumerable<int> SelectedCSVColumns
		{
			get
			{
				int i = 0;
				foreach (TreeNode n in this.treeView_columns.Nodes)
				{
					if (n.Checked)
					{
						yield return i;
					}
					++i;
				}
			}
		}

		private void OnToolStripMenuItemHelpClick(object sender, EventArgs e)
		{
			DisplayHelp();
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
			new DataView(this.CSVColumnNames, this.Rows).ShowDialog();
		}

		public string[] CSVColumnNames
		{
			get
			{
				List<string> colnames = new List<string>();
				foreach (TreeNode n in this.treeView_columns.Nodes)
				{
					colnames.Add(n.Text);
				}
				return colnames.ToArray();
			}
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
