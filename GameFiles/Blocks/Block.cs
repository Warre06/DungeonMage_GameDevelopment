using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Warre_Gehre_GameDevelopment.GameFiles.Blocks
{
    public class Block : IGameObject
    {
        protected readonly Texture2D _texture;
        protected Color _color;
        protected Rectangle _sourceRectangle;
        protected Vector2 _position;
        protected Vector2 _origin;

        public Block(int x, int y, Texture2D texture)
        {
            _texture = texture;
            _color = Color.White;
            _sourceRectangle = new Rectangle(127, 160, 32, 62);
            _position = new Vector2(x, y);
            _origin = new Vector2(0, 0);
        }

        public virtual void Draw(SpriteBatch sprite)
        {
            sprite.Draw(_texture, _position, _sourceRectangle, Color.White, 0, _origin, 1, SpriteEffects.None, 0);
        }

        public virtual void Update(GameTime gametime)
        {

        }
    }
}
