using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Reflection.Metadata;
using Microsoft.VisualBasic.Devices;
using Mouse = Microsoft.Xna.Framework.Input.Mouse;
using MonogameProject.ViewStates;

namespace MonogameProject.Classes.Levels
{
    internal class MainMenu 
    {
        public DeathButton restart;
        public SpriteFont InputExplanation;
        public SpriteFont title;
        public SpriteFont titleEdge;
        public Texture2D backgroundMainMenu;
        public MenuButtons btnPlay;
        public GraphicsDevice GraphicsDevice;
    
       
        public void Load(ContentManager Content)
        {
            btnPlay = new MenuButtons(Content.Load<Texture2D>("Start_Button"), Content.Load<Texture2D>("Quit_Button"), GraphicsDevice);
            btnPlay.SetPosition(new Vector2(40, 200), new Vector2(40, 350));
            InputExplanation = Content.Load<SpriteFont>("Explanation");
            title = Content.Load<SpriteFont>("Title");
            titleEdge = Content.Load<SpriteFont>("TitleEdge");
            backgroundMainMenu = Content.Load<Texture2D>("MenuScreen2");
            

        }
            public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(backgroundMainMenu, new Rectangle(0, 0, BioHunt.Instance.screenWidth + 80, BioHunt.Instance.screenHeight), Color.White);
            btnPlay.Draw(spriteBatch);
            spriteBatch.DrawString(titleEdge, "BIOHUNT", new Vector2(565, 15), Color.Black);
            spriteBatch.DrawString(title, "BIOHUNT", new Vector2(550, 0), Color.DarkViolet);
            spriteBatch.DrawString(InputExplanation, "Controls:\n- Left button to go left.\n- Right button to go right\n- Space button to jump\n- \'E\' button to shoot fireball", new Vector2(40, 500), Color.DarkGreen);
        }

        public void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            btnPlay.Update(mouse);
            if (btnPlay.isClicked == true)
            {
                restart.isRestarted = false;

                BioHunt.Instance.LevelStates = LevelStates.Level1; //zet player op juiste positie samen met spaceship en reset timer


            }
            else if (btnPlay.isClosed == true) BioHunt.Instance.Exit();


            
        }
    }
}
