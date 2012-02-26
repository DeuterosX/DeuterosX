using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teraluwide.Blackbird.Core.ScriptingSupport
{
	/// <summary>
	/// Represents a data container item.
	/// </summary>
	public interface IDataContainer
	{
		/// <summary>
		/// Gets the current index in the data source.
		/// </summary>
		/// <value>
		/// The current index in the data source.
		/// </value>
		int DataIndex { get; }

		/// <summary>
		/// Gets the current data item.
		/// </summary>
		object DataItem { get; }
	}
}
