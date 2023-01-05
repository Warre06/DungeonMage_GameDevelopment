using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Warre_Gehre_GameDevelopment.GameFiles.Animations.Mage
{
    public class MageIdleAnimation : Animation
    {
        public MageIdleAnimation()
        {
            AddFrame(new AnimationFrame(new Rectangle(0, 0, 50, 35)));
            AddFrame(new AnimationFrame(new Rectangle(50, 0, 50, 35)));
            AddFrame(new AnimationFrame(new Rectangle(100, 0, 50, 35)));
            AddFrame(new AnimationFrame(new Rectangle(150, 0, 50, 35)));
        }
    }
}
