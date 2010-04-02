using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Teraluwide.Blackbird.Core.Properties;
using Teraluwide.Blackbird.Core.ScriptingSupport;

namespace Teraluwide.Blackbird.Core.Gui.Controls
{
	/// <summary>
	/// Represents a base class for all gui controls.
	/// </summary>
	public abstract class GuiControl
	{
		/// <summary>
		/// Gets or sets the game.
		/// </summary>
		/// <value>The game.</value>
		protected BlackbirdGame Game { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="GuiControl"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public GuiControl(BlackbirdGame game)
		{
			this.Game = game;
		}

		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		/// <value>The id.</value>
		public GuiValue<string> Id { get; private set; }

		/// <summary>
		/// Gets or sets the X coordinate.
		/// </summary>
		/// <value>The X coordinate.</value>
		public GuiValue<int> X { get; private set; }

		/// <summary>
		/// Gets or sets the Y coordinate.
		/// </summary>
		/// <value>The Y coordinate.</value>
		public GuiValue<int> Y { get; private set; }

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
		/// Renders this control.
		/// </summary>
		/// <param name="offsetX">The X offset.</param>
		/// <param name="offsetY">The Y offset.</param>
		public abstract void Render(int offsetX, int offsetY);

		/// <summary>
		/// Loads the specified control.
		/// </summary>
		/// <param name="element">The element.</param>
		public virtual void Load(XmlElement element, string currentFileName)
		{
			this.Id = GuiValue<string>.Parse(Game, element.GetAttributeOrNull("id"));
			this.X = GuiValue<int>.Parse(Game, element.GetAttributeOrNull("x"));
			this.Y = GuiValue<int>.Parse(Game, element.GetAttributeOrNull("y"));
			this.Width = GuiValue<int>.Parse(Game, element.GetAttributeOrNull("w"));
			this.Height = GuiValue<int>.Parse(Game, element.GetAttributeOrNull("h"));
		}

		/// <summary>
		/// Loads the specified control.
		/// </summary>
		/// <param name="game">The game.</param>
		/// <param name="element">The element.</param>
		/// <returns></returns>
		public static GuiControl Load(BlackbirdGame game, XmlElement element, string currentFileName)
		{
			string type = element.GetAttributeOrNull("type");

			if (type == null)
				throw new BlackbirdException(string.Format(Resources.ModFileIsInIncorrectFormatSpecificException, currentFileName, "null", "type"));

			GuiControl control = XmlHelper.CreateType(game, type, game) as GuiControl;
			control.Load(element, currentFileName);
			return control;
		}
	}
}
