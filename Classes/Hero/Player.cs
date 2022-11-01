using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameProject.Interfaces;
using SharpDX.Direct3D9;


namespace MonogameProject.Classes.Hero
{
    internal class Player : IGameObject, ICollision
    {





        public Texture2D texture;

        public Texture2D bulletImage;
     
        public Rectangle collisionHitbox { get; set; }

        public Vector2 position = new Vector2(64, 600);
        public Vector2 velocity;
        public Rectangle rectangle;
        public int health;
        Fireball vuurbal;
       
        public AnimationModus animations { get; set; }
        public Animation currentAnimation { get; set; }
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
          

            health = newHealth;
            vuurbal = new Fireball(bulletImage);

            animations = new AnimationModus();

            animations.MoveStateRight = new Animation();
            animations.MoveStateLeft = new Animation();
            animations.IdleStateRight = new Animation();

            animations.IdleStateLeft = new Animation();
            animations.JumpRight = new Animation();
            animations.JumpLeft = new Animation();


            for (int i = 0; i < 2; i++)
            {
                animations.MoveStateRight.AddFrame(new AnimationFrame(new Rectangle(40 * i, 0, 40, 47)));
            }
            for (int i = 0; i < 2; i++)
            {
                animations.MoveStateLeft.AddFrame(new AnimationFrame(new Rectangle(40 * i, 49, 40, 49)));

            }
            animations.IdleStateRight.AddFrame(new AnimationFrame(new Rectangle(0, 0, 40, 47)));
            animations.IdleStateLeft.AddFrame(new AnimationFrame(new Rectangle(0, 49, 40, 49)));
            animations.JumpRight.AddFrame(new AnimationFrame(new Rectangle(120, 0, 40, 49)));
            animations.JumpLeft.AddFrame(new AnimationFrame(new Rectangle(120, 49, 40, 49)));


            currentAnimation = animations.IdleStateRight;
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
                if (hasJumped == false) currentAnimation = animations.MoveStateRight;
                isRight = true;
                isLeft = false;
                

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 7;
                if (hasJumped == false) currentAnimation = animations.MoveStateLeft;
                isLeft = true;
                isRight = false;
                
            }
            else
            {
                
                velocity.X = 0F;
                if (isRight && hasJumped == false)
                {
                    currentAnimation = animations.IdleStateRight;
                }
                else if (isLeft && hasJumped == false)
                {
                    currentAnimation = animations.IdleStateLeft;
                }
            }


            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false && isRight)
            {
                position.Y -= 3F;
                velocity.Y = -5F;
                hasJumped = true;

                currentAnimation = animations.JumpRight;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false && isLeft)
            {
                position.Y -= 3F;
                velocity.Y = -5F;
                hasJumped = true;
                currentAnimation = animations.JumpLeft;

            }
        }


        public void Update(GameTime gameTime)
        {
            currentAnimation.Update(gameTime);
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
                spriteBatch.Draw(texture, rectangle, currentAnimation.CurrentFrame.SourceRectangle, Color.White);
            }

            vuurbal.Draw(spriteBatch);

        }


    }
}

