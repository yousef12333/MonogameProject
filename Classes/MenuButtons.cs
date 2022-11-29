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
    internal class MenuButtons
    {
        Texture2D texturePlay;
        Texture2D textureQuit;
        Vector2 positionPlay;
        Vector2 positionQuit;
        Rectangle rectanglePlay;
        Rectangle rectangleQuit;

        Color colourPlay = new Color(255, 255, 255, 255);
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

           
                if (mouseRectangle.Intersects(rectanglePlay))
                {
                    if (colourPlay.A == 255) down = false;
                    if (colourPlay.A == 0) down = true;
                    if (down) colourPlay.A += 3;
                    else colourPlay.A -= 3;
                    if (mouse.LeftButton == ButtonState.Pressed) isClicked = true;
                }
                else if (colourPlay.A < 255)
                {
                colourPlay.A += 3;
                isClicked = false;
                }
                if (mouseRectangle.Intersects(rectangleQuit))
                {
                    if (colourQuit.A == 255) down = false;
                    if (colourQuit.A == 0) down = true;
                    if (down) colourQuit.A += 3;
                    else colourQuit.A -= 3;
                    if (mouse.LeftButton == ButtonState.Pressed) isClosed = true;
                }
                else if (colourQuit.A < 255)
                {
                    colourQuit.A += 3;
                    isClosed = false;
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
