using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameProject.Classes.Animations;
using MonogameProject.Interfaces;

namespace MonogameProject.Classes.Hero
{
    internal class Player : IUpdatable, IDrawableClass
    {
        public Texture2D texture;
        public Texture2D bulletImage; 
        public Color Color { get; set; }
        public Vector2 position = new Vector2(200, 200);
        public Vector2 velocity;
        public Rectangle rectangle;
        public int health;
        public Fireball vuurbal;
        public bool restarted;
        public AnimationModus Animations { get; set; }
        public Animation CurrentAnimation { get; set; }
        Vector2 position2;
        float hitCounter = 0;
        public bool levelLoaded = false;
        bool isLeft = false;
        bool isRight = false;
        public bool IsHit { get; set; } = false;

        private bool hasJumped = false;
        private static int heartRate = 3; 
        public int HeartRate
        {
            get { return heartRate; }
            set
            {
                if (value > -1 && value < 4)
                    heartRate = value;
            }
        }
        private static Player instance;
        public static Player Instance
        {
            get
            {
                instance ??= new Player();
                    
                return instance;
            }
        }
        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }

        }
        public Player(Texture2D texture, int newHealth, Texture2D bullet)
        {
            this.texture = texture;
            health = newHealth;
            vuurbal = new Fireball(bullet);
            Color = new Color();
            Color = Color.White;
            Animations = new AnimationModus
            {
                MoveStateRight = new Animation(),
                MoveStateLeft = new Animation(),
                IdleStateRight = new Animation(),
                IdleStateLeft = new Animation(),
                JumpRight = new Animation(),
                JumpLeft = new Animation()
            };
            for (int i = 0; i < 2; i++)
            {
                Animations.MoveStateRight.AddFrame(new AnimationFrame(new Rectangle(40 * i, 0, 40, 47)));
            }
            for (int i = 0; i < 2; i++)
            {
                Animations.MoveStateLeft.AddFrame(new AnimationFrame(new Rectangle(40 * i, 49, 40, 49)));

            }
            Animations.IdleStateRight.AddFrame(new AnimationFrame(new Rectangle(0, 0, 40, 47)));
            Animations.IdleStateLeft.AddFrame(new AnimationFrame(new Rectangle(0, 49, 40, 49)));
            Animations.JumpRight.AddFrame(new AnimationFrame(new Rectangle(120, 0, 40, 49)));
            Animations.JumpLeft.AddFrame(new AnimationFrame(new Rectangle(120, 49, 40, 49)));
            CurrentAnimation = Animations.IdleStateRight;
           
        }

        public Player()
        {
        }
        private void Input()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                
                if(velocity.X < 3.7F)
                {
                    velocity.X += 0.15F;
                }
                if (hasJumped == false) CurrentAnimation = Animations.MoveStateRight;
                isRight = true;
                isLeft = false;
                

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                
                if (velocity.X > -3.7F)
                {
                    velocity.X -= 0.15F;
                }
                if (hasJumped == false) CurrentAnimation = Animations.MoveStateLeft;
                isLeft = true;
                isRight = false;
                
            }
            else
            {
                
                velocity.X = 0F;
                if (isRight && hasJumped == false)
                {
                    CurrentAnimation = Animations.IdleStateRight;
                }
                else if (isLeft && hasJumped == false)
                {
                    CurrentAnimation = Animations.IdleStateLeft;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false && isRight)
            {
                position.Y -= 4F;
                velocity.Y = -9F;
                hasJumped = true;

                CurrentAnimation = Animations.JumpRight;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false && isLeft)
            {
                position.Y -= 4F;
                velocity.Y = -9F;
                hasJumped = true;
                CurrentAnimation = Animations.JumpLeft;

            }
        }
        public void Update(GameTime gameTime)
        {
            if (restarted == true)
            {
                Position = new Vector2(203, 200);
                velocity.Y = 0F;
            }
            position += velocity;
            position2 = position;
          
            CurrentAnimation.Update(gameTime);
           
            if (levelLoaded)
            {
                if (velocity.Y < 20) velocity.Y += 0.22F;
                    restarted = false;
            }
            else
            {
                velocity.X = 0;
                
            }
            if (IsHit == true)
            {
                
                Color = Color.Red;
                hitCounter += (float)gameTime.ElapsedGameTime.TotalSeconds;

            }
            if(hitCounter > 2)
            {
                Color = Color.White;
                hitCounter = 0;
                IsHit = false;
            }
            vuurbal.Update(gameTime, position2, position, isLeft, isRight, bulletImage, bulletImage);
            rectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);
            Input();
        }
        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            for(int i = 0; i < vuurbal.Rectangle.Count; i++)
            {
                if (vuurbal.Rectangle[i].CollideLeft(newRectangle) || vuurbal.Rectangle[i].CollideRight(newRectangle))
                {
                    vuurbal.bullets.Remove(vuurbal.bullets[i]);
                    vuurbal.fireballRect.Remove(vuurbal.fireballRect[i]);
                    vuurbal.aanmaakBullet = false;
                    vuurbal.timer = 0;
                    vuurbal.directionFireball.RemoveAt(vuurbal.directionFireball.Count - 1);
                }
            }
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
                position.X = newRectangle.X + rectangle.Width;
            }
            if (rectangle.TouchBottomOf(newRectangle)) velocity.Y = 1F;

            if (position.X < 0) position.X = 0;
            if (position.X > xOffset - rectangle.Width) position.X = xOffset - rectangle.Width;
            if (position.Y < 0) {
                velocity.Y = 0;
                position.Y = 0.01F;
                
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
          spriteBatch.Draw(texture, rectangle, CurrentAnimation.CurrentFrame.SourceRectangle, Color);
          vuurbal.Draw(spriteBatch);
        }
    }
}
/*ISP: gebruikt alleen draw en update of eventueel zelfgemaakte methoden, en de interfaces geven de draw en update methoden apart aan dit klasse*/

