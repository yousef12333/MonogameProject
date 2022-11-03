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
    internal class Ufo : IGameObject
    {
       
        private Texture2D ufoImage;
        private Rectangle ufoRectangle = new Rectangle(80, 200, 300, 65);
        private Vector2 velocity = new Vector2(0, 0);
        int timer;

        public Ufo(Texture2D texture)
        {
            ufoImage = texture;
        }
        public void Update(GameTime gameTime)
        {
            ufoRectangle.X -= (int)velocity.X;
           

            timer = (int)gameTime.TotalGameTime.TotalSeconds;
            if(timer > 3)
            {
                velocity.X = 6;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ufoImage, ufoRectangle, Color.White);
        }
    }
}
