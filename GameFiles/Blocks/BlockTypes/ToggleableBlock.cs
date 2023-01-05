using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;

namespace Warre_Gehre_GameDevelopment.GameFiles.Blocks.BlockTypes
{
    public class ToggleableBlock : Block
    {
        protected int DelayInSec { get; set; } = 1;
        public bool IsVisible { get; set; } = true;
        public double PreviousGameTimeTotalSec { get; set; }

        public ToggleableBlock(int x, int y, Texture2D texture) : base(x, y, texture)
        {

        }

        public override void Draw(SpriteBatch sprite)
        {
            if (IsVisible)
            {
                sprite.Draw(_texture, _position, _sourceRectangle, Color.White, 0, _origin, 1.2f, SpriteEffects.None, 0);
            }
        }

        public override void Update(GameTime gametime)
        {
            if (IsVisible)
            {
                PreviousGameTimeTotalSec = gametime.TotalGameTime.TotalSeconds;
            }
            else
            {
                if (gametime.TotalGameTime.TotalSeconds - PreviousGameTimeTotalSec > DelayInSec)
                {
                    IsVisible = true;
                    PreviousGameTimeTotalSec = gametime.TotalGameTime.TotalSeconds;
                }
            }
        }
    }
}
