using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teraluwide.Blackbird.Core.ScriptingSupport
{
	/// <summary>
	/// Represents a constant value.
	/// </summary>
	/// <typeparam name="T">The type of the value.</typeparam>
	public class GuiConstantValue<T> : GuiValue<T>
	{
		T value;

		/// <summary>
		/// Initializes a new instance of the <see cref="GuiConstantValue`1"/> class.
		/// </summary>
		/// <param name="value">The value.</param>
		public GuiConstantValue(BlackbirdGame game, T value)
			: base(game)
		{
			this.value = value;
		}

		/// <summary>
		/// Gets a value indicating whether this instance has value.
		/// </summary>
		/// <value><c>true</c> if this instance has value; otherwise, <c>false</c>.</value>
		public override bool HasValue
		{
			get { return true; }
		}

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>The value.</value>
		public override T Value
		{
			get
			{
				return this.value;
			}
			set
			{
				throw new NotSupportedException();
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
			return string.Format("Constant: {0}", HasValue ? string.Format("{0}", Value) : "NULL");
		}
	}
}
