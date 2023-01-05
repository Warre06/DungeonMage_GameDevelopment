using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Warre_Gehre_GameDevelopment.GameFiles.Animations.Environment
{
    class CoinAnimation : Animation
    {
        public CoinAnimation()
        {
            AddFrame(new AnimationFrame(new Rectangle(168, 8, 16, 15)));
            AddFrame(new AnimationFrame(new Rectangle(201, 8, 16, 15)));
            AddFrame(new AnimationFrame(new Rectangle(235, 8, 11, 15)));
            AddFrame(new AnimationFrame(new Rectangle(268, 8, 8, 15)));
            AddFrame(new AnimationFrame(new Rectangle(299, 8, 11, 15)));
            AddFrame(new AnimationFrame(new Rectangle(330, 8, 14, 15)));

        }
    }
}
