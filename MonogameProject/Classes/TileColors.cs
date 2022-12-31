using Microsoft.Xna.Framework;
using MonogameProject.Interfaces;
using System;


namespace MonogameProject.Classes
{
    internal class TileColors : ITileColorProvider
    {
        private static double timer = 0;
        private static DateTime previousTime;
        private static readonly double interval = 3.0;
        private static readonly Color[] colors = { Color.LightPink, Color.LightGreen, Color.LightBlue, Color.LightYellow };
        private static int currentColor = 0;

        public Color GetColor()
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan elapsedTime = currentTime - previousTime;
            previousTime = currentTime;
            timer += elapsedTime.TotalSeconds;
            if (timer >= interval)
            {
                timer = 0;
                currentColor = (currentColor + 1) % colors.Length; 
            }
            float colorAmount = (float)(Math.Abs(Math.Sin(timer / interval * Math.PI)));
            return Color.Lerp(Color.White, colors[currentColor], colorAmount);
        }
    }
}

