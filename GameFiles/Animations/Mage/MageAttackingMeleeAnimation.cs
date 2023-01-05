using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Warre_Gehre_GameDevelopment.GameFiles.Animations.Mage
{
    public class MageAttackingMeleeAnimation : Animation
    {
        public MageAttackingMeleeAnimation()
        {
            AddFrame(new AnimationFrame(new Rectangle(11, 156, 20, 26)));
            AddFrame(new AnimationFrame(new Rectangle(63, 156, 20, 27)));
            AddFrame(new AnimationFrame(new Rectangle(111, 150, 23, 33)));
            AddFrame(new AnimationFrame(new Rectangle(156, 154, 40, 29)));
            AddFrame(new AnimationFrame(new Rectangle(199, 162, 37, 21)));
            AddFrame(new AnimationFrame(new Rectangle(252, 161, 31, 22)));
            AddFrame(new AnimationFrame(new Rectangle(300, 160, 33, 23)));
            AddFrame(new AnimationFrame(new Rectangle(250, 194, 33, 26)));
            AddFrame(new AnimationFrame(new Rectangle(311, 186, 23, 33)));
            AddFrame(new AnimationFrame(new Rectangle(364, 192, 20, 28)));
            AddFrame(new AnimationFrame(new Rectangle(411, 192, 21, 28)));
            AddFrame(new AnimationFrame(new Rectangle(464, 192, 18, 29)));
        }
    }
}
