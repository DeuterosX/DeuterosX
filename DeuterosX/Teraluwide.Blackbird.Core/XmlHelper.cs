using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Teraluwide.Blackbird.Core.Properties;
using System.Drawing;
using System.ComponentModel;
using System.Globalization;

namespace Teraluwide.Blackbird.Core
{
	/// <summary>
	/// Represents a set of Xml helper methods.
	/// </summary>
	public static class XmlHelper
	{
		private static class TypeConverterProvider<T>
		{
			public static TypeConverter Converter = TypeDescriptor.GetConverter(typeof(T));
		}

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
		/// Parses a Rectangle from a XmlElement.
		/// </summary>
		/// <param name="parent">The parent.</param>
		/// <param name="name">The name.</param>
		/// <param name="defaultValue">The default value.</param>
		/// <returns></returns>
		public static Rectangle ParseRectangle(XmlElement parent, string name, Rectangle defaultValue)
		{
			if (parent == null)
				return defaultValue;

			XmlElement el = parent.SelectSingleNode(name) as XmlElement;

			if (el == null)
				return defaultValue;

			return
				new Rectangle(
						int.Parse(GetAttribute(el, "x", "0")),
						int.Parse(GetAttribute(el, "y", "0")),
						int.Parse(GetAttribute(el, "width", "0")),
						int.Parse(GetAttribute(el, "height", "0"))
					);
		}

		/// <summary>
		/// Gets the attribute or null.
		/// </summary>
		/// <param name="parent">The parent.</param>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public static string GetAttributeOrNull(this XmlElement parent, string name)
		{
			return GetAttribute(parent, name);
		}

		/// <summary>
		/// Creates an attribute with value.
		/// </summary>
		/// <param name="document">The document.</param>
		/// <param name="name">The name.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static XmlAttribute CreateAttributeWithValue(this XmlDocument document, string name, string value)
		{
			var attribute = document.CreateAttribute(name);
			attribute.Value = value;
			return attribute;
		}

		/// <summary>
		/// Gets the attribute.
		/// </summary>
		/// <param name="parent">The parent.</param>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public static string GetAttribute(XmlElement parent, string name)
		{
			return GetAttribute(parent, name, null);
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
			if (parent == null || !parent.HasAttribute(name))
				return defaultValue;

			return parent.GetAttribute(name);
		}


		/// <summary>
		/// Parses the enumeration using the specified generic parameter as enum type and a text string (Flags enums are supported in A|B|C format).
		/// </summary>
		/// <typeparam name="T">The type of the enum being parsed.</typeparam>
		/// <param name="text">The input text.</param>
		/// <returns></returns>
		public static T ParseEnum<T>(string text)
		{
			int ret = 0;

			foreach (string part in text.Split('|'))
				ret = ret | (int)Enum.Parse(typeof(T), part.Trim());
			
			return (T)(object)ret;
		}

		/// <summary>
		/// Parses the specified text.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="text">The text.</param>
		/// <returns></returns>
		public static T Parse<T>(string text)
		{
			Type type = typeof(T);
			
			if (type.IsEnum)
				return (T)(object)ParseEnum<T>(text);
			else
				return (T)TypeConverterProvider<T>.Converter.ConvertFromString(null, CultureInfo.InvariantCulture, text);
		}

		/// <summary>
		/// Creates the object of the specified type.
		/// </summary>
		/// <param name="typeName">Name of the type.</param>
		/// <returns></returns>
		public static object CreateType(BlackbirdGame game, string typeName, params object[] pars)
		{
			Type type = game.TypeManager.GetType(typeName);

			if (type == null)
				throw new BlackbirdException(string.Format(Resources.TypeNotFound, typeName));

			object ret = Activator.CreateInstance(type, pars);

			if (ret == null)
				throw new BlackbirdException(string.Format(Resources.TypeNotInitialized, typeName));

			return ret;
		}
	}
}
