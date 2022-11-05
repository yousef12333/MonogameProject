using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Interfaces;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject.Classes.Enemies
{
    internal class LavaBall :IGameObject
    {
        Vector2 lavaBallPosition = new Vector2(470, 0);
        Vector2 lavaBallPosition2 = new Vector2(670, 400);
        Vector2 velocity = new Vector2(0, 9);
        Vector2 velocity2 = new Vector2(0, 9);
        public Texture2D lavaBall;
        public Rectangle rectangle;
        public Rectangle rectangle2;

        //verwijder dubbels en maak het object oriented, dus zorg gewoon voor dat ht in game1 met juiste waarden er 2 kunnen staan.


        public Rectangle Rectangle
        {
            get
            {
                return rectangle;
            }

        }
        public Rectangle Rectangle2
        {
            get
            {
                return rectangle2;
            }

        }

        public Vector2 Position
        {
            get
            {
                return lavaBallPosition;
            }

        }
        public Vector2 Position2
        {
            get
            {
                return lavaBallPosition2;
            }

        }

        public LavaBall(Texture2D texture)
        {

            lavaBall = texture;

        }
        public void Update(GameTime gameTime)
        {
            move();
        }
        private void move()
        {

            lavaBallPosition.Y += velocity.Y;
            lavaBallPosition2.Y += velocity2.Y;


            if (lavaBallPosition.Y > 400)
            {
                velocity.Y = 9;
                velocity.Y *= -1;
               




            }
            else if(lavaBallPosition2.Y > 400)
            {
                velocity2.Y = 9;
                velocity2.Y *= -1;
            }
            velocity.Y += 0.10F;
            velocity2.Y += 0.10F;

            rectangle = new Rectangle((int)lavaBallPosition.X, (int)lavaBallPosition.Y, 80, 60);
            rectangle2 = new Rectangle((int)lavaBallPosition2.X, (int)lavaBallPosition2.Y, 80, 60);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(lavaBall, rectangle, Color.White);
            spriteBatch.Draw(lavaBall, rectangle2, Color.White);
        }
    }
}
