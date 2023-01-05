using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Warre_Gehre_GameDevelopment.GameFiles.Blocks.BlockTypes
{
    class Platform1 : Block
    {
        public Platform1(int x, int y, Texture2D texture) : base(x, y, texture)
        {
            _sourceRectangle = new Rectangle(129, 32, 32, 25);
        }
    }
}
