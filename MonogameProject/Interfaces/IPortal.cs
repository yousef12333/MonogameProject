using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject.Interfaces
{
    internal interface IPortal : IUpdatable, IDrawableClass
    {
        bool Teleported { get; set; }
        List<Rectangle> Portals { get; set; }
        void AddPortal(Rectangle rect);
    }
}
