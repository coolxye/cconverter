﻿using System;
using System.IO;
using System.Text;

namespace CConverter
{
	enum CustomEncoding
	{ ANSI, UTF8, UTF8woBOM, UCS2, BigUCS2, UTF32, BigUTF32 }

	enum EndOfLine
	{ Windows, UNIX, MAC, Mix }

	class Code
	{
		public String FullName
		{ get; set; }

		public String Extension
		{ get; set; }

		public CustomEncoding EncodeType
		{ get; set; }

		public EndOfLine EOLFormat
		{ get; set; }

		public String EncodeString
		{
			get
			{
				return GetEncodeString(this.EncodeType);
			}
		}

		/// <summary>
		/// Get the Encoding of a file
		/// </summary>
		/// <param name="fs">FileStream</param>
		/// <returns>Encoding</returns>
		public static Encoding GetEncoding(FileStream fs)
		{
			#region
			/// with BOM
			/// UTF-16 Big: byte[] { 0xFE, 0xFF }
			/// UTF-16 Little: byte[] { 0xFF, 0xFE }
			/// UTF-32 Big: byte[] { 0x00, 0x00, 0xFE, 0xFF }
			/// UTF-32 Little: byte[] { 0xFF, 0xFE, 0x00, 0x00 }
			/// UTF8: byte[] { 0xEF, 0xBB, 0xBF }
			/// without BOM
			/// UNICODE UTF-8
			/// 00000000 - 0000007F 0xxxxxxx
			/// 00000080 - 000007FF 110xxxxx 10xxxxxx
			/// 00000800 - 0000FFFF 1110xxxx 10xxxxxx 10xxxxxx
			/// 00010000 - 001FFFFF 11110xxx 10xxxxxx 10xxxxxx 10xxxxxx
			/// 00200000 - 03FFFFFF 111110xx 10xxxxxx 10xxxxxx 10xxxxxx 10xxxxxx
			/// 04000000 - 7FFFFFFF 1111110x 10xxxxxx 10xxxxxx 10xxxxxx 10xxxxxx 10xxxxxx
			#endregion

			byte[] bc;
			Encoding ec = Encoding.Default;
			long lf = fs.Length;

			if (lf < 0 || lf > Int32.MaxValue)
				ec = null;
			else if (lf == 2)
			{
				// UTF-16 / UTF-8 without BOM / ANSI
				bc = new byte[2];
				fs.Read(bc, 0, 2);

				if (bc[0] == 0xFE && bc[1] == 0xFF)
					ec = Encoding.BigEndianUnicode;
				else if (bc[0] == 0xFF && bc[1] == 0xFE)
					ec = Encoding.Unicode;
				else
					if (IsUTF8Code(bc))
						ec = Encoding.UTF8;
			}
			else if (lf == 3)
			{
				// UTF-16 / UTF-8 / ANSI
				bc = new byte[3];
				fs.Read(bc, 0, 3);

				if (bc[0] == 0xFE && bc[1] == 0xFF)
					ec = Encoding.BigEndianUnicode;
				else if (bc[0] == 0xFF && bc[1] == 0xFE)
					ec = Encoding.Unicode;
				else if (bc[0] == 0xEF && bc[1] == 0xBB && bc[2] == 0xBF)
					ec = Encoding.UTF8;
				else
					if (IsUTF8Code(bc))
						ec = Encoding.UTF8;
			}
			else if (lf > 3)
			{
				// UTF-32 / UTF-16 / UTF-8 / ANSI
				bc = new byte[4];
				fs.Read(bc, 0, 4);

				if (bc[0] == 0x00 && bc[1] == 0x00 && bc[2] == 0xFE && bc[3] == 0xFF)
					ec = new UTF32Encoding(true, true);
				else if (bc[0] == 0xFE && bc[1] == 0xFF)
					ec = Encoding.BigEndianUnicode;
				else if (bc[0] == 0xFF && bc[1] == 0xFE)
				{
					if (bc[2] == 0x00 && bc[3] == 0x00)
						ec = Encoding.UTF32;
					else
						ec = Encoding.Unicode;
				}
				else if (bc[0] == 0xEF && bc[1] == 0xBB && bc[2] == 0xBF)
					ec = Encoding.UTF8;
				else
				{
					fs.Seek(0, SeekOrigin.Begin);
					bc = new byte[lf];
					fs.Read(bc, 0, (int)lf);
					if (IsUTF8Code(bc))
						ec = Encoding.UTF8;
				}
			}

			return ec;
		}

