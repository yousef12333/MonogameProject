using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogameProject.Classes
{
    internal class WinButton
    {
        Texture2D texture;
        Vector2 position;
        Rectangle rectangle;
        Color colour = new Color(255, 255, 255, 255);

        public Vector2 size;
        public WinButton(Texture2D newTexture, GraphicsDevice graphics)
        {
            texture = newTexture;
            
            size = new Vector2(graphics.Viewport.Width / 3, graphics.Viewport.Height / 5);

        }
        bool down;
        public bool isClicked;

        public void Update(MouseState mouse)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);


            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if (mouseRectangle.Intersects(rectangle))
            {
                if (colour.A == 255) down = false;
                if (colour.A == 0) down = true;
                if (down) colour.A += 9;
                else colour.A -= 9;
                if (mouse.LeftButton == ButtonState.Pressed) isClicked = true;

            }
            else if (colour.A < 255)
            {
                colour.A += 3;
                isClicked = false;
            }

        }
        public void SetPosition(Vector2 newPosition)
        {
            position = newPosition;

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, colour);

        }
    }
}
