using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teraluwide.Blackbird.Core
{
	public static class Log
	{
		public static void WriteMessage(string text)
		{
			Console.WriteLine(text);
		}

		public static void WriteError(string text)
		{
			Console.WriteLine("Error: " + text);
		}

		public static void WriteWarning(string text)
		{
			Console.WriteLine("Warning: " + text);
		}
	}
}
