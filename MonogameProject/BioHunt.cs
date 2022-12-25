
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameProject.Classes.Levels;
using MonogameProject.Collision;

using System.Diagnostics;



namespace MonogameProject
{
    public class BioHunt : Game
    {
        Rectangle mouseRectangle;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        CollisionManager collision;
        MainMenu mainMenu;
        Death death;
        Win win;


        level1 level1;
        level2 level2;
        level3 level3;
        SpriteFont tekst;
        public LevelStates LevelStates = LevelStates.Level1;
        public int screenWidth = 1790, screenHeight = 703;
        public int Screenwidth
        {
            get { return screenWidth; }
        }
        Texture2D ghostTexture;
        Texture2D mouseTexture;
        GraphicsDevice grap;
        Texture2D coinTexture;
        Texture2D ufoTexture;
        Texture2D portalTexture;
        Texture2D healthTexture;
        Texture2D fishTexture;
        Texture2D bossTexture;
        Texture2D lavaBallTexture;
        Texture2D playerTexture;
        Texture2D fireballImage;

        private static BioHunt instance;

        public static BioHunt Instance
        {
            get
            {
                if (instance == null)
                    instance = new BioHunt();

                return instance;
            }
        }
        public BioHunt()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            fireballImage = Content.Load<Texture2D>("Fireball");
            ufoTexture = Content.Load<Texture2D>("Pixel_Ufo");
            portalTexture = Content.Load<Texture2D>("Portal");
            ghostTexture = Content.Load<Texture2D>("SpookBeweging");
            coinTexture = Content.Load<Texture2D>("CoinMovement2");
            playerTexture = Content.Load<Texture2D>("VerbeterigSpeler2");
            fireballImage = Content.Load<Texture2D>("Fireball");
            tekst = Content.Load<SpriteFont>("File");
            lavaBallTexture = Content.Load<Texture2D>("Lava_Ball2");
            fishTexture = Content.Load<Texture2D>("FishmonsterMovement4");
            bossTexture = Content.Load<Texture2D>("BossMonsterMovement2");

           
            mainMenu = new MainMenu(this); // this zorgt ervoor dat quit button werkt, is instance;
            death = new Death(this);
            win = new Win(this);
         
                level1 = new level1(ufoTexture, portalTexture, ghostTexture, coinTexture, playerTexture, fireballImage, tekst, this);
           
                level2 = new level2(portalTexture, coinTexture, playerTexture, fireballImage, tekst, lavaBallTexture, fishTexture, this);
        
                level3 = new level3(healthTexture, bossTexture, playerTexture, fireballImage, coinTexture, tekst, this);
            collision = new CollisionManager(this);
            //hier moeten de levels, BOVEN base.initialize
            base.Initialize();
        }

        protected override void LoadContent()
        {
            IsMouseVisible = true;
            mouseTexture = new Texture2D(GraphicsDevice, 1, 1);
            mouseTexture.SetData(new[] { Color.White });
            mainMenu.Load(Content, GraphicsDevice);
            death.Load(Content, GraphicsDevice);
            win.Load(Content, GraphicsDevice);
            level1.Load(Content);
         
                level2.Load(Content);
     
                level3.Load(Content);
          
            healthTexture = Content.Load<Texture2D>("HealthBar");
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _graphics.PreferredBackBufferHeight = screenHeight;
            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.ApplyChanges();
            grap = GraphicsDevice;
            screenWidth = grap.PresentationParameters.BackBufferWidth;
            screenHeight = grap.PresentationParameters.BackBufferHeight;
            Tiles.Tiles.Content = Content;
            IsMouseVisible = true;
        }
        protected override void Update(GameTime gameTime)
        {
            Debug.WriteLine(gameTime.TotalGameTime);
            MouseState mouse = Mouse.GetState();
            Debug.WriteLine(mouse.Position);
          
            mouseRectangle = new Rectangle(mouse.X, mouse.Y, 5, 5);
            if (LevelStates == LevelStates.MainMenu)
                mainMenu.Update(gameTime);
            if (LevelStates == LevelStates.Death)
                death.Update(gameTime);
            if (LevelStates == LevelStates.Win)
                win.Update(gameTime);
            LevelStates = mainMenu.LevelStates;


            collision.level1 = level1;
            level1.Update(gameTime);
            collision.level2 = level2;
            level2.Update(gameTime);
            collision.level3 = level3;
            level3.Update(gameTime);

              
            collision.Update(gameTime);
            //LevelStates = collision.LevelStates;


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkViolet);
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null);
            switch (LevelStates)
            {
                case LevelStates.MainMenu:
                    mainMenu.Draw(_spriteBatch);
                    break;
                case LevelStates.Level1:
                    level1.Draw(_spriteBatch); //hier
                    break;
                case LevelStates.Level2:
                    level2.Draw(_spriteBatch);
                    break;
                case LevelStates.Level3:
                    level3.Draw(_spriteBatch);
                    break;
                case LevelStates.Win:
                    win.Draw(_spriteBatch);
                    break;
                case LevelStates.Death:
                    death.Draw(_spriteBatch);
                    break;
            }
            _spriteBatch.Draw(mouseTexture, mouseRectangle, Color.Red);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}