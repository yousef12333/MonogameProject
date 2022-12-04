using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Classes.Hero;
using MonogameProject.Tiles;
using MonogameProject.Classes.Enemies;
using MonogameProject.Screen;
using MonogameProject.Collision;

namespace MonogameProject.Classes.Levels
{
    internal class Level1
    {

        Texture2D healthTexture;
        Ufo ufo;
        Texture2D ufoTexture;
        Health playerLife;
        public SpriteFont tekst;
        public Portal portal1;
        Texture2D coinTexture;
        Player player;
        public bool objectInitialized = false;

        Coin coinLevel1;
        Texture2D portalTexture;
        Texture2D fireballImage;
        Fireball fireball;
        Score score;
        GhostMonster spook;
        BackgroundMusic music;
        Rectangle healthRectangleGhost;
        private Texture2D backgroundjeLevel1;
        Texture2D ghostTexture;
        Transitions transitions;
        CollisionManager collision;
        Texture2D playerTexture;

        public Level1()
        {
            player = new Player(playerTexture, 100, fireballImage);
            fireball = new Fireball(fireballImage);
            score = new Score(tekst);
            coinLevel1 = new Coin(coinTexture);
            ufo = new Ufo(ufoTexture);
            portal1 = new Portal(portalTexture);
            score = new Score(tekst);
            playerLife = new Health();
            music = new BackgroundMusic();
            spook = new GhostMonster(ghostTexture, 100);
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

            playerTexture = Content.Load<Texture2D>("VerbeterigSpeler2");

            player = new Player(playerTexture, 100, fireballImage);
            coinTexture = Content.Load<Texture2D>("CoinMovement2");
            
            portalTexture = Content.Load<Texture2D>("Portal");
           
            music.Load(Content);
            playerLife.Load(Content);
            
            ghostTexture = Content.Load<Texture2D>("SpookBeweging");
            ufoTexture = Content.Load<Texture2D>("Pixel_Ufo");
           
            healthTexture = Content.Load<Texture2D>("HealthBar");
            backgroundjeLevel1 = Content.Load<Texture2D>("background");
        }
        public void Update(GameTime gameTime)
        {
           
                ufo.Update(gameTime);
                player.Update(gameTime);
            
            if (objectInitialized == false)
            {
                coinLevel1.AddCoin(new Rectangle(910, 290, 32, 32));
                coinLevel1.AddCoin(new Rectangle(1200, 580, 32, 32));
                coinLevel1.AddCoin(new Rectangle(1700, 355, 32, 32));
                portal1.AddPortal(new Rectangle(1150, 625, 128, 64));
                objectInitialized = true;
            }
            playerLife.Update(gameTime);
          
            coinLevel1.Update(gameTime);
            spook.Update(gameTime);
            healthRectangleGhost = new Rectangle(spook.rectangle.X - 10, spook.Rectangle.Y - 25, spook.health, 15);
            
           
            portal1.Update(gameTime);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle rectje = new Rectangle(0, 0, ScreenSettings.Instance.screenWidth + 50, ScreenSettings.Instance.screenHeight + 30);
            playerLife.Draw(spriteBatch);
            portal1.Draw(spriteBatch);
            score.Draw(spriteBatch);
            spook.Draw(spriteBatch);
            music.Draw(spriteBatch);
            spriteBatch.Draw(backgroundjeLevel1, rectje, Color.White);
            spriteBatch.Draw(healthTexture, healthRectangleGhost, Color.White);
            player.Draw(spriteBatch);
            ufo.Draw(spriteBatch);
        }
    }
}
