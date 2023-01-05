using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Warre_Gehre_GameDevelopment.GameFiles.Animations.MiniBoss
{
    class MiniBossDieAnimation : Animation
    {
        public MiniBossDieAnimation()
        {
            AddFrame(new AnimationFrame(new Rectangle(0, 64, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(64, 64, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(128, 64, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(192, 64, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(256, 64, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(320, 64, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(384, 64, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(448, 64, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(512, 64, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(576, 64, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(640, 64, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(704, 64, 64, 64)));
            AddFrame(new AnimationFrame(new Rectangle(768, 64, 64, 64)));
        }
    }
}
