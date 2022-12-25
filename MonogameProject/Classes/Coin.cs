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
    /*SRP: deze klasse houdt zich aan de single responsibility principe omdat het slechts één hoofdverantwoordelijkheid heeft, 
     * namelijk het maken en weergeven van munten in het spel. Het heeft geen andere verantwoordelijkheden, zoals het verwerken van gebruikersinvoer of het 
     * beheren van de score van het spel. Alle methoden zijn gerelateerd aan zijn enige verantwoordelijkheid om munten te beheren, 
     * waaronder de methode AddCoin voor het toevoegen van munten aan het spel, de methode Update voor het bijwerken van de animatie van de munt, 
     * en de methode Draw voor het weergeven van de munten op het scherm.
   */
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
