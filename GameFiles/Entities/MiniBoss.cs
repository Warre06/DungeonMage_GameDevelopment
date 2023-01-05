using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Warre_Gehre_GameDevelopment.GameFiles.Animations.MiniBoss;
using Warre_Gehre_GameDevelopment.GameFiles.Animations;
using Warre_Gehre_GameDevelopment.GameFiles.CollideWithEvents;
using Warre_Gehre_GameDevelopment.GameFiles.Entities.Attacks;
using Warre_Gehre_GameDevelopment.GameFiles.Entities.Health;
using Warre_Gehre_GameDevelopment.GameFiles.Inputs;
using Warre_Gehre_GameDevelopment.GameFiles.Movement;
using Warre_Gehre_GameDevelopment.GameFiles.Sounds;

namespace Warre_Gehre_GameDevelopment.GameFiles.Entities
{
    public class MiniBoss : Moveable
    {
        private readonly Texture2D _texture;
        private readonly Texture2D _healthBar;
        private readonly AnimationCollection _animations;
        public readonly SoundDictionary _sounds;

        public Mage _enemy;

        private Vector2 _origin;
        private float _scale;

        private Attack _lastAttack;
        private double _previousGameTimeTotalSecMeleeAttack;

        private bool _lastDirectionWasRight;

        private int delayInMs;
        private double counter;

        private bool _playedDeadAnimation;

        public MiniBoss(Texture2D texture, Texture2D healthBar, SoundDictionary sounds, IInputProvider inputReader, List<ICollideable> collideables) : base(new BossHealth(), inputReader, collideables, 21 * 2, 32 * 2)
        {
            _texture = texture;
            _healthBar = healthBar;
            _sounds = sounds;

            _animations = new AnimationCollection();
            _animations.AddAnimation("MiniBossIdleAnimation", new MiniBossIdleAnimation());
            _animations.AddAnimation("MiniBossWalkingAnimation", new MiniBossWalkingAnimation());
            _animations.AddAnimation("MiniBossAttackingAnimation", new MiniBossAttackingAnimation());
            _animations.AddAnimation("MiniBossDieAnimation", new MiniBossDieAnimation());
            _animations.AddAnimation("MiniBossHitAnimation", new MiniBossHitAnimation());

            _origin = new Vector2(0, 0);
            _scale = 2.3f;
            _position = new Vector2(750, 91);

            _lastAttack = null;

            delayInMs = 500;
            counter = 0;

            _playedDeadAnimation = false;

            BoundingBox = new Rectangle(320, 0, 960, 200);

            _velocity = new Vector2(20f, 20f);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!Health.IsDead)
            {
                if (_lastAttack != null && _lastAttack is MiniBossSwingAttack)
                {
                    SpriteEffects lookingDirection = _lastDirectionWasRight ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
                    spriteBatch.Draw(_texture, _position, _animations["MiniBossAttackingAnimation"].CurrentFrame.SourceRectangle, Color.White, 0, _origin, _scale, lookingDirection, 0);
                }
                else if (_direction == _compareRight)
                {
                    _lastDirectionWasRight = true;
                    spriteBatch.Draw(_texture, _position, _animations["MiniBossWalkingAnimation"].CurrentFrame.SourceRectangle, Color.White, 0, _origin, _scale, SpriteEffects.None, 0);
                }
                else if (_direction == _compareLeft)
                {
                    _lastDirectionWasRight = false;
                    spriteBatch.Draw(_texture, _position, _animations["MiniBossWalkingAnimation"].CurrentFrame.SourceRectangle, Color.White, 0, _origin, _scale, SpriteEffects.FlipHorizontally, 0);
                }
                else if (_direction == _compareUp)
                {
                    spriteBatch.Draw(_texture, _position, _animations["MiniBossWalkingAnimation"].CurrentFrame.SourceRectangle, Color.White, 0, _origin, _scale, SpriteEffects.None, 0);
                }
                else if (_direction == new Vector2(1, -1))
                {
                    spriteBatch.Draw(_texture, _position, _animations["MiniBossWalkingAnimation"].CurrentFrame.SourceRectangle, Color.White, 0, _origin, _scale, SpriteEffects.None, 0);
                }
                else if (_direction == new Vector2(-1, -1))
                {
                    spriteBatch.Draw(_texture, _position, _animations["MiniBossWalkingAnimation"].CurrentFrame.SourceRectangle, Color.White, 0, _origin, _scale, SpriteEffects.FlipHorizontally, 0);
                }
                else if (falling)
                {
                    spriteBatch.Draw(_texture, _position, _animations["MiniBossWalkingAnimation"].CurrentFrame.SourceRectangle, Color.White, 0, _origin, _scale, SpriteEffects.None, 0);
                }
                else
                {
                    spriteBatch.Draw(_texture, _position, _animations["MiniBossIdleAnimation"].CurrentFrame.SourceRectangle, Color.White, 0, _origin, _scale, SpriteEffects.None, 0);
                }

                DrawHealthBar(spriteBatch);
            }
            else if (!_playedDeadAnimation)
            {
                spriteBatch.Draw(_texture, _position, _animations["MiniBossDieAnimation"].CurrentFrame.SourceRectangle, Color.White, 0, _origin, _scale, SpriteEffects.None, 0);
            }
        }

