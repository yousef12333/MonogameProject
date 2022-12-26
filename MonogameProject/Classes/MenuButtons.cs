using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogameProject.Classes
{
    internal class MenuButtons
    {
        Texture2D texturePlay;
        Texture2D textureQuit;
        Vector2 positionPlay;
        Vector2 positionQuit;
        Rectangle rectanglePlay;
        Rectangle rectangleQuit;
        Color colourPlay = new Color(255, 255, 255, 255); //twee knoppen komen op twee verschillende posities te staan en zullen allebei een verschillende functionaliteit hebben.
        Color colourQuit = new Color(255, 255, 255, 255);
        public Vector2 size;
        public MenuButtons(Texture2D newTexture, Texture2D newTexture2, GraphicsDevice graphics)
        {
            texturePlay = newTexture;
            textureQuit = newTexture2;
            size = new Vector2(graphics.Viewport.Width / 3, graphics.Viewport.Height / 5);
        }
        bool down;
        public bool isClicked;
        public bool isClosed;
        public void Update(MouseState mouse)
        {
            rectanglePlay = new Rectangle((int)positionPlay.X, (int)positionPlay.Y, (int)size.X, (int)size.Y);
            rectangleQuit = new Rectangle((int)positionQuit.X, (int)positionQuit.Y, (int)size.X, (int)size.Y);
            Rectangle mouseRectangle = new(mouse.X, mouse.Y, 1, 1);

            UpdateButton(mouseRectangle, rectanglePlay, ref colourPlay, ref isClicked, mouse);
            UpdateButton(mouseRectangle, rectangleQuit, ref colourQuit, ref isClosed, mouse);
        }

        private void UpdateButton(Rectangle mouseRectangle, Rectangle rectangle, ref Color colour, ref bool state, MouseState mouse)
        {
            if (mouseRectangle.Intersects(rectangle))
            {
                if (colour.A == 255) down = false;
                if (colour.A == 0) down = true;
                if (down) colour.A += 3;
                else colour.A -= 3;
                if (mouse.LeftButton == ButtonState.Pressed) state = true;
            }
            else if (colour.A < 255)
            {
                colour.A += 3;
                state = false;
            }
        }

        public void SetPosition(Vector2 newPosition, Vector2 newPosition2)
        {
            positionPlay = newPosition;
            positionQuit = newPosition2;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texturePlay, rectanglePlay, colourPlay);
            spriteBatch.Draw(textureQuit, rectangleQuit, colourQuit);
        }
    }
}

