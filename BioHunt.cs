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
        
        public LevelStates LevelStates = LevelStates.MainMenu;
        MainMenu mainMenu;
       


        
      
       
        Texture2D mouseTexture;
        BackgroundMusic music;
        Health playerLife;
        
        

        
       
        GraphicsDevice grap;

       
        
        Map mapLevel3;


        


        

        Coin coinLevel3;
        Texture2D coinTexture;
        Death death;
        Win win;

   
      

        Texture2D healthTexture;

       


        Player player;
        Texture2D playerTexture;
        Texture2D fireballImage;
        Fireball fireball;
       
       
        float monsterHitCounter;
       

        public SpriteFont tekst;

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
            
            score = new Score(tekst);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            fireballImage = Content.Load<Texture2D>("Fireball");
            
          
           
            
        
            music = new BackgroundMusic();
           
            mapLevel3 = new Map();
            playerLife = new Health();
            mainMenu = new MainMenu();
            death = new Death();
            win = new Win();


            base.Initialize();
        }

        protected override void LoadContent()
        {
           
            mouseTexture = new Texture2D(GraphicsDevice, 1, 1);
            mouseTexture.SetData(new[] { Color.White });
            mainMenu = new MainMenu();
            death = new Death();
            win.Load(Content);
            death.Load(Content);
            mainMenu.Load(Content);
          

            score = new Score(tekst);

            player = new Player(playerTexture, 100, fireballImage);
            healthTexture = Content.Load<Texture2D>("HealthBar");
      
            playerTexture = Content.Load<Texture2D>("VerbeterigSpeler2");
            
            bossTexture = Content.Load<Texture2D>("BossMonsterMovement2");
            lavaBallTexture = Content.Load<Texture2D>("Lava_Ball2");
           
            portalTexture = Content.Load<Texture2D>("Portal");
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _graphics.PreferredBackBufferHeight = screenHeight;
            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.ApplyChanges();
            grap = GraphicsDevice;
            screenWidth = grap.PresentationParameters.BackBufferWidth;
            screenHeight = grap.PresentationParameters.BackBufferHeight;
            Tiles.Tiles.Content = Content;

           

            
                
              

            playerLife.Load(Content);
            IsMouseVisible = true;
            
            
           
            music.Load(Content);


        }


        protected override void Update(GameTime gameTime)
        {
            Debug.WriteLine(gameTime.TotalGameTime);
            if(LevelStates == LevelStates.Level1) 

          



            MouseState mouse = Mouse.GetState();
            mouseRectangle = new Rectangle(mouse.X, mouse.Y, 5, 5);

            if(objectInitialized == false)
            {
                coinLevel3.AddCoin(new Rectangle(1300, 250, 32, 32));
                coinLevel3.AddCoin(new Rectangle(880, 520, 32, 32));
            }

            //else if (mouseRectangle.Intersects(player.rectanglePlay))
            //{
            //    player.health -= 10;
            //}
            //else if (mouseRectangle.Intersects(fish.rectanglePlay))
            //{
            //    fish.health -= 10;
            //}
            
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
                    mainMenu.Update(gameTime);
                    break;


                case LevelStates.Level1:
                    if (Keyboard.GetState().IsKeyDown(Keys.A)) { LevelStates = LevelStates.Death; }
                    if (Keyboard.GetState().IsKeyDown(Keys.R)) LevelStates = LevelStates.Level2;
                    if (portal2.teleported == true)
                    {
                        LevelStates = LevelStates.Level2;
                    }
                   

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
                    win.Update(gameTime);
                    break;
                case LevelStates.Death:
                    death.Update(gameTime);
                    
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
           
            portal2.Update(gameTime);

          
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

                    mainMenu.Draw(_spriteBatch);

                    break;
                case LevelStates.Level1:
                  
                   
             
                    break;

                case LevelStates.Level2:


                    break;
                case LevelStates.Level3:
                  
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