using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject
{
    internal class Player : IGameObject
    {





        public Texture2D texture;

        public Texture2D bulletImage;


        public Vector2 position = new Vector2(64, 384);
        public Vector2 velocity;
        public Rectangle rectangle;
        public int health;
        Fireball vuurbal;
      

        Vector2 position2;

        bool isLeft = false;
        bool isRight = false;




        private bool hasJumped = false;
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
                return position;
            }

        }
        public Vector2 Position2
        {
            get
            {
                return position2;
            }

        }
        public Player(Texture2D texture, int newHealth, Texture2D bulletImage)
        {

            this.texture = texture;
            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 40, 49)));

            health = newHealth;
            vuurbal = new Fireball(bulletImage);
        }




        Animation animation;

        int shuifopX = 0;
        public void StandRight()
        {
            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 40, 49)));
        }
        public void Standleft()
        {
            animation = new Animation();   
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 49, 40, 49)));
        }
        public void MoveRight()
        {
            animation = new Animation();
            for (int i = 0; i < 2; i++) { animation.AddFrame(new AnimationFrame(new Rectangle(40 * i, 0, 40, 49))); }
        }
        public void Moveleft()
        {
            animation = new Animation();
            for (int i = 0; i < 2; i++) { animation.AddFrame(new AnimationFrame(new Rectangle(40 * i, 49, 40, 49))); }
        }
        public void JumpRight()
        {
            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(120, 0, 40, 49))); 
        }
        public void JumpLeft()
        {
            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(120, 49, 40, 49)));
        }





        public void Load(ContentManager Content)
        {
           
            bulletImage = Content.Load<Texture2D>("Fireball");

        }
        private void Input(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 7;
                if (hasJumped == false) MoveRight();
                isRight = true;
                isLeft = false;

            }
           
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 7;
                if (hasJumped == false) Moveleft();
                isLeft = true;
                isRight = false;

            }
            else
            {
                velocity.X = 0F;
            }
           

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false && isRight)
            {
                position.Y -= 3F;
                velocity.Y = -5F;
                hasJumped = true;

                JumpRight();

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false && isLeft)
            {
                position.Y -= 3F;
                velocity.Y = -5F;
                hasJumped = true;
                JumpLeft();



            }



            /*   1. Aanmaken eigen klasse met eigen property, 2. in die klasse ervoor zorgen dat bij schieten de zelfgekozen waarde al gekozen is*/



        }


        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);


            shuifopX += 40; //moet je ook fixen bij verandering
            if (shuifopX > 159)
            {
                shuifopX = 0;
            }
            rectangle.X = shuifopX;
            vuurbal.Update(gameTime, position2, position, isLeft, isRight, bulletImage, bulletImage);
            position += velocity;
            position2 = position;
            rectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);





            Input(gameTime);

            if (velocity.Y < 10) velocity.Y += 0.2F; //hoe hoog je springt
        }

        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (rectangle.TouchTopOf(newRectangle))
            {
                rectangle.Y = newRectangle.Y - rectangle.Height + 5;
                velocity.Y = 0F;
                hasJumped = false;
                
                
            }
            if (rectangle.TouchLeftOf(newRectangle))
            {
                position.X = newRectangle.X - rectangle.Width;
            }
            if (rectangle.TouchRightOf(newRectangle))
            {
                position.X = newRectangle.X + rectangle.Width + 17F;
            }
            if (rectangle.TouchBottomOf(newRectangle)) velocity.Y = 1F;

            if (position.X < 0) position.X = 0;
            if (position.X > xOffset - rectangle.Width) position.X = xOffset - rectangle.Width;
            if (position.Y < 0) velocity.Y = 1F;
            if (position.Y > yOffset - rectangle.Height) position.Y = yOffset - rectangle.Height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (health > 0)
            {
                spriteBatch.Draw(texture,rectangle, animation.CurrentFrame.SourceRectangle, Color.White);
            }

           vuurbal.Draw(spriteBatch);

        }


    }
}

