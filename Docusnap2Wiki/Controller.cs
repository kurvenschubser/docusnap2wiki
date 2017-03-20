using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

using DotNetWikiBot;



namespace Docusnap2Wiki
{
    public class CategoriesChangedEventArgs : EventArgs
    {
        public IEnumerable<string> AllCategories { get; set; }
        public IEnumerable<string> SelectedCategories { get; set; }
    }


    public class CSVColumnsChangedEventArgs : EventArgs
    {
        public IEnumerable<string> AllCSVColumns { get; set; }
        public IEnumerable<int> SelectedCSVColumns { get; set; }
    }


    public delegate void CategoriesChangedEventHandler(object sender, CategoriesChangedEventArgs e);
    public delegate void CSVColumnsChangedEventHandler(object sender, CSVColumnsChangedEventArgs e);

    public interface IController
    {
        IEnumerable<string> GetAllTemplates();
        void SetSelectedCategories(IEnumerable<string> selected_categories);
        void SetupCategories();
        void SetupCategories(IEnumerable<string> all_cats, IEnumerable<string> selected_cats);
        void OpenCSVFile(string filepath);
        void DisplayHelp();
        string FormatWithContext(string fmt, Dictionary<string, object> context, int row_no, int rows_count);
        IEnumerable<string> ConvertToEnumerable(string input);
        Dictionary<string, object> MakeContext(string[] row, IEnumerable<string>all_columns, IEnumerable<int>selected_columns);
		string WrapTextInSelection(string txt, int start, int end, string with_);
		string WrapTextInSelectionWithTag(string txt, int start, int end, string tag);
		string WrapTextInSelectionWithLink(string txt, int start, int end);
		string ChangeListLevel(string txt, int start, string pointsign, int direction);
		HashSet<string> ExtractCategories(string txt, int caret_pos);

        string CSVFilePath { get; set; }
        bool CSVHasColumnTitles { get; set; }
        bool CompactCSVRows { get; set; }
        IEnumerable<string> AllCSVColumns { get; set; }
        IEnumerable<int> SelectedCSVColumns { get; set; }
        IEnumerable<string[]> CSVRows {get; set; }
        IEnumerable<string> AllCategories { get; set; }
        IEnumerable<string> SelectedCategories { get; set; }
        Site Site { get; set; }

        event CategoriesChangedEventHandler CategoriesChanged;
        event CSVColumnsChangedEventHandler CSVColumnsChanged;
    }

	public class Controller : IController
	{
        private Site site;

        private bool csv_has_column_titles;
        private bool compact_csv_rows;
        private IEnumerable<int> selected_csv_columns;
        private IEnumerable<string> all_categories; 
        private IEnumerable<string> selected_categories;

		private Regex RE_CATEGORY = new Regex(@"\[\[Kategorie:(?<category>\w+?)\]\]");

        private Regex RE_FORLOOP = new Regex(
            @".*?(?<loop_begin>[{])\s?for\s?"
                + @"(?<loop_var>[a-zA-Z_]+[a-zA-Z0-9]*) in "
                + @"(?<loop_iterable>[a-zA-Z_]+[a-zA-Z0-9]*)\s?}(?<loop_body>.*)"
                + @"(?<loop_end>{\s?endfor\s?}).*"
            , RegexOptions.Singleline);
        
        public event CategoriesChangedEventHandler CategoriesChanged;
        public event CSVColumnsChangedEventHandler CSVColumnsChanged;
        

