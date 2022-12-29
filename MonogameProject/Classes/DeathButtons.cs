﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MonogameProject.Classes
{
    internal class DeathButtons
    {
        Texture2D texture;
        Vector2 position;
        Rectangle rectangle;
        Color colour = new Color(255, 255, 255, 255);


        public Vector2 size;
        private static DeathButtons instance;
        public static DeathButtons Instance
        {
            get
            {
                if (instance == null)
                    instance = new DeathButtons();

                return instance;
            }
        }
        public DeathButtons(Texture2D newTexture, GraphicsDevice graphics)
        {
            texture = newTexture;

            size = new Vector2(graphics.Viewport.Width / 3, graphics.Viewport.Height / 5);

        }

      

        bool down;
        public bool isRestarted;

        public void Update(MouseState mouse)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);


            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if (mouseRectangle.Intersects(rectangle))
            {
                if (colour.A == 255) down = false;
                if (colour.A == 0) down = true;
                if (down) colour.A += 3;
                else colour.A -= 3;
                if (mouse.LeftButton == ButtonState.Pressed) isRestarted = true;
            }
            else if (colour.A < 255)
            {
                colour.A += 3;
                isRestarted = false;
            }

        }
        public void setPosition(Vector2 newPosition)
        {
            position = newPosition;

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, colour);

        }
        public DeathButtons()
        {
        }
    }
}

