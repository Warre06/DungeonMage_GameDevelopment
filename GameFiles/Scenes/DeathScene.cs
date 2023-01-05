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
    public class DeathScene : Scene
    {
        private Texture2D _deathScreen;
        private Vector2 _deathScreenPosition;

        public DeathScene(Game1 game) : base(game)
        {

        }

        public override void Initialize()
        {
            _deathScreenPosition = new Vector2(0, 0);
        }

        public override void LoadContent()
        {
            _deathScreen = _content.Load<Texture2D>("Death_Screen_2");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_deathScreen, _deathScreenPosition, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                MageStats.Reset();
                _game.ChangeScene(new Level1Scene(_game));
            }
        }
    }
}
