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
    internal class Death
    {
        Player player;
        Ufo ufo;
        public DeathButton restart;
        public Texture2D backgroundDeath;
        public MenuButtons btnPlay;
        

        public void Load(ContentManager Content)
        {
            backgroundDeath = Content.Load<Texture2D>("Death_Screen");
            restart.setPosition(new Vector2(620, 250));
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundDeath, new Rectangle(0, 0, BioHunt.Instance.screenWidth + 80, BioHunt.Instance.screenHeight), Color.White);
            restart.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            restart.Update(mouse);
            if (restart.isRestarted == true)
            {
                btnPlay.isClicked = false;
                BioHunt.Instance.LevelStates = LevelStates.Level1; //bug, bij hoverout gaat het steeds terug van menu naar death
                player.timer = 0; //werkt gewoon, komt door knop bug, hij blijft 0 als je ingedrukt houdt en als je loslaat wordt het 2,3,4.. zie debug.writeline
                ufo.timer = 0;
                player.restarted = true;
                ufo.restarted = true;

            }



        }
    }
}

