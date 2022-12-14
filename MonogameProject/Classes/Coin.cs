using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Classes.Animations;
using MonogameProject.Interfaces;
using System.Collections.Generic;


namespace MonogameProject.Classes
{
    /*ISP: In dit geval implementeert de Coin class alleen de methoden die vereist zijn door de IDrawableClass interface, 
     * en implementeert geen andere methoden die hij niet nodig heeft.
     * De addcoin methode maakt deel uit van de Coin klasse en volgt dus nog altijd de ISP principe. 
   */
    internal class Coin : IDrawableClass
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
            for (int i = 0; i < coins.Count; i++)
            {
                spriteBatch.Draw(coinImage, coins[i], animation.CurrentFrame.SourceRectangle, Color.White);
            }
        }
    }
}
//Design pattern: Factory Pattern:
//1. Voorziet in AddCoin voor het creëren van een lijst van coins van het type Rectangle.
//2. Definieert een gemeenschappelijke interface (AddCoin) voor creatie objecten, anderen hoeven dan deze code alleen te gebruiken zonder details van implementatie te kennen.
