using Microsoft.Xna.Framework;


namespace MonogameProject.Classes.Animations
{
    internal class AnimationFrame
    {
        //bron: slides over animaties
        public Rectangle SourceRectangle { get; set; }

        public AnimationFrame(Rectangle sourceRectangle)
        {
            SourceRectangle = sourceRectangle;
        }

    }
}
