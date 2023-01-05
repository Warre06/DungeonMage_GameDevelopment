using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Warre_Gehre_GameDevelopment.GameFiles.Animations.Mage
{
    public class MageAttackOrbAnimation : Animation
    {
        public MageAttackOrbAnimation()
        {
            AddFrame(new AnimationFrame(new Rectangle(0, 110, 50, 37)));
            AddFrame(new AnimationFrame(new Rectangle(50, 110, 50, 37)));
            AddFrame(new AnimationFrame(new Rectangle(100, 110, 50, 37)));
            AddFrame(new AnimationFrame(new Rectangle(150, 110, 50, 37)));
            AddFrame(new AnimationFrame(new Rectangle(200, 110, 50, 37)));
            AddFrame(new AnimationFrame(new Rectangle(250, 110, 50, 37)));
            AddFrame(new AnimationFrame(new Rectangle(300, 110, 50, 37)));
            AddFrame(new AnimationFrame(new Rectangle(350, 110, 50, 37)));
            AddFrame(new AnimationFrame(new Rectangle(400, 110, 50, 37)));
        }
    }
}
