using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Teraluwide.Blackbird.Core
{
	/// <summary>
	/// Represents a set of Xml helper methods.
	/// </summary>
	public static class XmlHelper
	{
		/// <summary>
		/// Parses a Xml boolean value.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <exception cref="System.FormatException"><seealso cref="System.FormatException"/> is thrown when the value is invalid.</exception>
		public static bool ParseBool(string value)
		{
			if (value == "0") return false;
			else if (value == "1") return true;

			throw new FormatException();
		}

		/// <summary>
		/// Gets the specified attribute from a XmlElement.
		/// </summary>
		/// <param name="parent">The parent.</param>
		/// <param name="name">The name.</param>
		/// <param name="defaultValue">The default value.</param>
		/// <returns></returns>
		public static string GetAttribute(XmlElement parent, string name, string defaultValue)
		{
			string ret = parent.GetAttribute(name);
			if (string.IsNullOrEmpty(ret)) ret = defaultValue;

			return ret;
		}

		/// <summary>
		/// Parses the enumeration using the specified generic parameter as enum type and a text string (Flags enums are supported in A|B|C format).
		/// </summary>
		/// <typeparam name="T">The type of the enum being parsed.</typeparam>
		/// <param name="text">The input text.</param>
		/// <returns></returns>
		public static int ParseEnum<T>(string text)
			where T: struct
		{
			int ret = 0;
			
			foreach (string part in text.Split('|'))
				ret = ret | (int)Enum.Parse(typeof(T), part.Trim());
			
			return ret;
		}
	}
}
