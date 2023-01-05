using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Warre_Gehre_GameDevelopment.GameFiles.Animations.Environment
{
    public class WaterAnimation : Animation
    {
        public WaterAnimation()
        {
            AddFrame(new AnimationFrame(new Rectangle(320, 160, 32, 64)));
            AddFrame(new AnimationFrame(new Rectangle(352, 160, 32, 64)));
            AddFrame(new AnimationFrame(new Rectangle(384, 160, 32, 64)));
            AddFrame(new AnimationFrame(new Rectangle(416, 160, 32, 64)));
            AddFrame(new AnimationFrame(new Rectangle(448, 160, 32, 64)));
        }
    }
}
