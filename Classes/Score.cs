using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject.Classes
{
    internal class Score 
    {

        public SpriteFont tekst;
        public static int score = 0;
        public void ScoreUp()
        {
            score++;
        }
        public Score(SpriteFont tekst)
        {
            this.tekst = tekst;
           
        }
    
        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.DrawString(tekst, "Score: " + score, new Vector2(Game1.Instance.screenWidth - 350, 10), Color.White);
        }

     
    }
}
