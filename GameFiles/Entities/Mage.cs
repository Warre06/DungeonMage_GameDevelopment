using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Timers;
using Warre_Gehre_GameDevelopment.GameFiles.Animations.Mage;
using Warre_Gehre_GameDevelopment.GameFiles.Animations;
using Warre_Gehre_GameDevelopment.GameFiles.CollideWithEvents;
using Warre_Gehre_GameDevelopment.GameFiles.Entities.Attacks;
using Warre_Gehre_GameDevelopment.GameFiles.Entities.Health;
using Warre_Gehre_GameDevelopment.GameFiles.Inputs;
using Warre_Gehre_GameDevelopment.GameFiles.Movement;
using Warre_Gehre_GameDevelopment.GameFiles.Sounds;

namespace Warre_Gehre_GameDevelopment.GameFiles.Entities
{
    public class Mage : Moveable
    {
        private readonly Texture2D _texture;
        private readonly AnimationCollection _animations;
        public readonly SoundDictionary _sounds;

        public List<Moveable> _enemies;
        private Attack _lastAttack;

        private double _previousGameTimeTotalSecMeleeAttack;
        private double _previousGameTimeTotalSecOrbAttack;

        private Vector2 _origin;
        private Vector2 _originCorrector;
        private int _scale;
        private bool _lastDirectionWasRight;

        public int Points { get; set; }
        public bool HasFinished { get; set; }
        public bool CanAttack { get; set; } = true;

        public Mage(Texture2D texture, SoundDictionary sounds, IInputProvider inputReader, List<ICollideable> collideables) : base(new MageHealth(), inputReader, collideables, 25 * 2, 35 * 2)
        {
            _texture = texture;
            _sounds = sounds;

            _animations = new AnimationCollection();
            _animations.AddAnimation("idle", new MageIdleAnimation());
            _animations.AddAnimation("walking", new MageWalkingAnimation());
            _animations.AddAnimation("jumping", new MageJumpingAnimation());
            _animations.AddAnimation("falling", new MageFallingAnimation());
            _animations.AddAnimation("orbAttack", new MageAttackOrbAnimation());
            _animations.AddAnimation("meleeAttack", new MageAttackingMeleeAnimation());

            _origin = new Vector2(0, 0);
            _originCorrector = new Vector2(-8, -10);
            _scale = 2;
            _lastDirectionWasRight = true;

            _enemies = new List<Moveable>();
            _lastAttack = null;

            Points = 0;
            HasFinished = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_lastAttack != null && _lastAttack is MageMeleeAttack)
            {
                SpriteEffects lookingDirection = _lastDirectionWasRight ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
                spriteBatch.Draw(_texture, _position, _animations["meleeAttack"].CurrentFrame.SourceRectangle, Color.White, 0, _originCorrector, _scale, lookingDirection, 0);
            }
            else if (_lastAttack != null && _lastAttack is MageOrbAttack)
            {
                SpriteEffects lookingDirection = _lastDirectionWasRight ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
                spriteBatch.Draw(_texture, _position, _animations["orbAttack"].CurrentFrame.SourceRectangle, Color.White, 0, _origin, _scale, lookingDirection, 0);
            }
            else if (_direction == _compareRight)
            {
                _lastDirectionWasRight = true;
                spriteBatch.Draw(_texture, _position, _animations["walking"].CurrentFrame.SourceRectangle, Color.White, 0, _origin, _scale, SpriteEffects.None, 0);
            }
            else if (_direction == _compareLeft)
            {
                _lastDirectionWasRight = false;
                spriteBatch.Draw(_texture, _position, _animations["walking"].CurrentFrame.SourceRectangle, Color.White, 0, _origin, _scale, SpriteEffects.FlipHorizontally, 0);
            }
            else if (_direction == _compareUp)
            {
                spriteBatch.Draw(_texture, _position, _animations["jumping"].CurrentFrame.SourceRectangle, Color.White, 0, _origin, _scale, SpriteEffects.None, 0);
            }
            else if (_direction == new Vector2(1, -1))
            {
                _lastDirectionWasRight = true;
                spriteBatch.Draw(_texture, _position, _animations["jumping"].CurrentFrame.SourceRectangle, Color.White, 0, _origin, _scale, SpriteEffects.None, 0);
            }
            else if (_direction == new Vector2(-1, -1))
            {
                _lastDirectionWasRight = false;
                spriteBatch.Draw(_texture, _position, _animations["jumping"].CurrentFrame.SourceRectangle, Color.White, 0, _origin, _scale, SpriteEffects.FlipHorizontally, 0);
            }
            else if (jumping && jumpSpeed > 0)
            {
                spriteBatch.Draw(_texture, _position, _animations["falling"].CurrentFrame.SourceRectangle, Color.White, 0, _origin, _scale, SpriteEffects.None, 0);
            }
            else
            {
                SpriteEffects lookingDirection = _lastDirectionWasRight ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
                spriteBatch.Draw(_texture, _position, _animations["idle"].CurrentFrame.SourceRectangle, Color.White, 0, _origin, _scale, lookingDirection, 0);
            }
        }

