using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teraluwide.Blackbird.Core.ScriptingSupport
{
	/// <summary>
	/// Represents a class which allows script engine method late binding.
	/// </summary>
	public interface ILateMethodBinder
	{
		/// <summary>
		/// Gets the name of the method to bind.
		/// </summary>
		/// <value>The name of the method.</value>
		string MethodName { get; }

		/// <summary>
		/// Gets the type of the delegate.
		/// </summary>
		/// <value>The type of the delegate.</value>
		Type DelegateType { get; }

		/// <summary>
		/// Binds the specified method delegate.
		/// </summary>
		/// <param name="method">The method delegate.</param>
		void BindMethod(Delegate method);
	}
}
