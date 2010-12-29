using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlDotNet.Input;

namespace Teraluwide.Blackbird.Core.ScriptingSupport.EventArguments
{
	/// <summary>
	/// Represents the event argument of a mouse click event.
	/// </summary>
	public class MouseClickEventArgument : BlackbirdEventArgument
	{
		/// <summary>
		/// Gets or sets a value indicating whether the receiving control is a last control in the event chain.
		/// </summary>
		/// <value><c>true</c> if the receiving control is a last control in the event chain; otherwise, <c>false</c>.</value>
		public bool LastControl { get; set; }

		/// <summary>
		/// Gets or sets the X-coordinate of the mouse click.
		/// </summary>
		/// <value>The X-coordinate of the mouse click.</value>
		public int X { get; set; }

		/// <summary>
		/// Gets or sets the Y-coordinate of the mouse click.
		/// </summary>
		/// <value>The Y-coordinate of the mouse click.</value>
		public int Y { get; set; }

		/// <summary>
		/// Gets or sets the mouse button.
		/// </summary>
		/// <value>The mouse button.</value>
		public MouseButton MouseButton { get; set; }
	}
}
