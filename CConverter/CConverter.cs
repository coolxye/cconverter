using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading;

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

		private List<Code> lstCode = new List<Code>();

#if DEBUG
		#region action of menuStrip
		private void tsmiOFi_Click(object sender, EventArgs e)
		{
			const string strFilter = "C/C++ Files (*.c;*.cpp;*.h;*.hpp)|*.c;*.cpp;*.h;*.hpp|Flash ActionScript Files(*.as)|*.as";
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = strFilter;
			ofd.Multiselect = true;

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				_lsFiPath.AddRange(ofd.FileNames);
				lbCC.Items.AddRange(ofd.FileNames);
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
						fi.Extension == ".cpp" || fi.Extension == ".hpp" ||
						fi.Extension == ".as")
					{
						_lsFiPath.Add(fi.FullName);
						lbCC.Items.Add(fi.FullName);
					}
			}
		}
		#endregion
#endif

		private Encoding CovertEncode(CustomEncoding ce)
		{
			Encoding ecd;

			switch (ce)
			{
				case CustomEncoding.UTF8:
					ecd = Encoding.UTF8;
					break;

				case CustomEncoding.UTF8woBOM:
					ecd = new UTF8Encoding(false);
					break;

				case CustomEncoding.UCS2:
					ecd = Encoding.Unicode;
					break;

				case CustomEncoding.BigUCS2:
					ecd = Encoding.BigEndianUnicode;
					break;

				case CustomEncoding.UTF32:
					ecd = Encoding.UTF32;
					break;

				case CustomEncoding.BigUTF32:
					ecd = new UTF32Encoding(true, true);
					break;

				case CustomEncoding.Default:
				default:
					ecd = Encoding.Default;
					break;
			}

			return ecd;
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			#region old
			//Encoding ec = Encoding.UTF8;
			//bool bf = false;

			//if (_lsFiPath.Count == 0)
			//    return;

			//this.btnStart.Enabled = false;
			//this.btnClear.Enabled = false;
			//pbCC.Value = 0;
			//pbCC.Maximum = _lsFiPath.Count;

			//if (cbEncode.SelectedIndex == 0)
			//    ec = Encoding.Default;

			//if (rbUnix.Checked)
			//    bf = true;

			//Encoding ecCur;
			//StreamReader sr;
			//StreamWriter sw;
			//string sfile;
			//FileStream fs;

			//foreach (string s in _lsFiPath)
			//{
			//    fs = new FileStream(s, FileMode.Open, FileAccess.Read);
			//    ecCur = Code.GetEncoding(fs);
			//    fs.Close();

			//    if (ecCur != Encoding.UTF8 && ecCur != Encoding.Default)
			//    {
			//        pbCC.PerformStep();
			//        continue;
			//    }

			//    sr = new StreamReader(s, ecCur);
			//    sfile = sr.ReadToEnd();
			//    sr.Close();

			//    if (ecCur == ec && bf == !sfile.Contains("\r\n"))
			//    {
			//        pbCC.PerformStep();
			//        continue;
			//    }

			//    FileAttributes fiatr = File.GetAttributes(s);
			//    if ((fiatr & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
			//        File.SetAttributes(s, FileAttributes.Normal);

			//    // Convert to UTF-8 without BOM
			//    if (ec == Encoding.UTF8)
			//        ec = new UTF8Encoding(false);

			//    sw = new StreamWriter(s, false, ec);

			//    if (bf && sfile.Contains("\r\n"))
			//        sw.Write(sfile.Replace("\r\n", "\n"));
			//    else if (!bf && !sfile.Contains("\r\n"))
			//        sw.Write(sfile.Replace("\n", "\r\n"));
			//    else
			//        sw.Write(sfile);

			//    sw.Close();

			//    pbCC.PerformStep();
			//}

			//Prompt pt = new Prompt("The Converting is Completed.", "Success");
			//pt.ShowDialog(this);

			//this.btnStart.Enabled = true;
			//this.btnClear.Enabled = true;
			#endregion

			if (lstCode.Count == 0)
				return;

			CustomEncoding ec = CustomEncoding.Default;
			EndOfLine eol = EndOfLine.Windows;

			this.btnStart.Enabled = false;
			this.btnClear.Enabled = false;

			switch (this.cbEncode.SelectedIndex)
			{
				case 0:
					ec = CustomEncoding.Default;
					break;

				case 1:
					ec = CustomEncoding.UTF8woBOM;
					break;

				case 2:
					ec = CustomEncoding.UTF8;
					break;

				default:
					break;
			}

			if (this.rbWin.Checked)
				eol = EndOfLine.Windows;
			else if (this.rbUnix.Checked)
				eol = EndOfLine.UNIX;
			else
				eol = EndOfLine.MAC;

			foreach (Code cd in lstCode)
			{
				if (ec == cd.EncodeType && eol == cd.EOLFormat)
					continue;

				StreamReader sr = new StreamReader(cd.FullName, CovertEncode(cd.EncodeType));
				String sfile = sr.ReadToEnd();
				sr.Close();

				FileAttributes fiatr = File.GetAttributes(cd.FullName);
				if ((fiatr & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
					File.SetAttributes(cd.FullName, FileAttributes.Normal);

				Encoding cov = CovertEncode(ec);

				StreamWriter sw = new StreamWriter(cd.FullName, false, cov);

				cd.EncodeType = ec;

				if (eol != cd.EOLFormat)
				{
					if (cd.EOLFormat == EndOfLine.Windows)
					{
						if (eol == EndOfLine.UNIX)
							sw.Write(sfile.Replace("\r\n", "\n"));
						else
							sw.Write(sfile.Replace("\r\n", "\r"));
					}
					else if (cd.EOLFormat == EndOfLine.UNIX)
					{
						if (eol == EndOfLine.Windows)
							sw.Write(sfile.Replace("\n", "\r\n"));
						else
							sw.Write(sfile.Replace("\n", "\r"));
					}
					else
					{
						if (eol == EndOfLine.Windows)
							sw.Write(sfile.Replace("\r", "\r\n"));
						else
							sw.Write(sfile.Replace("\r", "\n"));
					}

					cd.EOLFormat = eol;
				}
				else
					sw.Write(sfile);

				sw.Close();
			}

			this.lbCC.BeginUpdate();

			this.lbCC.Items.Clear();

			foreach (Code cd in lstCode)
				this.lbCC.Items.Add(cd.FullName + " (" + cd.EncodeString + ", " + cd.EOLFormat.ToString() + ")");

			this.lbCC.EndUpdate();

			this.btnStart.Enabled = true;
			this.btnClear.Enabled = true;
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			if (_lsFiPath.Count != 0)
				_lsFiPath.Clear();

			if (lbCC.Items.Count != 0)
				lbCC.Items.Clear();

			pbCC.Value = 0;
		}

		private void lbCC_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}

		private void lbCC_DragOver(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}

		private void ParseCode(string file)
		{
			FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);

			if (Code.IsTxtFile(fs))
			{
				Code cd = new Code();
				cd.FullName = file;
				cd.EncodeType = Code.GetCustomEncoding(fs);
				cd.EOLFormat = Code.GetEOL(fs);

				lstCode.Add(cd);
				//lbCC.Items.Add(cd.FullName + " (" + Code.EncodeString(cd.EncodeType) + ", " + cd.EOLFormat.ToString() + ")");
			}

			fs.Close();
		}

		private void lbCC_DragDrop(object sender, DragEventArgs e)
		{
			string[] sp = (String[])e.Data.GetData(DataFormats.FileDrop);

			if (sp.Length == 0)
				return;

			Thread trd = new Thread(new ThreadStart(this.DoThread));
			trd.Start();

			foreach (string p in sp)
			{
				if (Directory.Exists(p))
				{
					DirectoryInfo di = new DirectoryInfo(p);

					#region old
					//foreach (FileInfo fi in di.GetFiles("*.*", SearchOption.AllDirectories))
					//    if (fi.Extension == ".c" || fi.Extension == ".h" ||
					//    fi.Extension == ".cpp" || fi.Extension == ".hpp" ||
					//    fi.Extension == ".as")
					//    {
					//        _lsFiPath.Add(fi.FullName);
					//        lbCC.Items.Add(fi.FullName);
					//    }
					#endregion

					foreach (FileInfo fi in di.GetFiles("*", SearchOption.AllDirectories))
					{
						ParseCode(fi.FullName);
					}
				}
				else if (File.Exists(p))
				{
					#region old
					//FileInfo fi = new FileInfo(p);

					//if (fi.Extension == ".c" || fi.Extension == ".h" ||
					//    fi.Extension == ".cpp" || fi.Extension == ".hpp" ||
					//    fi.Extension == ".as")
					//{
					//    _lsFiPath.Add(fi.FullName);
					//    lbCC.Items.Add(fi.FullName);
					//}
					#endregion

					ParseCode(p);
				}
			}

			foreach (Code cd in lstCode)
				this.lbCC.Items.Add(cd.FullName + " (" + cd.EncodeString + ", " + cd.EOLFormat.ToString() + ")");
		}

		private delegate void IncreaseProg();
		private IncreaseProg ipLoad;

		private delegate void LoadProgress(int maxValue);
		private delegate void RunProgress();

		private RunProgress rpCode;

		private void ShowProgress()
		{
			Progress pg = new Progress();
			pg.InitProgBar(10000);
			ipLoad = new IncreaseProg(pg.RunProgBar);
			pg.ShowDialog(this);
		}

		private void DoThread()
		{
			//MethodInvoker mi = new MethodInvoker(this.ShowProgress);
			//this.BeginInvoke(mi);

			//Thread.Sleep(2000);

			IncreaseProg xx = new IncreaseProg(this.ShowProgress);

			this.BeginInvoke(xx);

			while (ipLoad == null)
			{
				Thread.Sleep(100);
			}

			this.Invoke(ipLoad);

			ipLoad = null;
		}
	}
}