		public static CustomEncoding GetCustomEncoding(FileStream fs)
		{
			byte[] bc;
			CustomEncoding ec = CustomEncoding.ANSI;
			long lf = fs.Length;

			fs.Seek(0, SeekOrigin.Begin);

			if (lf < 0 || lf > Int32.MaxValue)
			{ }
			else if (lf == 2)
			{
				// UTF-16 / UTF-8 without BOM / ANSI
				bc = new byte[2];
				fs.Read(bc, 0, 2);

				if (bc[0] == 0xFE && bc[1] == 0xFF)
					ec = CustomEncoding.BigUCS2;
				else if (bc[0] == 0xFF && bc[1] == 0xFE)
					ec = CustomEncoding.UCS2;
				else
					if (IsUTF8Code(bc))
						ec = CustomEncoding.UTF8woBOM;
			}
			else if (lf == 3)
			{
				// UTF-16 / UTF-8 / ANSI
				bc = new byte[3];
				fs.Read(bc, 0, 3);

				if (bc[0] == 0xFE && bc[1] == 0xFF)
					ec = CustomEncoding.BigUCS2;
				else if (bc[0] == 0xFF && bc[1] == 0xFE)
					ec = CustomEncoding.UCS2;
				else if (bc[0] == 0xEF && bc[1] == 0xBB && bc[2] == 0xBF)
					ec = CustomEncoding.UTF8;
				else
					if (IsUTF8Code(bc))
						ec = CustomEncoding.UTF8woBOM;
			}
			else if (lf > 3)
			{
				// UTF-32 / UTF-16 / UTF-8 / ANSI
				bc = new byte[4];
				fs.Read(bc, 0, 4);

				if (bc[0] == 0x00 && bc[1] == 0x00 && bc[2] == 0xFE && bc[3] == 0xFF)
					ec = CustomEncoding.BigUTF32;
				else if (bc[0] == 0xFE && bc[1] == 0xFF)
					ec = CustomEncoding.BigUCS2;
				else if (bc[0] == 0xFF && bc[1] == 0xFE)
				{
					if (bc[2] == 0x00 && bc[3] == 0x00)
						ec = CustomEncoding.UTF32;
					else
						ec = CustomEncoding.UCS2;
				}
				else if (bc[0] == 0xEF && bc[1] == 0xBB && bc[2] == 0xBF)
					ec = CustomEncoding.UTF8;
				else
				{
					fs.Seek(0, SeekOrigin.Begin);
					bc = new byte[lf];
					fs.Read(bc, 0, (int)lf);
					if (IsUTF8Code(bc))
						ec = CustomEncoding.UTF8woBOM;
				}
			}

			return ec;
		}

		/// <summary>
		/// Check the Txt-Type of a file (Bug)
		/// </summary>
		/// <param name="fs">FileStream</param>
		/// <returns>Boolean</returns>
		public static Boolean IsTxtFile(FileStream fs)
		{
			byte[] bc;
			bool bl = true;
			long lf = fs.Length;

			fs.Seek(0, SeekOrigin.Begin);

			if (lf < 0 || lf > Int32.MaxValue)
				bl = false;
			else if (lf <= 3)
			{
				bc = new byte[lf];
				fs.Read(bc, 0, (int)lf);

				foreach (byte b in bc)
					if (b == 0x00)
					{
						bl = false;
						break;
					}
			}
			else
			{
				// UTF-32
				bc = new byte[4];
				fs.Read(bc, 0, 4);

				if ((bc[0] == 0x00 && bc[1] == 0x00 && bc[2] == 0xFE && bc[3] == 0xFF) ||
					(bc[0] == 0xFF && bc[1] == 0xFE && bc[2] == 0x00 && bc[3] == 0x00))
						bl = true;
				else
				{
					fs.Seek(0, SeekOrigin.Begin);
					bc = new byte[lf];
					fs.Read(bc, 0, (int)lf);

					foreach (byte b in bc)
						if (b == 0x00)
						{
							bl = false;
							break;
						}
				}
			}

			return bl;
		}

		//public static const List<String> FileExt = new List<string>(
		//    new String[] {
		//        "txt", "as", "mx", "mxml", "c", "cpp", "cxx",
		//        "h", "hpp", "hxx", "cc", "cs", "java", "js",
		//        "jsp", "rc", "vb", "vbs", "xml", "xsml",
		//        "xsl", "xsd", "kml"
		//    }
		//);

		private static String[] FileExt = {
			".txt",
			".as", ".mx", ".mxml",
			".c", ".cpp", ".cxx", ".h", ".hpp", ".hxx", ".cc",
			".cs", ".sln", ".csproj", ".resx",
			".java", ".js", ".jsp",
			".rc",
			".vb", ".vbs",
			".xml", ".xsml", ".xsl", ".xsd", ".kml"
		};

