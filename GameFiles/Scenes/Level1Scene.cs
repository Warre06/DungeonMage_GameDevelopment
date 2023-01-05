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
using Warre_Gehre_GameDevelopment.GameFiles.Levels;
using Warre_Gehre_GameDevelopment.GameFiles.Movement;
using Warre_Gehre_GameDevelopment.GameFiles.Sounds;
using Warre_Gehre_GameDevelopment.GameFiles.Textures;

namespace Warre_Gehre_GameDevelopment.GameFiles.Scenes
{
    public class Level1Scene : Scene
    {
        private TextureDictionary _textures;
        private SoundDictionary _sounds;

        private IceLevel _iceLevel;

        private SpriteFont font;

        public bool ShowHitbox { get; set; }
        public double PreviousGameTimeTotalSec { get; set; }

        public Level1Scene(Game1 game) : base(game)
        {
            ShowHitbox = false;
        }

        public override void Initialize()
        {
            _iceLevel = new IceLevel(_textures, _sounds);
        }

        public override void LoadContent()
        {
            _textures = new TextureDictionary();
            _textures.AddTexture("mage", _content.Load<Texture2D>("Fullmain"));
            _textures.AddTexture("healthBar", _content.Load<Texture2D>("Health_Bar"));
            _textures.AddTexture("skeleton", _content.Load<Texture2D>("SkeletonSprite"));
            _textures.AddTexture("miniBoss", _content.Load<Texture2D>("MiniBoss"));
            _textures.AddTexture("iceAssets", _content.Load<Texture2D>("ice_assets"));
            _textures.AddTexture("background", _content.Load<Texture2D>("ice_background"));

            SoundEffect.MasterVolume = 0.5f;

            _sounds = new SoundDictionary();
            _sounds.AddTexture("orb", _content.Load<SoundEffect>("orb"));
            _sounds.AddTexture("sword-slash", _content.Load<SoundEffect>("sword-slash"));
            _sounds.AddTexture("axe", _content.Load<SoundEffect>("axe"));
            _sounds.AddTexture("double-axe", _content.Load<SoundEffect>("double-axe"));
            _sounds.AddTexture("coin", _content.Load<SoundEffect>("coin"));
            _sounds.AddTexture("heal", _content.Load<SoundEffect>("heal"));
            _sounds.AddTexture("level-complete", _content.Load<SoundEffect>("level-complete"));
            _sounds.AddTexture("death-boss", _content.Load<SoundEffect>("death-boss"));
            _sounds.AddTexture("death-skeleton", _content.Load<SoundEffect>("death-skeleton"));

            font = _content.Load<SpriteFont>("Points");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _iceLevel.Draw(spriteBatch);

            spriteBatch.DrawString(font, $"Points: {_iceLevel._mage.Points}", new Vector2(10, 10), Color.Gold);
            spriteBatch.DrawString(font, $"HP: {_iceLevel._mage.Health.HP}", new Vector2(10, 50), Color.Red);

            if (ShowHitbox)
            {
                DrawHitboxes(spriteBatch);
            }
        }

        private void DrawHitboxes(SpriteBatch spriteBatch)
        {
            Texture2D _textureRed, _textureGreen, _textureBlue, _textureYellow;

            GraphicsDevice graphicsDevice = _game.GraphicsDevice;

            _textureRed = new Texture2D(graphicsDevice, 1, 1);
            _textureRed.SetData(new[] { Color.Red });

            _textureGreen = new Texture2D(graphicsDevice, 1, 1);
            _textureGreen.SetData(new[] { Color.Green });

            _textureBlue = new Texture2D(graphicsDevice, 1, 1);
            _textureBlue.SetData(new[] { Color.Blue });

            _textureYellow = new Texture2D(graphicsDevice, 1, 1);
            _textureYellow.SetData(new[] { Color.Yellow });

            spriteBatch.Draw(_textureRed, _iceLevel._mage.GetHitbox(), Color.White);
            spriteBatch.Draw(_textureRed, _iceLevel._skeleton.GetHitbox(), Color.White);
            spriteBatch.Draw(_textureRed, _iceLevel._skeleton2.GetHitbox(), Color.White);
            spriteBatch.Draw(_textureRed, _iceLevel._miniBoss.GetHitbox(), Color.White);

            foreach (CollideableRectangle collideable in _iceLevel._blockCollection.CollideableRectangles.Where(v => v.GetCollideWithEvent().GetType() == typeof(NoEvent) && v.IsActive))
            {
                spriteBatch.Draw(_textureGreen, collideable.GetHitbox(), Color.White);
            }

            foreach (CollideableRectangle collideable in _iceLevel._blockCollection.CollideableRectangles.Where(v => v.GetCollideWithEvent().GetType() != typeof(NoEvent) && v.IsActive))
            {
                spriteBatch.Draw(_textureBlue, collideable.GetHitbox(), Color.White);
            }

            //spriteBatch.Draw(_textureYellow, _iceLevel._miniBoss.BoundingBox, Color.White);
            //spriteBatch.Draw(_textureYellow, _iceLevel._skeleton.BoundingBox, Color.White);
            //spriteBatch.Draw(_textureYellow, _iceLevel._skeleton2.BoundingBox, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.H) && gameTime.TotalGameTime.TotalSeconds - PreviousGameTimeTotalSec > 1)
            {
                ShowHitbox = !ShowHitbox;
                PreviousGameTimeTotalSec = gameTime.TotalGameTime.TotalSeconds;
            }

            _iceLevel.Update(gameTime);

            if (_iceLevel._mage.Health.IsDead)
            {
                _game.ChangeScene(new DeathScene(_game));
            }
            else if (_iceLevel._mage.HasFinished)
            {
                _game.ChangeScene(new Level2Scene(_game));
            }
        }
    }
}
