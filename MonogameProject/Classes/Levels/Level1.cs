using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Classes.Hero;
using MonogameProject.Tiles;
using MonogameProject.Classes.Enemies;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using MonogameProject.Screen;

namespace MonogameProject.Classes.Levels
{
    internal class level1
    {
        public Map mapLevel1;
        public Texture2D healthTexture;
        public Rectangle healthRectangleGhost;
        public BackgroundMusic music;
        public Portal portal1;
        public Ufo ufo;
        public GhostMonster spook;
        public Player player;
        public Coin coinLevel1;
        public Rectangle rectje = new Rectangle(0, 0, 1840, 733); //biohunt instance is de reden dat muis vast staat
        public Texture2D backgroundje1;
        public Health playerLife;
        public Score score;
        public bool started = false;
        public bool objectInitialized = false;
        public bool addedPortal = false;
        public ScoreUpdater scoreUpdater;
        public ScoreStorage scoreStorage;
        public DamageDisplay damageDisplay;
        private BioHunt game;

        public level1(Texture2D textureUfo, Texture2D texturePortal, Texture2D ghostTexture, Texture2D coinTexture, Texture2D playerTexture, Texture2D fireballImage, SpriteFont scoreTekst, SpriteFont damageText, BioHunt game)
        {

            music = new BackgroundMusic();
            spook = new GhostMonster(ghostTexture, 100); //iets voor newhealth? (tenzij geen nullreferror)
            portal1 = new Portal(texturePortal);
            ufo = new Ufo(textureUfo);
            coinLevel1 = new Coin(coinTexture);
            player = new Player(playerTexture, 100, fireballImage);
            playerLife = new Health();
            mapLevel1 = new Map();
            scoreStorage = new ScoreStorage();
            scoreUpdater = new ScoreUpdater(scoreStorage);
            score = new Score(scoreTekst, scoreStorage);
            damageDisplay = new DamageDisplay(damageText);
            this.game = game;
        }



        private static level1 instance;

        public static level1 Instance
        {
            get
            {
                if (instance == null)
                    instance = new level1();

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
                { 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 1, 2, 2, 2, 2, 0, 0, 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2},
                { 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 2, 2, 2, 2, 2, 0, 0, 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2},
                { 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 2, 2, 2, 2, 2, 0, 0, 2, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2},

      }, 64);
        }
        public void Update(GameTime gameTime)
        {
          
            if (objectInitialized == false)
            {
                portal1.AddPortal(new Rectangle(1150, 575, 128, 64));
                addedPortal = true;
                coinLevel1.AddCoin(new Rectangle(910, 290, 32, 32));
                coinLevel1.AddCoin(new Rectangle(1200, 530, 32, 32));
                coinLevel1.AddCoin(new Rectangle(1700, 355, 32, 32));
                objectInitialized = true;
            }
          
            if(game.LevelStates == LevelStates.Level1)
            {
                player.levelLoaded = true;
                ufo.levelLoaded = true;
            }
           

            player.Update(gameTime);
            ufo.Update(gameTime);
            portal1.Update(gameTime);
            spook.Update(gameTime);
            coinLevel1.Update(gameTime);
            damageDisplay.Update(gameTime);
            if (game.LevelStates == LevelStates.Level1)
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
            score.Draw(spriteBatch, new Vector2(game.screenWidth - 330, 10));
            music.Draw(spriteBatch);
            portal1.Draw(spriteBatch);
            mapLevel1.Draw(spriteBatch);
            spriteBatch.Draw(healthTexture, healthRectangleGhost, Color.White);
            player.Draw(spriteBatch);
            ufo.Draw(spriteBatch);
            spook.Draw(spriteBatch);
            damageDisplay.Draw(spriteBatch);
            coinLevel1.Draw(spriteBatch);
        }
        public level1()
        {
        }
    }
}
