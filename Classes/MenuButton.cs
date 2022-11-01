using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject.Classes
{
    internal class MenuButton
    {
        Texture2D texture;
        Texture2D texture2;
        Vector2 position;
        Vector2 position2;
        Rectangle rectangle;
        Rectangle rectangle2;

        Color colour = new Color(255, 255, 255, 255);
        Color colour2 = new Color(255, 255, 255, 255);

        public Vector2 size;
        public MenuButton(Texture2D newTexture, Texture2D newTexture2, GraphicsDevice graphics)
        {
            texture = newTexture;
            texture2 = newTexture2;
            size = new Vector2(graphics.Viewport.Width / 3, graphics.Viewport.Height / 5);

        }
        bool down;
        public bool isClicked;
        public bool isClosed;
        public void Update(MouseState mouse)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
            rectangle2 = new Rectangle((int)position2.X, (int)position2.Y, (int)size.X, (int)size.Y);

            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if (mouseRectangle.Intersects(rectangle))
            {
                if (colour.A == 255) down = false;
                if (colour.A == 0) down = true;
                if (down) colour.A += 3;
                else colour.A -= 3;
                if (mouse.LeftButton == ButtonState.Pressed) isClicked = true;

            }
            else if (colour.A < 255)
            {
                colour.A += 3;
                isClicked = false;
            }
            if (mouseRectangle.Intersects(rectangle2))
            {
                if (colour2.A == 255) down = false;
                if (colour2.A == 0) down = true;
                if (down) colour2.A += 3;
                else colour2.A -= 3;
                if (mouse.LeftButton == ButtonState.Pressed) isClosed = true;
            }
            else if (colour2.A < 255)
            {
                colour2.A += 3;
                isClosed = false;
            }
        }
        public void SetPosition(Vector2 newPosition, Vector2 newPosition2)
        {
            position = newPosition;
            position2 = newPosition2;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, colour);
            spriteBatch.Draw(texture2, rectangle2, colour2);
        }

    }
}
