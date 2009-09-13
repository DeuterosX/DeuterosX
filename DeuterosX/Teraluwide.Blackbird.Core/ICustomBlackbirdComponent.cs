using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teraluwide.Blackbird.Core
{
	/// <summary>
	/// Represents a custom Blackbird Engine component.
	/// </summary>
	public interface ICustomBlackbirdComponent : IBlackbirdComponent
	{
		/// <summary>
		/// Gets the unique identifier of this custom component.
		/// </summary>
		/// <value>The unique identifier of this custom component.</value>
		string Id { get; }
	}
}
