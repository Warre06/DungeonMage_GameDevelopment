using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Warre_Gehre_GameDevelopment.GameFiles.Animations.Skeleton
{
    class SkeletonAttackingAnimation : Animation
    {
        public SkeletonAttackingAnimation()
        {
            AddFrame(new AnimationFrame(new Rectangle(0, 64, 43, 32)));
            AddFrame(new AnimationFrame(new Rectangle(42, 64, 43, 38)));
            AddFrame(new AnimationFrame(new Rectangle(85, 64, 43, 38)));
            AddFrame(new AnimationFrame(new Rectangle(126, 64, 43, 38)));
            AddFrame(new AnimationFrame(new Rectangle(168, 64, 43, 38)));
            AddFrame(new AnimationFrame(new Rectangle(210, 64, 43, 38)));
            AddFrame(new AnimationFrame(new Rectangle(252, 64, 43, 38)));
            AddFrame(new AnimationFrame(new Rectangle(305, 64, 43, 38)));
            AddFrame(new AnimationFrame(new Rectangle(340, 64, 43, 38)));
            AddFrame(new AnimationFrame(new Rectangle(383, 64, 43, 38)));
            AddFrame(new AnimationFrame(new Rectangle(426, 64, 43, 38)));
            AddFrame(new AnimationFrame(new Rectangle(469, 64, 43, 38)));
            AddFrame(new AnimationFrame(new Rectangle(512, 64, 43, 38)));
            AddFrame(new AnimationFrame(new Rectangle(553, 64, 43, 38)));
            AddFrame(new AnimationFrame(new Rectangle(596, 64, 43, 38)));
            AddFrame(new AnimationFrame(new Rectangle(639, 64, 43, 38)));
            AddFrame(new AnimationFrame(new Rectangle(688, 64, 43, 38)));
            AddFrame(new AnimationFrame(new Rectangle(731, 64, 43, 38)));
        }
    }
}
