using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using MonogameProject.Classes.Hero;

namespace MonogameProject.Classes.Levels
{
    internal class Death
    {
        DeathButtons restart;
        Rectangle mouseRectangle;
        Texture2D deathBackground;
        private BioHunt game;
        private static Death instance;

        public static Death Instance
        {
            get
            {
                if (instance == null)
                    instance = new Death();

                return instance;
            }
        }
        public Death(BioHunt game)
        {
            this.game = game;
        }

        public void Load(ContentManager Content, GraphicsDevice graphics)
        {
            restart = new DeathButtons(Content.Load<Texture2D>("Restart_Button"), graphics);
            deathBackground = Content.Load<Texture2D>("Death_Screen");
            restart.setPosition(new Vector2((game.screenWidth / 2) - 100, 250));
        }
        public void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            mouseRectangle = new Rectangle(mouse.X, mouse.Y, 5, 5);
            restart.Update(mouse);
            if (restart.isRestarted == true)
            {
                gameTime.TotalGameTime = TimeSpan.Zero;
                MainMenu.Instance.btnPlay.isClicked = false; //instance error                                                      hier hier hier
                game.LevelStates = LevelStates.Level1; //bug, bij hoverout gaat het steeds terug van menu naar death



                Player.Instance.timer = 0; //werkt gewoon, komt door knop bug, hij blijft 0 als je ingedrukt houdt en als je loslaat wordt het 2,3,4.. zie debug.writeline
                                           //ufo.timer = 0;



                Player.Instance.restarted = true;
                Ufo.Instance.restarted = true;

            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(deathBackground, new Rectangle(0, 0, game.screenWidth + 80, game.screenHeight), Color.White);
            restart.Draw(spriteBatch);
        }
        public Death()
        {

        }
    }
}
