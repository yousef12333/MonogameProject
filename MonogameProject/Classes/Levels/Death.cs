using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace MonogameProject.Classes.Levels
{
    internal class Death
    {
        DeathButtons restart;
        Rectangle mouseRectangle;
        Texture2D deathBackground;
        public Death()
        {

        }
        public void Load(ContentManager Content, GraphicsDevice graphics)
        {
            restart = new DeathButtons(Content.Load<Texture2D>("Restart_Button"), graphics);
            deathBackground = Content.Load<Texture2D>("Death_Screen");
            restart.setPosition(new Vector2((BioHunt.Instance.screenWidth / 2)-100, 250));
        }
        public void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            mouseRectangle = new Rectangle(mouse.X, mouse.Y, 5, 5);
            restart.Update(mouse);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(deathBackground, new Rectangle(0, 0, BioHunt.Instance.screenWidth + 80, BioHunt.Instance.screenHeight), Color.White);
            restart.Draw(spriteBatch);
        }
    }
}
