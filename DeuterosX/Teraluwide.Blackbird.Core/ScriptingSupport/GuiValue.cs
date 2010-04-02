using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teraluwide.Blackbird.Core.ScriptingSupport
{
	/// <summary>
	/// Represents a value in the system.
	/// </summary>
	/// <typeparam name="T">The type of the value.</typeparam>
	public abstract class GuiValue<T>
	{
		/// <summary>
		/// Gets or sets the game.
		/// </summary>
		/// <value>The game.</value>
		protected BlackbirdGame Game { get; private set; }

		/// <summary>
		/// Gets a value indicating whether this instance has value.
		/// </summary>
		/// <value><c>true</c> if this instance has value; otherwise, <c>false</c>.</value>
		public abstract bool HasValue { get; }

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>The value.</value>
		public abstract T Value { get; set; }

		/// <summary>
		/// Gets the current value of this instance or <paramref cref="defaultValue" /> if this instance has no value.
		/// </summary>
		/// <param name="defaultValue">The default value.</param>
		/// <returns></returns>
		public virtual T GetValueOrDefault(T defaultValue)
		{
			if (HasValue)
				return Value;
			else
				return defaultValue;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GuiValue`1"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public GuiValue(BlackbirdGame game)
		{
			this.Game = game;
		}

		/// <summary>
		/// Parses the specified input string.
		/// </summary>
		/// <param name="inputString">The input string.</param>
		/// <returns></returns>
		public static GuiValue<T> Parse(BlackbirdGame game, string inputString)
		{
			if (inputString == null || inputString == "$null")
				return new GuiNullValue<T>(game);

			if (inputString.StartsWith("$"))
				return new GuiVariableValue<T>(game, inputString.Substring(1));
			else
				return new GuiConstantValue<T>(game, XmlHelper.Parse<T>(inputString));
		}
	}
}
