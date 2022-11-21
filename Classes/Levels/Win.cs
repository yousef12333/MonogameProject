using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Reflection.Metadata;
using Microsoft.VisualBasic.Devices;
using Mouse = Microsoft.Xna.Framework.Input.Mouse;
using MonogameProject.ViewStates;
using MonogameProject.Classes.Hero;

namespace MonogameProject.Classes.Levels
{
    internal class Win
    {
        Player player;
        Ufo ufo;
        public DeathButton restart;
        public Texture2D backgroundDeath;
        public MenuButtons btnPlay;
        public GraphicsDevice GraphicsDevice;
        private Texture2D winScreen;
        WinButton winEindigKnop;

        public void Load(ContentManager Content)
        {
            winScreen = Content.Load<Texture2D>("Win_Background");
            winEindigKnop = new WinButton(Content.Load<Texture2D>("Quit_Button"), GraphicsDevice);
            winEindigKnop.SetPosition(new Vector2(640, 450));
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundDeath, new Rectangle(0, 0, BioHunt.Instance.screenWidth + 80, BioHunt.Instance.screenHeight), Color.White);
            restart.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            if (winEindigKnop.isClicked == true) BioHunt.Instance.Exit();
            winEindigKnop.Update(mouse);



        }
    }
}
