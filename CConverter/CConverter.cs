using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace CConverter
{
	public partial class CConverter : Form
	{
		public CConverter()
		{
			InitializeComponent();

			this.cbEncode.SelectedIndex = 1;
		}

		private String _sPathRoot = null;
		private String _sDirName = null;
		private List<String> _lsFiPath = new List<String>();

		private void tsmiOFi_Click(object sender, EventArgs e)
		{
			const string strFilter = "C/C++ Files (*.c;*.cpp;*.h;*.hpp)|*.c;*.cpp;*.h;*.hpp";
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = strFilter;
			ofd.Multiselect = true;

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				_lsFiPath.Clear();
				lbCC.Items.Clear();
				_lsFiPath.AddRange(ofd.FileNames);
				lbCC.Items.AddRange(ofd.SafeFileNames);
			}
		}

		private void tsmiOFo_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fdb = new FolderBrowserDialog();

			if (fdb.ShowDialog() == DialogResult.OK)
			{
				_lsFiPath.Clear();
				lbCC.Items.Clear();
				DirectoryInfo di = new DirectoryInfo(fdb.SelectedPath);
				_sPathRoot = di.Parent.FullName;
				_sDirName = di.Name;

				foreach (FileInfo fi in di.GetFiles("*.*", SearchOption.AllDirectories))
					if (fi.Extension.Contains(".c") || fi.Extension.Contains(".h"))
					{
						_lsFiPath.Add(fi.FullName);
						lbCC.Items.Add(fi.FullName);
					}
			}
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			Encoding ec = Encoding.UTF8;
			bool bf = false;

			if (_lsFiPath.Count == 0)
				return;

			if (cbEncode.SelectedIndex == 0)
				ec = Encoding.Default;

			if (rbUnix.Checked)
				bf = true;

			foreach (string s in _lsFiPath)
			{
				Encoding ecCur;
				StreamReader sr;
				StreamWriter sw;
				string sfile;
				FileStream fs = new FileStream(s, FileMode.Open, FileAccess.Read);

				ecCur = Code.GetEncoding(fs);
				fs.Close();

				if (ecCur == Encoding.UTF8)
					sr = new StreamReader(s, Encoding.UTF8);
				else
					sr = new StreamReader(s, Encoding.Default);

				sfile = sr.ReadToEnd();
				sr.Close();

				if (ecCur == ec && bf == !sfile.Contains("\r\n"))
					continue;

				if (ec == Encoding.UTF8)
					ec = new UTF8Encoding(false);

				sw = new StreamWriter(s, false, ec);

				if (bf && sfile.Contains("\r\n"))
					sw.Write(sfile.Replace("\r\n", "\n"));
				else if (!bf && !sfile.Contains("\r\n"))
					sw.Write(sfile.Replace("\n", "\r\n"));
				else
					sw.Write(sfile);

				sw.Close();
			}

			MessageBox.Show(this, "Convert OK", "OK", MessageBoxButtons.OK);
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
