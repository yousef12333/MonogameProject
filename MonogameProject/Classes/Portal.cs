using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Classes.Animations;
using MonogameProject.Interfaces;
using System.Collections.Generic;

namespace MonogameProject.Classes
{
    internal class Portal : IPortal
{
    Animation animation;
    private Texture2D portal1;
    public bool teleported = false;
    public List<Rectangle> portals = new List<Rectangle>();

    public bool Teleported
    {
        get { return teleported; }
        set { teleported = value; }
    }

    public List<Rectangle> Portals
    {
        get { return portals; }
        set { portals = value; }
    }

    public Portal(Texture2D texture)
    {
        portal1 = texture;
        animation = new Animation();
        for (int i = 0; i < 3; i++) { animation.AddFrame(new AnimationFrame(new Rectangle(205 * i, 0, 205, 104))); }
    }

    public void AddPortal(Rectangle rect)
    {
        portals.Add(rect);
    }

    public void Update(GameTime gameTime)
    {
        animation.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        for (int i = 0; i < portals.Count; i++)
        {
            spriteBatch.Draw(portal1, portals[i], animation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
}
//LSP: volgt het Liskov Substitutie Principe omdat het de Iportal interface implementeert, die het gedrag specificeert dat wordt verwacht van objecten die
//kunnen worden gebruikt in plaats van dan in portal klasse the specifieren. Door de interface te implementeren,
//zorgt portal ervoor dat het het vereiste gedrag heeft en dat je dit specifieke overridet gedrag overal kunt gebruiken waar een instantie
//van dat interface wordt verwacht, die zal dus op dezelfde manier gedragen als de bovenliggende klasse



