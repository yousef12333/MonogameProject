using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using MonogameProject.Interfaces;
using MonogameProject.Classes;

namespace MonogameProject.Classes.Enemies
{
    internal class GhostMonster : IGameObject
    {

        Vector2 ghostPosition = new Vector2(1400, 323);
        Vector2 velocity = new Vector2(2, 0);
        public Texture2D ghost;
        public Rectangle rectangle;
        public int health;
        public AnimationModus animations { get; set; }
        public Animation currentAnimation { get; set; }
        public Rectangle Rectangle { get { return rectangle; } }
        public Vector2 Position{ get{ return ghostPosition; }}
        public Vector2 Velocity { get { return velocity; } set{ velocity = value; }}
        public GhostMonster(Texture2D texture, int newHealth)
        {
            ghost = texture;
            animations = new AnimationModus();
            animations.MoveStateRight = new Animation();
            animations.MoveStateLeft = new Animation();
            for (int i = 0; i < 4; i++) { animations.MoveStateRight.AddFrame(new AnimationFrame(new Rectangle(37 * i, 0, 37, 62))); }
            for (int i = 0; i < 4; i++) { animations.MoveStateLeft.AddFrame(new AnimationFrame(new Rectangle(37 * i, 62, 37, 62))); }
            health = newHealth;
            currentAnimation = animations.MoveStateRight;
        }
        public void Update(GameTime gameTime)
        {
            currentAnimation.Update(gameTime);
            rectangle = new Rectangle((int)ghostPosition.X, (int)ghostPosition.Y, 74, 74);
            move();
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
            if (health > 0)
            {
                spriteBatch.Draw(ghost, rectangle, currentAnimation.CurrentFrame.SourceRectangle, Color.White);
            }
        }
    }
}
