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
 
    internal class Coin : IGameObject
    {
        public List<Rectangle> coins = new List<Rectangle>();
        Animation animation;
        private Texture2D coinImage;
        public Coin(Texture2D texture)
        {
            coinImage = texture;
            animation = new Animation();
            for (int i = 0; i < 4; i++) { animation.AddFrame(new AnimationFrame(new Rectangle(264 * i, 0, 264, 245))); }
        }
        public void AddCoin(Rectangle rect)
        {
            coins.Add(rect);
        }
        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i < coins.Count; i++)
            {
                spriteBatch.Draw(coinImage, coins[i], animation.CurrentFrame.SourceRectangle, Color.White);
            }
            
        }
    }
}
