using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using Teraluwide.Blackbird.Core.ScriptingSupport;

namespace Teraluwide.Blackbird.Core.Gui
{
	public class GuiBackground
	{
		/// <summary>
		/// Gets or sets the game.
		/// </summary>
		/// <value>The game.</value>
		protected BlackbirdGame Game { get; private set; }

		/// <summary>
		/// Gets or sets the color.
		/// </summary>
		/// <value>The color.</value>
		public GuiValue<Color> Color { get; private set; }

		/// <summary>
		/// Gets or sets the image.
		/// </summary>
		/// <value>The image.</value>
		public GuiValue<string> Image { get; private set; }

		/// <summary>
		/// Gets or sets the repeat style.
		/// </summary>
		/// <value>The repeat.</value>
		public GuiValue<GuiRepeatStyle> Repeat { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="GuiBackground"/> class.
		/// </summary>
		public GuiBackground(BlackbirdGame game)
		{
			this.Game = game;

			Color = new GuiNullValue<Color>(Game);
			Image = new GuiNullValue<string>(Game);
			Repeat = new GuiNullValue<GuiRepeatStyle>(Game);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GuiBackground"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		/// <param name="el">The el.</param>
		/// <param name="currentFileName">Name of the current file.</param>
		public GuiBackground(BlackbirdGame game, XmlElement el, string currentFileName)
			: this(game)
		{
			Load(el, currentFileName);
		}

		/// <summary>
		/// Loads the background information from the specified Xml element.
		/// </summary>
		/// <param name="el">The source Xml element.</param>
		/// <param name="currentFileName">Name of the current file.</param>
		public void Load(XmlElement el, string currentFileName)
		{
			string color = el.GetAttributeOrNull("color");
			string image = el.GetAttributeOrNull("image");
			string repeat = el.GetAttributeOrNull("repeat");

			Color = GuiValue<Color>.Parse(Game, color);
			Image = GuiValue<string>.Parse(Game, image);
			Repeat = GuiValue<GuiRepeatStyle>.Parse(Game, repeat);
		}
	}
}
