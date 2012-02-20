using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.Blackbird.Core;

namespace Teraluwide.DeuterosEx.DeuterosGame.Stations
{
	/// <summary>
	/// Represents a generic station in the game.
	/// </summary>
	public class Station : StationBase
	{
		/// <summary>
		/// Gets the mining store.
		/// </summary>
		public MiningStoreStationModule MiningStore { get; private set; }

		/// <summary>
		/// Gets the mining facility.
		/// </summary>
		public MiningFacilityStationModule MiningFacility { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Station"/> class.
		/// </summary>
		/// <param name="game"></param>
		public Station(BlackbirdGame game)
			: base(game)
		{
			
		}

		/// <summary>
		/// Performs all that is needed to build the station (ie. create all the default modules etc.).
		/// </summary>
		public override void Build()
		{
			base.Build();

			MountModule(new MiningStoreStationModule(Game));
			MountModule(new MiningFacilityStationModule(Game));
		}

		/// <summary>
		/// Mounts a new module to the station
		/// </summary>
		/// <param name="module">Station module to mount</param>
		/// <returns>
		/// Negative if error. If successful, returns the module index.
		/// </returns>
		public override int MountModule(StationModuleBase module)
		{
			int ret = base.MountModule(module);

			if (ret >= 0)
			{
				if (module is MiningStoreStationModule)
					this.MiningStore = module as MiningStoreStationModule;
				else if (module is MiningFacilityStationModule)
					this.MiningFacility = module as MiningFacilityStationModule;
			}

			return ret;
		}
	}
}
