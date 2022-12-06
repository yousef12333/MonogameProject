using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject.Classes
{
    internal class AnimationModus
    {
        public Animation IdleStateRight { get; set; }
        public Animation IdleStateLeft { get; set; }
        public Animation DyingState { get; set; }
        public Animation MoveStateRight { get; set; }
        public Animation MoveStateLeft { get; set; }
        public Animation JumpLeft { get; set; }
        public Animation JumpRight { get; set; }

    }
}
