using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Warre_Gehre_GameDevelopment.GameFiles.Animations.MiniBoss
{
    class MiniBossAttackingAnimation : Animation
    {
        public MiniBossAttackingAnimation()
        {
            AddFrame(new AnimationFrame(new Rectangle(0, 0, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(64, 0, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(128, 0, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(192, 0, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(256, 0, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(320, 0, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(384, 0, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(448, 0, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(512, 0, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(576, 0, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(640, 0, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(704, 0, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(768, 0, 64, 64)));
        }
    }
}
