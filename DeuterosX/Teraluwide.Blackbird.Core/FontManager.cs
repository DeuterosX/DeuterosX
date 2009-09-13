using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SdlDotNet.Graphics;
using Teraluwide.Blackbird.Core.Properties;
using System.Xml;
using System.Globalization;

namespace Teraluwide.Blackbird.Core
{
	/// <summary>
	/// Represents a font manager.
	/// </summary>
	public class FontManager : IBlackbirdComponent
	{
		public const string FileName = "Fonts.xml";

		/// <summary>
		/// Gets the game instance associated with this component instance.
		/// </summary>
		/// <value>The game.</value>
		public BlackbirdGame Game { get; private set; }

		private Dictionary<string, Font> innerData = new Dictionary<string, Font>();

		/// <summary>
		/// Initializes a new instance of the <see cref="FontManager"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public FontManager(BlackbirdGame game)
		{
			this.Game = game;
			this.innerData = new Dictionary<string, Font>();
		}

		/// <summary>
		/// Loads the component data for the currently selected mod.
		/// </summary>
		public void Load()
		{
			Load(VirtualPathProvider.GetFile(VirtualPathProvider.EnsureModVirtualPath(FileName, Game.ModName)));
		}

		/// <summary>
		/// Loads the component data from the specified stream.
		/// </summary>
		/// <param name="stream">The input stream.</param>
		public void Load(Stream stream)
		{
			XmlDocument doc = new XmlDocument();
			try
			{
				doc.Load(stream);
			}
			catch (XmlException ex)
			{
				throw new BlackbirdException(string.Format(Resources.ModFileIsInIncorrectFormatException, FileName), ex);
			}
			finally
			{
				stream.Close();
			}

			XmlElement root = doc.SelectSingleNode("/FDRFile") as XmlElement;

			if (root == null || root.Attributes["type"].Value != "fonts")
				throw new BlackbirdException(string.Format(Resources.ModFileIsInIncorrectFormatException, FileName));

			foreach (XmlElement font in root.SelectNodes("FontList/*"))
			{
				string id = string.Empty;
				string fontName = string.Empty;
				decimal fontSize = 0;
				bool systemFont = false;
				Styles fontStyles = Styles.None;

				foreach (XmlElement param in font.ChildNodes)
				{
					try
					{
						switch (param.Name)
						{
							case "Id": id = param.InnerText; break;
							case "FontName": fontName = param.InnerText; break;
							case "FontSize": fontSize = decimal.Parse(param.InnerText, CultureInfo.InvariantCulture); break;
							case "SystemFont": systemFont = XmlHelper.ParseBool(param.InnerText); break;
							case "FontStyles": fontStyles = (Styles)XmlHelper.ParseEnum<Styles>(param.InnerText); break;
						}
					}
					catch (FormatException ex)
					{
						throw new BlackbirdException(string.Format(Resources.ModFileIsInIncorrectFormatSpecificException, FileName, param.InnerText, param.Name), ex);
					}
				}

				if (string.IsNullOrEmpty(id))
					throw new BlackbirdException(string.Format(Resources.ModFileIsInIncorrectFormatSpecificException, FileName, "null", "Id"));
				if (string.IsNullOrEmpty(fontName))
					throw new BlackbirdException(string.Format(Resources.ModFileIsInIncorrectFormatSpecificException, FileName, "null", "FontName"));
				if (fontSize == 0)
					throw new BlackbirdException(string.Format(Resources.ModFileIsInIncorrectFormatSpecificException, FileName, "null", "FontSize"));

				if (innerData.ContainsKey(id))
					throw new BlackbirdException(string.Format(Resources.FontAlreadyRegistered, id));

				Font pom;

				if (systemFont)
					pom = new Font(fontName, (int)fontSize);
				else
				{
					byte[] data;
					using (Stream fileStream = VirtualPathProvider.GetFile(VirtualPathProvider.EnsureModVirtualPath(fontName, Game.ModName)))
					{
						int length = (int)fileStream.Length;

						data = new byte[length];
						if (fileStream.Read(data, 0, length) != length)
							return;
					}

					pom = new Font(data, (int)fontSize);
					pom.Style = fontStyles;
				}

				innerData.Add(id, pom);
			}
		}

		/// <summary>
		/// Saves the component data of the currently selected mod.
		/// </summary>
		public void Save()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Saves the component data of the currently selected mod to the specified stream.
		/// </summary>
		/// <param name="stream">The target stream.</param>
		public void Save(Stream stream)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the font specified by unique identifier.
		/// </summary>
		/// <param name="fontId">The font unique identifier.</param>
		/// <returns></returns>
		Font GetFont(string fontId)
		{
			if (!innerData.ContainsKey(fontId))
				throw new BlackbirdException(string.Format(Resources.FontUndefined, fontId));

			return innerData[fontId];
		}

		/// <summary>
		/// Draws text string in the specified font.
		/// </summary>
		/// <param name="fontId">The font unique identifier.</param>
		/// <param name="text">The text string.</param>
		/// <param name="color">The text color.</param>
		/// <returns></returns>
		public Surface DrawText(string fontId, string text, System.Drawing.Color color)
		{
			return GetFont(fontId).Render(text, color, true);
		}

		#region IDisposable Members

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			foreach (var font in innerData.Values)
				font.Dispose();

			innerData.Clear();
		}

		#endregion
	}
}
