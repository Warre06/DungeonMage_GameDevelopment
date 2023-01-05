using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Warre_Gehre_GameDevelopment.GameFiles.Animations.MiniBoss
{
    class MiniBossWalkingAnimation : Animation
    {
        public MiniBossWalkingAnimation()
        {
            AddFrame(new AnimationFrame(new Rectangle(0, 128, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(64, 128, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(128, 128, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(192, 128, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(256, 128, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(320, 128, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(384, 128, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(448, 128, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(512, 128, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(576, 128, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(640, 128, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(704, 128, 64, 64)));
        }
    }
}
