using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Warre_Gehre_GameDevelopment.GameFiles.Animations.Mage
{
    public class MageWalkingAnimation : Animation
    {
        public MageWalkingAnimation()
        {
            AddFrame(new AnimationFrame(new Rectangle(0, 35, 50, 35)));
            AddFrame(new AnimationFrame(new Rectangle(50, 35, 50, 35)));
            AddFrame(new AnimationFrame(new Rectangle(100, 35, 50, 35)));
            AddFrame(new AnimationFrame(new Rectangle(150, 35, 50, 35)));
            AddFrame(new AnimationFrame(new Rectangle(200, 35, 50, 35)));
            AddFrame(new AnimationFrame(new Rectangle(250, 35, 50, 35)));
        }
    }
}
