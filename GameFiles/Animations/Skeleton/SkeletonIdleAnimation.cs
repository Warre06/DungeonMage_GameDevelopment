using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Warre_Gehre_GameDevelopment.GameFiles.Animations.Skeleton
{
    class SkeletonIdleAnimation : Animation
    {
        public SkeletonIdleAnimation()
        {
            AddFrame(new AnimationFrame(new Rectangle(0, 0, 24, 32)));
            AddFrame(new AnimationFrame(new Rectangle(24, 0, 24, 32)));
            AddFrame(new AnimationFrame(new Rectangle(48, 0, 24, 32)));
            AddFrame(new AnimationFrame(new Rectangle(72, 0, 24, 32)));
            AddFrame(new AnimationFrame(new Rectangle(96, 0, 24, 32)));
            AddFrame(new AnimationFrame(new Rectangle(120, 0, 24, 32)));
            AddFrame(new AnimationFrame(new Rectangle(144, 0, 24, 32)));
            AddFrame(new AnimationFrame(new Rectangle(168, 0, 24, 32)));
            AddFrame(new AnimationFrame(new Rectangle(192, 0, 24, 32)));
            AddFrame(new AnimationFrame(new Rectangle(216, 0, 24, 32)));
            AddFrame(new AnimationFrame(new Rectangle(240, 0, 24, 32)));


        }
    }
}
