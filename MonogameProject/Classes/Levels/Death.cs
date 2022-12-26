using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using MonogameProject.Classes.Hero;
using MonogameProject.Screen;

namespace MonogameProject.Classes.Levels
{
    internal class Death
    {
        DeathButtons quit;
        Rectangle mouseRectangle;
        Texture2D deathBackground;
        private BioHunt game;
        private static Death instance;
        public MainMenu menu;
        public Score score;
        public ScoreUpdater scoreUpdater;
        public ScoreStorage scoreStorage;
        public static Death Instance
        {
            get
            {
                if (instance == null)
                    instance = new Death();

                return instance;
            }
        }
        public Death(BioHunt game, SpriteFont scoreTekst)
        {
            scoreUpdater = new ScoreUpdater(scoreStorage);
            scoreStorage = new ScoreStorage();
            score = new Score(scoreTekst, scoreStorage);
            this.game = game;
        }

        public void Load(ContentManager Content, GraphicsDevice graphics)
        {
            quit = new DeathButtons(Content.Load<Texture2D>("Quit_Button"), graphics);
            deathBackground = Content.Load<Texture2D>("Death_Screen");
            quit.setPosition(new Vector2((game.screenWidth / 2) - 100, 300));
        }
        public void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            mouseRectangle = new Rectangle(mouse.X, mouse.Y, 5, 5);
            quit.Update(mouse);
            if (quit.isRestarted == true) game.Exit();
        
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(deathBackground, new Rectangle(0, 0, game.screenWidth + 80, game.screenHeight), Color.White);
            score.Draw(spriteBatch, new Vector2((game.screenWidth /2)-110, 200));
            quit.Draw(spriteBatch);
        }
        public Death()
        {

        }
    }
}
