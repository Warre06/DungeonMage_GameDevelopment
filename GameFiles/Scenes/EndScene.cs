using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warre_Gehre_GameDevelopment.GameFiles.Entities.Stats;

namespace Warre_Gehre_GameDevelopment.GameFiles.Scenes
{
    public class EndScene : Scene
    {
        private Texture2D _endScreen;
        private Vector2 _endScreenPosition;

        private SpriteFont font;

        public EndScene(Game1 game) : base(game)
        {

        }

        public override void Initialize()
        {
            _endScreenPosition = new Vector2(0, 0);
        }

        public override void LoadContent()
        {
            _endScreen = _content.Load<Texture2D>("endscreen");
            font = _content.Load<SpriteFont>("Points");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_endScreen, _endScreenPosition, Color.White);

            spriteBatch.DrawString(font, $"{MageStats.TotalPoints} / 25", new Vector2(810, 354), Color.White);
            spriteBatch.DrawString(font, $"{MageStats.TotalHPHealed}", new Vector2(810, 400), Color.White);
            spriteBatch.DrawString(font, $"{MageStats.TimeElapsed.ToShortTimeString()}", new Vector2(810, 444), Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                _game.ChangeScene(new Level1Scene(_game));
            }
        }
    }

    public static class TimeSpanExtensions
    {
        public static string ToShortTimeString(this TimeSpan @this)
        {
            string min = @this.Minutes.ToString();
            string sec = @this.Seconds.ToString().Length == 2 ? @this.Seconds.ToString() : $"0{@this.Seconds}";

            return $"{min}:{sec}";
        }
    }
}
