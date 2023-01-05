using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Warre_Gehre_GameDevelopment.GameFiles.Animations.Mage
{
    public class MageFallingAnimation : Animation
    {
        public MageFallingAnimation()
        {
            AddFrame(new AnimationFrame(new Rectangle(250, 75, 50, 40)));
            AddFrame(new AnimationFrame(new Rectangle(300, 75, 50, 40)));
            AddFrame(new AnimationFrame(new Rectangle(350, 75, 50, 40)));
            AddFrame(new AnimationFrame(new Rectangle(400, 75, 50, 40)));
            AddFrame(new AnimationFrame(new Rectangle(450, 75, 50, 40)));
        }
    }
}
