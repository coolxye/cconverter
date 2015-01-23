using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CConverter
{
	public partial class CConverter : Form
	{
		public CConverter()
		{
			InitializeComponent();

			this.cbEncode.DataSource = Enum.GetValues(typeof(CustomEncoding));
			this.cbEncode.SelectedItem = CustomEncoding.UTF8woBOM;

			this.rbUnix.Checked = true;
		}

		private List<Code> lstCode = new List<Code>();

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

				case CustomEncoding.ANSI:
				default:
					ecd = Encoding.Default;
					break;
			}

			return ecd;
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			if (lstCode.Count == 0)
				return;

			CustomEncoding ec;
			EndOfLine eol;

			this.btnStart.Enabled = false;
			this.btnClear.Enabled = false;

			ec = (CustomEncoding)this.cbEncode.SelectedItem;

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
				StringBuilder sb = new StringBuilder(sr.ReadToEnd());
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
							sb.Replace("\r\n", "\n");
						else
							sb.Replace("\r\n", "\r");
					}
					else if (cd.EOLFormat == EndOfLine.UNIX)
					{
						if (eol == EndOfLine.Windows)
							sb.Replace("\n", "\r\n");
						else
							sb.Replace("\n", "\r");
					}
					else if (cd.EOLFormat == EndOfLine.MAC)
					{
						if (eol == EndOfLine.Windows)
							sb.Replace("\r", "\r\n");
						else
							sb.Replace("\r", "\n");
					}
					else
					{
						if (eol == EndOfLine.Windows)
						{
							sb.Replace("\r\n", "\n");
							sb.Replace("\r", "\n");
							sb.Replace("\n", "\r\n");
						}
						else if (eol == EndOfLine.UNIX)
						{
							sb.Replace("\r\n", "\n");
							sb.Replace("\r", "\n");
						}
						else
						{
							sb.Replace("\r\n", "\r");
							sb.Replace("\n", "\r");
						}
					}

					cd.EOLFormat = eol;
				}

				sw.Write(sb.ToString());

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
			if (lstCode.Count != 0)
				lstCode.Clear();

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

		private void ParseCode(FileInfo file)
		{
			if (Code.IsCnvFile(file.Extension))
			{
				FileStream fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read);

				Code cd = new Code();
				cd.FullName = file.FullName;
				cd.Extension = file.Extension;
				cd.EncodeType = Code.GetCustomEncoding(fs);
				cd.EOLFormat = Code.GetEOL(cd.EncodeType, fs);

				lstCode.Add(cd);

				fs.Close();
			}
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

					foreach (FileInfo fi in di.GetFiles("*", SearchOption.AllDirectories))
						ParseCode(fi);
				}
				else if (File.Exists(p))
				{
					FileInfo fi = new FileInfo(p);
					ParseCode(fi);
				}
			}

			foreach (Code cd in lstCode)
				this.lbCC.Items.Add(cd.FullName + " (" + cd.EncodeString + ", " + cd.EOLFormat.ToString() + ")");
		}
	}
}
