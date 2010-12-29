using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace Teraluwide.Blackbird.Core
{
	public static class Extensions
	{
		public static string ReadToEnd(this Stream stream)
		{
			StreamReader rdr = new StreamReader(stream);
			StringWriter sw = new StringWriter();

			char[] buf = new char[512];
			int bytesRead = 0;
			while ( (bytesRead = rdr.Read(buf, 0, buf.Length)) > 0)
			{
				sw.Write(buf, 0, bytesRead);
			}

			rdr.Close();
			stream.Close();
			return sw.ToString();
		}
	}
}
