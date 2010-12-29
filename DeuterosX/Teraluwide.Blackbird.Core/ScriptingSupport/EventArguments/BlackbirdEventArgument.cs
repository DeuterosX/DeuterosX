using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teraluwide.Blackbird.Core.ScriptingSupport.EventArguments
{
	/// <summary>
	/// Represents a base class for all event arguments.
	/// </summary>
	public abstract class BlackbirdEventArgument
	{
		/// <summary>
		/// Gets or sets a value indicating whether the event should bubble down to child controls.
		/// </summary>
		/// <value><c>true</c> if the event should propagate down; otherwise, <c>false</c>.</value>
		public bool Bubble { get; set; }
	}
}
