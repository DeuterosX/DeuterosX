using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.Blackbird.Core;

namespace Teraluwide.DeuterosEx.DeuterosGame.Stations
{
	/// <summary>
	/// Represents a generic station in game.
	/// </summary>
	public class Station : StationBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Station"/> class.
		/// </summary>
		/// <param name="game"></param>
		public Station(BlackbirdGame game)
			: base(game)
		{
			
		}
	}
}
