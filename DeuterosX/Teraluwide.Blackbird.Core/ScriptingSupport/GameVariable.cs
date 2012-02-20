using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

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
		public GameVariable(T value, bool isPersistent)
			: this()
		{
			this.value = value;
			this.isPersistent = isPersistent;
		}

		T value;

		/// <summary>
		/// Gets or sets the current value of this variable.
		/// </summary>
		/// <value>The value.</value>
		public T Value { get { return this.value; } set { this.value = value; } }

		bool isPersistent;
		/// <summary>
		/// Gets or sets a value indicating whether this variable should be stored in the savegame.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is persistent; otherwise, <c>false</c>.
		/// </value>
		public bool IsPersistent { get { return this.isPersistent; } set { this.isPersistent = value; } }

		#region IGameVariable Members

		/// <summary>
		/// Loads the variable from the specified savegame Xml element.
		/// </summary>
		/// <param name="el">The Xml element.</param>
		/// <param name="currentFileName">Name of the current file.</param>
		public void LoadXml(XmlElement el)
		{
			this.value = el.InnerText == "$null" ? default(T) : XmlHelper.Parse<T>(el.InnerText);
		}

		/// <summary>
		/// Saves the variable to the specified savegame Xml element.
		/// </summary>
		/// <param name="el">The Xml element.</param>
		/// <param name="currentFileName">Name of the current file.</param>
		public void SaveXml(XmlElement el)
		{
			if (Activator.ReferenceEquals(this.value, null) || this.value.Equals(default(T)))
				el.InnerText = "$null";
			else
				el.InnerText = string.Format("{0}", this.value);
		}

		#endregion
	}
}
