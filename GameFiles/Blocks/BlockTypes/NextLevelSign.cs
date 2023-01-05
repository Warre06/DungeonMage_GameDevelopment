using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Warre_Gehre_GameDevelopment.GameFiles.Blocks.BlockTypes
{
    public class NextLevelSign : ToggleableBlock
    {
        public NextLevelSign(int x, int y, Texture2D texture) : base(x, y, texture)
        {
            _sourceRectangle = new Rectangle(404, 268, 32, 32);
        }

        public override void Update(GameTime gametime)
        {

        }
    }
}
