using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teraluwide.Blackbird.Core.ScriptingSupport
{
	/// <summary>
	/// Represents a variable in the engine.
	/// </summary>
	public class GameVariable<T> : IGameVariable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GameVariable&lt;T&gt;"/> class.
		/// </summary>
		public GameVariable()
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GameVariable&lt;T&gt;"/> class.
		/// </summary>
		/// <param name="value">The value.</param>
		public GameVariable(T value)
			: this()
		{
			this.value = value;
		}

		T value;

		/// <summary>
		/// Gets or sets the current value of this variable.
		/// </summary>
		/// <value>The value.</value>
		public T Value { get { return this.value; } set { this.value = value; } }

		#region IGameVariable Members

		/// <summary>
		/// Loads the variable from the specified savegame Xml element.
		/// </summary>
		/// <param name="el">The Xml element.</param>
		/// <param name="currentFileName">Name of the current file.</param>
		public void LoadXml(System.Xml.XmlElement el)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Saves the variable to the specified savegame Xml element.
		/// </summary>
		/// <param name="el">The Xml element.</param>
		/// <param name="currentFileName">Name of the current file.</param>
		public void SaveXml(System.Xml.XmlElement el)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
