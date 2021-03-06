﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.Blackbird.Core.Gui.Controls;
using System.Threading;

namespace Teraluwide.Blackbird.Core.ScriptingSupport
{
	public class GuiEventReference<T> : ILateMethodBinder
	{
		/// <summary>
		/// Gets or sets the game.
		/// </summary>
		/// <value>The game.</value>
		protected BlackbirdGame Game { get; private set; }

		private GuiControl sender;
		private string methodName;

		/// <summary>
		/// Initializes a new instance of the <see cref="GuiEventReference&lt;T&gt;"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public GuiEventReference(BlackbirdGame game, GuiControl sender)
		{
			this.Game = game;
			this.sender = sender;
		}

		private GuiControlEventDelegate<T> eventDelegate;

		/// <summary>
		/// Gets a value indicating whether this event reference is bound to a method.
		/// </summary>
		/// <value><c>true</c> if this event reference is bound; otherwise, <c>false</c>.</value>
		public bool IsBound
		{
			get
			{
				return eventDelegate != null;
			}
		}

		/// <summary>
		/// Binds the specified method.
		/// </summary>
		/// <param name="method">The method.</param>
		public void BindMethod(GuiControlEventDelegate<T> method)
		{
			this.eventDelegate = method;
		}

		/// <summary>
		/// Invokes the specified event.
		/// </summary>
		/// <param name="e">The event argument.</param>
		public void Invoke(T e)
		{
			if (!IsBound)
				return;

			if (sender == null)
				eventDelegate(GuiControl.Current, e);
			else
				eventDelegate(sender, e);
		}

		public static GuiEventReference<T> Parse(BlackbirdGame game, string inputString, GuiControl sender)
		{
			// A null event reference. Is not method bound so it will not be called.
			if (inputString == null || inputString == "$null")
				return new GuiEventReference<T>(game, sender);

			// Inline event (lambda-like syntax).
			if (inputString.StartsWith("("))
			{
				GuiEventReference<T> reference = new GuiEventReference<T>(game, sender);
				reference.methodName = "__L" + GuiEventReferenceUniqueIndex.GetNewIndex().ToString("X4");
				string code = inputString;
				string typeName = "global::" + typeof(GuiControlEventDelegate<>).Namespace + ".GuiControlEventDelegate<global::" + typeof(T).FullName + ">";
				string senderId = "EmptySenderId";
				if (sender != null && sender.Id.HasValue)
					senderId = sender.Id.Value;

				reference.IsInline = true;

				game.ScriptManager.RegisterInlineMethod(string.Format("\r\n#line 1 \"gc:{3}\" \r\nprivate {0} {1}(global::Teraluwide.Blackbird.Core.Gui.Controls.GuiControl sender) {{ return {2}; }}", typeName, reference.methodName, code, senderId), reference);

				return reference;
			}
			// Late-bound to a script method.
			else
			{
				GuiEventReference<T> reference = new GuiEventReference<T>(game, sender);
				reference.methodName = inputString;
				reference.IsInline = false;
				game.ScriptManager.RegisterLateBinder(reference);

				return reference;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether the event handler is an inline event reference.
		/// </summary>
		/// <value><c>true</c> if this instance is inline; otherwise, <c>false</c>.</value>
		protected bool IsInline
		{
			get;
			private set;
		}

		#region ILateMethodBinder Members

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
			get { return IsInline ? typeof(GuiEventLambdaBinderDelegate<T>) : typeof(GuiControlEventDelegate<T>); }
		}

		/// <summary>
		/// Binds the specified method delegate.
		/// </summary>
		/// <param name="method">The method delegate.</param>
		public void BindMethod(Delegate method)
		{
			if (IsInline)
				this.BindMethod((method as GuiEventLambdaBinderDelegate<T>)(sender));
			else
				this.BindMethod(method as GuiControlEventDelegate<T>);
		}

		#endregion
	}

	/// <summary>
	/// A helper class to maintain unique indices over the various generic variations of the GuiEventReference`1 class.
	/// </summary>
	internal class GuiEventReferenceUniqueIndex
	{
		static int uniqueIndex;

		/// <summary>
		/// Gets a new unique index.
		/// </summary>
		/// <returns></returns>
		public static int GetNewIndex()
		{
			return Interlocked.Increment(ref uniqueIndex);
		}
	}
}
