using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Teraluwide.Blackbird.Core.ScriptingSupport
{
	/// <summary>
	/// Represents an engine variable.
	/// </summary>
	public interface IGameVariable
	{
		/// <summary>
		/// Loads the variable from the specified savegame Xml element.
		/// </summary>
		/// <param name="el">The Xml element.</param>
		/// <param name="currentFileName">Name of the current file.</param>
		void LoadXml(XmlElement el);

		/// <summary>
		/// Saves the variable to the specified savegame Xml element.
		/// </summary>
		/// <param name="el">The Xml element.</param>
		/// <param name="currentFileName">Name of the current file.</param>
		void SaveXml(XmlElement el);

		/// <summary>
		/// Gets or sets a value indicating whether this variable should be stored in the savegame.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is persistent; otherwise, <c>false</c>.
		/// </value>
		bool IsPersistent { get; set; }
	}
}
