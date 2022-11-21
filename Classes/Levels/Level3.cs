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
    internal class Level3
    {
        Texture2D healthTexture;
        bool levelLoaded = false;


        Health playerLife;
        public SpriteFont tekst;

        Texture2D coinTexture;
        Player player;
        Texture2D playerTexture;
        Texture2D fireballImage;
        Fireball fireball;
        public bool objectInitialized = false;
        Map mapLevel3;
        Coin coinLevel3;
        Score score;
        private Texture2D backgroundje3;


        Rectangle healthRectangleBoss;
        BossMonster boss;
        Texture2D bossTexture;
        BackgroundMusic music;
        private Texture2D backgroundjeLevel3;

        public Level3()
        {
            fireball = new Fireball(fireballImage);
            score = new Score(tekst);
            player = new Player(playerTexture, 100, fireballImage);
            BioHunt.Instance.IsMouseVisible = true;
            boss = new BossMonster(bossTexture, 200);

            coinLevel3 = new Coin(coinTexture);
        }
        public void Load(ContentManager Content)
        {
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

            coinLevel3 = new Coin(coinTexture);
            mapLevel3 = new Map();
            coinTexture = Content.Load<Texture2D>("CoinMovement2");
            score = new Score(tekst);
            playerLife = new Health();
            music = new BackgroundMusic();
            mapLevel3 = new Map();
            music.Load(Content);
            playerLife.Load(Content);
            healthTexture = Content.Load<Texture2D>("HealthBar");
            backgroundje3 = Content.Load<Texture2D>("Castle_Background");
            player = new Player(playerTexture, 100, fireballImage);
            boss = new BossMonster(bossTexture, 200);
           


            coinLevel3 = new Coin(coinTexture);
            playerLife.Load(Content);
            BioHunt.Instance.IsMouseVisible = true;
            Tiles.Tiles.Content = Content;


            music.Load(Content);
        }
        public void Update(GameTime gameTime)
        {

            if (objectInitialized == false)
            {
                coinLevel3.AddCoin(new Rectangle(594, 95, 32, 32));
                coinLevel3.AddCoin(new Rectangle(1110, 95, 32, 32));
                coinLevel3.AddCoin(new Rectangle(1687, 287, 32, 32));

                objectInitialized = true;
            }
            playerLife.Update(gameTime);

            coinLevel3.Update(gameTime);
          
            healthRectangleBoss = new Rectangle(boss.rectangle.X, boss.Rectangle.Y - 25, boss.health, 15);
        }
        Rectangle rectje = new Rectangle(0, 0, BioHunt.Instance.screenWidth + 50, BioHunt.Instance.screenHeight + 30);

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundje3, rectje, Color.White);
            music.Draw(spriteBatch);
            mapLevel3.Draw(spriteBatch);
            coinLevel3.Draw(spriteBatch);
            boss.Draw(spriteBatch);
            spriteBatch.Draw(healthTexture, healthRectangleBoss, Color.White);
            player.Draw(spriteBatch);
            playerLife.Draw(spriteBatch);
            score.Draw(spriteBatch);
        }
    }
}
