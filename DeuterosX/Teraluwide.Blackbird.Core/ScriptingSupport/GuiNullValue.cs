using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teraluwide.Blackbird.Core.ScriptingSupport
{
	/// <summary>
	/// Represents an empty value.
	/// </summary>
	/// <typeparam name="T">The type of the value.</typeparam>
	public class GuiNullValue<T> : GuiValue<T>
	{
		/// <summary>
		/// Gets a value indicating whether this instance has value.
		/// </summary>
		/// <value><c>true</c> if this instance has value; otherwise, <c>false</c>.</value>
		public override bool HasValue
		{
			get { return false; }
		}

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>The value.</value>
		public override T Value
		{
			get
			{
				return default(T);
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GuiNullValue&lt;T&gt;"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public GuiNullValue(BlackbirdGame game)
			: base(game)
		{	}
	}
}
