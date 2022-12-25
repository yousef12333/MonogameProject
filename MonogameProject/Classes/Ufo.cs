using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Classes.Hero;
using MonogameProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Deze klasse houdt zich aan het Singleton design pattern omdat er slechts één instantie van de klasse kan worden aangemaakt. 
 * Het volgt het Single Responsibility Principle door alleen methoden te bevatten die gerelateerd zijn aan het Ufo game object, zoals update en draw.*/

namespace MonogameProject.Classes
{
    internal class Ufo : IGameObject
    {
       
        private Texture2D ufoImage;
        private Rectangle ufoRectangle = new Rectangle(80, 200, 300, 65);
        public Vector2 velocity = new Vector2(0, 0);
        public int timer;
        public bool restarted;
        public bool levelLoaded = false;
        public Vector2 Velocity
        {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
            }
        }
        public Rectangle UfoRectangle
        {
            get
            {
                return ufoRectangle;
            }
            set
            {
                ufoRectangle = value;
            }
        }
        private static Ufo instance;
        public static Ufo Instance
        {
            get
            {
                if (instance == null)
                    instance = new Ufo();

                return instance;
            }
        }
        public Ufo(Texture2D texture)
        {
            ufoImage = texture;
           
        }
        public void Update(GameTime gameTime)
        {
            ufoRectangle.X -= (int)velocity.X;
           if(restarted == true)
            {
                UfoRectangle = new Rectangle(80, 200, 300, 65);
                Velocity = new Vector2(0, 0);
            }

  
            if(levelLoaded)
            {
                velocity.X = 6;
                restarted = false;  
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ufoImage, ufoRectangle, Color.White);
        }
        public Ufo()
        {
        }
    }
}
