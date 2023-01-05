using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Warre_Gehre_GameDevelopment.GameFiles.Animations.Skeleton
{
    class SkeletonWalkingAnimation : Animation
    {
        public SkeletonWalkingAnimation()
        {
            AddFrame(new AnimationFrame(new Rectangle(0, 32, 22, 32)));
            AddFrame(new AnimationFrame(new Rectangle(21, 32, 22, 32)));
            AddFrame(new AnimationFrame(new Rectangle(43, 32, 22, 32)));
            AddFrame(new AnimationFrame(new Rectangle(65, 32, 22, 32)));
            AddFrame(new AnimationFrame(new Rectangle(86, 32, 22, 32)));
            AddFrame(new AnimationFrame(new Rectangle(109, 32, 22, 32)));
            AddFrame(new AnimationFrame(new Rectangle(131, 32, 22, 32)));
            AddFrame(new AnimationFrame(new Rectangle(131, 32, 22, 32)));
            AddFrame(new AnimationFrame(new Rectangle(153, 32, 21, 32)));
            AddFrame(new AnimationFrame(new Rectangle(175, 32, 22, 32)));
            AddFrame(new AnimationFrame(new Rectangle(197, 32, 22, 32)));
            AddFrame(new AnimationFrame(new Rectangle(220, 32, 22, 32)));
            AddFrame(new AnimationFrame(new Rectangle(243, 32, 22, 32)));
            AddFrame(new AnimationFrame(new Rectangle(267, 32, 21, 32)));
        }
    }
}
