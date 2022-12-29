using Microsoft.Xna.Framework;

namespace MonogameProject.Classes
{//Bron: https://www.youtube.com/watch?v=CV8P9aq2gQo
    internal static class RectangleHelperFireball
    {
        public static bool CollideLeft(this Rectangle r1, Rectangle r2)
        {
            return r1.Right <= r2.Right + 29 &&
                    r1.Right >= r2.Left + 29 &&
                    r1.Top <= r2.Bottom - r2.Width / 4 &&
                    r1.Bottom >= r2.Top + r2.Width / 4;
        }
        public static bool CollideRight(this Rectangle r1, Rectangle r2)
        {
            return r1.Left >= r2.Left - 25 &&
                    r1.Left <= r2.Right - 25 &&
                    r1.Top <= r2.Bottom - r2.Width / 4 &&
                    r1.Bottom >= r2.Top + r2.Width / 4;
        }
    }
}
