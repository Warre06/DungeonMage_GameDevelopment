using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warre_Gehre_GameDevelopment.GameFiles.Entities.Stats;

namespace Warre_Gehre_GameDevelopment.GameFiles.Scenes
{
    public class MenuScene : Scene
    {
        private Texture2D _startUpBackground;
        private Vector2 _startButtonPosition;

        public MenuScene(Game1 game) : base(game)
        {

        }

        public override void Initialize()
        {
            _startButtonPosition = new Vector2(0, 0);
        }

        public override void LoadContent()
        {
            _startUpBackground = _content.Load<Texture2D>("StartUpBackground");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_startUpBackground, _startButtonPosition, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                MageStats.Reset();
                _game.ChangeScene(new Level1Scene(_game));
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                MageStats.Reset();
                _game.ChangeScene(new Level2Scene(_game));
            }
        }
    }
}