        public override void Update(GameTime gameTime)
        {
            Move();

            if (CanAttack)
            {
                Attack(gameTime);
            }

            if (_lastAttack != null && _lastAttack is MageMeleeAttack)
            {
                _animations["meleeAttack"].Update(gameTime);

                if (_animations["meleeAttack"].DidFullAnimation)
                {
                    _animations["meleeAttack"].DidFullAnimation = false;
                    _lastAttack = null;
                }
            }
            else if (_lastAttack != null && _lastAttack is MageOrbAttack)
            {
                _animations["orbAttack"].Update(gameTime);

                if (_animations["orbAttack"].DidFullAnimation)
                {
                    _animations["orbAttack"].DidFullAnimation = false;
                    _lastAttack = null;
                }
            }
            else if (_direction == new Vector2(1, 0) || _direction == new Vector2(-1, 0))
            {
                _animations["walking"].Update(gameTime);
            }
            else if (_direction == new Vector2(1, -1))
            {
                _animations["jumping"].Update(gameTime);
            }
            else if (_direction == new Vector2(-1, -1))
            {
                _animations["jumping"].Update(gameTime);
            }
            else if (_direction == new Vector2(0, -1))
            {
                _animations["jumping"].Update(gameTime);
            }
            else
            {
                _animations["idle"].Update(gameTime);
            }
        }

        public void Attack(GameTime gameTime)
        {
            Attack attack = null;

            if (Keyboard.GetState().IsKeyDown(Keys.X) && gameTime.TotalGameTime.TotalSeconds - _previousGameTimeTotalSecMeleeAttack > 1)
            {
                attack = new MageMeleeAttack();
                _previousGameTimeTotalSecMeleeAttack = gameTime.TotalGameTime.TotalSeconds;

                Timer timer = new Timer(500);
                timer.Elapsed += PlaySwordEvent;
                timer.AutoReset = false;
                timer.Enabled = true;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.C) && gameTime.TotalGameTime.TotalSeconds - _previousGameTimeTotalSecOrbAttack > 5)
            {
                attack = new MageOrbAttack();
                _previousGameTimeTotalSecOrbAttack = gameTime.TotalGameTime.TotalSeconds;

                Timer timer = new Timer(500);
                timer.Elapsed += PlayOrdEvent;
                timer.AutoReset = false;
                timer.Enabled = true;
            }

            if (attack != null)
            {
                _lastAttack = attack;

                Rectangle hurtBox = attack.GetHurtBox(GetHitbox(), _lastDirectionWasRight);
                foreach (Moveable enemy in _enemies)
                {
                    if (hurtBox.Intersects(enemy.GetHitbox()))
                    {
                        CollideableRectangle collideableRectangle = new CollideableRectangle(enemy.GetHitbox(), new DamageEvent(attack.Damage));
                        CollideWithEventHandler.Handle(enemy, collideableRectangle);
                    }
                }
            }
        }

        private void PlayOrdEvent(object source, ElapsedEventArgs e)
        {
            _sounds["orb"].Play();
        }

        private void PlaySwordEvent(object source, ElapsedEventArgs e)
        {
            _sounds["sword-slash"].Play();
        }

        public override Rectangle GetHitbox()
        {
            Rectangle original = base.GetHitbox();
            return new Rectangle(original.X + 27, original.Y + 5, original.Width - 8, original.Height - 5);
        }
    }
}
