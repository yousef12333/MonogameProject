using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject.Screen
{
    internal class ScreenSettings
    {
        public int screenWidth = 1790, screenHeight = 703;
        public bool objectInitialized = false;
        public bool monsterHit = false;
        public bool IsMouseVisible = true;

        private static ScreenSettings instance;
        public static ScreenSettings Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScreenSettings();

                return instance;
            }
        }

    }
}
