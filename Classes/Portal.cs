using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Interfaces;
using System.Collections.Generic;

namespace MonogameProject.Classes
{
    internal class Portal : IGameObject
    {
        Animation animation;
        private Texture2D portal1;
        public bool teleported = false;
        public List<Rectangle> portals = new List<Rectangle>();


        public Portal(Texture2D texture)
        {

            portal1 = texture;
            animation = new Animation();
            for (int i = 0; i < 3; i++) { animation.AddFrame(new AnimationFrame(new Rectangle(205 * i, 0, 205, 104))); }


        }
        public void AddPortal(Rectangle rect)
        {
            portals.Add(rect);
        }
        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < portals.Count; i++)
            {
                spriteBatch.Draw(portal1, portals[i], animation.CurrentFrame.SourceRectangle, Color.White);
            }
            
        }
    }
}
