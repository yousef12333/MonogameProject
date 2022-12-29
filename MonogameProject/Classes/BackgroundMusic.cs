using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;


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
