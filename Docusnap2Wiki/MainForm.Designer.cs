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
			this.richTextBox = new System.Windows.Forms.RichTextBox();
			this.label_pagetext = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label_pagetitle = new System.Windows.Forms.Label();
			this.textBox_template_path = new System.Windows.Forms.TextBox();
			this.label_template = new System.Windows.Forms.Label();
			this.button_upload = new System.Windows.Forms.Button();
			this.button_browse_template = new System.Windows.Forms.Button();
			this.listView_columns = new System.Windows.Forms.ListView();
			this.textBox_input_path = new System.Windows.Forms.TextBox();
			this.label_inputfile = new System.Windows.Forms.Label();
			this.button_browse_inputfile = new System.Windows.Forms.Button();
			this.listView_categories = new System.Windows.Forms.ListView();
			this.label_columns = new System.Windows.Forms.Label();
			this.label_categories = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// richTextBox
			// 
			this.richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox.Location = new System.Drawing.Point(115, 301);
			this.richTextBox.Name = "richTextBox";
			this.richTextBox.Size = new System.Drawing.Size(425, 256);
			this.richTextBox.TabIndex = 0;
			this.richTextBox.Text = "";
			// 
			// label_pagetext
			// 
			this.label_pagetext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_pagetext.AutoSize = true;
			this.label_pagetext.Location = new System.Drawing.Point(13, 305);
			this.label_pagetext.Name = "label_pagetext";
			this.label_pagetext.Size = new System.Drawing.Size(54, 13);
			this.label_pagetext.TabIndex = 1;
			this.label_pagetext.Text = "Seitentext";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(115, 275);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(425, 20);
			this.textBox1.TabIndex = 2;
			// 
			// label_pagetitle
			// 
			this.label_pagetitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_pagetitle.AutoSize = true;
			this.label_pagetitle.Location = new System.Drawing.Point(13, 279);
			this.label_pagetitle.Name = "label_pagetitle";
			this.label_pagetitle.Size = new System.Drawing.Size(53, 13);
			this.label_pagetitle.TabIndex = 3;
			this.label_pagetitle.Text = "Seitentitel";
			// 
			// textBox_template_path
			// 
			this.textBox_template_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_template_path.Location = new System.Drawing.Point(115, 128);
			this.textBox_template_path.Name = "textBox_template_path";
			this.textBox_template_path.Size = new System.Drawing.Size(425, 20);
			this.textBox_template_path.TabIndex = 4;
			// 
			// label_template
			// 
			this.label_template.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_template.AutoSize = true;
			this.label_template.Location = new System.Drawing.Point(13, 132);
			this.label_template.Name = "label_template";
			this.label_template.Size = new System.Drawing.Size(43, 13);
			this.label_template.TabIndex = 5;
			this.label_template.Text = "Vorlage";
			// 
			// button_upload
			// 
			this.button_upload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.button_upload.Location = new System.Drawing.Point(547, 519);
			this.button_upload.Name = "button_upload";
			this.button_upload.Size = new System.Drawing.Size(112, 37);
			this.button_upload.TabIndex = 6;
			this.button_upload.Text = "Hochladen";
			this.button_upload.UseVisualStyleBackColor = true;
			// 
			// button_browse_template
			// 
			this.button_browse_template.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.button_browse_template.Location = new System.Drawing.Point(547, 128);
			this.button_browse_template.Name = "button_browse_template";
			this.button_browse_template.Size = new System.Drawing.Size(112, 23);
			this.button_browse_template.TabIndex = 7;
			this.button_browse_template.Text = "Vorlage öffnen";
			this.button_browse_template.UseVisualStyleBackColor = true;
			// 
			// listView_columns
			// 
			this.listView_columns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.listView_columns.CheckBoxes = true;
			this.listView_columns.Location = new System.Drawing.Point(115, 36);
			this.listView_columns.Name = "listView_columns";
			this.listView_columns.Size = new System.Drawing.Size(425, 85);
			this.listView_columns.TabIndex = 8;
			this.listView_columns.UseCompatibleStateImageBehavior = false;
			// 
			// textBox_input_path
			// 
			this.textBox_input_path.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.textBox_input_path.Location = new System.Drawing.Point(115, 10);
			this.textBox_input_path.Name = "textBox_input_path";
			this.textBox_input_path.Size = new System.Drawing.Size(425, 20);
			this.textBox_input_path.TabIndex = 9;
			// 
			// label_inputfile
			// 
			this.label_inputfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_inputfile.AutoSize = true;
			this.label_inputfile.Location = new System.Drawing.Point(16, 10);
			this.label_inputfile.Name = "label_inputfile";
			this.label_inputfile.Size = new System.Drawing.Size(59, 13);
			this.label_inputfile.TabIndex = 10;
			this.label_inputfile.Text = "Input Datei";
			// 
			// button_browse_inputfile
			// 
			this.button_browse_inputfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.button_browse_inputfile.Location = new System.Drawing.Point(547, 9);
			this.button_browse_inputfile.Name = "button_browse_inputfile";
			this.button_browse_inputfile.Size = new System.Drawing.Size(112, 23);
			this.button_browse_inputfile.TabIndex = 11;
			this.button_browse_inputfile.Text = "Datei öffnen";
			this.button_browse_inputfile.UseVisualStyleBackColor = true;
			// 
			// listView_categories
			// 
			this.listView_categories.CheckBoxes = true;
			this.listView_categories.Location = new System.Drawing.Point(115, 155);
			this.listView_categories.Name = "listView_categories";
			this.listView_categories.Size = new System.Drawing.Size(425, 114);
			this.listView_categories.TabIndex = 12;
			this.listView_categories.UseCompatibleStateImageBehavior = false;
			// 
			// label_columns
			// 
			this.label_columns.AutoSize = true;
			this.label_columns.Location = new System.Drawing.Point(16, 36);
			this.label_columns.Name = "label_columns";
			this.label_columns.Size = new System.Drawing.Size(29, 13);
			this.label_columns.TabIndex = 13;
			this.label_columns.Text = "Filter";
			// 
			// label_categories
			// 
			this.label_categories.AutoSize = true;
			this.label_categories.Location = new System.Drawing.Point(13, 155);
			this.label_categories.Name = "label_categories";
			this.label_categories.Size = new System.Drawing.Size(58, 13);
			this.label_categories.TabIndex = 14;
			this.label_categories.Text = "Kategorien";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(671, 568);
			this.Controls.Add(this.label_categories);
			this.Controls.Add(this.label_columns);
			this.Controls.Add(this.listView_categories);
			this.Controls.Add(this.button_browse_inputfile);
			this.Controls.Add(this.label_inputfile);
			this.Controls.Add(this.textBox_input_path);
			this.Controls.Add(this.listView_columns);
			this.Controls.Add(this.button_browse_template);
			this.Controls.Add(this.button_upload);
			this.Controls.Add(this.label_template);
			this.Controls.Add(this.textBox_template_path);
			this.Controls.Add(this.label_pagetitle);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label_pagetext);
			this.Controls.Add(this.richTextBox);
			this.Name = "MainForm";
			this.Text = "Docusnap2Wiki";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox richTextBox;
		private System.Windows.Forms.Label label_pagetext;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label_pagetitle;
		private System.Windows.Forms.TextBox textBox_template_path;
		private System.Windows.Forms.Label label_template;
		private System.Windows.Forms.Button button_upload;
		private System.Windows.Forms.Button button_browse_template;
		private System.Windows.Forms.ListView listView_columns;
		private System.Windows.Forms.TextBox textBox_input_path;
		private System.Windows.Forms.Label label_inputfile;
		private System.Windows.Forms.Button button_browse_inputfile;
		private System.Windows.Forms.ListView listView_categories;
		private System.Windows.Forms.Label label_columns;
		private System.Windows.Forms.Label label_categories;
	}
}

