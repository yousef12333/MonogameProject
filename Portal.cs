using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject
{
    internal class Portal : IGameObject
    {
        Animation animation;
        private Texture2D portal1;
        public bool teleported = false;
        private Rectangle portal;
        public Portal(Texture2D texture)
        {

            this.portal1 = texture;
            animation = new Animation();
            for (int i = 0; i < 3; i++) { animation.AddFrame(new AnimationFrame(new Rectangle(205 * i, 0, 205, 104))); }


        }
        public void Load(ContentManager Content)
        {
            portal1 = Content.Load<Texture2D>("Portal");
            portal = new Rectangle(1150, 640, 128, 64);
        }
         

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
            portal = new Rectangle(1150, 640, 128, 64);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(portal1, portal, animation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
