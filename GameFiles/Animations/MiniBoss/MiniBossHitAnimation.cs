using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Warre_Gehre_GameDevelopment.GameFiles.Animations.MiniBoss
{
    class MiniBossHitAnimation : Animation
    {
        public MiniBossHitAnimation()
        {
            AddFrame(new AnimationFrame(new Rectangle(0, 256, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(64, 256, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(128, 256, 64, 64)));
        }
    }
}
