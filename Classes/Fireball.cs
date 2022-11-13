using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogameProject.Classes
{
    internal class Fireball
    {
        public List<Vector2> bullets;
        public List<string> directionFireball;
        public List<Rectangle> fireballRect;
        public float timer;
        public bool aanmaakBullet = false;
        private Texture2D fireballTexture;
        private int bulletDirection = 6;
        public AnimationModus animations { get; set; }
        public Animation currentAnimation { get; set; }
        public List<Rectangle> Rectangle { get { return fireballRect; } set { fireballRect = value; } }

        public int BulletDirection { get { return bulletDirection; } set { bulletDirection = value; } }
        public Fireball(Texture2D texture)
        {
            
            fireballTexture = texture;
            bullets = new List<Vector2>();
            fireballRect = new List<Rectangle>();
            directionFireball = new List<string>();
            animations = new AnimationModus();
            animations.MoveStateRight = new Animation();
            animations.MoveStateLeft = new Animation();
            for (int i = 0; i < 7; i++) { animations.MoveStateRight.AddFrame(new AnimationFrame(new Rectangle(71 * i, 0, 71, 28))); }
            for (int i = 0; i < 7; i++) { animations.MoveStateLeft.AddFrame(new AnimationFrame(new Rectangle(71 * i, 28, 71, 28))); }
            currentAnimation = animations.MoveStateRight;
        }
        public void Update(GameTime gameTime, Vector2 position2, Vector2 position, bool isLeft, bool isRight, Texture2D image1, Texture2D image2)
        {
            currentAnimation.Update(gameTime);
            if (aanmaakBullet) timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Keyboard.GetState().IsKeyDown(Keys.E) && aanmaakBullet == false)
            {
                position2.Y = position.Y + 10;
                bullets.Add(position2);
                fireballRect.Add(new Rectangle((int)position2.X, (int)position2.Y, currentAnimation.CurrentFrame.SourceRectangle.Width, currentAnimation.CurrentFrame.SourceRectangle.Height));
                if (isRight)
                {
                    directionFireball.Add("isRight");
                }
                else if (isLeft)
                {

                    directionFireball.Add("isLeft");
                }
                else if (isRight == false && isLeft == false)
                {
                    directionFireball.Add("isRight");
                }
                if (directionFireball.Count > fireballRect.Count)
                {
                    directionFireball.RemoveAt(directionFireball.Count - 1);
                }
                aanmaakBullet = true;
            }
            for (int i = 0; i < bullets.Count; i++)
            {
                int x = (int)bullets[i].X;
                bullets[i] = new Vector2(x, bullets[i].Y);
               
                if (directionFireball[i] == "isRight")
                {
                    currentAnimation = animations.MoveStateRight;
                    bulletDirection = 6;
                }
                else if (directionFireball[i] == "isLeft")
                {
                    currentAnimation = animations.MoveStateLeft;
                    bulletDirection = -6; //de richting van image veranderd bij waar je player naar draait
                }
                bullets[i] += new Vector2(bulletDirection, 0);
                fireballRect[i] = new Rectangle((int)bullets[i].X, (int)bullets[i].Y, currentAnimation.CurrentFrame.SourceRectangle.Width, currentAnimation.CurrentFrame.SourceRectangle.Height);

                if (timer > 2)
                {
                    bullets.Remove(bullets[i]);
                    fireballRect.Remove(fireballRect[i]);
                    aanmaakBullet = false;
                    timer = 0;
                    directionFireball.RemoveAt(directionFireball.Count - 1);
                }
            }
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                spriteBatch.Draw(fireballTexture, fireballRect[i], currentAnimation.CurrentFrame.SourceRectangle, Color.White);
            }
        }

    }
}


