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

		private List<String> _lsFiPath = new List<String>();

		private void tsmiOFi_Click(object sender, EventArgs e)
		{
			const string strFilter = "C/C++ Files (*.c;*.cpp;*.h;*.hpp)|*.c;*.cpp;*.h;*.hpp";
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = strFilter;
			ofd.Multiselect = true;

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				_lsFiPath.AddRange(ofd.FileNames);
				lbCC.Items.AddRange(ofd.FileNames);
				tsslCC.Text = String.Format("{0} files were loaded.", _lsFiPath.Count);
			}
		}

		private void tsmiOFo_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fdb = new FolderBrowserDialog();

			if (fdb.ShowDialog() == DialogResult.OK)
			{
				DirectoryInfo di = new DirectoryInfo(fdb.SelectedPath);
				foreach (FileInfo fi in di.GetFiles("*.*", SearchOption.AllDirectories))
					if (fi.Extension == ".c" || fi.Extension == ".h" ||
						fi.Extension == ".cpp" || fi.Extension == ".hpp")
					{
						_lsFiPath.Add(fi.FullName);
						lbCC.Items.Add(fi.FullName);
					}

				tsslCC.Text = String.Format("{0} files were loaded.", _lsFiPath.Count);
			}
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			Encoding ec = Encoding.UTF8;
			bool bf = false;

			if (_lsFiPath.Count == 0)
				return;

			tspbCC.Maximum = _lsFiPath.Count;

			tsslCC.Text = "The CodePage of files is Converting...";

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

				tspbCC.PerformStep();

				if (ecCur == ec && bf == !sfile.Contains("\r\n"))
					continue;

				FileAttributes fiatr = File.GetAttributes(s);
				if ((fiatr & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
					File.SetAttributes(s, FileAttributes.Normal);

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

			tsslCC.Text = "The Converting is Completed.";
			//tsslCC.ScrollToCaret();
			//MessageBox.Show(this, "Convert OK", "OK", MessageBoxButtons.OK);
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			if (_lsFiPath.Count != 0)
				_lsFiPath.Clear();

			if (lbCC.Items.Count != 0)
				lbCC.Items.Clear();

			tsslCC.Text = "";
			tspbCC.Value = 0;
		}

		private void lbCC_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}

		private void lbCC_DragOver(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}

		private void lbCC_DragDrop(object sender, DragEventArgs e)
		{
			string[] sp = (String[])e.Data.GetData(DataFormats.FileDrop);

			if (sp.Length == 0)
				return;

			foreach (string p in sp)
			{
				if (Directory.Exists(p))
				{
					DirectoryInfo di = new DirectoryInfo(p);

					foreach (FileInfo fi in di.GetFiles("*.*", SearchOption.AllDirectories))
						if (fi.Extension == ".c" || fi.Extension == ".h" ||
						fi.Extension == ".cpp" || fi.Extension == ".hpp")
						{
							_lsFiPath.Add(fi.FullName);
							lbCC.Items.Add(fi.FullName);
						}
				}
				else if (File.Exists(p))
				{
					FileInfo fi = new FileInfo(p);

					if (fi.Extension == ".c" || fi.Extension == ".h" ||
						fi.Extension == ".cpp" || fi.Extension == ".hpp")
					{
						_lsFiPath.Add(fi.FullName);
						lbCC.Items.Add(fi.FullName);
					}
				}
			}

			tsslCC.Text = String.Format("{0} files were loaded.", _lsFiPath.Count);
		}
	}
}
