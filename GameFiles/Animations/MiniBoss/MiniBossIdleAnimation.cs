using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Warre_Gehre_GameDevelopment.GameFiles.Animations.MiniBoss
{
    class MiniBossIdleAnimation : Animation
    {
        public MiniBossIdleAnimation()
        {
            AddFrame(new AnimationFrame(new Rectangle(0, 192, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(64, 192, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(128, 192, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(192, 192, 64, 64)));
        }
    }
}
