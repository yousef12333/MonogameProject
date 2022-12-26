using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Classes.Hero;
using MonogameProject.Tiles;
using MonogameProject.Classes.Enemies;
using Microsoft.Xna.Framework.Input;


namespace MonogameProject.Classes.Levels
{
    internal class level3
    {
        public Rectangle rectje = new Rectangle(0, 0, 1840, 733);
        public BackgroundMusic music;
        public Texture2D backgroundje3;
        public Map mapLevel3;
        public Coin coinLevel3;
        public Rectangle healthRectangleBoss;
        public BossMonster boss;
        public Player player;
        public SpriteFont tekst;
        public Score score;
        public Health playerLife;
        public Texture2D healthTexture;
        public bool objectInitialized = false;
        public bool playerFrozen = true;
        public bool shiftLevel = false;
        private BioHunt game;

        public level3(Texture2D healthTexture, Texture2D bossTexture, Texture2D playerTexture, Texture2D fireballImage, Texture2D coinTexture, SpriteFont scoreTekst, BioHunt game)
        {

            music = new BackgroundMusic();
            score = new Score(scoreTekst);
            mapLevel3 = new Map();
            playerLife = new Health();
            boss = new BossMonster(bossTexture, 200);
            player = new Player(playerTexture, 100, fireballImage);
            coinLevel3 = new Coin(coinTexture);
            player.rectangle = new Rectangle(200, 200, 64, 64); //werkt maar geen gravity en beweging
            this.game = game;
        }
        private static level3 instance;

        public static level3 Instance
        {
            get
            {
                if (instance == null)
                    instance = new level3();

                return instance;
            }
        }
        public void Load(ContentManager Content)
        {

            backgroundje3 = Content.Load<Texture2D>("Castle_Background");
           
            healthTexture = Content.Load<Texture2D>("HealthBar");
            tekst = Content.Load<SpriteFont>("File");

            playerLife.Load(Content);
            music.Load(Content);

            music.Load(Content);
            Tiles.Tiles.Content = Content;
            mapLevel3.Generate(new int[,]
        {
                { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                { 3, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 3},
                { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},

        }, 64);
            playerLife.Load(Content);

        }
        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            if (objectInitialized == false)
            {
                coinLevel3.AddCoin(new Rectangle(1300, 250, 32, 32));
                coinLevel3.AddCoin(new Rectangle(880, 520, 32, 32));
                objectInitialized = true;
            }
            healthRectangleBoss = new Rectangle(boss.rectangle.X, boss.Rectangle.Y - 25, boss.health, 15);
            boss.Update(gameTime);
            playerLife.Update(gameTime);
            coinLevel3.Update(gameTime);
            if (shiftLevel)
            {
                if (game.LevelStates == LevelStates.Level2)
                {
                    game.LevelStates = LevelStates.Level3;
                }
            }
            if (game.LevelStates == LevelStates.Level3)
            {
                player.levelLoaded = true;
            }
            if (game.LevelStates == LevelStates.Level3)
            {
                foreach (CollisionTiles tile in mapLevel3.CollisionTiles)
                {
                    player.Collision(tile.Rectangle, mapLevel3.Width, mapLevel3.Height);

                }
            }
       
            if (playerFrozen)
            {
                player.position = new Vector2(100, 200);
                player.velocity.Y = 0;

            }
            if (playerFrozen && game.LevelStates == LevelStates.Level3)
            {
                playerFrozen = false;
            }
         

        }
        public void Draw(SpriteBatch spriteBatch)
        {

            music.Draw(spriteBatch);
            spriteBatch.Draw(backgroundje3, rectje, Color.White);
            
            mapLevel3.Draw(spriteBatch);
            coinLevel3.Draw(spriteBatch);
            boss.Draw(spriteBatch);
            spriteBatch.Draw(healthTexture, healthRectangleBoss, Color.White);

            playerLife.Draw(spriteBatch);
            score.Draw(spriteBatch);
            player.Draw(spriteBatch);
        }
        public level3()
        {
        }
    }
}
