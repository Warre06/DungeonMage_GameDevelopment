using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warre_Gehre_GameDevelopment.GameFiles.Scenes
{
    public abstract class Scene : IGameObject
    {
        protected Game1 _game;
        protected ContentManager _content;

        public Scene(Game1 game)
        {
            _game = game;
            _content = _game.Content;

            LoadContent();
            Initialize();
        }

        public abstract void Initialize();

        public abstract void LoadContent();

        public abstract void Draw(SpriteBatch sprite);

        public abstract void Update(GameTime gameTime);
    }
}
