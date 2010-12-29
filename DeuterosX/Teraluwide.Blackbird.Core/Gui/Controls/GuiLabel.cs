using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Teraluwide.Blackbird.Core.ScriptingSupport;
using System.Drawing;
using SdlDotNet.Graphics;

namespace Teraluwide.Blackbird.Core.Gui.Controls
{
	/// <summary>
	/// Represents a text label.
	/// </summary>
	public class GuiLabel : GuiControl
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GuiLabel"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public GuiLabel(BlackbirdGame game)
			: base(game)
		{	}

		/// <summary>
		/// Gets or sets the text.
		/// </summary>
		/// <value>The text.</value>
		public GuiValue<string> Text { get; private set; }

		/// <summary>
		/// Gets or sets the color.
		/// </summary>
		/// <value>The color.</value>
		public GuiValue<Color> Color { get; private set; }

		/// <summary>
		/// Gets or sets the font.
		/// </summary>
		/// <value>The font.</value>
		public GuiValue<string> Font { get; private set; }

		/// <summary>
		/// Renders this control.
		/// </summary>
		/// <param name="offsetX">The X offset.</param>
		/// <param name="offsetY">The Y offset.</param>
		public override void RenderControl(int offsetX, int offsetY)
		{
			// TODO: Render a text label
		}

		/// <summary>
		/// Loads the specified control.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="currentFileName"></param>
		public override void Load(XmlElement element, string currentFileName)
		{
			base.Load(element, currentFileName);

			this.Text = GuiValue<string>.Parse(Game, element.GetAttribute("text"), this);
			this.Color = GuiValue<Color>.Parse(Game, element.GetAttribute("color"), this);
			this.Font = GuiValue<string>.Parse(Game, element.GetAttribute("font"), this);
		}
	}
}
