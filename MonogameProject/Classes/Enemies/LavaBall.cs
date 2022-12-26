using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Interfaces;
using System.Collections.Generic;

namespace MonogameProject.Classes.Enemies
{
    internal class LavaBall:IGameObject
    {
        public List<Vector2> lavaballList = new List<Vector2>();
        Vector2 velocity = new Vector2(0, 9);
        public Texture2D lavaBall;
        private Rectangle rectangle;
        public Rectangle Rectangle
        {
            get
            {
                return rectangle;
            }
        }
        public List<Vector2> previousPositions = new List<Vector2>();
        Trails trail;
        public void AddLavaball(Vector2 pos)
        {
            lavaballList.Add(pos);
        }
        public LavaBall(Texture2D texture)
        {
            trail = new Trails();
            trail.maxTrails = 6;
            trail.trailDelay = 7;
            trail.trailDelayCounter = 0;
            lavaBall = texture;
        }
        public void Update(GameTime gameTime)
        {
          
            move();
            trail.Update(gameTime, rectangle);
        }
        private void move()
        {
            for(int i = 0; i < lavaballList.Count; i++)
            {
                lavaballList[i] += new Vector2(0, velocity.Y);
                if (lavaballList[i].Y > 400)
                {
                    velocity.Y = 9;
                    velocity.Y *= -1;
                }
                velocity.Y += 0.10F;
                rectangle = new Rectangle((int)lavaballList[i].X, (int)lavaballList[i].Y, 80, 60);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < lavaballList.Count; i++){

                for (int j = 0; j < trail.previousPositions.Count; j++)
                {
                    spriteBatch.Draw(lavaBall, new Rectangle((int)trail.previousPositions[j].X, (int)trail.previousPositions[j].Y, 74, 74), Color.White * 0.5F);
                }
                spriteBatch.Draw(lavaBall, rectangle, Color.White);
            }
        }
    }
}