        public Controller()
        {
            this.CSVHasColumnTitles = true;
        }

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
					f.LoginCredentialsProvided += new LoginForm.LoginCredentialsProvidedEventHandler(OnLoginCredentialsProvided);
					f.ShowDialog();
#endif
                }
                return this.site;
            }
            set
            {
                this.site = value;
            }
        }

		private void OnLoginCredentialsProvided(object sender, LoginCredentialsProvidedEventArgs args)
		{
			try
			{
				this.site = new Site(args.WikiURL, args.Username, args.Password);
			}
			catch (WikiBotException)
			{
				args.Cancel = true;
			}
		}

        public void DisplayHelp()
        {
			ProcessStartInfo inf = new ProcessStartInfo("notepad", "helpfile.txt");
			Process.Start(inf);
        }

        public IEnumerable<string> GetAllTemplates()
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

        public void SetSelectedCategories(IEnumerable<string> selected_categories)
        {
            if (new HashSet<string>(selected_categories).SetEquals(
                new HashSet<string>(this.SelectedCategories)))
            {
                return;
            }

            this.SetupCategories(this.AllCategories, selected_categories);
        }

        public void OpenCSVFile(string filepath)
        {
            if (filepath == null)
            {
                return;
            }
            this.CSVFilePath = filepath;

            List<string[]> rows_ = new List<string[]>();
            IEnumerator<string[]> rows_enumerator = this.ReadCSV(filepath).GetEnumerator();
            if (!rows_enumerator.MoveNext())
            {
                return;
            }

            if (this.CSVHasColumnTitles)
            {
                try
                {
                    this.AllCSVColumns = rows_enumerator.Current.ToArray();
                    this.SelectedCSVColumns = Enumerable.Range(0, this.AllCSVColumns.Count());
                }
                catch (Microsoft.VisualBasic.FileIO.MalformedLineException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                rows_.Add(rows_enumerator.Current);
                this.AllCSVColumns =
                    Enumerable.Range(1, rows_enumerator.Current.Length).Select(
                        o => string.Format("Spalte {0}", o)
                    ).ToArray();
            }

            while(rows_enumerator.MoveNext())
            {
                rows_.Add(rows_enumerator.Current);
            }
            this.CSVRows = rows_;

            IEnumerable<string[]> new_rows = this.CSVRows;
            if (this.CompactCSVRows)
            {
                List<int> selected_columns = new List<int>(this.SelectedCSVColumns);
                if (selected_columns.Count == 0)
                {
                    MessageBox.Show("Keine Spalten ausgewählt");
                }
                else
                {
                    new_rows = this.CompactRows(new_rows.ToList(), selected_columns[0]);
                }
            }
            this.CSVRows = new_rows;
            
            this.CSVColumnsChanged(
                  this
                , new CSVColumnsChangedEventArgs 
                  {
                        AllCSVColumns = this.AllCSVColumns
                      , SelectedCSVColumns = this.SelectedCSVColumns }
            );
        }

        IEnumerable<string[]> CopyRows(List<string[]> rows_)
		{
			// deep copy 'Rows'
			foreach (string[] row in rows_)
			{
				List<string> row_copy = new List<string>();
				foreach (string s in row)
				{
					row_copy.Add(string.Copy(s));
				}
				yield return row_copy.ToArray();
			}
		}

        /**
         * Compact rows 'rows' by given column index (0-based) 'groupby_column'.
         * All fields in columns that are not 'groupby_column' will be merged,
         * seperated by commas.
         */
		public IEnumerable<string[]> CompactRows(List<string[]> rows, int groupby_column)
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

        private IEnumerable<string[]> ReadCSV(string filepath)
        {
            Microsoft.VisualBasic.FileIO.TextFieldParser p = new Microsoft.VisualBasic.FileIO.TextFieldParser(filepath);
            p.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
            p.Delimiters = new String[] { ";" };

            while (!p.EndOfData)
            {
                yield return p.ReadFields();
            }
        }


        /**
         * Format input string according to the following rules:
         * 
         * {{{x}}}: Replace by value in context with the name of 'x'.
         * {index}: Replace by 1-based index of input row.
         * {row_count}: Replace by total number of rows.
         * {for i in iterable} [loop body] {endfor}: For each 'i' in 'iterable', add 'i' to 
         *      context inside 'loop body'. 'iterable' must be a comma-separated list.
         * 
         * See unit test for example usage.
         */ 
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
            } while (match_forloop.Success);

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
            catch (Exception)
            {
                return new string[] { };
            }
        }

        public Dictionary<string, object> MakeContext(
			string[] row, 
			IEnumerable<string> all_columns, 
			IEnumerable<int> selected_columns)
        {
            Dictionary<string, object> context = new Dictionary<string, object>();
            foreach (int i in selected_columns)
            {
                context[all_columns.ElementAt(i)] = row[i];
            }
            return context;
        }

		public string WrapTextIn(string txt, int start, int end, string before, string after)
		{
			return
				txt.Substring(0, start) + before
				+ txt.Substring(start, end - start) + after
				+ txt.Substring(end);
		}

		public string WrapTextInSelection(string txt, int start, int end, string with_)
		{
			return this.WrapTextIn(txt, start, end, with_, with_);
		}

		public string WrapTextInSelectionWithTag(string txt, int start, int end, string tag)
		{
			return this.WrapTextIn(txt, start, end, "<" + tag + ">", "</" + tag + ">");
		}

		public string WrapTextInSelectionWithLink(string txt, int start, int end)
		{
			return this.WrapTextIn(txt, start, end,
				"[[" + txt.Substring(start, end - start).Replace(' ', '_') + "|", "]]");
		}

		public string ChangeListLevel(string txt, int start, string pointsign, int direction)
		{
			if (direction == 0)
			{
				throw new ArgumentException("direction must not be equal to 0.");
			}

			string newline = "\n";

			List<string> lines = txt.Split(new string[] { newline }, StringSplitOptions.None).ToList();
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

			return string.Join(newline, res.ToArray());
		}

		public HashSet<string> ExtractCategories(string txt, int caret_pos)
		{
			HashSet<string> cats = new HashSet<string>();

			MatchCollection matches = RE_CATEGORY.Matches(txt);
			foreach (Match m in matches)
			{
				Group c = m.Groups["category"];
				// ignore the matches that have *caret_pos* inside themselves
				//if (c.Index <= caret_pos && caret_pos <= c.Index + c.Length)
				//{
				//    continue;
				//}
				cats.Add(c.Value);
			}
			return cats;
		}

        public string CSVFilePath
        {
            get;
            set;
        }

        public bool CompactCSVRows
        {
            get
            {
                return this.compact_csv_rows;
            }
            set
            {
                this.compact_csv_rows = value;
                this.OpenCSVFile(this.CSVFilePath);
            }
        }

        public bool CSVHasColumnTitles
        {
            get
            {
                return this.csv_has_column_titles;
            }
            set
            {
                this.csv_has_column_titles = value;
                this.OpenCSVFile(this.CSVFilePath);
            }
        }

        public IEnumerable<string[]> CSVRows
        {
            get;
            set;
        }

        public IEnumerable<string> AllCSVColumns
        {
            get;
            set;
        }

        public IEnumerable<int> SelectedCSVColumns
        {
            get
            {
                return this.selected_csv_columns;
            }
            set
            {
                this.selected_csv_columns = value;
            }
        }

        public IEnumerable<string> AllCategories
        {
            get
            {
                if (this.all_categories == null)
                {
                    this.all_categories = this.GetAllCategories();
                }
                return this.all_categories;
            }
            set
            {
                this.all_categories = value;
                this.CategoriesChanged(
                      this
                    , new CategoriesChangedEventArgs
                      { 
                             AllCategories = this.AllCategories
                           , SelectedCategories = this.SelectedCategories
                      }
                );
            }
        }

        public IEnumerable<string> SelectedCategories
        {
            get
            {
                if (this.selected_categories == null)
                {
                    this.selected_categories = new HashSet<string>();
                }
                return this.selected_categories;
            }
            set
            {
                this.selected_categories = value;
                this.CategoriesChanged(
                    this
                    , new CategoriesChangedEventArgs 
                      {
                            AllCategories = this.AllCategories
                          , SelectedCategories = this.SelectedCategories 
                      }
                );
            }
        }

        public void SetupCategories()
        {
            this.SetupCategories(this.AllCategories, this.SelectedCategories);
        }

        public void SetupCategories(IEnumerable<string> all_cats, IEnumerable<string> selected_cats)
        {
            this.AllCategories = all_cats;
            this.SelectedCategories = selected_cats;
            this.CategoriesChanged(
                this
                , new CategoriesChangedEventArgs 
                  {   AllCategories = all_cats
                      , SelectedCategories = selected_cats });
        }

        /**
         * Return all categories present in the MediaWiki.
         */
        private string[] GetAllCategories()
		{
			List<string> cats = new List<string>();
            string[] bits = {     this.Site.site
                                , this.Site.indexPath
                                , "api.php?format=xml&action=query&list=allcategories" };
            string src = this.Site.GetPageHTM(string.Join("", bits));

			XmlDocument doc = new XmlDocument();
			doc.LoadXml(src);
			XmlNode node = doc.SelectSingleNode("/api/query/allcategories");
			foreach (XmlNode n in node)
			{
				cats.Add(n.InnerText.Trim());
			}
			return cats.ToArray();
		}

        public bool IsPageProtected(string pagetitle)
        {
            string[] bits = {     this.Site.site
                                , this.Site.indexPath
                                , "index.php?title="
                                , System.Uri.EscapeUriString(pagetitle) };

            string src = this.Site.GetPageHTM(string.Join("", bits));
            return !src.Contains("...");
        }
	}
}
