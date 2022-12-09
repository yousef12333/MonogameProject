using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Classes.Hero;
using MonogameProject.Tiles;
using MonogameProject.Classes.Enemies;


namespace MonogameProject.Classes.Levels
{
    internal class Level3
    {
        Rectangle rectje = new Rectangle(0, 0, BioHunt.Instance.Screenwidth + 50, BioHunt.Instance.screenHeight + 30);
        BackgroundMusic music;
        private Texture2D backgroundje3;
        Map mapLevel3;
        Coin coinLevel3;
        Rectangle healthRectangleBoss;
        BossMonster boss;
        Player player;
        bool objectInitialized = false;
        public SpriteFont tekst;
        Score score;
        Health playerLife;
        Texture2D healthTexture;

        public Level3(Texture2D healthTexture, Texture2D bossTexture, Texture2D playerTexture, Texture2D fireballImage, Texture2D coinTexture, SpriteFont scoreTekst)
        {

            music = new BackgroundMusic();
            score = new Score(scoreTekst);
            mapLevel3 = new Map();
            playerLife = new Health();
            boss = new BossMonster(bossTexture, 200);
            player = new Player(playerTexture, 100, fireballImage);
            coinLevel3 = new Coin(coinTexture);
        }
        private static Level3 instance;

        public static Level3 Instance
        {
            get
            {
                if (instance == null)
                    instance = new Level3();

                return instance;
            }
        }
        public void Load(ContentManager Content)
        {

            backgroundje3 = Content.Load<Texture2D>("Castle_Background");
           
            healthTexture = Content.Load<Texture2D>("HealthBar");

         
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
            if (BioHunt.Instance.LevelStates == LevelStates.Level3)
            {
                foreach (CollisionTiles tile in mapLevel3.CollisionTiles)
                {
                    player.Collision(tile.Rectangle, mapLevel3.Width, mapLevel3.Height);

                }
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
            player.Draw(spriteBatch);
            playerLife.Draw(spriteBatch);
            score.Draw(spriteBatch);

        }
        public Level3()
        {
        }
    }
}
