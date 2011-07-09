using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teraluwide.Blackbird.Core.ScriptingSupport
{
	/// <summary>
	/// Represents a variable value.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class GuiVariableValue<T> : GuiValue<T>
	{
		string variableName;

		/// <summary>
		/// Initializes a new instance of the <see cref="GuiVariableValue`1"/> class.
		/// </summary>
		/// <param name="variableName">Name of the variable.</param>
		public GuiVariableValue(BlackbirdGame game, string variableName) 
			: base(game)
		{
			this.variableName = variableName;
		}

		/// <summary>
		/// Gets a value indicating whether this instance has value.
		/// </summary>
		/// <value><c>true</c> if this instance has value; otherwise, <c>false</c>.</value>
		public override bool HasValue
		{
			get { return Game.VariableManager.HasVariable(this.variableName); }
		}

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>The value.</value>
		public override T Value
		{
			get
			{
				return Game.VariableManager.GetVariable<T>(this.variableName);
			}
			set
			{
				Game.VariableManager.SetVariable(this.variableName, value);
			}
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return string.Format("Variable: {0}", HasValue ? string.Format("{0}", Value) : "NULL");
		}
	}
}
