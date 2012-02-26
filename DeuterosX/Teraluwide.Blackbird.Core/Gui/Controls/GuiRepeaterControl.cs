using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.Blackbird.Core.ScriptingSupport;
using System.Xml;
using System.Collections;

namespace Teraluwide.Blackbird.Core.Gui.Controls
{
	/// <summary>
	/// Represents a repeater control. Takes a data source and renders the specified face for each of the data items.
	/// </summary>
	public class GuiRepeaterControl : GuiControl, IDataContainer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GuiRepeaterControl"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public GuiRepeaterControl(BlackbirdGame game)
			: base(game)
		{ }

		/// <summary>
		/// Gets or sets the face id.
		/// </summary>
		/// <value>The face id.</value>
		public GuiValue<string> FaceId { get; private set; }

		/// <summary>
		/// Gets the data source.
		/// </summary>
		public GuiValue<IEnumerable> DataSource { get; private set; }

		/// <summary>
		/// Gets or sets the child X coordinate.
		/// </summary>
		/// <value>The child X coordinate.</value>
		public GuiValue<int> ChildOffsetX { get; private set; }

		/// <summary>
		/// Gets or sets the child Y coordinate.
		/// </summary>
		/// <value>The child Y coordinate.</value>
		public GuiValue<int> ChildOffsetY { get; private set; }

		/// <summary>
		/// Gets the current index in the data source.
		/// </summary>
		/// <value>
		/// The current index in the data source.
		/// </value>
		public int DataIndex { get; private set; }

		/// <summary>
		/// Gets the data item.
		/// </summary>
		public object DataItem { get; private set; }

		/// <summary>
		/// Renders this control.
		/// </summary>
		/// <param name="offsetX">The X offset.</param>
		/// <param name="offsetY">The Y offset.</param>
		public override void RenderControl(int offsetX, int offsetY)
		{
			if (this.FaceId.HasValue && this.DataSource.HasValue)
			{
				GuiFace face = Game.GuiManager.GetFace(this.FaceId.Value);

				DataIndex = 0;

				foreach (var dataItem in this.DataSource.Value)
				{
					DataItem = dataItem;

					// Note that ChildOffsetX is usually a data bound and would be called with a different DataItem each time - exactly the way we want it.
					face.Render(offsetX + X.GetValueOrDefault(0) + ChildOffsetX.GetValueOrDefault(0), offsetY + Y.GetValueOrDefault(0) + ChildOffsetY.GetValueOrDefault(0));

					DataIndex++;
				}

				DataItem = null;
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

			this.FaceId = GuiValue<string>.Parse(Game, element.GetAttribute("faceId"), this);
			this.DataSource = GuiValue<IEnumerable>.Parse(Game, element.GetAttribute("dataSource"), this);
			this.ChildOffsetX = GuiValue<int>.Parse(Game, element.GetAttributeOrNull("childOffsetX"), this);
			this.ChildOffsetY = GuiValue<int>.Parse(Game, element.GetAttributeOrNull("childOffsetY"), this);
		}
	}
}
