﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject.Classes.Enemies
{
    internal class BossMonster : IGameObject
    {


        Vector2 bossPosition = new Vector2(1400, 515);
        Vector2 velocity = new Vector2(9, 0);
        public Texture2D boss;
        public Rectangle rectangle;
        public bool goLeft = false;
        public bool goRight = false;
        public bool timerLeft = false;
        public bool timerRight = false;





        public AnimationModus animations { get; set; }
        public Animation currentAnimation { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return rectangle;
            }

        }

        public Vector2 Position
        {
            get
            {
                return bossPosition;
            }

        }

        public BossMonster(Texture2D texture)
        {

            boss = texture;
            animations = new AnimationModus();

            animations.MoveStateRight = new Animation();
            animations.MoveStateLeft = new Animation();
            for (int i = 0; i < 5; i++) { animations.MoveStateRight.AddFrame(new AnimationFrame(new Rectangle(89 * i, 0, 86, 71))); }
            for (int i = 0; i < 5; i++) { animations.MoveStateLeft.AddFrame(new AnimationFrame(new Rectangle(88 * i, 71, 86, 71))); }
           

            currentAnimation = animations.MoveStateRight;

        }

      
        public void Update(GameTime gameTime)
        {

          
            currentAnimation.Update(gameTime);
          
            rectangle = new Rectangle((int)bossPosition.X, (int)bossPosition.Y, 160, 128);



            move(gameTime);


        }
        private void move(GameTime gameTime)
        {

            bossPosition.X += velocity.X;


            if (bossPosition.X > 1570)
            {
                velocity.X = 9;
                velocity.X *= -1;
              
                goLeft = true;
                goRight = false;
                currentAnimation = animations.MoveStateLeft;

            }
            else if (bossPosition.X < 50)
            {
                velocity.X = -9;
                velocity.X *= -1;
              
                goLeft = false;
                goRight = true;
                currentAnimation = animations.MoveStateRight;
            }
            if (goLeft)
            {
                velocity.X += 0.15F;
                if (velocity.X > 0)
                {

                        velocity.X = 9;
                        velocity.X *= -1;
                        velocity.X += 0.15F;
                        
                    
                }
            }
            else if (goRight)
            {
                velocity.X -= 0.15F;
                if (velocity.X < 0)
                {
                   
                        velocity.X = -9;
                        velocity.X *= -1;
                        velocity.X -= 0.15F;
                        
                 
                }
            }
            
            rectangle = new Rectangle((int)bossPosition.X, (int)bossPosition.Y, 160, 128);


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
                spriteBatch.Draw(boss, rectangle, currentAnimation.CurrentFrame.SourceRectangle, Color.White);
            
        }
    }
}
