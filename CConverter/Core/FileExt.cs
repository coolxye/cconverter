using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CConverter.Core
{
	class FileExt
	{
		//public static String[] Exts
		//{ get; set; }

		//public static String ExtsXml
		//{ get; set; }

		public static List<String> Exts
		{ get; set;	}

		public static Boolean IsCnvFile(String ext)
		{
			foreach (string str in Exts)
				if (ext.Equals(str))
					return true;

			return false;
		}

		//public static String Exts2Xml(string[] exts)
		//{
		//	string xml = "";

		//	foreach (string ext in exts)
		//	{
		//		xml += ext;
		//		xml += ",";
		//	}

		//	return xml.Remove(xml.Length - 1);
		//}

		//public static String[] Xml2Exts(string xml)
		//{
		//	return xml.Split(',');
		//}
	}
}
