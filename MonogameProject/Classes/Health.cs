using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Classes.Hero;

using System.Collections.Generic;


namespace MonogameProject.Classes
{
    internal class Health
    {
        private Texture2D heart;
        public static List<Texture2D> amountOfHealth;

        public Health() { }
        public void Load(ContentManager Content)
        {
            amountOfHealth = new List<Texture2D>();
            for (int i = 0; i < Player.Instance.HeartRate; i++)
            {
                amountOfHealth.Add(heart);
            }
            heart = Content.Load<Texture2D>("Health1");
            if (Player.Instance.HeartRate != amountOfHealth.Count)
            {
                healthReduce();
            }
        }
        public void Update(GameTime gameTime)
        {
            
         
        }
        public void healthReduce()
        {
            amountOfHealth.RemoveAt(amountOfHealth.Count - 1);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < amountOfHealth.Count; i++)
            {
                    spriteBatch.Draw(heart, new Rectangle(i * 130, 0, 150, 100), Color.White);  
            }
        }
    }
}
