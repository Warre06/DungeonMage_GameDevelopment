using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warre_Gehre_GameDevelopment.GameFiles.CollideWithEvents;
using Warre_Gehre_GameDevelopment.GameFiles.Entities.Stats;
using Warre_Gehre_GameDevelopment.GameFiles.Levels;
using Warre_Gehre_GameDevelopment.GameFiles.Movement;
using Warre_Gehre_GameDevelopment.GameFiles.Sounds;
using Warre_Gehre_GameDevelopment.GameFiles.Textures;

namespace Warre_Gehre_GameDevelopment.GameFiles.Scenes
{
    public class Level2Scene : Scene
    {
        private TextureDictionary _parkourTextures;
        private SoundDictionary _sounds;

        private ParkourLevel _parkourLevel;

        private SpriteFont font;

        public bool ShowHitbox { get; set; }
        public double PreviousGameTimeTotalSec { get; set; }

        public Level2Scene(Game1 game) : base(game)
        {
            ShowHitbox = false;
        }

        public override void Initialize()
        {
            _parkourLevel = new ParkourLevel(_parkourTextures, _sounds);
        }

        public override void LoadContent()
        {
            _parkourTextures = new TextureDictionary();
            _parkourTextures.AddTexture("mage", _content.Load<Texture2D>("Fullmain"));
            _parkourTextures.AddTexture("caveAssets", _content.Load<Texture2D>("cave_assets"));
            _parkourTextures.AddTexture("background", _content.Load<Texture2D>("backgroundParkourLevel"));

            _sounds = new SoundDictionary();
            _sounds.AddTexture("coin", _content.Load<SoundEffect>("coin"));
            _sounds.AddTexture("level-complete", _content.Load<SoundEffect>("level-complete"));

            font = _content.Load<SpriteFont>("Points");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _parkourLevel.Draw(spriteBatch);

            spriteBatch.DrawString(font, $"Points: {_parkourLevel._mage.Points}", new Vector2(10, 10), Color.Gold);

            if (ShowHitbox)
            {
                DrawHitboxes(spriteBatch);
            }
        }
        private void DrawHitboxes(SpriteBatch spriteBatch)
        {
            Texture2D _textureRed, _textureGreen, _textureBlue;

            GraphicsDevice graphicsDevice = _game.GraphicsDevice;

            _textureRed = new Texture2D(graphicsDevice, 1, 1);
            _textureRed.SetData(new[] { Color.Red });

            _textureGreen = new Texture2D(graphicsDevice, 1, 1);
            _textureGreen.SetData(new[] { Color.Green });

            _textureBlue = new Texture2D(graphicsDevice, 1, 1);
            _textureBlue.SetData(new[] { Color.Blue });

            spriteBatch.Draw(_textureRed, _parkourLevel._mage.GetHitbox(), Color.White);

            foreach (CollideableRectangle collideable in _parkourLevel._blockCollection.CollideableRectangles.Where(v => v.GetCollideWithEvent().GetType() == typeof(NoEvent) && v.IsActive))
            {
                spriteBatch.Draw(_textureGreen, collideable.GetHitbox(), Color.White);
            }

            foreach (CollideableRectangle collideable in _parkourLevel._blockCollection.CollideableRectangles.Where(v => v.GetCollideWithEvent().GetType() != typeof(NoEvent) && v.IsActive))
            {
                spriteBatch.Draw(_textureBlue, collideable.GetHitbox(), Color.White);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.H) && gameTime.TotalGameTime.TotalSeconds - PreviousGameTimeTotalSec > 1)
            {
                ShowHitbox = !ShowHitbox;
                PreviousGameTimeTotalSec = gameTime.TotalGameTime.TotalSeconds;
            }

            _parkourLevel.Update(gameTime);

            if (_parkourLevel._mage.Health.IsDead)
            {
                MageStats.ResetPointsToLevel1();
                _game.ChangeScene(new Level2Scene(_game));
            }
            else if (_parkourLevel._mage.HasFinished)
            {
                MageStats.SetEndTime(DateTime.Now);
                _game.ChangeScene(new EndScene(_game));
            }
        }
    }
}
