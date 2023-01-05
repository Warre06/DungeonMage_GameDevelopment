using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Warre_Gehre_GameDevelopment.GameFiles.Animations.Skeleton
{
    class SkeletonHitAnimation : Animation
    {
        public SkeletonHitAnimation()
        {
            AddFrame(new AnimationFrame(new Rectangle(0, 101, 30, 32)));
            AddFrame(new AnimationFrame(new Rectangle(30, 101, 30, 32)));
            AddFrame(new AnimationFrame(new Rectangle(56, 101, 30, 32)));
            AddFrame(new AnimationFrame(new Rectangle(84, 101, 30, 32)));
            AddFrame(new AnimationFrame(new Rectangle(117, 101, 30, 32)));
            AddFrame(new AnimationFrame(new Rectangle(150, 101, 30, 32)));
            AddFrame(new AnimationFrame(new Rectangle(180, 101, 30, 32)));
            AddFrame(new AnimationFrame(new Rectangle(210, 101, 30, 32)));
        }
    }
}
