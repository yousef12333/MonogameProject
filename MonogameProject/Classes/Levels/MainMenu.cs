using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameProject.Classes.Hero;

namespace MonogameProject.Classes.Levels
{
    internal class MainMenu 
    {

        public MenuButtons btnPlay;
        Texture2D menuScreen;
        public SpriteFont InputExplanation;
        public SpriteFont title;
        public SpriteFont titleEdge;
        public LevelStates LevelStates;
        private BioHunt game;

        public MainMenu(BioHunt game)
        {
            this.game = game;
        }

        public void ExitGame()
        {
            game.Exit();
        }

        private static MainMenu instance;
        public static MainMenu Instance
        {
            get
            {
                if (instance == null)
                    instance = new MainMenu();

                return instance;
            }
        }

        public void Load(ContentManager Content, GraphicsDevice graphics)
        {
            btnPlay = new MenuButtons(Content.Load<Texture2D>("Start_Button"), Content.Load<Texture2D>("Quit_Button"), graphics);
            btnPlay.SetPosition(new Vector2(40, 200), new Vector2(40, 350));
            menuScreen = Content.Load<Texture2D>("MenuScreen2");
            InputExplanation = Content.Load<SpriteFont>("Explanation");
            title = Content.Load<SpriteFont>("Title");
            titleEdge = Content.Load<SpriteFont>("TitleEdge");
        }
        public void Update(GameTime gameTime)
        {
           

            MouseState mouse = Mouse.GetState();
            btnPlay.Update(mouse);
            //-----------------------------------------
            if (btnPlay.isClicked == true)
            {
                DeathButtons.Instance.isRestarted = false;
               
                LevelStates = LevelStates.Level1; //zet player op juiste positie samen met spaceship en reset timer
                Player.Instance.restarted = true;


            }
            else if (btnPlay.isClosed == true) ExitGame(); // verwijder biohunt instance
           

            //-----------------------------------------------------------------------
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(menuScreen, new Rectangle(0, 0, 1840, 733), Color.White);
            btnPlay.Draw(spriteBatch);
            spriteBatch.DrawString(titleEdge, "BIOHUNT", new Vector2(565, 15), Color.Black);
            spriteBatch.DrawString(title, "BIOHUNT", new Vector2(550, 0), Color.DarkViolet);
            spriteBatch.DrawString(InputExplanation, "Controls:\n- Left button to go left.\n- Right button to go right\n- Space button to jump\n- \'E\' button to shoot fireball", new Vector2(40, 500), Color.DarkGreen);
        }
        public MainMenu()
        {

        }
    }
}
