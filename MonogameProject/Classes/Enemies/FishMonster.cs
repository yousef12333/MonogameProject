using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Interfaces;

namespace MonogameProject.Classes.Enemies
{
    internal class FishMonster : IUpdatable, IDrawableClass
    {
        Vector2 fishPosition = new Vector2(1200, 60);
        Vector2 velocity = new Vector2(2, 0);
        public Vector2 Velocity { get { return velocity; } set { velocity = value; } }
        public Texture2D fishImage;
        public Rectangle rectangle;
        Trails trail;
        public AnimationModus animations { get; set; }
        public Animation currentAnimation { get; set; }
        public int health;
        public Rectangle Rectangle
        {
            get
            {
                return rectangle;
            }
        }
        public FishMonster(Texture2D texture, int newHealth)
        {
            trail = new Trails();
            trail.maxTrails = 3;
            trail.trailDelay = 10;
            trail.trailDelayCounter = 0;
            fishImage = texture;
            animations = new AnimationModus();
            animations.MoveStateRight = new Animation();
            animations.MoveStateLeft = new Animation();
            for (int i = 0; i < 4; i++)
            {
                animations.MoveStateRight.AddFrame(new AnimationFrame(new Rectangle(142 * i, 0, 142, 75)));
            }
            for (int i = 0; i < 4; i++)
            {
                animations.MoveStateLeft.AddFrame(new AnimationFrame(new Rectangle(142 * i, 75, 142, 75)));
            }
            currentAnimation = animations.MoveStateRight;
            health = newHealth;
        }
        public void Update(GameTime gameTime)
        {
            currentAnimation.Update(gameTime);
            if (health < 1)
            {
                rectangle = new Rectangle(1900, (int)fishPosition.Y, 130, 80);
            }
            else
            {
                rectangle = new Rectangle((int)fishPosition.X, (int)fishPosition.Y, 130, 80);
            }
            move();
            trail.Update(gameTime, rectangle);
        }
        private void move()
        {
            fishPosition.X += velocity.X;
            if ((fishPosition.X - rectangle.Width) > 1380)
            {
                velocity.X *= -1;
            }
            else if ((fishPosition.X - rectangle.Width) < 950)
            {
                velocity.X *= -1;
            }
            if (velocity.X > 1)
            {
                currentAnimation = animations.MoveStateRight;
            }
            else if (velocity.X < -1)
            {
                currentAnimation = animations.MoveStateLeft;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < trail.previousPositions.Count; i++)
            {
                spriteBatch.Draw(
                    fishImage,
                    new Rectangle((int)trail.previousPositions[i].X, (int)trail.previousPositions[i].Y, 130, 80),
                    currentAnimation.CurrentFrame.SourceRectangle,
                    Color.White * 0.5F
                );
            }
            spriteBatch.Draw(fishImage,rectangle,currentAnimation.CurrentFrame.SourceRectangle,Color.White);
        }
    }
}
/*ISP: gebruikt alleen draw en update of eventueel zelfgemaakte methoden, en de interfaces geven de draw en update methoden apart aan dit klasse*/