		public static Boolean IsCnvFile(String ext)
		{
			foreach (string str in FileExt)
				if (ext.Equals(str))
					return true;

			return false;
		}

		public static String GetEncodeString(CustomEncoding ce)
		{
			String strEnc;

			switch (ce)
			{
				case CustomEncoding.UTF8:
					strEnc = "UTF-8";
					break;

				case CustomEncoding.UTF8woBOM:
					strEnc = "UTF-8 w/o BOM";
					break;

				case CustomEncoding.UCS2:
					strEnc = "Unicode(UTF-16)";
					break;

				case CustomEncoding.BigUCS2:
					strEnc = "Unicode(UTF-16) Big Endian";
					break;

				case CustomEncoding.UTF32:
					strEnc = "UTF-32 Little Endian";
					break;

				case CustomEncoding.BigUTF32:
					strEnc = "UTF-32 Big Endian";
					break;

				case CustomEncoding.ANSI:
				default:
					strEnc = "ANSI";
					break;
			}

			return strEnc;
		}

		public static EndOfLine GetEOL(FileStream fs)
		{
			if (fs == FileStream.Null || fs.Length == 0)
				return EndOfLine.Windows;

			EndOfLine eol = EndOfLine.Windows;
			int iL = (int)fs.Length;
			byte[] bt = new byte[iL + 1];

			fs.Seek(0, SeekOrigin.Begin);
			fs.Read(bt, 0, iL);
			bt[iL] = 0x00;

			for (int i = 0; i < iL; i++)
			{
				if (bt[i] == 0x0D)
				{
					if (bt[i + 1] == 0x0A)
						eol = EndOfLine.Windows;
					else
						eol = EndOfLine.MAC;

					break;
				}
				else if (bt[i] == 0x0A)
				{
					eol = EndOfLine.UNIX;

					break;
				}
			}

			return eol;
		}

		public static EndOfLine GetEOL(CustomEncoding ce, FileStream fs)
		{
			if (fs == FileStream.Null || fs.Length == 0)
			{
				return EndOfLine.Windows;
			}

			EndOfLine eol = EndOfLine.Windows;
			int iL = (int)fs.Length;
			byte[] bt = new byte[iL + 1];
			byte beol = 0x00;

			fs.Seek(0, SeekOrigin.Begin);
			fs.Read(bt, 0, iL);
			bt[iL] = 0x00;

			switch (ce)
			{
				case CustomEncoding.ANSI:
				case CustomEncoding.UTF8:
				case CustomEncoding.UTF8woBOM:
					for (int i = 0; i < iL; i++)
					{
						if (bt[i] == 0x0D && bt[i + 1] == 0x0A)
						{
							beol |= 0x01;
							i++;
						}
						else if (bt[i] == 0x0D)
							beol |= 0x02;
						else if (bt[i] == 0x0A)
							beol |= 0x04;
					}

					if (beol == 0x01)
						eol = EndOfLine.Windows;
					else if (beol == 0x02)
						eol = EndOfLine.MAC;
					else if (beol == 0x04)
						eol = EndOfLine.UNIX;
					else
						eol = EndOfLine.Mix;

					break;

				case CustomEncoding.BigUCS2:
					break;
				case CustomEncoding.BigUTF32:
					break;
				case CustomEncoding.UCS2:
					break;
				case CustomEncoding.UTF32:
					break;

				default:
					break;
			}

			return eol;
		}

		private static bool IsUTF8Code(byte[] data)
		{
			int charByteCounter = 1;	//计算当前正分析的字符应还有的字节数
			byte curByte;	//当前分析的字节

			for (int i = 0; i < data.Length; i++)
			{
				curByte = data[i];
				if (charByteCounter == 1)
				{
					if (curByte >= 0x80)
					{
						//判断当前
						while (((curByte <<= 1) & 0x80) != 0)
						{
							charByteCounter++;
						}
						//标记位首位若为非0 则至少以2个1开始 如:110XXXXX~1111110X
						if (charByteCounter == 1 || charByteCounter > 6)
						{
							return false;
						}
					}
				}
				else
				{
					//若是UTF-8 此时第一位必须为1
					if ((curByte & 0xC0) != 0x80)
					{
						return false;
					}
					charByteCounter--;
				}
			}

			if (charByteCounter > 1)
			{
				throw new Exception("非预期的byte格式!");
			}

			return true;
		}
	}
}
