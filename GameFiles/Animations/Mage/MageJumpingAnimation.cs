using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Warre_Gehre_GameDevelopment.GameFiles.Animations.Mage
{
    public class MageJumpingAnimation : Animation
    {
        public MageJumpingAnimation()
        {
            AddFrame(new AnimationFrame(new Rectangle(0, 80, 50, 34)));
            AddFrame(new AnimationFrame(new Rectangle(50, 80, 50, 34)));
            AddFrame(new AnimationFrame(new Rectangle(100, 80, 50, 34)));
            AddFrame(new AnimationFrame(new Rectangle(150, 80, 50, 34)));
        }
    }
}
