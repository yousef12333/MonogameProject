using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Interfaces;

namespace MonogameProject.Classes.Enemies
{
    internal class GhostMonster : IGameObject
    {
        Vector2 ghostPosition = new Vector2(1400, 323);
        Vector2 velocity = new Vector2(2, 0);
        public Texture2D ghost;
        public Rectangle rectangle;
        public int health;
        Trails trail;
        public AnimationModus animations { get; set; }
        public Animation currentAnimation { get; set; }
        public Rectangle Rectangle { get { return rectangle; } }
        public Vector2 Velocity { get { return velocity; } set { velocity = value; } }
        public GhostMonster(Texture2D texture, int newHealth)
        {
            trail = new Trails();
            trail.maxTrails = 3;
            trail.trailDelay = 10;
            trail.trailDelayCounter = 0;
            ghost = texture;
            animations = new AnimationModus();
            animations.MoveStateRight = new Animation();
            animations.MoveStateLeft = new Animation();
            for (int i = 0; i < 4; i++)
            {
                animations.MoveStateRight.AddFrame(new AnimationFrame(new Rectangle(37 * i, 0, 37, 62)));
            }
            for (int i = 0; i < 4; i++)
            {
                animations.MoveStateLeft.AddFrame(new AnimationFrame(new Rectangle(37 * i, 62, 37, 62)));
            }
            health = newHealth;
            currentAnimation = animations.MoveStateRight;
        }
        public void Update(GameTime gameTime)
        {
            currentAnimation.Update(gameTime);
            if (health < 1) rectangle = new Rectangle(1900, (int)ghostPosition.Y, 74, 74);
            else{rectangle = new Rectangle((int)ghostPosition.X, (int)ghostPosition.Y, 74, 74);}
            move();
            trail.Update(gameTime, rectangle);
        }
        private void move()
        {
            ghostPosition.X += velocity.X;
            if (ghostPosition.X > 1700)
            {
                velocity.X *= -1;
            }
            else if (ghostPosition.X < 1300)
            {
                velocity.X *= -1;
            }
            if(velocity.X > 1)
            {
                currentAnimation = animations.MoveStateRight;
            }
            else if(velocity.X < -1)
            {
                currentAnimation = animations.MoveStateLeft;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < trail.previousPositions.Count; i++)
            {
                spriteBatch.Draw(ghost,new Rectangle((int)trail.previousPositions[i].X, (int)trail.previousPositions[i].Y, 74, 74),currentAnimation.CurrentFrame.SourceRectangle,Color.White * 0.5F);
            }
            spriteBatch.Draw(ghost, rectangle, currentAnimation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
