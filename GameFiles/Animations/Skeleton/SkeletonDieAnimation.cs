using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Warre_Gehre_GameDevelopment.GameFiles.Animations.Skeleton
{
    class SkeletonDieAnimation : Animation
    {
        public SkeletonDieAnimation()
        {
            AddFrame(new AnimationFrame(new Rectangle(0, 133, 30, 32)));
            AddFrame(new AnimationFrame(new Rectangle(30, 133, 30, 32)));
            AddFrame(new AnimationFrame(new Rectangle(62, 133, 30, 32)));
            AddFrame(new AnimationFrame(new Rectangle(93, 133, 30, 32)));
            AddFrame(new AnimationFrame(new Rectangle(126, 133, 30, 32)));
            AddFrame(new AnimationFrame(new Rectangle(159, 133, 30, 32)));
            AddFrame(new AnimationFrame(new Rectangle(192, 133, 30, 32)));
            AddFrame(new AnimationFrame(new Rectangle(225, 133, 30, 32)));
            AddFrame(new AnimationFrame(new Rectangle(258, 133, 30, 32)));
            AddFrame(new AnimationFrame(new Rectangle(290, 133, 30, 32)));
            AddFrame(new AnimationFrame(new Rectangle(323, 133, 30, 32)));
            AddFrame(new AnimationFrame(new Rectangle(356, 133, 30, 32)));
            AddFrame(new AnimationFrame(new Rectangle(385, 133, 30, 32)));
            AddFrame(new AnimationFrame(new Rectangle(418, 133, 30, 32)));
            AddFrame(new AnimationFrame(new Rectangle(451, 133, 30, 32)));
        }
    }
}
