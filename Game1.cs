using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameProject.Classes;
using MonogameProject.Classes.Enemies;
using MonogameProject.Classes.Hero;
using MonogameProject.Tiles;


using MonogameProject.ViewStates;

namespace MonogameProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public enum GameState { MainMenu, Death, Level1, Level2, Level3, Win }
        public GameState CurrentGameState = GameState.MainMenu;

        int screenWidth = 1790, screenHeight = 705;

        MenuButton btnPlay;
        Death restart;
        Texture2D ghostTexture;
        BackgroundMusic music;
        Health playerLife;
        WinButton winEindigKnop;
        private Texture2D backgroundje1;
        private Texture2D backgroundje2;
        private Texture2D backgroundje3;
        private Texture2D winScreen;
        GraphicsDevice grap;

        Map mapLevel1;
        Map mapLevel2;
        Map mapLevel3;


        Portal portalSprite;
        Texture2D portalTexture;

        Coin coinLevel1;
        Coin coinLevel2;
        Coin coinLevel3;
        Texture2D coinTexture;


   
        Ufo ufo;
        Texture2D ufoTexture;

        Texture2D healthTexture;
        Rectangle healthRectanglePlayer;
        Rectangle healthRectangleFish;
        Rectangle healthRectangleGhost;
        Rectangle healthRectangleBoss;
        Texture2D fishTexture;
        FishMonsterTrap fish;
        BossMonster boss;
        Texture2D bossTexture;
        GhostMonster spook;
        Texture2D lavaBallTexture;
        LavaBall lBall;
        Player player;
        Texture2D playerTexture;
        Texture2D fireballImage;
        Fireball fireball;
        bool levelLoaded = false;

        
        public SpriteFont tekst;
        public static int score = 0;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            fireballImage = Content.Load<Texture2D>("Fireball");
            backgroundje1 = Content.Load<Texture2D>("background");
            backgroundje2 = Content.Load<Texture2D>("Vulcanic_Background");
            backgroundje3 = Content.Load<Texture2D>("Castle_Background");
            winScreen = Content.Load<Texture2D>("Win_Background");
            ufoTexture = Content.Load<Texture2D>("Pixel_Ufo");
            music = new BackgroundMusic();
            mapLevel1 = new Map();
            mapLevel2 = new Map();
            mapLevel3 = new Map();
          
            
            playerLife = new Health();


            tekst = Content.Load<SpriteFont>("File");



            base.Initialize();
            spook = new GhostMonster(ghostTexture, 100);
            boss = new BossMonster(bossTexture, 200);
            lBall = new LavaBall(lavaBallTexture);
            fish = new FishMonsterTrap(fishTexture, 150);
            player = new Player(playerTexture, 100, fireballImage);
            portalSprite = new Portal(portalTexture);
            coinLevel1 = new Coin(coinTexture);
            coinLevel2 = new Coin(coinTexture);
            coinLevel3 = new Coin(coinTexture);
            ufo = new Ufo(ufoTexture);
        }

        protected override void LoadContent()
        {
            IsMouseVisible = true;
            spook = new GhostMonster(ghostTexture, 100);
            boss = new BossMonster(bossTexture, 250);
            ufo = new Ufo(ufoTexture);
            lBall = new LavaBall(lavaBallTexture);
            
            fish = new FishMonsterTrap(fishTexture, 150);
            player = new Player(playerTexture, 100, fireballImage);
            healthTexture = Content.Load<Texture2D>("HealthBar");
      
            playerTexture = Content.Load<Texture2D>("VerbeterigSpeler2");
            ghostTexture = Content.Load<Texture2D>("SpookBeweging");
            bossTexture = Content.Load<Texture2D>("BossMonsterMovement2");
            lavaBallTexture = Content.Load<Texture2D>("Lava_Ball2");
            fishTexture = Content.Load<Texture2D>("FishmonsterMovement4");
            portalTexture = Content.Load<Texture2D>("Portal");
            coinTexture = Content.Load<Texture2D>("CoinMovement2");
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _graphics.PreferredBackBufferHeight = screenHeight;
            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.ApplyChanges();
            grap = GraphicsDevice;
            screenWidth = grap.PresentationParameters.BackBufferWidth;
            screenHeight = grap.PresentationParameters.BackBufferHeight;
            Tiles.Tiles.Content = Content;
           

            btnPlay = new MenuButton(Content.Load<Texture2D>("Start_Button"), Content.Load<Texture2D>("Quit_Button"), GraphicsDevice);
            winEindigKnop = new WinButton(Content.Load<Texture2D>("Quit_Button"), GraphicsDevice);
            restart = new Death(Content.Load<Texture2D>("Restart_Button"), GraphicsDevice);

          
            
                mapLevel1.Generate(new int[,]
               {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 0, 0, 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2},
                { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 0, 0, 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2},
                { 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 2, 2, 2, 2, 2, 0, 0, 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2},
                { 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 2, 2, 2, 2, 2, 0, 0, 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2},

           }, 64);
            



            mapLevel2.Generate(new int[,]
           {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 6, 0, 0, 6, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 6, 7, 5, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 6, 6, 6, 6, 7, 7, 5, 5, 5, 5, 5, 5, 5, 5, 7, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 7, 7, 7, 7, 7, 7, 5, 5, 5, 5, 5, 5, 5, 5, 7, 0, 0, 0, 0, 0, 6, 6, 6, 6, 6, 6, 6, 6},
                { 7, 7, 7, 7, 7, 7, 5, 5, 5, 5, 5, 5, 5, 5, 7, 0, 0, 0, 0, 6, 7, 7, 7, 7, 7, 7, 7, 7},
                { 7, 7, 7, 7, 7, 7, 5, 5, 5, 5, 5, 5, 5, 5, 7, 0, 0, 6, 0, 0, 7, 7, 7, 7, 7, 7, 7, 7},
                { 7, 7, 7, 7, 7, 7, 5, 5, 5, 5, 5, 5, 5, 5, 7, 0, 0, 0, 0, 6, 7, 7, 7, 7, 7, 7, 7, 7},
                { 7, 7, 7, 7, 7, 7, 5, 5, 5, 5, 5, 5, 5, 5, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7},

           }, 64);

            
                  mapLevel3.Generate(new int[,]
              {
                { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                { 3, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 3},
                { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},

              }, 64);
              

            playerLife.Load(Content);
            IsMouseVisible = true;
            btnPlay.SetPosition(new Vector2(75, 300), new Vector2(75, 450));
            winEindigKnop.SetPosition(new Vector2(640, 450));
            restart.setPosition(new Vector2(620, 250));
            music.Load(Content);


        }


        protected override void Update(GameTime gameTime)
        {
            if(CurrentGameState == GameState.Level1) levelLoaded = true;
        
            
            MouseState mouse = Mouse.GetState();
            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);
            healthRectanglePlayer = new Rectangle(player.rectangle.X - 12, player.Rectangle.Y - 25, player.health, 15);
            healthRectangleGhost = new Rectangle(spook.rectangle.X - 10, spook.Rectangle.Y - 25, spook.health, 15);
            healthRectangleFish = new Rectangle(fish.rectangle.X - 2, fish.Rectangle.Y - 25, fish.health, 15);
            healthRectangleBoss = new Rectangle(boss.rectangle.X, boss.Rectangle.Y - 25, boss.health, 15);

            coinLevel1.AddCoin(new Rectangle(910, 290, 32, 32));
            coinLevel1.AddCoin(new Rectangle(1200, 600, 32, 32));
            coinLevel1.AddCoin(new Rectangle(1700, 355, 32, 32));

            coinLevel2.AddCoin(new Rectangle(1030, 420, 32, 32));
            coinLevel2.AddCoin(new Rectangle(1350, 352, 32, 32));
            coinLevel2.AddCoin(new Rectangle(1200, 385, 32, 32));

            coinLevel3.AddCoin(new Rectangle(1030, 420, 32, 32));
            coinLevel3.AddCoin(new Rectangle(1350, 352, 32, 32));
            coinLevel3.AddCoin(new Rectangle(1200, 385, 32, 32));

            // Perfect werkende collisie gedeelte, je hebt hier muis-onzin verwijderd, verkeerde afstand van collisie ligde aan muis lol
            if (player.rectangle.Intersects(spook.rectangle) || player.rectangle.Intersects(boss.rectangle) || player.rectangle.Intersects(fish.rectangle))
            {
                player.health -= 2;
            }
            // stel later een rectangle in fireball in, de x en y waarden moeten hetzelfde als bullet[i door te doen= rect.X = bullet[i].X enzo..

            //for (int i = 0; i < fireball.bullets.Count; i++)
            //{
            //    if (fireball.bullets[i].Intersects(boss.rectangle))
            //    {
            //        boss.health -= 10;
            //    }
            //}

            //else if (mouseRectangle.Intersects(player.rectangle))
            //{
            //    player.health -= 10;
            //}
            //else if (mouseRectangle.Intersects(fish.rectangle))
            //{
            //    fish.health -= 10;
            //}

            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    if (btnPlay.isClicked == true) { CurrentGameState = GameState.Level1; }
                    else if (btnPlay.isClosed == true) Exit();
                    btnPlay.Update(mouse);
                    break;


                case GameState.Level1:
                    if (Keyboard.GetState().IsKeyDown(Keys.A)) { CurrentGameState = GameState.Death; }
                    if (Keyboard.GetState().IsKeyDown(Keys.R)) CurrentGameState = GameState.Level2;
                    if (portalSprite.teleported == true)
                    {
                        CurrentGameState = GameState.Level2;
                    }
                    break;


                case GameState.Level2:
                    if (Keyboard.GetState().IsKeyDown(Keys.T)) { CurrentGameState = GameState.Level3; }
                    break;
                case GameState.Level3:
                    if (Keyboard.GetState().IsKeyDown(Keys.P)) { CurrentGameState = GameState.Win; }

                    break;
                case GameState.Win:
                    if (winEindigKnop.isClicked == true) Exit();
                    winEindigKnop.Update(mouse);
                    break;
                case GameState.Death:
                    if (restart.isRestarted == true) CurrentGameState = GameState.Level1;
                    restart.Update(mouse);
                    break;
            }

            if (levelLoaded)
            {
                ufo.Update(gameTime);
                player.Update(gameTime);
            }
           
            spook.Update(gameTime);
            boss.Update(gameTime);
            lBall.Update(gameTime);
            fish.Update(gameTime);
            


            playerLife.Update(gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.H))
            {
                score++;

            }
            coinLevel1.Update(gameTime);
            coinLevel2.Update(gameTime);
            coinLevel3.Update(gameTime);
            portalSprite.Update(gameTime);
            if (CurrentGameState == GameState.Level1)
            {
                foreach (CollisionTiles tile in mapLevel1.CollisionTiles)
                {
                    player.Collision(tile.Rectangle, mapLevel1.Width, mapLevel1.Height);


                }
            }
            if (CurrentGameState == GameState.Level2)
            {
                foreach (CollisionTiles tile in mapLevel2.CollisionTiles)
                {
                    player.Collision(tile.Rectangle, mapLevel2.Width, mapLevel2.Height);

                }
            }
            if (CurrentGameState == GameState.Level3)
            {
                foreach (CollisionTiles tile in mapLevel3.CollisionTiles)
            {
                player.Collision(tile.Rectangle, mapLevel3.Width, mapLevel3.Height);
              
            }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkViolet);

            Rectangle rectje = new Rectangle(0, 0, screenWidth + 50, screenHeight + 30);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null);

            switch (CurrentGameState)
            {
                case GameState.MainMenu:

                    _spriteBatch.Draw(Content.Load<Texture2D>("MenuScreen"), new Rectangle(0, 0, screenWidth + 80, screenHeight), Color.White);
                    btnPlay.Draw(_spriteBatch);
                    break;
                case GameState.Level1:
                    music.Draw(_spriteBatch);
                    _spriteBatch.Draw(backgroundje1, rectje, Color.White);
                    playerLife.Draw(_spriteBatch);
                    mapLevel1.Draw(_spriteBatch);
                    spook.Draw(_spriteBatch);
                    _spriteBatch.Draw(healthTexture, healthRectanglePlayer, Color.White);
                    _spriteBatch.Draw(healthTexture, healthRectangleGhost, Color.White);
                    portalSprite.Draw(_spriteBatch);
                    player.Draw(_spriteBatch);
                    ufo.Draw(_spriteBatch);
                    coinLevel1.Draw(_spriteBatch);
                    _spriteBatch.DrawString(tekst, "Score: " + score, new Vector2(screenWidth - 360, 0), Color.White); ;
                    break;

                case GameState.Level2:
                    _spriteBatch.Draw(backgroundje2, rectje, Color.White);
                    music.Draw(_spriteBatch);
                    playerLife.Draw(_spriteBatch);
                    lBall.Draw(_spriteBatch);
                    mapLevel2.Draw(_spriteBatch);
                    coinLevel2.Draw(_spriteBatch);
                    fish.Draw(_spriteBatch);
                    _spriteBatch.Draw(healthTexture, healthRectangleFish, Color.White);
                    _spriteBatch.Draw(healthTexture, healthRectanglePlayer, Color.White);
                    player.Draw(_spriteBatch);
                    _spriteBatch.DrawString(tekst, "Score: " + score, new Vector2(screenWidth - 360, 0), Color.White);
                    break;
                case GameState.Level3:
                    _spriteBatch.Draw(backgroundje3, rectje, Color.White);
                    music.Draw(_spriteBatch);
                    mapLevel3.Draw(_spriteBatch);
                    coinLevel3.Draw(_spriteBatch);
                    boss.Draw(_spriteBatch);
                    _spriteBatch.Draw(healthTexture, healthRectanglePlayer, Color.White);
                    _spriteBatch.Draw(healthTexture, healthRectangleBoss, Color.White);
                    player.Draw(_spriteBatch);
                    playerLife.Draw(_spriteBatch);
                    _spriteBatch.DrawString(tekst, "Score: " + score, new Vector2(screenWidth - 360, 0), Color.White);
                    break;

                case GameState.Win:
                    _spriteBatch.Draw(winScreen, new Rectangle(0, 0, screenWidth + 80, screenHeight), Color.White);
                    winEindigKnop.Draw(_spriteBatch);
                    break;
                case GameState.Death:
                    _spriteBatch.Draw(Content.Load<Texture2D>("Death_Screen"), new Rectangle(0, 0, screenWidth + 80, screenHeight), Color.White);
                    restart.Draw(_spriteBatch);
                    break;
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}