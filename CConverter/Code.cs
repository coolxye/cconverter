using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CConverter
{
	class Code
	{
		public static Encoding GetEncoding(Stream fs)
		{
			// Unicode: byte[] { 0xFF, 0xFE, 0x41 }
			// UnicodeBIG: byte[] { 0xFE, 0xFF, 0x00 }
			// UTF8: byte[] { 0xEF, 0xBB, 0xBF }
			Encoding ec = Encoding.Default;
			byte[] bc;
			BinaryReader br;

			if (fs.Length == 0)
				return ec;

			br = new BinaryReader(fs, Encoding.Default);

			if (fs.Length < 4)
			{
				bc = br.ReadBytes((Int32)fs.Length);
				if (IsUTF8Bytes(bc))
					ec = Encoding.UTF8;

				br.Close();

				return ec;
			}

			bc = br.ReadBytes(4);

			if (bc[0] == 0xFE && bc[1] == 0xFF && bc[2] == 0x00)
			{
				ec = Encoding.BigEndianUnicode;
			}
			else if (bc[0] == 0xFF && bc[1] == 0xFE && bc[2] == 0x41)
			{
				ec = Encoding.Unicode;
			}
			else
			{
				if (bc[0] == 0xEF && bc[1] == 0xBB && bc[2] == 0xBF)
				{
					ec = Encoding.UTF8;
				}
				else
				{
					int i;
					Int32.TryParse(fs.Length.ToString(), out i);
					bc = br.ReadBytes(i);
					if (IsUTF8Bytes(bc))
						ec = Encoding.UTF8;
				}
			}

			br.Close();

			return ec;
		}

		private static Boolean IsUTF8Bytes(byte[] data)
		{
			int charByteCounter = 1;　 //计算当前正分析的字符应还有的字节数
			byte curByte; //当前分析的字节.

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
						//标记位首位若为非0 则至少以2个1开始 如:110XXXXX...........1111110X
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
				return false;
			}

			return true;
		}
	}
}
