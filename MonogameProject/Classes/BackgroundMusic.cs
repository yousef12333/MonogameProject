using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject.Classes
{
    internal class BackgroundMusic
    {
        private Song music;

        public void Load(ContentManager Content)
        {
            music = Content.Load<Song>("BackgroundMusicBetter");
        }

        public void Play()
        {
            if (MediaPlayer.State != MediaState.Playing || MediaPlayer.State == MediaState.Stopped || MediaPlayer.State == MediaState.Paused)
            {
                MediaPlayer.Volume = 0.07F;
                MediaPlayer.Play(music);
            }
        }
    }
}