        private void DrawHealthBar(SpriteBatch spriteBatch)
        {
            Rectangle hitbox = GetHitbox();

            float percentHealth = (float)Health.HP / 100;

            if (percentHealth > 100)
            {
                percentHealth = 100;
            }

            int barWidth = (int)(_healthBar.Width * percentHealth) / 10;

            var barPos = new Vector2(hitbox.X - 100, hitbox.Y - 15);
            spriteBatch.Draw(_healthBar, barPos, new Rectangle(0, 0, barWidth, 8), Color.White, 0, _origin, 0.5f, SpriteEffects.None, 0);
        }

        public override void Update(GameTime gameTime)
        {
            if (!Health.IsDead)
            {
                if (gameTime.TotalGameTime.TotalMilliseconds - counter >= delayInMs)
                {
                    Move();
                    Attack(gameTime);
                    counter = gameTime.TotalGameTime.TotalMilliseconds;
                }

                if (_lastAttack != null && _lastAttack is MiniBossSwingAttack)
                {
                    _animations["MiniBossAttackingAnimation"].Update(gameTime);

                    if (_animations["MiniBossAttackingAnimation"].DidFullAnimation)
                    {
                        _animations["MiniBossAttackingAnimation"].DidFullAnimation = false;
                        _lastAttack = null;
                    }
                }
                else if (_direction == new Vector2(1, 0) || _direction == new Vector2(-1, 0))
                {
                    _animations["MiniBossWalkingAnimation"].Update(gameTime);
                }
                else if (_direction == new Vector2(1, -1))
                {
                    _animations["MiniBossWalkingAnimation"].Update(gameTime);
                }
                else if (_direction == new Vector2(-1, -1))
                {
                    _animations["MiniBossWalkingAnimation"].Update(gameTime);
                }
                else if (_direction == new Vector2(0, -1))
                {
                    _animations["MiniBossWalkingAnimation"].Update(gameTime);
                }
                else
                {
                    _animations["MiniBossIdleAnimation"].Update(gameTime);
                }
            }
            else if (!_playedDeadAnimation)
            {
                _animations["MiniBossDieAnimation"].Update(gameTime);

                if (_animations["MiniBossDieAnimation"].DidFullAnimation)
                {
                    _playedDeadAnimation = true;
                }
            }
        }

        public void Attack(GameTime gameTime)
        {
            Attack attack = null;

            if (DoAttack() && gameTime.TotalGameTime.TotalSeconds - _previousGameTimeTotalSecMeleeAttack > 4)
            {
                attack = new MiniBossSwingAttack();
                _previousGameTimeTotalSecMeleeAttack = gameTime.TotalGameTime.TotalSeconds;
                _sounds["double-axe"].Play();
            }

            if (attack != null)
            {
                _lastAttack = attack;

                Rectangle hurtBox = attack.GetHurtBox(GetHitbox(), _lastDirectionWasRight);

                if (hurtBox.Intersects(_enemy.GetHitbox()))
                {
                    CollideableRectangle collideableRectangle = new CollideableRectangle(_enemy.GetHitbox(), new DamageEvent(attack.Damage));
                    CollideWithEventHandler.Handle(_enemy, collideableRectangle);
                }
            }
        }

        private bool DoAttack()
        {
            Rectangle myHitbox = GetHitbox();
            Rectangle myExpandedHitBox = new Rectangle(myHitbox.X - 30, myHitbox.Y, myHitbox.Width + 30, myHitbox.Height);
            Rectangle enemyHitBox = _enemy.GetHitbox();
            Random random = new Random();

            return myExpandedHitBox.Intersects(enemyHitBox) ? random.NextDouble() > 0.75 : false;
        }

        public override Rectangle GetHitbox()
        {
            Rectangle original = base.GetHitbox();
            return new Rectangle(original.X + 40, original.Y + 35, original.Width + 10, original.Height + 10);
        }
    }
}
