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
    internal class monsterMovement : IGameObject
    {

        Vector2 ghostPosition = new Vector2(1400, 328);
        Vector2 velocity = new Vector2(2, 0);
        public Texture2D ghost;
        public Rectangle rectangle;
        SpriteFont file;
        public int health;
        Animation animation;

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
                return ghostPosition;
            }

        }


        public monsterMovement(Texture2D texture, int newHealth)
        {

            ghost = texture;
            animation = new Animation();
            for (int i = 0; i < 4; i++) { animation.AddFrame(new AnimationFrame(new Rectangle(37 * i, 0, 37, 62))); }
            //Speler = new Player(texture, 100);
            health = newHealth;






        }

        public void Load(ContentManager Content)
        {
            ghost = Content.Load<Texture2D>("SpookBeweging");



            file = Content.Load<SpriteFont>("File");

        }
        public void Update(GameTime gameTime)
        {

            //if (Speler.rectangle.TouchTopOf(new Rectangle((int)ghostPosition.X, (int)ghostPosition.X, 64, 64)))
            //{
            //    velocity.X *= -1;
            //}

            //werkt alleen als je if(this.rectangle.X < 1450)) doet



            animation.Update(gameTime);
            int shuifopX = 0;


            shuifopX += 37;
            if (shuifopX > 148)
            {
                shuifopX = 0;
            }
            rectangle.X = shuifopX;
            rectangle = new Rectangle((int)ghostPosition.X, (int)ghostPosition.Y, 64, 64);



            move();


        }
        private void move()
        {

            ghostPosition.X += velocity.X;


            if (ghostPosition.X > 1700)
            {
                velocity.X *= -1;
                Moveleft();

            }
            else if (ghostPosition.X < 1300)
            {
                velocity.X *= -1;
                MoveRight();
            }
            rectangle = new Rectangle((int)ghostPosition.X, (int)ghostPosition.Y, 64, 64);







        }
        public void MoveRight()
        {
            animation = new Animation();
            for (int i = 0; i < 4; i++) { animation.AddFrame(new AnimationFrame(new Rectangle(37 * i, 0, 37, 62))); }


        }
        public void Moveleft()
        {
            animation = new Animation();
            for (int i = 0; i < 4; i++) { animation.AddFrame(new AnimationFrame(new Rectangle(37 * i, 62, 37, 62))); }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (health > 0)
            {
                spriteBatch.Draw(ghost, rectangle, animation.CurrentFrame.SourceRectangle, Color.White);
            }


        }

    }
}
