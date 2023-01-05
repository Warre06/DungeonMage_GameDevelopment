using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using Warre_Gehre_GameDevelopment.GameFiles.Animations.Environment;
using Warre_Gehre_GameDevelopment.GameFiles.Animations;

namespace Warre_Gehre_GameDevelopment.GameFiles.Blocks.BlockTypes
{
    public class WaterBlock : Block
    {
        private readonly Animation _animation;

        public WaterBlock(int x, int y, Texture2D texture) : base(x, y, texture)
        {
            _animation = new WaterAnimation();
        }

        public override void Draw(SpriteBatch sprite)
        {
            sprite.Draw(_texture, _position, _animation.CurrentFrame.SourceRectangle, Color.White, 0, _origin, 1, SpriteEffects.None, 0);
        }

        public override void Update(GameTime gametime)
        {
            _animation.Update(gametime);
            base.Update(gametime);
        }
    }
}
