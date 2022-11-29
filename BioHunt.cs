using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameProject.Classes.Levels;
using MonogameProject.Collision;
using MonogameProject.Screen;
using System.Diagnostics;
namespace MonogameProject
{
    public class BioHunt : Game
    {
        Rectangle mouseRectangle;
        Texture2D mouseTexture;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public LevelStates LevelStates = LevelStates.MainMenu;
        MainMenu mainMenu;
        Level1 level1;
        Level2 level2;
        Level3 level3;
        public GraphicsDevice grap;
        Death death;
        Win win;
        CollisionManager collision;
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
        }
        protected override void Initialize()
        {
            mainMenu = new MainMenu();
            level1 = new Level1();
            level2 = new Level2();
            level3 = new Level3();
            death = new Death();
            win = new Win();
            collision = new CollisionManager();
            base.Initialize();
        }
        protected override void LoadContent()
        {
            mouseTexture = new Texture2D(GraphicsDevice, 1, 1);
            mouseTexture.SetData(new[] { Color.White });
            mainMenu = new MainMenu();
            death = new Death();
            win.Load(Content);
            death.Load(Content);
            mainMenu.Load(Content);
            level1.Load(Content);
            level2.Load(Content);
            level3.Load(Content);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _graphics.PreferredBackBufferHeight = ScreenSettings.Instance.screenHeight;
            _graphics.PreferredBackBufferWidth = ScreenSettings.Instance.screenWidth;
            _graphics.ApplyChanges();
            grap = GraphicsDevice;
            ScreenSettings.Instance.screenWidth = grap.PresentationParameters.BackBufferWidth;
            ScreenSettings.Instance.screenHeight = grap.PresentationParameters.BackBufferHeight;
            IsMouseVisible = true;
        }
        protected override void Update(GameTime gameTime)
        {
            Debug.WriteLine(gameTime.TotalGameTime);
            level1.Update(gameTime);
            level2.Update(gameTime);
            level3.Update(gameTime);
            MouseState mouse = Mouse.GetState();
            mouseRectangle = new Rectangle(mouse.X, mouse.Y, 5, 5);
            collision.Update(gameTime);
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
                    level1.Draw(_spriteBatch);
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
