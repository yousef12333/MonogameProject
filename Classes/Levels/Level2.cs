using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Reflection.Metadata;
using Microsoft.VisualBasic.Devices;
using Mouse = Microsoft.Xna.Framework.Input.Mouse;
using MonogameProject.ViewStates;
using MonogameProject.Classes.Hero;
using MonogameProject.Tiles;
using static System.Net.Mime.MediaTypeNames;
using SharpDX.Direct3D9;
using MonogameProject.Classes.Enemies;
using Microsoft.Xna.Framework.Content;

namespace MonogameProject.Classes.Levels
{
    internal class Level2
    {
        Texture2D healthTexture;
        bool levelLoaded = false;
        Health playerLife;
        public SpriteFont tekst;
        Portal portal2;
        Texture2D coinTexture;
        Player player;
        Texture2D playerTexture;
        Texture2D fireballImage;
        Fireball fireball;
        public bool objectInitialized = false;
        Map mapLevel2;
        Coin coinLevel2;
        Texture2D portalTexture;
        Score score;
        private Texture2D backgroundje2;
        Rectangle healthRectangleFish;
        Texture2D fishTexture;
        FishMonsterTrap fish;
        BackgroundMusic music;
        private Texture2D backgroundjeLevel2;
        Texture2D lavaBallTexture;
        LavaBall lBall1;
        LavaBall lBall2;
        public Level2()
        {
            fireball = new Fireball(fireballImage);
            score = new Score(tekst);
            lBall1 = new LavaBall(lavaBallTexture);
            lBall2 = new LavaBall(lavaBallTexture);
            fish = new FishMonsterTrap(fishTexture, 150);
            player = new Player(playerTexture, 100, fireballImage);

            portal2 = new Portal(portalTexture);

            coinLevel2 = new Coin(coinTexture);
        }
        public void Load(ContentManager Content)
        {
            mapLevel2.Generate(new int[,]
        {
             { 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6},
             { 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6},
             { 6, 0, 0, 0, 0, 0, 6, 0, 0, 6, 0, 0, 6, 0, 0, 0, 0, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 6},
             { 6, 0, 0, 0, 0, 6, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6},
             { 6, 0, 0, 6, 6, 7, 5, 5, 5, 5, 5, 5, 5, 5, 7, 7, 7, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6},
             { 6, 6, 6, 6, 7, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 7, 7, 6, 0, 0, 0, 0, 0, 0, 0, 0, 6, 6},
             { 7, 7, 7, 7, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 7, 7, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6},
             { 7, 7, 7, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 7, 6, 0, 0, 0, 0, 6, 0, 0, 0, 0, 6},
             { 7, 7, 7, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 7, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6},
             { 7, 7, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6},
             { 7, 7, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6},

        }, 64);

            coinLevel2 = new Coin(coinTexture);
            mapLevel2 = new Map();
            coinTexture = Content.Load<Texture2D>("CoinMovement2");
            portal2 = new Portal(portalTexture);
            portalTexture = Content.Load<Texture2D>("Portal");
            score = new Score(tekst);
            playerLife = new Health();
            music = new BackgroundMusic();
            mapLevel2 = new Map();
            music.Load(Content);
            playerLife.Load(Content);
            healthTexture = Content.Load<Texture2D>("HealthBar");
            backgroundje2 = Content.Load<Texture2D>("Vulcanic_Background");
            lBall1 = new LavaBall(lavaBallTexture);
            lBall2 = new LavaBall(lavaBallTexture);
            fish = new FishMonsterTrap(fishTexture, 150);
            player = new Player(playerTexture, 100, fireballImage);
            fishTexture = Content.Load<Texture2D>("FishmonsterMovement4");
            portal2 = new Portal(portalTexture);

            coinLevel2 = new Coin(coinTexture);
            playerLife.Load(Content);
            BioHunt.Instance.IsMouseVisible = true;
            Tiles.Tiles.Content = Content;


            music.Load(Content);
        }
        public void Update(GameTime gameTime)
        {

            if (objectInitialized == false)
            {
                coinLevel2.AddCoin(new Rectangle(594, 95, 32, 32));
                coinLevel2.AddCoin(new Rectangle(1110, 95, 32, 32));
                coinLevel2.AddCoin(new Rectangle(1687, 287, 32, 32));

                portal2.AddPortal(new Rectangle(65, 257, 128, 64));

                lBall1.AddLavaball(new Vector2(470, 0));
                lBall2.AddLavaball(new Vector2(670, 400));

                objectInitialized = true;
            }
            playerLife.Update(gameTime);
            portal2.Update(gameTime);
            coinLevel2.Update(gameTime);
            healthRectangleFish = new Rectangle(fish.rectangle.X - 2, fish.Rectangle.Y - 25, fish.health, 15);
        }
        Rectangle rectje = new Rectangle(0, 0, BioHunt.Instance.screenWidth + 50, BioHunt.Instance.screenHeight + 30);
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundje2, rectje, Color.White);
            music.Draw(spriteBatch);
            lBall1.Draw(spriteBatch);
            lBall2.Draw(spriteBatch);
            mapLevel2.Draw(spriteBatch);
            coinLevel2.Draw(spriteBatch);
            fish.Draw(spriteBatch);
            portal2.Draw(spriteBatch);
            spriteBatch.Draw(healthTexture, healthRectangleFish, Color.White);
            player.Draw(spriteBatch);
            playerLife.Draw(spriteBatch);
            score.Draw(spriteBatch);
        }
    }
}
