namespace Docusnap2Wiki
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
			this.richTextBox_pagetext = new System.Windows.Forms.RichTextBox();
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
			this.button_help = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// richTextBox_pagetext
			// 
			this.richTextBox_pagetext.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.richTextBox_pagetext.Location = new System.Drawing.Point(107, 230);
			this.richTextBox_pagetext.Name = "richTextBox_pagetext";
			this.richTextBox_pagetext.Size = new System.Drawing.Size(425, 256);
			this.richTextBox_pagetext.TabIndex = 0;
			this.richTextBox_pagetext.Text = "";
			// 
			// label_pagetext
			// 
			this.label_pagetext.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label_pagetext.AutoSize = true;
			this.label_pagetext.Location = new System.Drawing.Point(5, 234);
			this.label_pagetext.Name = "label_pagetext";
			this.label_pagetext.Size = new System.Drawing.Size(54, 13);
			this.label_pagetext.TabIndex = 1;
			this.label_pagetext.Text = "Seitentext";
			// 
			// textBox_pagetitle
			// 
			this.textBox_pagetitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.textBox_pagetitle.Location = new System.Drawing.Point(107, 204);
			this.textBox_pagetitle.Name = "textBox_pagetitle";
			this.textBox_pagetitle.Size = new System.Drawing.Size(425, 20);
			this.textBox_pagetitle.TabIndex = 2;
			// 
			// label_pagetitle
			// 
			this.label_pagetitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label_pagetitle.AutoSize = true;
			this.label_pagetitle.Location = new System.Drawing.Point(5, 208);
			this.label_pagetitle.Name = "label_pagetitle";
			this.label_pagetitle.Size = new System.Drawing.Size(53, 13);
			this.label_pagetitle.TabIndex = 3;
			this.label_pagetitle.Text = "Seitentitel";
			// 
			// button_upload
			// 
			this.button_upload.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.button_upload.Location = new System.Drawing.Point(539, 491);
			this.button_upload.Name = "button_upload";
			this.button_upload.Size = new System.Drawing.Size(112, 24);
			this.button_upload.TabIndex = 6;
			this.button_upload.Text = "Hochladen";
			this.button_upload.UseVisualStyleBackColor = true;
			this.button_upload.Click += new System.EventHandler(this.OnUploadClick);
			// 
			// textBox_input_path
			// 
			this.textBox_input_path.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.textBox_input_path.Location = new System.Drawing.Point(107, 9);
			this.textBox_input_path.Name = "textBox_input_path";
			this.textBox_input_path.Size = new System.Drawing.Size(425, 20);
			this.textBox_input_path.TabIndex = 9;
			// 
			// label_inputfile
			// 
			this.label_inputfile.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label_inputfile.AutoSize = true;
			this.label_inputfile.Location = new System.Drawing.Point(4, 9);
			this.label_inputfile.Name = "label_inputfile";
			this.label_inputfile.Size = new System.Drawing.Size(59, 13);
			this.label_inputfile.TabIndex = 10;
			this.label_inputfile.Text = "Input Datei";
			// 
			// button_browse_inputfile
			// 
			this.button_browse_inputfile.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.button_browse_inputfile.Location = new System.Drawing.Point(539, 8);
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
			this.label_columns.Location = new System.Drawing.Point(4, 62);
			this.label_columns.Name = "label_columns";
			this.label_columns.Size = new System.Drawing.Size(29, 13);
			this.label_columns.TabIndex = 13;
			this.label_columns.Text = "Filter";
			// 
			// label_comment
			// 
			this.label_comment.AutoSize = true;
			this.label_comment.Location = new System.Drawing.Point(5, 496);
			this.label_comment.Name = "label_comment";
			this.label_comment.Size = new System.Drawing.Size(60, 13);
			this.label_comment.TabIndex = 19;
			this.label_comment.Text = "Kommentar";
			// 
			// textBox_comment
			// 
			this.textBox_comment.Location = new System.Drawing.Point(112, 493);
			this.textBox_comment.Name = "textBox_comment";
			this.textBox_comment.Size = new System.Drawing.Size(418, 20);
			this.textBox_comment.TabIndex = 20;
			// 
			// timer_template
			// 
			this.timer_template.Interval = 600;
			// 
			// label_template
			// 
			this.label_template.AutoSize = true;
			this.label_template.Location = new System.Drawing.Point(5, 179);
			this.label_template.Name = "label_template";
			this.label_template.Size = new System.Drawing.Size(43, 13);
			this.label_template.TabIndex = 22;
			this.label_template.Text = "Vorlage";
			// 
			// textBox_template
			// 
			this.textBox_template.Location = new System.Drawing.Point(107, 176);
			this.textBox_template.Name = "textBox_template";
			this.textBox_template.Size = new System.Drawing.Size(423, 20);
			this.textBox_template.TabIndex = 23;
			// 
			// checkBox_csv_has_column_titles
			// 
			this.checkBox_csv_has_column_titles.AutoSize = true;
			this.checkBox_csv_has_column_titles.Checked = true;
			this.checkBox_csv_has_column_titles.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_csv_has_column_titles.Location = new System.Drawing.Point(107, 36);
			this.checkBox_csv_has_column_titles.Name = "checkBox_csv_has_column_titles";
			this.checkBox_csv_has_column_titles.Size = new System.Drawing.Size(165, 17);
			this.checkBox_csv_has_column_titles.TabIndex = 24;
			this.checkBox_csv_has_column_titles.Text = "CSV hat Spaltenüberschriften";
			this.checkBox_csv_has_column_titles.UseVisualStyleBackColor = true;
			this.checkBox_csv_has_column_titles.CheckedChanged += new System.EventHandler(this.OnCheckBoxCsvHasColumnTitles_CheckedChanged);
			// 
			// treeView_columns
			// 
			this.treeView_columns.CheckBoxes = true;
			this.treeView_columns.Location = new System.Drawing.Point(107, 62);
			this.treeView_columns.Name = "treeView_columns";
			this.treeView_columns.Size = new System.Drawing.Size(423, 108);
			this.treeView_columns.TabIndex = 25;
			// 
			// button_help
			// 
			this.button_help.Location = new System.Drawing.Point(576, 57);
			this.button_help.Name = "button_help";
			this.button_help.Size = new System.Drawing.Size(75, 23);
			this.button_help.TabIndex = 26;
			this.button_help.Text = "Hilfe";
			this.button_help.UseVisualStyleBackColor = true;
			this.button_help.Click += new System.EventHandler(this.OnButtonHelpClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(660, 521);
			this.Controls.Add(this.button_help);
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
			this.Name = "MainForm";
			this.Text = "Docusnap2Wiki";
			this.Load += new System.EventHandler(this.MainForm_Load);
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
		private System.Windows.Forms.Button button_help;
	}
}

