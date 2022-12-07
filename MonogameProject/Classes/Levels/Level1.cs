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
        Map mapLevel1;
        Texture2D healthTexture;
        Rectangle healthRectangleGhost;
        BackgroundMusic music;
        public Portal portal1;
        Ufo ufo;
        GhostMonster spook;
        Player player;
        Coin coinLevel1;
        Rectangle rectje = new Rectangle(0, 0, BioHunt.Instance.Screenwidth + 50, BioHunt.Instance.screenHeight + 30);
        private Texture2D backgroundje1;
        Health playerLife;
        Score score;

        public bool objectInitialized = false;
        public Level1(Texture2D textureUfo, Texture2D texturePortal, Texture2D ghostTexture, Texture2D coinTexture, Texture2D playerTexture, Texture2D fireballImage, SpriteFont scoreTekst)
        {
         
            music = new BackgroundMusic();
            spook = new GhostMonster(ghostTexture, 100); //iets voor newhealth? (tenzij geen nullreferror)
            portal1 = new Portal(texturePortal); 
            ufo = new Ufo(textureUfo);
            coinLevel1 = new Coin(coinTexture);
            player = new Player(playerTexture, 100, fireballImage);
            playerLife = new Health();
            mapLevel1 = new Map();
            score = new Score(scoreTekst);
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
            Tiles.Tiles.Content = Content;
            backgroundje1 = Content.Load<Texture2D>("background");
            playerLife.Load(Content);
            music.Load(Content);
            healthTexture = Content.Load<Texture2D>("HealthBar");
            mapLevel1.Generate(new int[,]
          {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1},
                { 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 0, 0, 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2},
                { 2, 2, 1, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 0, 0, 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2},
                { 2, 2, 2, 1, 1, 1, 0, 0, 0, 0, 2, 2, 2, 2, 2, 0, 0, 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2},
                { 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 2, 2, 2, 2, 2, 0, 0, 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2},

      }, 64);
        }
        public void Update(GameTime gameTime)
        {
            if (objectInitialized == false)
            {
                portal1.AddPortal(new Rectangle(1150, 625, 128, 64));
                coinLevel1.AddCoin(new Rectangle(910, 290, 32, 32));
                coinLevel1.AddCoin(new Rectangle(1200, 580, 32, 32));
                coinLevel1.AddCoin(new Rectangle(1700, 355, 32, 32));
                objectInitialized = true;
            }
           
            player.Update(gameTime);
            ufo.Update(gameTime);
            portal1.Update(gameTime);
            spook.Update(gameTime);
            coinLevel1.Update(gameTime);
            if (BioHunt.Instance.LevelStates == LevelStates.Level1)
            {
                foreach (CollisionTiles tile in mapLevel1.CollisionTiles)
                {
                    player.Collision(tile.Rectangle, mapLevel1.Width, mapLevel1.Height);
                }
            }
            healthRectangleGhost = new Rectangle(spook.rectangle.X - 10, spook.Rectangle.Y - 25, spook.health, 15);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundje1, rectje, Color.White);
            playerLife.Draw(spriteBatch);
            score.Draw(spriteBatch);
            music.Draw(spriteBatch);
            portal1.Draw(spriteBatch);
            mapLevel1.Draw(spriteBatch);
            spriteBatch.Draw(healthTexture, healthRectangleGhost, Color.White);
            player.Draw(spriteBatch);
            ufo.Draw(spriteBatch);
            spook.Draw(spriteBatch);
            coinLevel1.Draw(spriteBatch);
        }
        public Level1()
        {
        }
    }
}
