using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Classes;
using MonogameProject.Interfaces;

namespace MonogameProject.Tiles
{
    //Bron:  https://www.youtube.com/watch?v=PKlHcxFAEk0 deel1 en 2
    //Bron: DIP heb ik geleerd van de slides van het vak .NET advanced
    internal class Tiles
    {
        protected Texture2D texture;
        private Rectangle rectangle;
        public Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }

        }
        private static ContentManager content;
        public static ContentManager Content
        {
            get { return content; }
            set
            {
                content = value;
            }
        }

        private readonly ITileColorProvider colorProvider;

        public Tiles(ITileColorProvider colorProvider)
        {
            this.colorProvider = colorProvider;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, colorProvider.GetColor());
        }
    }

    internal class CollisionTiles : Tiles
    {
        public CollisionTiles(int i, Rectangle newRectangle) : base(new TileColors())
        {
            texture = Content.Load<Texture2D>("Tile" + i);
            Rectangle = newRectangle;
        }
    }
}
/*SRP: Tiles zorgt voor tekenen textuur van tegels, collisiontiles zorgt ervoor dat de tiles uiteindelijk zijn collision meegegeven krijgt.

 
 Design pattern: DIP (Dependency Injection Pattern): In dit geval is de klasse tiles afhankelijk van een instantie van de ITileColorProvider om de kleur voor de tiles te meegeven, 
en de klasse CollisionTiles injecteert deze afhankelijkheid in de basisklasse door een instantie van de klasse TileColors door te geven aan 
de constructor van de basisklasse. (misschien een slechte uitleg maar als je tilecolors and ITilecolorprovider bekijkt, is het correct)
 */