using System.Drawing;
using System;

public partial class Core
{
	/// <summary>
	/// Changes the current gamescreen.
	/// </summary>
	/// <param name="newGamescreenId">The new gamescreen id.</param>
	public void ChangeGamescreen(string newGamescreenId)
	{
		Game.GameScreenManager.CurrentGameScreen = Game.GameScreenManager[newGamescreenId];
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