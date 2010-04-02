using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.Blackbird.Core.Properties;

namespace Teraluwide.Blackbird.Core
{
	/// <summary>
	/// Represents a friendly type information.
	/// </summary>
	public class TypeManagerItem
	{
		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		/// <value>The id.</value>
		public string Id { get; private set; }
	
		/// <summary>
		/// Gets or sets the assembly qualified name of this type.
		/// </summary>
		/// <value>The name of the assembly qualified.</value>
		public string AssemblyQualifiedName { get; private set; }

		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		/// <value>The type.</value>
		public Type Type { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="TypeManagerItem"/> class.
		/// </summary>
		/// <param name="id">The id.</param>
		/// <param name="assemblyQualifiedName">Name of the assembly qualified.</param>
		public TypeManagerItem(string id, string assemblyQualifiedName)
		{
			this.Id = id;
			this.AssemblyQualifiedName = assemblyQualifiedName;
			this.Type = Type.GetType(assemblyQualifiedName);

			if (this.Type == null)
				throw new BlackbirdException(string.Format(Resources.TypeNotFound, assemblyQualifiedName));
		}
	}
}
