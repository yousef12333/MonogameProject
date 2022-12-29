using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Interfaces;
using System.Collections.Generic;

/*Deze klasse houdt zich aan het Singleton design pattern omdat er slechts één instantie van de klasse kan worden aangemaakt. 
 
 */

namespace MonogameProject.Classes
{
    internal class Ufo : IUpdatable, IDrawableClass
    {

        private readonly Texture2D ufoImage;
        private Rectangle ufoRectangle = new Rectangle(80, 200, 300, 65);
        private Vector2 velocity = new Vector2(0, 0);
        private bool restarted;
        public bool levelLoaded;
        public List<Vector2> previousPositions = new List<Vector2>();
        public const int maxTrails = 3;
        public const int trailDelay = 5;
        public int trailDelayCounter = 0;
        public Vector2 Velocity
        {
            get => velocity;
            set => velocity = value;
        }

        public Rectangle UfoRectangle
        {
            get => ufoRectangle;
            set => ufoRectangle = value;
        }

        public Ufo(Texture2D texture)
        {
            ufoImage = texture;
        }
       
        public void Update(GameTime gameTime)
        {
            ufoRectangle.X -= (int)velocity.X;

            if (restarted)
            {
                ufoRectangle = new Rectangle(80, 200, 300, 65);
                velocity = new Vector2(0, 0);
            }

            if (levelLoaded)
            {
                velocity.X = 6;
                restarted = false;
            }
            trailDelayCounter++;
            if (trailDelayCounter >= trailDelay)
            {
                previousPositions.Add(new Vector2(ufoRectangle.X, ufoRectangle.Y));
                trailDelayCounter = 0;
            }
            if (previousPositions.Count > maxTrails)
            {
                previousPositions.RemoveAt(0);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < previousPositions.Count; i++)
            {
                spriteBatch.Draw(ufoImage, new Rectangle((int)previousPositions[i].X, (int)previousPositions[i].Y, 300, 65), Color.White * 0.4F);
            }
            spriteBatch.Draw(ufoImage, ufoRectangle, Color.White);
        }
    }
}
/*ISP: gebruikt alleen draw en update of eventueel zelfgemaakte methoden, en de interfaces geven de draw en update methoden apart aan dit klasse*/
