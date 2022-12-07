
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameProject.Classes;
using MonogameProject.Classes.Enemies;
using MonogameProject.Classes.Hero;
using MonogameProject.Classes.Levels;
using MonogameProject.Tiles;


using MonogameProject.ViewStates;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MonogameProject
{
    public class BioHunt : Game
    {
        Rectangle mouseRectangle;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Level1 level1;
        Level2 level2;
        Level3 level3;

        public LevelStates LevelStates = LevelStates.MainMenu;
        public int screenWidth = 1790, screenHeight = 703;
        public int Screenwidth
        {
            get { return screenWidth; }
        }


        MenuButtons btnPlay;
        Death restart;
        Texture2D ghostTexture;
        Texture2D mouseTexture;
        
        Health playerLife;
        WinButton winEindigKnop;
       
        private Texture2D backgroundje2;
        private Texture2D backgroundje3;
        private Texture2D winScreen;
        GraphicsDevice grap;

       
        Map mapLevel2;
        Map mapLevel3;


      
        //Portal portal2;
        //Texture2D portalTexture;

        

        Coin coinLevel2;
        Coin coinLevel3;
        Texture2D coinTexture;



        //Ufo ufo;
        Texture2D ufoTexture;
        Texture2D portalTexture;
        Texture2D healthTexture;
        Rectangle healthRectangleFish;
        
        Rectangle healthRectangleBoss;
        Texture2D fishTexture;
        FishMonsterTrap fish;
        BossMonster boss;
        Texture2D bossTexture;
        //GhostMonster spook;
        Texture2D lavaBallTexture;
        LavaBall lBall1;
        LavaBall lBall2;

        Player player;
        Texture2D playerTexture;
        Texture2D fireballImage;
        Fireball fireball;
        bool levelLoaded = false;
        bool objectInitialized = false;
        float monsterHitCounter;
        bool monsterHit = false;

        public SpriteFont tekst;
        public SpriteFont title;
        public SpriteFont titleEdge;
        public SpriteFont InputExplanation;
        Score score;

        private static BioHunt instance;

        public static BioHunt Instance
        {
            get
            {
                if (instance == null)
                    instance = new BioHunt();

                return instance;
            }
        }
        public BioHunt()
        {
            _graphics = new GraphicsDeviceManager(this);
          
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            fireball = new Fireball(fireballImage);
            score = new Score(tekst);
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            fireballImage = Content.Load<Texture2D>("Fireball");
            
            backgroundje2 = Content.Load<Texture2D>("Vulcanic_Background");
            backgroundje3 = Content.Load<Texture2D>("Castle_Background");
            winScreen = Content.Load<Texture2D>("Win_Background");
            ufoTexture = Content.Load<Texture2D>("Pixel_Ufo");
            portalTexture = Content.Load<Texture2D>("Portal");
            ghostTexture = Content.Load<Texture2D>("SpookBeweging");
            coinTexture = Content.Load<Texture2D>("CoinMovement2");
            playerTexture = Content.Load<Texture2D>("VerbeterigSpeler2");
            fireballImage = Content.Load<Texture2D>("Fireball");
            tekst = Content.Load<SpriteFont>("File");

            mapLevel2 = new Map();
            mapLevel3 = new Map();
            playerLife = new Health();
            level1 = new Level1(ufoTexture, portalTexture, ghostTexture, coinTexture, playerTexture, fireballImage, tekst);
            level2 = new Level2();
            level3 = new Level3();
            //hier moeten de levels, BOVEN base.initialize


           
            title = Content.Load<SpriteFont>("Title");
            titleEdge = Content.Load<SpriteFont>("TitleEdge");
            InputExplanation = Content.Load<SpriteFont>("Explanation");
            
            base.Initialize();
            
            
            boss = new BossMonster(bossTexture, 200);
            lBall1 = new LavaBall(lavaBallTexture);
            lBall2 = new LavaBall(lavaBallTexture);
            fish = new FishMonsterTrap(fishTexture, 150);
            player = new Player(playerTexture, 100, fireballImage);
            
            //portal2 = new Portal(portalTexture);
            
            coinLevel2 = new Coin(coinTexture);
            coinLevel3 = new Coin(coinTexture);
            //ufo = new Ufo(ufoTexture);
        }

        protected override void LoadContent()
        {
            IsMouseVisible = true;
            mouseTexture = new Texture2D(GraphicsDevice, 1, 1);
            mouseTexture.SetData(new[] { Color.White });

            level1.Load(Content);
            level2.Load(Content);
            level3.Load(Content);
            //ufo = new Ufo(ufoTexture);

            score = new Score(tekst);

            player = new Player(playerTexture, 100, fireballImage);
            healthTexture = Content.Load<Texture2D>("HealthBar");

           
            
            bossTexture = Content.Load<Texture2D>("BossMonsterMovement2");
            lavaBallTexture = Content.Load<Texture2D>("Lava_Ball2");
            fishTexture = Content.Load<Texture2D>("FishmonsterMovement4");
            //portalTexture = Content.Load<Texture2D>("Portal");
           
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _graphics.PreferredBackBufferHeight = screenHeight;
            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.ApplyChanges();
            grap = GraphicsDevice;
            screenWidth = grap.PresentationParameters.BackBufferWidth;
            screenHeight = grap.PresentationParameters.BackBufferHeight;
            Tiles.Tiles.Content = Content;


            btnPlay = new MenuButtons(Content.Load<Texture2D>("Start_Button"), Content.Load<Texture2D>("Quit_Button"), GraphicsDevice);
            winEindigKnop = new WinButton(Content.Load<Texture2D>("Quit_Button"), GraphicsDevice);
            restart = new Death(Content.Load<Texture2D>("Restart_Button"), GraphicsDevice);



           




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
            IsMouseVisible = true;
            btnPlay.SetPosition(new Vector2(40, 200), new Vector2(40, 350));
            winEindigKnop.SetPosition(new Vector2(640, 450));
            restart.setPosition(new Vector2(620, 250));
            


        }


        protected override void Update(GameTime gameTime)
        {
            Debug.WriteLine(gameTime.TotalGameTime);
            





            MouseState mouse = Mouse.GetState();
            mouseRectangle = new Rectangle(mouse.X, mouse.Y, 5, 5);

            if (objectInitialized == false)
            {
               

                coinLevel2.AddCoin(new Rectangle(594, 95, 32, 32));
                coinLevel2.AddCoin(new Rectangle(1110, 95, 32, 32));
                coinLevel2.AddCoin(new Rectangle(1687, 287, 32, 32));

                coinLevel3.AddCoin(new Rectangle(1300, 250, 32, 32));
                coinLevel3.AddCoin(new Rectangle(880, 520, 32, 32));

              

                //portal2.AddPortal(new Rectangle(65, 257, 128, 64));

                lBall1.AddLavaball(new Vector2(470, 0));
                lBall2.AddLavaball(new Vector2(670, 400));
                objectInitialized = true;
            }



            
            //healthRectangleFish = new Rectangle(fish.rectangle.X - 2, fish.Rectangle.Y - 25, fish.health, 15);
            //healthRectangleBoss = new Rectangle(boss.rectangle.X, boss.Rectangle.Y - 25, boss.health, 15);




            //if ((player.rectangle.Intersects(spook.rectangle) && LevelStates == LevelStates.Level1) || (player.rectangle.Intersects(boss.rectangle) && LevelStates == LevelStates.Level3) || (player.rectangle.Intersects(fish.rectangle) && LevelStates == LevelStates.Level2 || (player.rectangle.Intersects(lBall1.Rectangle) && LevelStates == LevelStates.Level2 || (player.rectangle.Intersects(lBall2.Rectangle) && LevelStates == LevelStates.Level2))))
            //{
            //    if (player.isHit == false)
            //    {
            //        player.isHit = true;
            //        Player.Instance.HeartRate--;
            //    }

            //}
            //if ((player.rectangle.Intersects(spook.rectangle) && LevelStates == LevelStates.Level1))
            //{
            //    if (monsterHit == false)
            //    {
            //        monsterHit = true;

            //        spook.Velocity *= new Vector2(-1, 0);
            //    }
            //}
            //else if ((player.rectangle.Intersects(fish.rectangle) && LevelStates == LevelStates.Level2))
            //{
            //    if (monsterHit == false)
            //    {
            //        monsterHit = true;
            //        fish.Velocity *= new Vector2(-1, 0);
            //    }
            //}
            //if ((player.rectangle.Intersects(boss.rectangle) && player.rectangle.X - boss.rectangle.X < 0 && LevelStates == LevelStates.Level3)) //werkt niet
            //{
            //    if (monsterHit == false)
            //    {
            //        monsterHit = true;
            //        boss.VelocityX = -9;
            //        boss.VelocityX *= -1;

            //        boss.goLeft = false;
            //        boss.goRight = true;


            //    }
            //}
            //else if ((player.rectangle.Intersects(boss.rectangle) && player.rectangle.X - boss.rectangle.X > 0 && LevelStates == LevelStates.Level3))
            //{
            //    if (monsterHit == false)
            //    {
            //        monsterHit = true;

            //        boss.VelocityX = 9;
            //        boss.VelocityX *= -1;

            //        boss.goLeft = true;
            //        boss.goRight = false;
            //    }
            //}

            //if ((player.rectangle.X - boss.rectangle.X < -500) && LevelStates == LevelStates.Level3)
            //{
            //    boss.VelocityX = 9;
            //    boss.VelocityX *= -1;

            //    boss.goLeft = true;
            //    boss.goRight = false;
            //}
            //else if ((player.rectangle.X - boss.rectangle.X > 500) && LevelStates == LevelStates.Level3)
            //{
            //    boss.VelocityX = -9;
            //    boss.VelocityX *= -1;

            //    boss.goLeft = false;
            //    boss.goRight = true;
            //}
            //if (monsterHit == true)
            //{
            //    monsterHitCounter += (float)gameTime.ElapsedGameTime.TotalSeconds;
            //    if (monsterHitCounter > 1)
            //    {
            //        monsterHit = false;
            //        monsterHitCounter = 0;
            //    }
            //}

            //for (int i = 0; i < coinLevel1.coins.Count; i++)
            //{
            //    if (player.rectangle.Intersects(coinLevel1.coins[i]) && LevelStates == LevelStates.Level1)
            //    {
            //        coinLevel1.coins.RemoveAt(i);
            //        score.ScoreUp();
            //    }
            //}
            //for (int i = 0; i < coinLevel2.coins.Count; i++)
            //{
            //    if (player.rectangle.Intersects(coinLevel2.coins[i]) && LevelStates == LevelStates.Level2)
            //    {
            //        coinLevel2.coins.RemoveAt(i);
            //        score.ScoreUp();
            //    }
            //}
            //for (int i = 0; i < coinLevel3.coins.Count; i++)
            //{
            //    if (player.rectangle.Intersects(coinLevel3.coins[i]) && LevelStates == LevelStates.Level3)
            //    {
            //        coinLevel3.coins.RemoveAt(i);
            //        score.ScoreUp();
            //    }
            //}

            //if (player.rectangle.Intersects(portal1.portals[0]) && LevelStates == LevelStates.Level1)
            //{
            //    LevelStates = LevelStates.Level2;
            //}
            //else if (player.rectangle.Intersects(portal2.portals[0]) && LevelStates == LevelStates.Level2)
            //{
            //    LevelStates = LevelStates.Level3;
            //}



            //for (int i = 0; i < player.vuurbal.fireballRect.Count; i++)
            //{
            //    if (player.vuurbal.fireballRect[i].Intersects(spook.rectangle) && LevelStates == LevelStates.Level1)
            //    {
            //        spook.health -= 10;
            //        player.vuurbal.bullets.Remove(player.vuurbal.bullets[i]);
            //        player.vuurbal.fireballRect.Remove(player.vuurbal.fireballRect[i]);
            //        player.vuurbal.aanmaakBullet = false;
            //        player.vuurbal.timer = 0;
            //        player.vuurbal.directionFireball.RemoveAt(player.vuurbal.directionFireball.Count - 1);
            //    }
            //    else if (player.vuurbal.fireballRect[i].Intersects(fish.rectangle) && LevelStates == LevelStates.Level2)
            //    {
            //        fish.health -= 10;
            //        player.vuurbal.bullets.Remove(player.vuurbal.bullets[i]);
            //        player.vuurbal.fireballRect.Remove(player.vuurbal.fireballRect[i]);
            //        player.vuurbal.aanmaakBullet = false;
            //        player.vuurbal.timer = 0;
            //        player.vuurbal.directionFireball.RemoveAt(player.vuurbal.directionFireball.Count - 1);
            //    }
            //    else if (player.vuurbal.fireballRect[i].Intersects(boss.rectangle) && LevelStates == LevelStates.Level3)
            //    {
            //        boss.health -= 10;
            //        player.vuurbal.bullets.Remove(player.vuurbal.bullets[i]);
            //        player.vuurbal.fireballRect.Remove(player.vuurbal.fireballRect[i]);
            //        player.vuurbal.aanmaakBullet = false;
            //        player.vuurbal.timer = 0;
            //        player.vuurbal.directionFireball.RemoveAt(player.vuurbal.directionFireball.Count - 1);
            //    }


            //}

            //else if (mouseRectangle.Intersects(player.rectanglePlay))
            //{
            //    player.health -= 10;
            //}
            //else if (mouseRectangle.Intersects(fish.rectanglePlay))
            //{
            //    fish.health -= 10;
            //}
            if (levelLoaded)
            {
                //ufo.Update(gameTime);
                player.Update(gameTime);
            }
            if (Player.Instance.HeartRate < 1)
            {
                LevelStates = LevelStates.Death;
            }
            else if (boss.health < 1)
            {
                LevelStates = LevelStates.Win;
            }
            switch (LevelStates)
            {
                case LevelStates.MainMenu:
                    if (Keyboard.GetState().IsKeyDown(Keys.A)) { LevelStates = LevelStates.Level1; }
                    btnPlay.Update(mouse);
                    if (btnPlay.isClicked == true)
                    {
                        restart.isRestarted = false;

                        LevelStates = LevelStates.Level1; //zet player op juiste positie samen met spaceship en reset timer


                    }
                    else if (btnPlay.isClosed == true) Exit();


                    break;


                case LevelStates.Level1:
                 
                    if (Keyboard.GetState().IsKeyDown(Keys.R)) LevelStates = LevelStates.Level2;
                    //if (portal2.teleported == true)
                    //{
                    //    LevelStates = LevelStates.Level2;
                    //}


                    break;


                case LevelStates.Level2:
                    if (Keyboard.GetState().IsKeyDown(Keys.T)) { LevelStates = LevelStates.Level3; }
                    if (Keyboard.GetState().IsKeyDown(Keys.U))
                    {
                        LevelStates = LevelStates.Death;
                    }
                    break;
                case LevelStates.Level3:
                    if (Keyboard.GetState().IsKeyDown(Keys.P)) { LevelStates = LevelStates.Win; }

                    break;
                case LevelStates.Win:
                    if (winEindigKnop.isClicked == true) Exit();
                    winEindigKnop.Update(mouse);
                    break;
                case LevelStates.Death:
                    restart.Update(mouse);
                    if (restart.isRestarted == true)
                    {
                        gameTime.TotalGameTime = TimeSpan.Zero;
                        btnPlay.isClicked = false;
                        LevelStates = LevelStates.Level1; //bug, bij hoverout gaat het steeds terug van menu naar death



                        player.timer = 0; //werkt gewoon, komt door knop bug, hij blijft 0 als je ingedrukt houdt en als je loslaat wordt het 2,3,4.. zie debug.writeline
                        //ufo.timer = 0;



                        player.restarted = true;
                        //ufo.restarted = true;

                    }

                    break;
            }



            
            boss.Update(gameTime);
            lBall1.Update(gameTime);
            lBall2.Update(gameTime);
            fish.Update(gameTime);



            playerLife.Update(gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.H))
            {
                score.ScoreUp();

            }
          
            coinLevel2.Update(gameTime);
            coinLevel3.Update(gameTime);
         
            //portal2.Update(gameTime);
            level1.Update(gameTime);
            level2.Update(gameTime);
            level3.Update(gameTime);
           
            if (LevelStates == LevelStates.Level2)
            {
                foreach (CollisionTiles tile in mapLevel2.CollisionTiles)
                {
                    player.Collision(tile.Rectangle, mapLevel2.Width, mapLevel2.Height);

                }
            }
            if (LevelStates == LevelStates.Level3)
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

           


            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null);

            switch (LevelStates)
            {
                case LevelStates.MainMenu:

                    _spriteBatch.Draw(Content.Load<Texture2D>("MenuScreen2"), new Rectangle(0, 0, screenWidth + 80, screenHeight), Color.White);
                    btnPlay.Draw(_spriteBatch);
                    _spriteBatch.DrawString(titleEdge, "BIOHUNT", new Vector2(565, 15), Color.Black);
                    _spriteBatch.DrawString(title, "BIOHUNT", new Vector2(550, 0), Color.DarkViolet);
                    _spriteBatch.DrawString(InputExplanation, "Controls:\n- Left button to go left.\n- Right button to go right\n- Space button to jump\n- \'E\' button to shoot fireball", new Vector2(40, 500), Color.DarkGreen);

                    break;
                case LevelStates.Level1:
                    level1.Draw(_spriteBatch); //hier
                    break;

                case LevelStates.Level2:
                    level2.Draw(_spriteBatch);
                    //_spriteBatch.Draw(backgroundje2, rectje, Color.White);
               
                    lBall1.Draw(_spriteBatch);
                    lBall2.Draw(_spriteBatch);
                    mapLevel2.Draw(_spriteBatch);
                    coinLevel2.Draw(_spriteBatch);
                    fish.Draw(_spriteBatch);
                    //portal2.Draw(_spriteBatch);
                    _spriteBatch.Draw(healthTexture, healthRectangleFish, Color.White);
                    player.Draw(_spriteBatch);
                    playerLife.Draw(_spriteBatch);
                    score.Draw(_spriteBatch);

                    break;
                case LevelStates.Level3:
                    level3.Draw(_spriteBatch);
                    //_spriteBatch.Draw(backgroundje3, rectje, Color.White);
                 
                    mapLevel3.Draw(_spriteBatch);
                    coinLevel3.Draw(_spriteBatch);
                    boss.Draw(_spriteBatch);
                    _spriteBatch.Draw(healthTexture, healthRectangleBoss, Color.White);
                    player.Draw(_spriteBatch);
                    playerLife.Draw(_spriteBatch);
                    score.Draw(_spriteBatch);
                    break;

                case LevelStates.Win:
                    _spriteBatch.Draw(winScreen, new Rectangle(0, 0, screenWidth + 80, screenHeight), Color.White);
                    winEindigKnop.Draw(_spriteBatch);
                    break;
                case LevelStates.Death:
                    _spriteBatch.Draw(Content.Load<Texture2D>("Death_Screen"), new Rectangle(0, 0, screenWidth + 80, screenHeight), Color.White);
                    restart.Draw(_spriteBatch);
                    break;
            }
            _spriteBatch.Draw(mouseTexture, mouseRectangle, Color.Red);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}