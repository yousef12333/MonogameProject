using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Classes;
using MonogameProject.Interfaces;
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
        Vector2 fishPosition = new Vector2(1400, 320);
        Vector2 velocity = new Vector2(2, 0);
        public Texture2D fishImage;
        public Rectangle rectangle;
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
                return fishPosition;
            }

        }
        public FishMonsterTrap(Texture2D texture)
        {

            fishImage = texture;
            animation = new Animation();
            for (int i = 0; i < 4; i++) { animation.AddFrame(new AnimationFrame(new Rectangle(142 * i, 75, 142, 75))); }
            //player = new Player();
        }
        public void Load(ContentManager Content)
        {
            fishImage = Content.Load<Texture2D>("FishmonsterMovement4");

        }
        public void MoveLeft()
        {
            animation = new Animation();
            for (int i = 0; i < 4; i++) { animation.AddFrame(new AnimationFrame(new Rectangle(142 * i, 75, 142, 75))); }
        }
        public void MoveRight()
        {
            animation = new Animation();
            for (int i = 0; i < 4; i++) { animation.AddFrame(new AnimationFrame(new Rectangle(142 * i, 0, 142, 75))); }
        }

        public void Update(GameTime gameTime)
        {


            animation.Update(gameTime);
            rectangle = new Rectangle((int)fishPosition.X, (int)fishPosition.Y, 64, 64);
            move();
        }
        private void move()
        {
            fishPosition.X += velocity.X;


            if ((fishPosition.X - rectangle.Width) > 1600)
            {
                velocity.X *= -1;
                MoveLeft();

            }
            else if ((fishPosition.X - rectangle.Width) < 1300)
            {
                velocity.X *= -1;
                MoveRight();
            }
            rectangle = new Rectangle((int)fishPosition.X, (int)fishPosition.Y, 128, 80);




        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(fishImage, rectangle, animation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}















