using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Warre_Gehre_GameDevelopment.GameFiles.Animations.Mage
{
    public class Orb : Animation
    {
        public Orb()
        {
            AddFrame(new AnimationFrame(new Rectangle(461, 127, 7, 8)));
        }
    }
}
