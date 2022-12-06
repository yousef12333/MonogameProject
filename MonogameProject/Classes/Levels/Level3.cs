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
using MonogameProject.Tiles;
using static System.Net.Mime.MediaTypeNames;
using SharpDX.Direct3D9;
using MonogameProject.Classes.Enemies;
using Microsoft.Xna.Framework.Content;
using MonogameProject.Screen;
using MonogameProject.Collision;

namespace MonogameProject.Classes.Levels
{
    internal class Level3
    {
        BackgroundMusic music;

        public Level3()
        {

            music = new BackgroundMusic();

        }
        private static Level3 instance;

        public static Level3 Instance
        {
            get
            {
                if (instance == null)
                    instance = new Level3();

                return instance;
            }
        }
        public void Load(ContentManager Content)
        {



            music.Load(Content);

        }
        public void Update(GameTime gameTime)
        {



        }
        public void Draw(SpriteBatch spriteBatch)
        {

            music.Draw(spriteBatch);

        }
    }
}
