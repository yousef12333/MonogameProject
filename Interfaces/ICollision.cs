using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MonogameProject.Interfaces
{
    internal interface ICollision
    {
        Rectangle collisionHitbox { get; set; }
    }
}
