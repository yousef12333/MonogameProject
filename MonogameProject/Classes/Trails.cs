using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject.Classes
{

    internal class Trails
    {
        public List<Vector2> previousPositions = new List<Vector2>();
        public int maxTrails = 3;
        public int trailDelay = 5;
        public int trailDelayCounter = 0;
        public void Update(GameTime gameTime, Rectangle rectangle)
        {
            trailDelayCounter++;
            if (trailDelayCounter >= trailDelay)
            {
                previousPositions.Add(new Vector2(rectangle.X, rectangle.Y));
                trailDelayCounter = 0;
            }
            if (previousPositions.Count > maxTrails)
            {
                previousPositions.RemoveAt(0);
            }
        }
    }
}
