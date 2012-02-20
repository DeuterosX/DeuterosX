using System.Drawing;
using System;
using Teraluwide.Blackbird.Core;
using Teraluwide.DeuterosEx.DeuterosGame.Stations;

public partial class Core
{
	/// <summary>
	/// Changes the current gamescreen.
	/// </summary>
	/// <param name="newGamescreenId">The new gamescreen id.</param>
	public void ChangeGamescreen(string newGamescreenId)
	{
		// If the game screen is EarthCity, change the current station too
		if (newGamescreenId == "earthCity")
			ChangeCurrentStation("MilkyWay.Sol.Earth");

		Game.GameScreenManager.CurrentGameScreen = Game.GameScreenManager[newGamescreenId];
	}

	/// <summary>
	/// Changes the current station.
	/// </summary>
	/// <param name="newStationLocation">The new station location.</param>
	public void ChangeCurrentStation(string newStationLocation)
	{
		CurrentStationLocation = newStationLocation;

		Log.WriteMessage(string.Format("Station changed to {0}.", newStationLocation));
	}

	/// <summary>
	/// Gets the current station.
	/// </summary>
	public Station CurrentStation
	{
		get
		{
			return Game.StationManager.GetStation(CurrentStationLocation) as Station;
		}
	}

	/// <summary>
	/// Toggles whether the simulation is currently running.
	/// </summary>
	public void ToggleSimulationRunning()
	{
		Game.SimulationRunning = !Game.SimulationRunning;
	}

	public Color Animate(Color from, Color to, float interval, bool bounce)
	{
		float alpha = (float)Environment.TickCount / interval;
		alpha -= (float)Math.Floor(alpha);

		if (bounce)
			alpha = ((float)Math.Sin(alpha * Math.PI * 2) + 1) / 2;

		return Color.FromArgb((int)(to.A * alpha + from.A * (1 - alpha)), (int)(to.R * alpha + from.R * (1 - alpha)), (int)(to.G * alpha + from.G * (1 - alpha)), (int)(to.B * alpha + from.B * (1 - alpha)));
	}
}