using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Interfaces;

namespace MonogameProject.Classes.Enemies
{
    internal class BossMonster : IUpdatable, IDrawableClass
    {
        Vector2 bossPosition = new Vector2(1400, 515);
        Vector2 velocity = new Vector2(9, 0);
        public Texture2D boss;
        Trails trail;
        public Rectangle rectangle;
        public bool goLeft = false;
        public bool goRight = false;
        public bool timerLeft = false;
        public bool timerRight = false;
        public int health;
        public float VelocityX { get { return velocity.X; } set { velocity.X = value; } }
        public AnimationModus animations { get; set; }
        public Animation currentAnimation { get; set; }
        public Rectangle Rectangle
        {
            get
            {
                return rectangle;
            }
        }
        public BossMonster(Texture2D texture, int newHealth)
        {
            boss = texture;
            animations = new AnimationModus();
            trail = new Trails();
            animations.MoveStateRight = new Animation();
            animations.MoveStateLeft = new Animation();
            for (int i = 0; i < 5; i++) { animations.MoveStateRight.AddFrame(new AnimationFrame(new Rectangle(89 * i, 0, 86, 71))); }
            for (int i = 0; i < 5; i++) { animations.MoveStateLeft.AddFrame(new AnimationFrame(new Rectangle(88 * i, 71, 86, 71))); }
            health = newHealth;
            currentAnimation = animations.MoveStateRight;
        }
        public void Update(GameTime gameTime)
        {
            currentAnimation.Update(gameTime);
            rectangle = new Rectangle((int)bossPosition.X, (int)bossPosition.Y, 160, 128);
            move(gameTime);
            trail.Update(gameTime, rectangle);
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
            }
            else if (bossPosition.X < 50)
            {
                velocity.X = -9;
                velocity.X *= -1;
                goLeft = false;
                goRight = true;
            }
            if (velocity.X > 1) currentAnimation = animations.MoveStateRight;
            else if (velocity.X < -1) currentAnimation = animations.MoveStateLeft;
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
            for (int i = 0; i < trail.previousPositions.Count; i++)
            {
                spriteBatch.Draw(boss, new Rectangle((int)trail.previousPositions[i].X, (int)trail.previousPositions[i].Y, 160, 128), currentAnimation.CurrentFrame.SourceRectangle, Color.White * 0.4F);
            }
            spriteBatch.Draw(boss, rectangle, currentAnimation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
/*ISP: gebruikt alleen draw en update of eventueel zelfgemaakte methoden, en de interfaces geven de draw en update methoden apart aan dit klasse*/
