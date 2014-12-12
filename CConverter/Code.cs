using System;
using System.IO;
using System.Text;

namespace CConverter
{
	class Code
	{
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
