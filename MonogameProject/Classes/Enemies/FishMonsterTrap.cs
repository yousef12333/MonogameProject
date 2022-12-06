using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Classes;
using MonogameProject.Interfaces;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonogameProject.Classes.Enemies
{
    internal class FishMonsterTrap : IGameObject
    {
        Vector2 fishPosition = new Vector2(1200, 60);
        Vector2 velocity = new Vector2(2, 0);
        public Vector2 Velocity { get { return velocity; } set { velocity = value; } }
        public Texture2D fishImage;
        public Rectangle rectangle;
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
        public FishMonsterTrap(Texture2D texture, int newHealth)
        {
            fishImage = texture;
            animations = new AnimationModus();
            animations.MoveStateRight = new Animation();
            animations.MoveStateLeft = new Animation();
            for (int i = 0; i < 4; i++) { animations.MoveStateRight.AddFrame(new AnimationFrame(new Rectangle(142 * i, 0, 142, 75))); }
            for (int i = 0; i < 4; i++) { animations.MoveStateLeft.AddFrame(new AnimationFrame(new Rectangle(142 * i, 75, 142, 75))); }
            currentAnimation = animations.MoveStateRight;
            health = newHealth;
        }
        public void Update(GameTime gameTime)
        {
            currentAnimation.Update(gameTime);
            if (health < 1) rectangle = new Rectangle(1900, (int)fishPosition.Y, 130, 80); 
            else{rectangle = new Rectangle((int)fishPosition.X, (int)fishPosition.Y, 130, 80);}
            move();
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
            spriteBatch.Draw(fishImage, rectangle, currentAnimation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}















