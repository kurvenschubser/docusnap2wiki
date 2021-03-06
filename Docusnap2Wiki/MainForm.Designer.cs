﻿namespace Docusnap2Wiki
{
	partial class MainForm
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.richTextBox_pagetext = new System.Windows.Forms.RichTextBox();
			this.contextMenuStrip_pagetext = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem_pagetext_cut = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_pagetext_copy = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_pagetext_paste = new System.Windows.Forms.ToolStripMenuItem();
			this.label_pagetext = new System.Windows.Forms.Label();
			this.textBox_pagetitle = new System.Windows.Forms.TextBox();
			this.label_pagetitle = new System.Windows.Forms.Label();
			this.button_upload = new System.Windows.Forms.Button();
			this.textBox_input_path = new System.Windows.Forms.TextBox();
			this.label_inputfile = new System.Windows.Forms.Label();
			this.button_browse_inputfile = new System.Windows.Forms.Button();
			this.label_columns = new System.Windows.Forms.Label();
			this.label_comment = new System.Windows.Forms.Label();
			this.textBox_comment = new System.Windows.Forms.TextBox();
			this.timer_template = new System.Windows.Forms.Timer(this.components);
			this.label_template = new System.Windows.Forms.Label();
			this.textBox_template = new System.Windows.Forms.TextBox();
			this.checkBox_csv_has_column_titles = new System.Windows.Forms.CheckBox();
			this.treeView_columns = new System.Windows.Forms.TreeView();
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			this.button_editor_italic = new System.Windows.Forms.Button();
			this.button_editor_bold = new System.Windows.Forms.Button();
			this.button_editor_italic_bold = new System.Windows.Forms.Button();
			this.button_editor_strike = new System.Windows.Forms.Button();
			this.button_editor_nowiki = new System.Windows.Forms.Button();
			this.groupBox_editor_headings = new System.Windows.Forms.GroupBox();
			this.button_editor_heading6 = new System.Windows.Forms.Button();
			this.button_editor_heading5 = new System.Windows.Forms.Button();
			this.button_editor_heading4 = new System.Windows.Forms.Button();
			this.button_editor_heading3 = new System.Windows.Forms.Button();
			this.button_editor_heading2 = new System.Windows.Forms.Button();
			this.button_editor_link = new System.Windows.Forms.Button();
			this.groupBox_editor_styles = new System.Windows.Forms.GroupBox();
			this.button_editor_underlined = new System.Windows.Forms.Button();
			this.groupBox_editor_diverse = new System.Windows.Forms.GroupBox();
			this.button_editor_quote = new System.Windows.Forms.Button();
			this.button_editor_code = new System.Windows.Forms.Button();
			this.groupBox_editor_lists = new System.Windows.Forms.GroupBox();
			this.button_editor_lists_bullets_right = new System.Windows.Forms.Button();
			this.button_editor_lists_bullets_left = new System.Windows.Forms.Button();
			this.label_editor_lists_bullets = new System.Windows.Forms.Label();
			this.label_editor_lists_numbered = new System.Windows.Forms.Label();
			this.button_editor_lists_numbered_right = new System.Windows.Forms.Button();
			this.button_editor_lists_numbered_left = new System.Windows.Forms.Button();
			this.label_categories = new System.Windows.Forms.Label();
			this.treeView_categories = new System.Windows.Forms.TreeView();
			this.groupBox_editor_categories = new System.Windows.Forms.GroupBox();
			this.button_editor_category_add = new System.Windows.Forms.Button();
			this.checkBox_compact = new System.Windows.Forms.CheckBox();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.ToolStripMenuItem_help = new System.Windows.Forms.ToolStripMenuItem();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.button_show_data = new System.Windows.Forms.Button();
			this.contextMenuStrip_pagetext.SuspendLayout();
			this.groupBox_editor_headings.SuspendLayout();
			this.groupBox_editor_styles.SuspendLayout();
			this.groupBox_editor_diverse.SuspendLayout();
			this.groupBox_editor_lists.SuspendLayout();
			this.groupBox_editor_categories.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// richTextBox_pagetext
			// 
			this.richTextBox_pagetext.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.richTextBox_pagetext.ContextMenuStrip = this.contextMenuStrip_pagetext;
			this.richTextBox_pagetext.Location = new System.Drawing.Point(103, 248);
			this.richTextBox_pagetext.Name = "richTextBox_pagetext";
			this.richTextBox_pagetext.Size = new System.Drawing.Size(425, 348);
			this.richTextBox_pagetext.TabIndex = 0;
			this.richTextBox_pagetext.Text = "";
			// 
			// contextMenuStrip_pagetext
			// 
			this.contextMenuStrip_pagetext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_pagetext_cut,
            this.toolStripMenuItem_pagetext_copy,
            this.toolStripMenuItem_pagetext_paste});
			this.contextMenuStrip_pagetext.Name = "contextMenuStrip_pagetext";
			this.contextMenuStrip_pagetext.Size = new System.Drawing.Size(149, 70);
			// 
			// toolStripMenuItem_pagetext_cut
			// 
			this.toolStripMenuItem_pagetext_cut.Name = "toolStripMenuItem_pagetext_cut";
			this.toolStripMenuItem_pagetext_cut.Size = new System.Drawing.Size(148, 22);
			this.toolStripMenuItem_pagetext_cut.Text = "Ausschneiden";
			this.toolStripMenuItem_pagetext_cut.Click += new System.EventHandler(this.OnToolStripMenuItemPagetextCutClick);
			// 
			// toolStripMenuItem_pagetext_copy
			// 
			this.toolStripMenuItem_pagetext_copy.Name = "toolStripMenuItem_pagetext_copy";
			this.toolStripMenuItem_pagetext_copy.Size = new System.Drawing.Size(148, 22);
			this.toolStripMenuItem_pagetext_copy.Text = "Kopieren";
			this.toolStripMenuItem_pagetext_copy.Click += new System.EventHandler(this.OnToolStripMenuItemPagetextCopyClick);
			// 
			// toolStripMenuItem_pagetext_paste
			// 
			this.toolStripMenuItem_pagetext_paste.Name = "toolStripMenuItem_pagetext_paste";
			this.toolStripMenuItem_pagetext_paste.Size = new System.Drawing.Size(148, 22);
			this.toolStripMenuItem_pagetext_paste.Text = "Einfügen";
			this.toolStripMenuItem_pagetext_paste.Click += new System.EventHandler(this.OnToolStripMenuItemPagetextPasteClick);
			// 
			// label_pagetext
			// 
			this.label_pagetext.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label_pagetext.AutoSize = true;
			this.label_pagetext.Location = new System.Drawing.Point(1, 252);
			this.label_pagetext.Name = "label_pagetext";
			this.label_pagetext.Size = new System.Drawing.Size(54, 13);
			this.label_pagetext.TabIndex = 1;
			this.label_pagetext.Text = "Seitentext";
			// 
			// textBox_pagetitle
			// 
			this.textBox_pagetitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.textBox_pagetitle.Location = new System.Drawing.Point(103, 222);
			this.textBox_pagetitle.Name = "textBox_pagetitle";
			this.textBox_pagetitle.Size = new System.Drawing.Size(425, 20);
			this.textBox_pagetitle.TabIndex = 2;
			// 
			// label_pagetitle
			// 
			this.label_pagetitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label_pagetitle.AutoSize = true;
			this.label_pagetitle.Location = new System.Drawing.Point(1, 226);
			this.label_pagetitle.Name = "label_pagetitle";
			this.label_pagetitle.Size = new System.Drawing.Size(53, 13);
			this.label_pagetitle.TabIndex = 3;
			this.label_pagetitle.Text = "Seitentitel";
			// 
			// button_upload
			// 
			this.button_upload.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.button_upload.Location = new System.Drawing.Point(535, 725);
			this.button_upload.Name = "button_upload";
			this.button_upload.Size = new System.Drawing.Size(112, 24);
			this.button_upload.TabIndex = 6;
			this.button_upload.Text = "Hochladen";
			this.button_upload.UseVisualStyleBackColor = true;
			this.button_upload.Click += new System.EventHandler(this.OnButtonUploadClick);
			// 
			// textBox_input_path
			// 
			this.textBox_input_path.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.textBox_input_path.Location = new System.Drawing.Point(103, 27);
			this.textBox_input_path.Name = "textBox_input_path";
			this.textBox_input_path.Size = new System.Drawing.Size(425, 20);
			this.textBox_input_path.TabIndex = 9;
			// 
			// label_inputfile
			// 
			this.label_inputfile.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label_inputfile.AutoSize = true;
			this.label_inputfile.Location = new System.Drawing.Point(0, 27);
			this.label_inputfile.Name = "label_inputfile";
			this.label_inputfile.Size = new System.Drawing.Size(59, 13);
			this.label_inputfile.TabIndex = 10;
			this.label_inputfile.Text = "Input Datei";
			// 
			// button_browse_inputfile
			// 
			this.button_browse_inputfile.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.button_browse_inputfile.Location = new System.Drawing.Point(535, 26);
			this.button_browse_inputfile.Name = "button_browse_inputfile";
			this.button_browse_inputfile.Size = new System.Drawing.Size(112, 23);
			this.button_browse_inputfile.TabIndex = 11;
			this.button_browse_inputfile.Text = "Datei öffnen";
			this.button_browse_inputfile.UseVisualStyleBackColor = true;
			this.button_browse_inputfile.Click += new System.EventHandler(this.OnBrowseInputFileClick);
			// 
			// label_columns
			// 
			this.label_columns.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label_columns.AutoSize = true;
			this.label_columns.Location = new System.Drawing.Point(0, 80);
			this.label_columns.Name = "label_columns";
			this.label_columns.Size = new System.Drawing.Size(29, 13);
			this.label_columns.TabIndex = 13;
			this.label_columns.Text = "Filter";
			// 
			// label_comment
			// 
			this.label_comment.AutoSize = true;
			this.label_comment.Location = new System.Drawing.Point(1, 730);
			this.label_comment.Name = "label_comment";
			this.label_comment.Size = new System.Drawing.Size(60, 13);
			this.label_comment.TabIndex = 19;
			this.label_comment.Text = "Kommentar";
			// 
			// textBox_comment
			// 
			this.textBox_comment.Location = new System.Drawing.Point(103, 727);
			this.textBox_comment.Name = "textBox_comment";
			this.textBox_comment.Size = new System.Drawing.Size(423, 20);
			this.textBox_comment.TabIndex = 20;
			// 
			// timer_template
			// 
			this.timer_template.Interval = 600;
			// 
			// label_template
			// 
			this.label_template.AutoSize = true;
			this.label_template.Location = new System.Drawing.Point(1, 197);
			this.label_template.Name = "label_template";
			this.label_template.Size = new System.Drawing.Size(43, 13);
			this.label_template.TabIndex = 22;
			this.label_template.Text = "Vorlage";
			// 
			// textBox_template
			// 
			this.textBox_template.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.textBox_template.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.textBox_template.Location = new System.Drawing.Point(103, 194);
			this.textBox_template.Name = "textBox_template";
			this.textBox_template.Size = new System.Drawing.Size(423, 20);
			this.textBox_template.TabIndex = 23;
			// 
			// checkBox_csv_has_column_titles
			// 
			this.checkBox_csv_has_column_titles.AutoSize = true;
			this.checkBox_csv_has_column_titles.Checked = true;
			this.checkBox_csv_has_column_titles.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_csv_has_column_titles.Location = new System.Drawing.Point(103, 54);
			this.checkBox_csv_has_column_titles.Name = "checkBox_csv_has_column_titles";
			this.checkBox_csv_has_column_titles.Size = new System.Drawing.Size(165, 17);
			this.checkBox_csv_has_column_titles.TabIndex = 24;
			this.checkBox_csv_has_column_titles.Text = "CSV hat Spaltenüberschriften";
			this.checkBox_csv_has_column_titles.UseVisualStyleBackColor = true;
			this.checkBox_csv_has_column_titles.CheckedChanged += new System.EventHandler(this.OnCheckBoxCsvHasColumnTitlesCheckedChanged);
			// 
			// treeView_columns
			// 
			this.treeView_columns.CheckBoxes = true;
			this.treeView_columns.Location = new System.Drawing.Point(103, 80);
			this.treeView_columns.Name = "treeView_columns";
			this.treeView_columns.Size = new System.Drawing.Size(423, 108);
			this.treeView_columns.TabIndex = 25;
			// 
			// button_editor_italic
			// 
			this.button_editor_italic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button_editor_italic.Location = new System.Drawing.Point(5, 16);
			this.button_editor_italic.Name = "button_editor_italic";
			this.button_editor_italic.Size = new System.Drawing.Size(22, 23);
			this.button_editor_italic.TabIndex = 27;
			this.button_editor_italic.Text = "i";
			this.toolTip.SetToolTip(this.button_editor_italic, "kursiv");
			this.button_editor_italic.UseVisualStyleBackColor = true;
			this.button_editor_italic.Click += new System.EventHandler(this.OnEditorButtonItalicClick);
			// 
			// button_editor_bold
			// 
			this.button_editor_bold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button_editor_bold.Location = new System.Drawing.Point(42, 16);
			this.button_editor_bold.Name = "button_editor_bold";
			this.button_editor_bold.Size = new System.Drawing.Size(26, 23);
			this.button_editor_bold.TabIndex = 28;
			this.button_editor_bold.Text = "button1";
			this.toolTip.SetToolTip(this.button_editor_bold, "fett");
			this.button_editor_bold.UseVisualStyleBackColor = true;
			this.button_editor_bold.Click += new System.EventHandler(this.OnButtonEditorBoldClick);
			// 
			// button_editor_italic_bold
			// 
			this.button_editor_italic_bold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button_editor_italic_bold.Location = new System.Drawing.Point(81, 16);
			this.button_editor_italic_bold.Name = "button_editor_italic_bold";
			this.button_editor_italic_bold.Size = new System.Drawing.Size(25, 23);
			this.button_editor_italic_bold.TabIndex = 29;
			this.button_editor_italic_bold.Text = "ib";
			this.toolTip.SetToolTip(this.button_editor_italic_bold, "kursiv+fett");
			this.button_editor_italic_bold.UseVisualStyleBackColor = true;
			this.button_editor_italic_bold.Click += new System.EventHandler(this.OnButtonEditorItalicBoldClick);
			// 
			// button_editor_strike
			// 
			this.button_editor_strike.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button_editor_strike.Location = new System.Drawing.Point(5, 41);
			this.button_editor_strike.Name = "button_editor_strike";
			this.button_editor_strike.Size = new System.Drawing.Size(29, 23);
			this.button_editor_strike.TabIndex = 30;
			this.button_editor_strike.Text = "gL";
			this.toolTip.SetToolTip(this.button_editor_strike, "durchgestrichen");
			this.button_editor_strike.UseVisualStyleBackColor = true;
			this.button_editor_strike.Click += new System.EventHandler(this.OnButtonEditorStrikeClick);
			// 
			// button_editor_nowiki
			// 
			this.button_editor_nowiki.Location = new System.Drawing.Point(53, 19);
			this.button_editor_nowiki.Name = "button_editor_nowiki";
			this.button_editor_nowiki.Size = new System.Drawing.Size(51, 23);
			this.button_editor_nowiki.TabIndex = 31;
			this.button_editor_nowiki.Text = "NoWiki";
			this.button_editor_nowiki.UseVisualStyleBackColor = true;
			this.button_editor_nowiki.Click += new System.EventHandler(this.OnButtonEditorNowikiClick);
			// 
			// groupBox_editor_headings
			// 
			this.groupBox_editor_headings.Controls.Add(this.button_editor_heading6);
			this.groupBox_editor_headings.Controls.Add(this.button_editor_heading5);
			this.groupBox_editor_headings.Controls.Add(this.button_editor_heading4);
			this.groupBox_editor_headings.Controls.Add(this.button_editor_heading3);
			this.groupBox_editor_headings.Controls.Add(this.button_editor_heading2);
			this.groupBox_editor_headings.Location = new System.Drawing.Point(535, 324);
			this.groupBox_editor_headings.Name = "groupBox_editor_headings";
			this.groupBox_editor_headings.Size = new System.Drawing.Size(112, 53);
			this.groupBox_editor_headings.TabIndex = 32;
			this.groupBox_editor_headings.TabStop = false;
			this.groupBox_editor_headings.Text = "Überschriften";
			// 
			// button_editor_heading6
			// 
			this.button_editor_heading6.Location = new System.Drawing.Point(86, 20);
			this.button_editor_heading6.Name = "button_editor_heading6";
			this.button_editor_heading6.Size = new System.Drawing.Size(18, 23);
			this.button_editor_heading6.TabIndex = 4;
			this.button_editor_heading6.Text = "6";
			this.toolTip.SetToolTip(this.button_editor_heading6, "h6-Überschrift");
			this.button_editor_heading6.UseVisualStyleBackColor = true;
			this.button_editor_heading6.Click += new System.EventHandler(this.OnButtonEditorHeading6Click);
			// 
			// button_editor_heading5
			// 
			this.button_editor_heading5.Location = new System.Drawing.Point(66, 20);
			this.button_editor_heading5.Name = "button_editor_heading5";
			this.button_editor_heading5.Size = new System.Drawing.Size(18, 23);
			this.button_editor_heading5.TabIndex = 3;
			this.button_editor_heading5.Text = "5";
			this.toolTip.SetToolTip(this.button_editor_heading5, "h5-Überschrift");
			this.button_editor_heading5.UseVisualStyleBackColor = true;
			this.button_editor_heading5.Click += new System.EventHandler(this.OnButtonEditorHeading5Click);
			// 
			// button_editor_heading4
			// 
			this.button_editor_heading4.Location = new System.Drawing.Point(46, 20);
			this.button_editor_heading4.Name = "button_editor_heading4";
			this.button_editor_heading4.Size = new System.Drawing.Size(18, 23);
			this.button_editor_heading4.TabIndex = 2;
			this.button_editor_heading4.Text = "4";
			this.toolTip.SetToolTip(this.button_editor_heading4, "h4-Überschrift");
			this.button_editor_heading4.UseVisualStyleBackColor = true;
			this.button_editor_heading4.Click += new System.EventHandler(this.OnButtonEditorHeading4Click);
			// 
			// button_editor_heading3
			// 
			this.button_editor_heading3.Location = new System.Drawing.Point(26, 20);
			this.button_editor_heading3.Name = "button_editor_heading3";
			this.button_editor_heading3.Size = new System.Drawing.Size(18, 23);
			this.button_editor_heading3.TabIndex = 1;
			this.button_editor_heading3.Text = "3";
			this.toolTip.SetToolTip(this.button_editor_heading3, "h3-Überschrift");
			this.button_editor_heading3.UseVisualStyleBackColor = true;
			this.button_editor_heading3.Click += new System.EventHandler(this.OnButtonEditorHeading3Click);
			// 
			// button_editor_heading2
			// 
			this.button_editor_heading2.Location = new System.Drawing.Point(7, 20);
			this.button_editor_heading2.Name = "button_editor_heading2";
			this.button_editor_heading2.Size = new System.Drawing.Size(18, 23);
			this.button_editor_heading2.TabIndex = 0;
			this.button_editor_heading2.Text = "2";
			this.toolTip.SetToolTip(this.button_editor_heading2, "h2-Überschrift");
			this.button_editor_heading2.UseVisualStyleBackColor = true;
			this.button_editor_heading2.Click += new System.EventHandler(this.OnButtonEditorHeading2Click);
			// 
			// button_editor_link
			// 
			this.button_editor_link.Location = new System.Drawing.Point(7, 19);
			this.button_editor_link.Name = "button_editor_link";
			this.button_editor_link.Size = new System.Drawing.Size(44, 23);
			this.button_editor_link.TabIndex = 33;
			this.button_editor_link.Text = "Link";
			this.button_editor_link.UseVisualStyleBackColor = true;
			this.button_editor_link.Click += new System.EventHandler(this.OnButtonEditorLinkClick);
			// 
			// groupBox_editor_styles
			// 
			this.groupBox_editor_styles.Controls.Add(this.button_editor_underlined);
			this.groupBox_editor_styles.Controls.Add(this.button_editor_bold);
			this.groupBox_editor_styles.Controls.Add(this.button_editor_italic);
			this.groupBox_editor_styles.Controls.Add(this.button_editor_italic_bold);
			this.groupBox_editor_styles.Controls.Add(this.button_editor_strike);
			this.groupBox_editor_styles.Location = new System.Drawing.Point(535, 248);
			this.groupBox_editor_styles.Name = "groupBox_editor_styles";
			this.groupBox_editor_styles.Size = new System.Drawing.Size(112, 71);
			this.groupBox_editor_styles.TabIndex = 34;
			this.groupBox_editor_styles.TabStop = false;
			this.groupBox_editor_styles.Text = "Stile";
			// 
			// button_editor_underlined
			// 
			this.button_editor_underlined.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button_editor_underlined.Location = new System.Drawing.Point(42, 41);
			this.button_editor_underlined.Name = "button_editor_underlined";
			this.button_editor_underlined.Size = new System.Drawing.Size(27, 23);
			this.button_editor_underlined.TabIndex = 31;
			this.button_editor_underlined.Text = "gL";
			this.toolTip.SetToolTip(this.button_editor_underlined, "unterstrichen");
			this.button_editor_underlined.UseVisualStyleBackColor = true;
			// 
			// groupBox_editor_diverse
			// 
			this.groupBox_editor_diverse.Controls.Add(this.button_editor_quote);
			this.groupBox_editor_diverse.Controls.Add(this.button_editor_code);
			this.groupBox_editor_diverse.Controls.Add(this.button_editor_nowiki);
			this.groupBox_editor_diverse.Controls.Add(this.button_editor_link);
			this.groupBox_editor_diverse.Location = new System.Drawing.Point(535, 381);
			this.groupBox_editor_diverse.Name = "groupBox_editor_diverse";
			this.groupBox_editor_diverse.Size = new System.Drawing.Size(112, 78);
			this.groupBox_editor_diverse.TabIndex = 35;
			this.groupBox_editor_diverse.TabStop = false;
			this.groupBox_editor_diverse.Text = "Diverse";
			// 
			// button_editor_quote
			// 
			this.button_editor_quote.Location = new System.Drawing.Point(53, 48);
			this.button_editor_quote.Name = "button_editor_quote";
			this.button_editor_quote.Size = new System.Drawing.Size(51, 23);
			this.button_editor_quote.TabIndex = 35;
			this.button_editor_quote.Text = "Quote";
			this.button_editor_quote.UseVisualStyleBackColor = true;
			this.button_editor_quote.Click += new System.EventHandler(this.OnButtonEditorQuoteClick);
			// 
			// button_editor_code
			// 
			this.button_editor_code.Location = new System.Drawing.Point(7, 48);
			this.button_editor_code.Name = "button_editor_code";
			this.button_editor_code.Size = new System.Drawing.Size(44, 23);
			this.button_editor_code.TabIndex = 34;
			this.button_editor_code.Text = "Code";
			this.button_editor_code.UseVisualStyleBackColor = true;
			this.button_editor_code.Click += new System.EventHandler(this.OnButtonEditorCodeClick);
			// 
			// groupBox_editor_lists
			// 
			this.groupBox_editor_lists.Controls.Add(this.button_editor_lists_bullets_right);
			this.groupBox_editor_lists.Controls.Add(this.button_editor_lists_bullets_left);
			this.groupBox_editor_lists.Controls.Add(this.label_editor_lists_bullets);
			this.groupBox_editor_lists.Controls.Add(this.label_editor_lists_numbered);
			this.groupBox_editor_lists.Controls.Add(this.button_editor_lists_numbered_right);
			this.groupBox_editor_lists.Controls.Add(this.button_editor_lists_numbered_left);
			this.groupBox_editor_lists.Location = new System.Drawing.Point(535, 466);
			this.groupBox_editor_lists.Name = "groupBox_editor_lists";
			this.groupBox_editor_lists.Size = new System.Drawing.Size(112, 79);
			this.groupBox_editor_lists.TabIndex = 36;
			this.groupBox_editor_lists.TabStop = false;
			this.groupBox_editor_lists.Text = "Auflistungen";
			// 
			// button_editor_lists_bullets_right
			// 
			this.button_editor_lists_bullets_right.Location = new System.Drawing.Point(83, 48);
			this.button_editor_lists_bullets_right.Name = "button_editor_lists_bullets_right";
			this.button_editor_lists_bullets_right.Size = new System.Drawing.Size(22, 23);
			this.button_editor_lists_bullets_right.TabIndex = 5;
			this.button_editor_lists_bullets_right.Text = ">";
			this.toolTip.SetToolTip(this.button_editor_lists_bullets_right, "Einrückung ERW");
			this.button_editor_lists_bullets_right.UseVisualStyleBackColor = true;
			this.button_editor_lists_bullets_right.Click += new System.EventHandler(this.OnButtonEditorListsBulletsRightClick);
			// 
			// button_editor_lists_bullets_left
			// 
			this.button_editor_lists_bullets_left.Location = new System.Drawing.Point(59, 48);
			this.button_editor_lists_bullets_left.Name = "button_editor_lists_bullets_left";
			this.button_editor_lists_bullets_left.Size = new System.Drawing.Size(22, 23);
			this.button_editor_lists_bullets_left.TabIndex = 4;
			this.button_editor_lists_bullets_left.Text = "<";
			this.toolTip.SetToolTip(this.button_editor_lists_bullets_left, "Einrückung verringern");
			this.button_editor_lists_bullets_left.UseVisualStyleBackColor = true;
			this.button_editor_lists_bullets_left.Click += new System.EventHandler(this.OnButtonEditorListsBulletsLeftClick);
			// 
			// label_editor_lists_bullets
			// 
			this.label_editor_lists_bullets.AutoSize = true;
			this.label_editor_lists_bullets.Location = new System.Drawing.Point(5, 53);
			this.label_editor_lists_bullets.Name = "label_editor_lists_bullets";
			this.label_editor_lists_bullets.Size = new System.Drawing.Size(41, 13);
			this.label_editor_lists_bullets.TabIndex = 3;
			this.label_editor_lists_bullets.Text = "Punkte";
			// 
			// label_editor_lists_numbered
			// 
			this.label_editor_lists_numbered.AutoSize = true;
			this.label_editor_lists_numbered.Location = new System.Drawing.Point(5, 25);
			this.label_editor_lists_numbered.Name = "label_editor_lists_numbered";
			this.label_editor_lists_numbered.Size = new System.Drawing.Size(52, 13);
			this.label_editor_lists_numbered.TabIndex = 2;
			this.label_editor_lists_numbered.Text = "Nummern";
			// 
			// button_editor_lists_numbered_right
			// 
			this.button_editor_lists_numbered_right.Location = new System.Drawing.Point(83, 20);
			this.button_editor_lists_numbered_right.Name = "button_editor_lists_numbered_right";
			this.button_editor_lists_numbered_right.Size = new System.Drawing.Size(22, 23);
			this.button_editor_lists_numbered_right.TabIndex = 1;
			this.button_editor_lists_numbered_right.Text = ">";
			this.toolTip.SetToolTip(this.button_editor_lists_numbered_right, "Einrückung erhöhen");
			this.button_editor_lists_numbered_right.UseVisualStyleBackColor = true;
			this.button_editor_lists_numbered_right.Click += new System.EventHandler(this.OnButtonEditorListsNumberedRightClick);
			// 
			// button_editor_lists_numbered_left
			// 
			this.button_editor_lists_numbered_left.Location = new System.Drawing.Point(59, 20);
			this.button_editor_lists_numbered_left.Name = "button_editor_lists_numbered_left";
			this.button_editor_lists_numbered_left.Size = new System.Drawing.Size(22, 23);
			this.button_editor_lists_numbered_left.TabIndex = 0;
			this.button_editor_lists_numbered_left.Text = "<";
			this.toolTip.SetToolTip(this.button_editor_lists_numbered_left, "Einrückung verringern");
			this.button_editor_lists_numbered_left.UseVisualStyleBackColor = true;
			this.button_editor_lists_numbered_left.Click += new System.EventHandler(this.OnButtonEditorListsNumberedLeftClick);
			// 
			// label_categories
			// 
			this.label_categories.AutoSize = true;
			this.label_categories.Location = new System.Drawing.Point(4, 605);
			this.label_categories.Name = "label_categories";
			this.label_categories.Size = new System.Drawing.Size(58, 13);
			this.label_categories.TabIndex = 38;
			this.label_categories.Text = "Kategorien";
			// 
			// treeView_categories
			// 
			this.treeView_categories.CheckBoxes = true;
			this.treeView_categories.Location = new System.Drawing.Point(103, 605);
			this.treeView_categories.Name = "treeView_categories";
			this.treeView_categories.Size = new System.Drawing.Size(423, 116);
			this.treeView_categories.TabIndex = 39;
			// 
			// groupBox_editor_categories
			// 
			this.groupBox_editor_categories.Controls.Add(this.button_editor_category_add);
			this.groupBox_editor_categories.Location = new System.Drawing.Point(535, 552);
			this.groupBox_editor_categories.Name = "groupBox_editor_categories";
			this.groupBox_editor_categories.Size = new System.Drawing.Size(109, 44);
			this.groupBox_editor_categories.TabIndex = 40;
			this.groupBox_editor_categories.TabStop = false;
			this.groupBox_editor_categories.Text = "Kategorien";
			// 
			// button_editor_category_add
			// 
			this.button_editor_category_add.Location = new System.Drawing.Point(8, 17);
			this.button_editor_category_add.Name = "button_editor_category_add";
			this.button_editor_category_add.Size = new System.Drawing.Size(95, 23);
			this.button_editor_category_add.TabIndex = 0;
			this.button_editor_category_add.Text = "Hinzufügen";
			this.button_editor_category_add.UseVisualStyleBackColor = true;
			this.button_editor_category_add.Click += new System.EventHandler(this.OnButtonEditorCategoryAddClick);
			// 
			// checkBox_compact
			// 
			this.checkBox_compact.AutoSize = true;
			this.checkBox_compact.Location = new System.Drawing.Point(275, 54);
			this.checkBox_compact.Name = "checkBox_compact";
			this.checkBox_compact.Size = new System.Drawing.Size(252, 17);
			this.checkBox_compact.TabIndex = 41;
			this.checkBox_compact.Text = "Kompaktiere anhand erster ausgewählter Spalte";
			this.checkBox_compact.UseVisualStyleBackColor = true;
			this.checkBox_compact.CheckedChanged += new System.EventHandler(this.OnCheckBoxCompactCheckedChanged);
			// 
			// menuStrip
			// 
			this.menuStrip.BackColor = System.Drawing.SystemColors.ControlLight;
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_help});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(660, 24);
			this.menuStrip.TabIndex = 42;
			this.menuStrip.Text = "menuStrip1";
			// 
			// ToolStripMenuItem_help
			// 
			this.ToolStripMenuItem_help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ToolStripMenuItem_help.Name = "ToolStripMenuItem_help";
			this.ToolStripMenuItem_help.Size = new System.Drawing.Size(44, 20);
			this.ToolStripMenuItem_help.Text = "Hilfe";
			this.ToolStripMenuItem_help.Click += new System.EventHandler(this.OnToolStripMenuItemHelpClick);
			// 
			// button_show_data
			// 
			this.button_show_data.Location = new System.Drawing.Point(535, 80);
			this.button_show_data.Name = "button_show_data";
			this.button_show_data.Size = new System.Drawing.Size(112, 23);
			this.button_show_data.TabIndex = 43;
			this.button_show_data.Text = "Daten anzeigen";
			this.button_show_data.UseVisualStyleBackColor = true;
			this.button_show_data.Click += new System.EventHandler(this.OnButtonShowDataClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(660, 767);
			this.Controls.Add(this.button_show_data);
			this.Controls.Add(this.checkBox_compact);
			this.Controls.Add(this.groupBox_editor_categories);
			this.Controls.Add(this.treeView_categories);
			this.Controls.Add(this.label_categories);
			this.Controls.Add(this.groupBox_editor_lists);
			this.Controls.Add(this.groupBox_editor_diverse);
			this.Controls.Add(this.groupBox_editor_styles);
			this.Controls.Add(this.groupBox_editor_headings);
			this.Controls.Add(this.treeView_columns);
			this.Controls.Add(this.checkBox_csv_has_column_titles);
			this.Controls.Add(this.textBox_template);
			this.Controls.Add(this.label_template);
			this.Controls.Add(this.textBox_comment);
			this.Controls.Add(this.label_comment);
			this.Controls.Add(this.label_columns);
			this.Controls.Add(this.button_browse_inputfile);
			this.Controls.Add(this.label_inputfile);
			this.Controls.Add(this.textBox_input_path);
			this.Controls.Add(this.button_upload);
			this.Controls.Add(this.label_pagetitle);
			this.Controls.Add(this.textBox_pagetitle);
			this.Controls.Add(this.label_pagetext);
			this.Controls.Add(this.richTextBox_pagetext);
			this.Controls.Add(this.menuStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip;
			this.Name = "MainForm";
			this.Text = "Docusnap2Wiki";
			this.Load += new System.EventHandler(this.OnMainFormLoad);
			this.contextMenuStrip_pagetext.ResumeLayout(false);
			this.groupBox_editor_headings.ResumeLayout(false);
			this.groupBox_editor_styles.ResumeLayout(false);
			this.groupBox_editor_diverse.ResumeLayout(false);
			this.groupBox_editor_lists.ResumeLayout(false);
			this.groupBox_editor_lists.PerformLayout();
			this.groupBox_editor_categories.ResumeLayout(false);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox richTextBox_pagetext;
		private System.Windows.Forms.Label label_pagetext;
		private System.Windows.Forms.TextBox textBox_pagetitle;
		private System.Windows.Forms.Label label_pagetitle;
		private System.Windows.Forms.Button button_upload;
		private System.Windows.Forms.TextBox textBox_input_path;
		private System.Windows.Forms.Label label_inputfile;
		private System.Windows.Forms.Button button_browse_inputfile;
		private System.Windows.Forms.Label label_columns;
		private System.Windows.Forms.Label label_comment;
		private System.Windows.Forms.TextBox textBox_comment;
		private System.Windows.Forms.Timer timer_template;
		private System.Windows.Forms.Label label_template;
		private System.Windows.Forms.TextBox textBox_template;
		private System.Windows.Forms.CheckBox checkBox_csv_has_column_titles;
		private System.Windows.Forms.TreeView treeView_columns;
		private System.Windows.Forms.HelpProvider helpProvider;
		private System.Windows.Forms.Button button_editor_italic;
		private System.Windows.Forms.Button button_editor_bold;
		private System.Windows.Forms.Button button_editor_italic_bold;
		private System.Windows.Forms.Button button_editor_strike;
		private System.Windows.Forms.Button button_editor_nowiki;
		private System.Windows.Forms.GroupBox groupBox_editor_headings;
		private System.Windows.Forms.Button button_editor_heading2;
		private System.Windows.Forms.Button button_editor_heading6;
		private System.Windows.Forms.Button button_editor_heading5;
		private System.Windows.Forms.Button button_editor_heading4;
		private System.Windows.Forms.Button button_editor_heading3;
		private System.Windows.Forms.Button button_editor_link;
		private System.Windows.Forms.GroupBox groupBox_editor_styles;
		private System.Windows.Forms.GroupBox groupBox_editor_diverse;
		private System.Windows.Forms.Button button_editor_code;
		private System.Windows.Forms.Button button_editor_quote;
		private System.Windows.Forms.Button button_editor_underlined;
		private System.Windows.Forms.GroupBox groupBox_editor_lists;
		private System.Windows.Forms.Button button_editor_lists_bullets_right;
		private System.Windows.Forms.Button button_editor_lists_bullets_left;
		private System.Windows.Forms.Label label_editor_lists_bullets;
		private System.Windows.Forms.Label label_editor_lists_numbered;
		private System.Windows.Forms.Button button_editor_lists_numbered_right;
		private System.Windows.Forms.Button button_editor_lists_numbered_left;
		private System.Windows.Forms.Label label_categories;
		private System.Windows.Forms.TreeView treeView_categories;
		private System.Windows.Forms.GroupBox groupBox_editor_categories;
		private System.Windows.Forms.Button button_editor_category_add;
		private System.Windows.Forms.CheckBox checkBox_compact;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_help;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip_pagetext;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_pagetext_cut;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_pagetext_copy;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_pagetext_paste;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Button button_show_data;
	}
}

