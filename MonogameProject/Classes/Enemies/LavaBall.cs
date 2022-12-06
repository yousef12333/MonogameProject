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
        public void AddLavaball(Vector2 pos)
        {
            lavaballList.Add(pos);
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
            for (int i = 0; i < lavaballList.Count; i++){spriteBatch.Draw(lavaBall, rectangle, Color.White);}
        }
    }
}
