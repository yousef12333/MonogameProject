﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Classes.Hero;
using MonogameProject.Tiles;
using MonogameProject.Classes.Enemies;
using Microsoft.Xna.Framework.Input;







namespace MonogameProject.Classes.Levels
{
    internal class level2
    {
        public Rectangle rectje = new Rectangle(0, 0, 1840, 733);
        public BackgroundMusic music;
        public LavaBall lBall1;
        public LavaBall lBall2;
        public Map mapLevel2;
        public Portal portal2;
        public Coin coinLevel2;
        public Rectangle healthRectangleFish;
        public FishMonsterTrap fish;
        public Player player;
        public Health playerLife;
        public Score score;
        public Texture2D backgroundje2;
        public Texture2D healthTexture;
        public bool playerFrozen = true;

        public bool objectInitialized = false;
        public bool addedPortal = false;
        private BioHunt game;
        public level2(Texture2D texturePortal, Texture2D coinTexture, Texture2D playerTexture, Texture2D fireballImage, SpriteFont scoreTekst, Texture2D lavaBallTexture, Texture2D fishTexture, BioHunt game)
        {

            music = new BackgroundMusic();
            portal2 = new Portal(texturePortal);
            coinLevel2 = new Coin(coinTexture);
            player = new Player(playerTexture, 100, fireballImage);
            playerLife = new Health();
            mapLevel2 = new Map();
            score = new Score(scoreTekst);
            lBall1 = new LavaBall(lavaBallTexture);
            lBall2 = new LavaBall(lavaBallTexture);
            fish = new FishMonsterTrap(fishTexture, 150);
            mapLevel2 = new Map();
            this.game = game;
        }
        private static level2 instance;

        public static level2 Instance
        {
            get
            {
                if (instance == null)
                    instance = new level2();

                return instance;
            }
        }
        public void Load(ContentManager Content)
        {
           
            Tiles.Tiles.Content = Content;
            healthTexture = Content.Load<Texture2D>("HealthBar");

            music.Load(Content);
            backgroundje2 = Content.Load<Texture2D>("Vulcanic_Background");
            playerLife.Load(Content);
            music.Load(Content);
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

        }
        public void Update(GameTime gameTime)
        {

            if (objectInitialized == false)
            {
                coinLevel2.AddCoin(new Rectangle(594, 95, 32, 32));
                coinLevel2.AddCoin(new Rectangle(1110, 95, 32, 32));
                coinLevel2.AddCoin(new Rectangle(1687, 287, 32, 32));
                portal2.AddPortal(new Rectangle(65, 257, 128, 64));
                addedPortal = true;
                lBall1.AddLavaball(new Vector2(470, 0));
                lBall2.AddLavaball(new Vector2(670, 400));

                objectInitialized = true;
            }
            player.Update(gameTime);
           
            lBall1.Update(gameTime);
            lBall2.Update(gameTime);
            fish.Update(gameTime);
            playerLife.Update(gameTime);
            coinLevel2.Update(gameTime);
            portal2.Update(gameTime);
            if (game.LevelStates == LevelStates.Level2)
            {
                foreach (CollisionTiles tile in mapLevel2.CollisionTiles)
                {
                    player.Collision(tile.Rectangle, mapLevel2.Width, mapLevel2.Height);

                }
            }
            healthRectangleFish = new Rectangle(fish.rectangle.X - 2, fish.Rectangle.Y - 25, fish.health, 15);
            if (Keyboard.GetState().IsKeyDown(Keys.T)) { game.LevelStates = LevelStates.Level3; }
            if (Keyboard.GetState().IsKeyDown(Keys.U))
            {
                game.LevelStates = LevelStates.Death;
            }
            if (playerFrozen)
            {
                player.position = new Vector2(1100, 600);
                player.velocity.Y = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundje2, rectje, Color.White);
            music.Draw(spriteBatch);
           
            spriteBatch.Draw(healthTexture, healthRectangleFish, Color.White);
            fish.Draw(spriteBatch);
            lBall1.Draw(spriteBatch);
            lBall2.Draw(spriteBatch);
            mapLevel2.Draw(spriteBatch);
            playerLife.Draw(spriteBatch);
            score.Draw(spriteBatch);
          
            coinLevel2.Draw(spriteBatch);
            
            portal2.Draw(spriteBatch);
            
            player.Draw(spriteBatch);
           
           
        }
        public level2()
        {
        }
    }
}
