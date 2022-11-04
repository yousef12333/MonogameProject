using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Interfaces;


namespace MonogameProject.Classes
{
    internal class Portal : IGameObject
    {
        Animation animation;
        private Texture2D portal1;
        public bool teleported = false;
        private Rectangle portal = new Rectangle(1150, 640, 128, 64);

       

        public Portal(Texture2D texture)
        {

            portal1 = texture;
            animation = new Animation();
            for (int i = 0; i < 3; i++) { animation.AddFrame(new AnimationFrame(new Rectangle(205 * i, 0, 205, 104))); }


        }
        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(portal1, portal, animation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
