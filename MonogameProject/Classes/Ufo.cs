using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Classes.Hero;
using MonogameProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Deze klasse houdt zich aan het Singleton design pattern omdat er slechts één instantie van de klasse kan worden aangemaakt. 
 
 */

namespace MonogameProject.Classes
{
    internal class Ufo : IGameObject
    {

        private readonly Texture2D ufoImage;
        private Rectangle ufoRectangle = new Rectangle(80, 200, 300, 65);
        private Vector2 velocity = new Vector2(0, 0);
        private bool restarted;
        public bool levelLoaded;

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
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ufoImage, ufoRectangle, Color.White);
        }
    }
}
