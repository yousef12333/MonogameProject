using Microsoft.Xna.Framework.Content;
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

namespace MonogameProject.Classes.Levels
{
    internal class Level1
    {
        Texture2D healthTexture;
        bool levelLoaded = false;
        Ufo ufo;
        Texture2D ufoTexture;
        Health playerLife;
        public SpriteFont tekst;
        Portal portal1;
        Texture2D coinTexture;
        Player player;
        public bool objectInitialized = false;
        Map mapLevel1;
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
        public Level1()
        {
            levelLoaded = true;
            fireball = new Fireball(fireballImage);
            score = new Score(tekst);
        }
        public void Load(ContentManager Content)
        {
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

            coinLevel1 = new Coin(coinTexture);
            mapLevel1 = new Map();
            coinTexture = Content.Load<Texture2D>("CoinMovement2");
            portal1 = new Portal(portalTexture);
            portalTexture = Content.Load<Texture2D>("Portal");
            score = new Score(tekst);
            playerLife = new Health();
            music = new BackgroundMusic();
            music.Load(Content);
            playerLife.Load(Content);
            spook = new GhostMonster(ghostTexture, 100);
            ghostTexture = Content.Load<Texture2D>("SpookBeweging");
            ufoTexture = Content.Load<Texture2D>("Pixel_Ufo");
            ufo = new Ufo(ufoTexture);
            healthTexture = Content.Load<Texture2D>("HealthBar");
            backgroundjeLevel1 = Content.Load<Texture2D>("background");
        }
        public void Update(GameTime gameTime)
        {
            if (levelLoaded)
            {
                ufo.Update(gameTime);
                player.Update(gameTime);
            }
            if (objectInitialized == false)
            {
                coinLevel1.AddCoin(new Rectangle(910, 290, 32, 32));
                coinLevel1.AddCoin(new Rectangle(1200, 580, 32, 32));
                coinLevel1.AddCoin(new Rectangle(1700, 355, 32, 32));
                portal1.AddPortal(new Rectangle(1150, 625, 128, 64));
                objectInitialized = true;
            }
            playerLife.Update(gameTime);
            portal1.Update(gameTime);
            coinLevel1.Update(gameTime);
            spook.Update(gameTime);
            healthRectangleGhost = new Rectangle(spook.rectangle.X - 10, spook.Rectangle.Y - 25, spook.health, 15);
         
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle rectje = new Rectangle(0, 0, BioHunt.Instance.screenWidth + 50, BioHunt.Instance.screenHeight + 30);
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
