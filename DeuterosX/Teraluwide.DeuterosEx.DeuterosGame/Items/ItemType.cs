using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teraluwide.DeuterosEx.DeuterosGame.Items
{
	public enum ItemType
	{
		Unknown = 0,
		/// <summary>
		/// Basic resources, like iron etc. Need no resources to be built.
		/// </summary>
		Mineral,
		/// <summary>
		/// Special item like the Derrick.
		/// </summary>
		Special,
		/// <summary>
		/// Used as a shuttle chassis.
		/// </summary>
		ShuttleChassis,
		/// <summary>
		/// Used as a shuttle drive.
		/// </summary>
		ShuttleDrive
	}
}
