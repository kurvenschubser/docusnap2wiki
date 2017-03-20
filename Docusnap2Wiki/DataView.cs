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
	public partial class DataView : Form
	{
		ColumnHeaderAutoResizeStyle auto_resize =
			ColumnHeaderAutoResizeStyle.ColumnContent;


		public DataView() : this(new string[] {}, new List<string[]>())
		{
			
		}

		public DataView(IEnumerable<string> colnames, IEnumerable<string[]> data)
		{
			InitializeComponent();

			SetupColumnNames(colnames);
			Populate(data);
		}

		public void SetupColumnNames(IEnumerable<string> colnames)
		{
			this.listView.SuspendLayout();

			this.listView.Columns.Clear();

			foreach (string colname in colnames)
			{
				this.listView.Columns.Add(colname);
			}

			this.listView.ResumeLayout();
		}

		public void Populate(IEnumerable<string[]> data)
		{
			IEnumerator<string[]> rows = data.GetEnumerator();
			List<ListViewItem> items = new List<ListViewItem>();
			if (rows.MoveNext())
			{
				if (rows.Current.Length != this.listView.Columns.Count)
				{
					throw new InvalidProgramException("row.length != listview.columns.count");
				}
				items.Add(new ListViewItem(rows.Current));
			}

			while(rows.MoveNext())
			{
				 items.Add(new ListViewItem(rows.Current));
			}

			this.listView.Items.AddRange(items.ToArray());

			this.listView.AutoResizeColumns(this.auto_resize);
		}
	}
}
