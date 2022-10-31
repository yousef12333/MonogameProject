
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject
{
    internal class Textures
    {
        private Texture2D rock1;
        private Texture2D rock2;
        private Texture2D rock3;
        private Texture2D sign;
        private Texture2D lamp;
        private Texture2D coin;


        
    
        //Player Speler = new Player();
      

        public void Load(ContentManager Content)
        {
            
            rock1 = Content.Load<Texture2D>("rock_1");
            rock2 = Content.Load<Texture2D>("rock_2");
            rock3 = Content.Load<Texture2D>("rock_3");
            sign = Content.Load<Texture2D>("sign");
            lamp = Content.Load<Texture2D>("lamp");
            coin = Content.Load<Texture2D>("Coin");
            
           

        }

        public void Update(GameTime gameTime)
        {
           
            // if (Speler.rectangle.TouchTopOf(portal) || Speler.rectangle.TouchLeftOf(portal) || Speler.rectangle.TouchRightOf(portal) || Speler.rectangle.TouchBottomOf(portal))
            // {
            //     teleported = true;
            // }



        }
            public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(rock1, new Vector2(520, 502), Color.White);
            spriteBatch.Draw(rock2, new Vector2(720,437), Color.White);
            spriteBatch.Draw(rock3, new Vector2(900,303), Color.White);
            spriteBatch.Draw(sign, new Vector2(1120, 355), Color.White);
            spriteBatch.Draw(coin, new Rectangle(1030, 420, 32, 32), Color.White);
            spriteBatch.Draw(lamp, new Vector2(1300,328), Color.White);
            spriteBatch.Draw(coin, new Rectangle(1350, 352, 32, 32), Color.White);
            spriteBatch.Draw(coin, new Rectangle(1200, 385, 32, 32), Color.White);
            
            
            
        }
    }
}