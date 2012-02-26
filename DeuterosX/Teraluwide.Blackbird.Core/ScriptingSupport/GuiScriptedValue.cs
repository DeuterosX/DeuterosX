using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Teraluwide.Blackbird.Core.Gui.Controls;
using System.Diagnostics;

namespace Teraluwide.Blackbird.Core.ScriptingSupport
{
	/// <summary>
	/// Represents a gui value resolved as an inline script method. At the moment only read-only values are supported.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class GuiScriptedValue<T> : GuiValue<T>, ILateMethodBinder
	{
		private string methodName;
		private GuiScriptedValueDelegate<T> cachedDelegate;
		private GuiScriptedDataBoundValueDelegate<T> cachedDataBoundDelegate;
		private GuiControl sender;
		private bool dataBound = false;

		/// <summary>
		/// Initializes a new instance of the <see cref="GuiScriptedValue&lt;T&gt;"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public GuiScriptedValue(BlackbirdGame game, string code, GuiControl sender)
			: base(game)
		{
			int idx = Interlocked.Increment(ref GuiScriptedValueUniqueIndex.uniqueIndex);
			// "global::" should make sure the type is right even when there are some name clashes (for example usings with an alias the same as a namespace etc.)
			string typeName = "global::" + typeof(T).FullName;
			this.methodName = "__" + GuiScriptedValueUniqueIndex.uniqueIndex.ToString("X4");
			this.sender = sender;
			string senderId = "EmptySenderId";
			if (sender != null && sender.Id.HasValue)
				senderId = sender.Id.Value;

			// NOTE: The generated code should perhaps be marked by the CompilerGenerated attribute?

			// Code only specifies the return value.
			if (code.StartsWith("="))
			{
				game.ScriptManager.RegisterInlineMethod(string.Format("\r\n#line 1 \"gc:{3}\" \r\nprivate {0} {1}(global::Teraluwide.Blackbird.Core.Gui.Controls.GuiControl sender) {{ return {2}; }}", typeName, methodName, code.Substring(1), senderId), this);
			}
			// Code is the whole method body including the return statement.
			else if (code.StartsWith("{"))
			{
				game.ScriptManager.RegisterInlineMethod(string.Format("\r\n#line 1 \"gc:{3}\" \r\nprivate {0} {1}(global::Teraluwide.Blackbird.Core.Gui.Controls.GuiControl sender) {2}", typeName, methodName, code, senderId), this);
			}
			// Code is data bound.
			else if (code.StartsWith("#{"))
			{
				dataBound = true;
				game.ScriptManager.RegisterInlineMethod(string.Format("\r\n#line 1 \"gc:{3}\" \r\nprivate {0} {1}(global::Teraluwide.Blackbird.Core.Gui.Controls.GuiControl sender, Teraluwide.Blackbird.Core.ScriptingSupport.IDataContainer container) {2}", typeName, methodName, code.Substring(1), senderId), this);
			}
			// Code is a data bound return value.
			else if (code.StartsWith("#="))
			{
				dataBound = true;
				game.ScriptManager.RegisterInlineMethod(string.Format("\r\n#line 1 \"gc:{3}\" \r\nprivate {0} {1}(global::Teraluwide.Blackbird.Core.Gui.Controls.GuiControl sender, Teraluwide.Blackbird.Core.ScriptingSupport.IDataContainer container) {{ return {2}; }}", typeName, methodName, code.Substring(2), senderId), this);
			}
		}

		/// <summary>
		/// Gets a value indicating whether this instance has value.
		/// </summary>
		/// <value><c>true</c> if this instance has value; otherwise, <c>false</c>.</value>
		public override bool HasValue
		{
			// NOTE: Perhaps the GuiScriptedValue should find out whether the method returns value somehow?
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
				Debug.Assert(cachedDelegate != null || cachedDataBoundDelegate != null);

				if (cachedDelegate != null)
				{
					// NOTE: Should probably have more "damage control".
					if (sender != null)
						return cachedDelegate(sender);
					else
					{
						// If we are rendering, try to find a GuiControl on top of this value.
						// HACK: Probably not very clean approach. Does anyone have a better idea to get this? GuiFaces are not instanced and their values are more or less fixed...
						return cachedDelegate(GuiControl.Current);
					}
				}
				else if (cachedDataBoundDelegate != null)
				{
					// Try to find the container
					IDataContainer container;
					if (sender != null && sender is IDataContainer)
						container = sender as IDataContainer;
					else
						container = GuiControl.DataContainer;

					// NOTE: Should probably have more "damage control".
					if (sender != null)
						return cachedDataBoundDelegate(sender, container);
					else
					{
						// If we are rendering, try to find a GuiControl on top of this value.
						// HACK: Probably not very clean approach. Does anyone have a better idea to get this? GuiFaces are not instanced and their values are more or less fixed...
						return cachedDataBoundDelegate(GuiControl.Current, container);
					}
				}
				else throw new Exception("GuiScriptedValue has an unbound delegate.");
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
			return string.Format("Scripted: {0}", HasValue ? string.Format("{0}", Value) : "NULL");
		}

		#region ILateMethodBinder Members
		/// <summary>
		/// Binds the specified method delegate.
		/// </summary>
		/// <param name="method">The method delegate.</param>
		public void BindMethod(Delegate method)
		{
			if (method is GuiScriptedValueDelegate<T>)
				this.cachedDelegate = method as GuiScriptedValueDelegate<T>;
			else if (method is GuiScriptedDataBoundValueDelegate<T>)
				this.cachedDataBoundDelegate = method as GuiScriptedDataBoundValueDelegate<T>;
		}


		/// <summary>
		/// Gets the name of the method to bind.
		/// </summary>
		/// <value>The name of the method.</value>
		public string MethodName
		{
			get { return this.methodName; }
		}

		/// <summary>
		/// Gets the type of the delegate.
		/// </summary>
		/// <value>The type of the delegate.</value>
		public Type DelegateType
		{
			get { return dataBound ? typeof(GuiScriptedDataBoundValueDelegate<T>) : typeof(GuiScriptedValueDelegate<T>); }
		}

		#endregion
	}

	internal static class GuiScriptedValueUniqueIndex
	{
		internal static int uniqueIndex;
	}
}
