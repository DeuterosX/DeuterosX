using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.Blackbird.Core.ScriptingSupport;
using System.Xml;

namespace Teraluwide.Blackbird.Core.Gui.Controls
{
	/// <summary>
	/// Represents a control which renders another frame inside itself.
	/// </summary>
	public class GuiFaceControl : GuiControl
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GuiLabel"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public GuiFaceControl(BlackbirdGame game)
			: base(game)
		{	}

		/// <summary>
		/// Gets or sets the face id.
		/// </summary>
		/// <value>The face id.</value>
		public GuiValue<string> FaceId { get; private set; }

		/// <summary>
		/// Renders this control.
		/// </summary>
		/// <param name="offsetX">The X offset.</param>
		/// <param name="offsetY">The Y offset.</param>
		public override void Render(int offsetX, int offsetY)
		{
			if (this.FaceId.HasValue)
			{
				GuiFace face = Game.GuiManager.GetFace(this.FaceId.Value);
				face.Render(offsetX + X.GetValueOrDefault(0), offsetY + Y.GetValueOrDefault(0));
			}
		}

		/// <summary>
		/// Loads the specified control.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="currentFileName"></param>
		public override void Load(XmlElement element, string currentFileName)
		{
			base.Load(element, currentFileName);

			this.FaceId = GuiValue<string>.Parse(Game, element.GetAttribute("faceId"));
		}
	}
}
