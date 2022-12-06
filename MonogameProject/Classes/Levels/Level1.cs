using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Classes.Hero;
using MonogameProject.Tiles;
using MonogameProject.Classes.Enemies;
using MonogameProject.Screen;
using MonogameProject.Collision;
using SharpDX.Direct3D9;
using static System.Net.Mime.MediaTypeNames;

namespace MonogameProject.Classes.Levels
{
    internal class Level1
    {
        BackgroundMusic music;
        //public Portal portal1;
        //Texture2D portalTexture;
        Ufo ufo;
        Texture2D ufoTexture;
        public bool objectInitialized = false;
        public Level1()//Texture2D texture
        {
         
            music = new BackgroundMusic();
            //portal1 = new Portal(texture); //vraag leerkracht
            ufo = new Ufo(ufoTexture);
        }



        private static Level1 instance;

        public static Level1 Instance
        {
            get
            {
                if (instance == null)
                    instance = new Level1();

                return instance;
            }
        }
        public void Load(ContentManager Content)
        {


            //portalTexture = Content.Load<Texture2D>("Portal");
            music.Load(Content);
            ufoTexture = Content.Load<Texture2D>("Pixel_Ufo");
        }
        public void Update(GameTime gameTime)
        {
            if (objectInitialized == false)
            {
                //portal1.AddPortal(new Rectangle(1150, 625, 128, 64));
                objectInitialized = true;
            }
           
            ufo.Update(gameTime);
            //portal1.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            
            music.Draw(spriteBatch);
            //portal1.Draw(spriteBatch);
            ufo.Draw(spriteBatch);
        }
    }
}
