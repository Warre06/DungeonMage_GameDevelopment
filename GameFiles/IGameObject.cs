using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Warre_Gehre_GameDevelopment.GameFiles
{
    public interface IGameObject
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch sprite);
    }
}
