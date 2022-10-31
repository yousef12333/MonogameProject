using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogameProject
{
    internal class Fireball
    {
        

        public List<Vector2> bullets;
        List<string> directionFireball;
        private float timer;
        bool aanmaakBullet = false;
        private Texture2D fireballTexture;
        private int bulletDirection = 6;
        Animation animation;
        public int BulletDirection
        {
            get
            {
                return bulletDirection;
            }
            set
            {
                bulletDirection = value;
            }
        }
        public Fireball(Texture2D texture)
        {

            this.fireballTexture = texture;
            bullets = new List<Vector2>();
            directionFireball = new List<string>();
            animation = new Animation();
            for (int i = 0; i < 7; i++) { animation.AddFrame(new AnimationFrame(new Rectangle(71 * i, 0, 71, 28))); }



        }
        public void ShootRight()
        {
            animation = new Animation();
            for (int i = 0; i < 7; i++) { animation.AddFrame(new AnimationFrame(new Rectangle(71 * i, 0, 71, 28))); } //functioneert niet als je beweegt
        }
        public void ShootLeft()
        {
            animation = new Animation();
            for (int i = 0; i < 7; i++) { animation.AddFrame(new AnimationFrame(new Rectangle(71 * i, 28, 71, 28))); } //functioneert niet als je beweegt
        }


        public void Update(GameTime gameTime, Vector2 position2, Vector2 position, bool isLeft, bool isRight, Texture2D image1, Texture2D image2)
        {
            animation.Update(gameTime);

            if (aanmaakBullet)
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            



            if (Keyboard.GetState().IsKeyDown(Keys.E) && aanmaakBullet == false)
            {

                position2.Y = position.Y + 10;
                bullets.Add(position2);
                if (isRight)
                {
                    directionFireball.Add("isRight");
                }
                else if (isLeft)
                {

                    directionFireball.Add("isLeft");
                }
                else if(isRight == false && isLeft == false)
                {
                    directionFireball.Add("isRight");
                }
                if(directionFireball.Count > bullets.Count)
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
                        ShootRight();
                     
                        bulletDirection = 6; 
                    }
                    else if (directionFireball[i] == "isLeft")
                    {
                        ShootLeft();
                        bulletDirection = -6; //de richting van image veranderd bij waar je player naar draait

                    }
                    bullets[i] += new Vector2(bulletDirection, 0);



                if (timer > 2)
                    {
                        bullets.Remove(bullets[i]);
                        directionFireball.Remove(directionFireball[i]);
                        aanmaakBullet = false;
                        timer = 0;
                    }
                }
        }
      
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
               spriteBatch.Draw(fireballTexture, bullets[i], animation.CurrentFrame.SourceRectangle, Color.White);
            }
        }
        
    }
}


