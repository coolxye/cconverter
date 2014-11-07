using System;
using System.IO;
using System.Text;

namespace CConverter
{
	class Code
	{
		public static Encoding GetEncoding(FileStream fs)
		{
			// Unicode: byte[] { 0xFF, 0xFE, 0x41 }
			// UnicodeBIG: byte[] { 0xFE, 0xFF, 0x00 }
			// UTF8: byte[] { 0xEF, 0xBB, 0xBF }
			Encoding ec = Encoding.Default;
			byte[] bc;

			if (fs.Length == 0)
				return ec;

			bc = new byte[(Int32)fs.Length];

			fs.Read(bc, 0, (Int32)fs.Length);

			if (IsUTF8Bytes(bc))
				ec = Encoding.UTF8;

			return ec;
		}

		private static Boolean IsUTF8Bytes(byte[] data)
		{
			int charByteCounter = 1;　 //计算当前正分析的字符应还有的字节数
			byte curByte; //当前分析的字节.
			bool bAllASCII = true;

			for (int i = 0; i < data.Length; i++)
			{
				curByte = data[i];

				if ((curByte & 0x80) != 0)
					bAllASCII = false;

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
						if (charByteCounter == 1)
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

			if (bAllASCII)
				return false;

			return true;
		}
	}
}
