
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameProject.Classes;
using MonogameProject.Classes.Enemies;
using MonogameProject.Classes.Hero;
using MonogameProject.Classes.Levels;
using System;
using System.Diagnostics;
using System.IO;


namespace MonogameProject
{
    public class BioHunt : Game
    {
        Rectangle mouseRectangle;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        MainMenu mainMenu;
        Death death;
        Win win;
        Level1 level1;
        Level2 level2;
        Level3 level3;
        SpriteFont tekst;
        public LevelStates LevelStates = LevelStates.MainMenu;
        public int screenWidth = 1790, screenHeight = 703;
        public int Screenwidth
        {
            get { return screenWidth; }
        }


        
        Death restart;
        Texture2D ghostTexture;
        Texture2D mouseTexture;
        
        Health playerLife;
        
       
       
        
        private Texture2D winScreen;
        GraphicsDevice grap;

       
     
        


      
        
     

        

        
        
        Texture2D coinTexture;



       
        Texture2D ufoTexture;
        Texture2D portalTexture;
        Texture2D healthTexture;
        Rectangle healthRectangleFish;
        
        
        Texture2D fishTexture;
        FishMonsterTrap fish;
        
        Texture2D bossTexture;
        //GhostMonster spook;
        Texture2D lavaBallTexture;
        Texture2D backgroundje2;
        Texture2D backgroundje3;
        Score score;
        BossMonster boss;

        Player player;
        Texture2D playerTexture;
        Texture2D fireballImage;
        Fireball fireball;
        bool levelLoaded = false;
        
        float monsterHitCounter;
        bool monsterHit = false;

        
        
       

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
            lavaBallTexture = Content.Load<Texture2D>("Lava_Ball2");
            fishTexture = Content.Load<Texture2D>("FishmonsterMovement4");
            bossTexture = Content.Load<Texture2D>("BossMonsterMovement2");

            mainMenu = new MainMenu();
            death = new Death();
            win = new Win();
            level1 = new Level1(ufoTexture, portalTexture, ghostTexture, coinTexture, playerTexture, fireballImage, tekst);
            level2 = new Level2(portalTexture, coinTexture, playerTexture, fireballImage, tekst, lavaBallTexture, fishTexture);
            level3 = new Level3(healthTexture, bossTexture, playerTexture, fireballImage, coinTexture, tekst);
            //hier moeten de levels, BOVEN base.initialize
            base.Initialize();
        }

        protected override void LoadContent()
        {
            IsMouseVisible = true;
            mouseTexture = new Texture2D(GraphicsDevice, 1, 1);
            mouseTexture.SetData(new[] { Color.White });
            mainMenu.Load(Content, GraphicsDevice);
            death.Load(Content, GraphicsDevice);
            win.Load(Content, GraphicsDevice);
            level1.Load(Content);
            level2.Load(Content);
            level3.Load(Content);
            //ufo = new Ufo(ufoTexture);
            player = new Player(playerTexture, 100, fireballImage);
            healthTexture = Content.Load<Texture2D>("HealthBar");
            //portalTexture = Content.Load<Texture2D>("Portal");
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _graphics.PreferredBackBufferHeight = screenHeight;
            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.ApplyChanges();
            grap = GraphicsDevice;
            screenWidth = grap.PresentationParameters.BackBufferWidth;
            screenHeight = grap.PresentationParameters.BackBufferHeight;
            Tiles.Tiles.Content = Content;
            IsMouseVisible = true;
        }
        protected override void Update(GameTime gameTime)
        {
            Debug.WriteLine(gameTime.TotalGameTime);
            MouseState mouse = Mouse.GetState();
            mouseRectangle = new Rectangle(mouse.X, mouse.Y, 5, 5);
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
            //if (levelLoaded)
            //{
            //ufo.Update(gameTime);
            //    player.Update(gameTime);
            //}
            //if (Player.Instance.HeartRate < 1)
            //{
            //    LevelStates = LevelStates.Death;
            //}
            //else if (boss.health < 1)
            //{
            //    LevelStates = LevelStates.Win;
            //}
            switch (LevelStates)
            {
                case LevelStates.MainMenu:
                   if (Keyboard.GetState().IsKeyDown(Keys.A)) { LevelStates = LevelStates.Level1; }
                //    btnPlay.Update(mouse);
                //    if (btnPlay.isClicked == true)
                //    {
                //        restart.isRestarted = false;

                //        LevelStates = LevelStates.Level1; //zet player op juiste positie samen met spaceship en reset timer


                //    }
                //    else if (btnPlay.isClosed == true) Exit();


                    break;


                case LevelStates.Level1:
                 
                    if (Keyboard.GetState().IsKeyDown(Keys.R)) LevelStates = LevelStates.Win;
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
                  
                    break;
                //case LevelStates.Death:
                //    restart.Update(mouse);
                //    if (restart.isRestarted == true)
                //    {
                //        gameTime.TotalGameTime = TimeSpan.Zero;
                //        btnPlay.isClicked = false;
                //        LevelStates = LevelStates.Level1; //bug, bij hoverout gaat het steeds terug van menu naar death



                //        player.timer = 0; //werkt gewoon, komt door knop bug, hij blijft 0 als je ingedrukt houdt en als je loslaat wordt het 2,3,4.. zie debug.writeline
                //        //ufo.timer = 0;



                //        player.restarted = true;
                //        //ufo.restarted = true;

                //    }

                //    break;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.H))
            {
                score.ScoreUp();

            }
            mainMenu.Update(gameTime);
            death.Update(gameTime);
            win.Update(gameTime);
            level1.Update(gameTime);
            level2.Update(gameTime);
            level3.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkViolet);
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null);
            switch (LevelStates)
            {
                case LevelStates.MainMenu:
                    mainMenu.Draw(_spriteBatch);
                    break;
                case LevelStates.Level1:
                    level1.Draw(_spriteBatch); //hier
                    break;
                case LevelStates.Level2:
                    level2.Draw(_spriteBatch);
                    break;
                case LevelStates.Level3:
                    level3.Draw(_spriteBatch);
                    break;
                case LevelStates.Win:
                    win.Draw(_spriteBatch);
                    break;
                case LevelStates.Death:
                    death.Draw(_spriteBatch);
                    break;
            }
            _spriteBatch.Draw(mouseTexture, mouseRectangle, Color.Red);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}