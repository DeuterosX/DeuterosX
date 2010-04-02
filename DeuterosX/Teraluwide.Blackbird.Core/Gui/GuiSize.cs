using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Teraluwide.Blackbird.Core.ScriptingSupport;

namespace Teraluwide.Blackbird.Core.Gui
{
	public class GuiSize
	{
		/// <summary>
		/// Gets or sets the game.
		/// </summary>
		/// <value>The game.</value>
		protected BlackbirdGame Game { get; private set; }

		/// <summary>
		/// Gets or sets the width.
		/// </summary>
		/// <value>The width.</value>
		public GuiValue<int> Width { get; private set; }

		/// <summary>
		/// Gets or sets the height.
		/// </summary>
		/// <value>The height.</value>
		public GuiValue<int> Height { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="GuiBackground"/> class.
		/// </summary>
		public GuiSize(BlackbirdGame game)
		{
			this.Game = game;

			Width = new GuiNullValue<int>(Game);
			Height = new GuiNullValue<int>(Game);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GuiBackground"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		/// <param name="el">The el.</param>
		/// <param name="currentFileName">Name of the current file.</param>
		public GuiSize(BlackbirdGame game, XmlElement el, string currentFileName)
			: this(game)
		{
			Load(el, currentFileName);
		}

		/// <summary>
		/// Loads the size information from the specified Xml element.
		/// </summary>
		/// <param name="el">The source Xml element.</param>
		/// <param name="currentFileName">Name of the current file.</param>
		public void Load(XmlElement el, string currentFileName)
		{
			string width = el.GetAttributeOrNull("width");
			string height = el.GetAttributeOrNull("height");

			Width = GuiValue<int>.Parse(Game, width);
			Height = GuiValue<int>.Parse(Game, height);
		}
	}
}
