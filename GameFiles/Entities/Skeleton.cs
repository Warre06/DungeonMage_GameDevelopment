using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Warre_Gehre_GameDevelopment.GameFiles.Animations.Skeleton;
using Warre_Gehre_GameDevelopment.GameFiles.Animations;
using Warre_Gehre_GameDevelopment.GameFiles.CollideWithEvents;
using Warre_Gehre_GameDevelopment.GameFiles.Entities.Attacks;
using Warre_Gehre_GameDevelopment.GameFiles.Entities.Health;
using Warre_Gehre_GameDevelopment.GameFiles.Sounds;
using Warre_Gehre_GameDevelopment.GameFiles.Movement;
using Warre_Gehre_GameDevelopment.GameFiles.Inputs;

namespace Warre_Gehre_GameDevelopment.GameFiles.Entities
{
    public class Skeleton : Moveable
    {
        private readonly Texture2D _texture;
        private readonly Texture2D _healthBar;
        private readonly AnimationCollection _animations;
        public readonly SoundDictionary _sounds;

        public Mage _enemy;

        private Vector2 _origin;
        private Vector2 _originCorrector;
        private float _scale;

        private Attack _lastAttack;
        private double _previousGameTimeTotalSecMeleeAttack;

        private bool _lastDirectionWasRight;

        private int delayInMs;
        private double counter;

        private bool _playedDeadAnimation;

        public Skeleton(Texture2D texture, Texture2D healthBar, SoundDictionary sounds, Vector2 startPosition, IInputProvider inputReader, List<ICollideable> collideables) : base(new SkeletonHealth(), inputReader, collideables, 21 * 2, 32 * 2)
        {
            _texture = texture;
            _healthBar = healthBar;
            _sounds = sounds;

            _animations = new AnimationCollection();
            _animations.AddAnimation("SkeletonIdleAnimation", new SkeletonIdleAnimation());
            _animations.AddAnimation("SkeletonWalkingAnimation", new SkeletonWalkingAnimation());
            _animations.AddAnimation("SkeletonAttackingAnimation", new SkeletonAttackingAnimation());
            _animations.AddAnimation("SkeletonHitAnimation", new SkeletonHitAnimation());
            _animations.AddAnimation("SkeletonDieAnimation", new SkeletonDieAnimation());

            _origin = new Vector2(0, 0);
            _originCorrector = new Vector2(0, 5);
            _scale = 2.3f;
            _position = startPosition;

            _lastAttack = null;

            delayInMs = 500;
            counter = 0;

            _playedDeadAnimation = false;

            _velocity = new Vector2(13f, 13f);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!Health.IsDead)
            {
                if (_lastAttack != null && _lastAttack is SkeletonMeleeAttack)
                {
                    SpriteEffects lookingDirection = _lastDirectionWasRight ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
                    spriteBatch.Draw(_texture, _position, _animations["SkeletonAttackingAnimation"].CurrentFrame.SourceRectangle, Color.White, 0, _originCorrector, _scale, lookingDirection, 0);
                }
                else if (_direction == _compareRight)
                {
                    _lastDirectionWasRight = true;
                    spriteBatch.Draw(_texture, _position, _animations["SkeletonWalkingAnimation"].CurrentFrame.SourceRectangle, Color.White, 0, _origin, _scale, SpriteEffects.None, 0);
                }
                else if (_direction == _compareLeft)
                {
                    _lastDirectionWasRight = false;
                    spriteBatch.Draw(_texture, _position, _animations["SkeletonWalkingAnimation"].CurrentFrame.SourceRectangle, Color.White, 0, _origin, _scale, SpriteEffects.FlipHorizontally, 0);
                }
                else if (_direction == _compareUp)
                {
                    spriteBatch.Draw(_texture, _position, _animations["SkeletonWalkingAnimation"].CurrentFrame.SourceRectangle, Color.White, 0, _origin, _scale, SpriteEffects.None, 0);
                }
                else if (_direction == new Vector2(1, -1))
                {
                    spriteBatch.Draw(_texture, _position, _animations["SkeletonWalkingAnimation"].CurrentFrame.SourceRectangle, Color.White, 0, _origin, _scale, SpriteEffects.None, 0);
                }
                else if (_direction == new Vector2(-1, -1))
                {
                    spriteBatch.Draw(_texture, _position, _animations["SkeletonWalkingAnimation"].CurrentFrame.SourceRectangle, Color.White, 0, _origin, _scale, SpriteEffects.FlipHorizontally, 0);
                }
                else if (falling)
                {
                    spriteBatch.Draw(_texture, _position, _animations["SkeletonWalkingAnimation"].CurrentFrame.SourceRectangle, Color.White, 0, _origin, _scale, SpriteEffects.None, 0);
                }
                else
                {
                    spriteBatch.Draw(_texture, _position, _animations["SkeletonIdleAnimation"].CurrentFrame.SourceRectangle, Color.White, 0, _origin, _scale, SpriteEffects.None, 0);
                }

                DrawHealthBar(spriteBatch);
            }
            else if (!_playedDeadAnimation)
            {
                spriteBatch.Draw(_texture, _position, _animations["SkeletonDieAnimation"].CurrentFrame.SourceRectangle, Color.White, 0, _origin, _scale, SpriteEffects.None, 0);
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

            var barPos = new Vector2(hitbox.X - 5, hitbox.Y - 15);
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

                if (_lastAttack != null && _lastAttack is SkeletonMeleeAttack)
                {
                    _animations["SkeletonAttackingAnimation"].Update(gameTime);

                    if (_animations["SkeletonAttackingAnimation"].DidFullAnimation)
                    {
                        _animations["SkeletonAttackingAnimation"].DidFullAnimation = false;
                        _lastAttack = null;
                    }
                }
                if (_direction == new Vector2(1, 0) || _direction == new Vector2(-1, 0))
                {
                    _animations["SkeletonWalkingAnimation"].Update(gameTime);
                }
                else if (_direction == new Vector2(1, -1))
                {
                    _animations["SkeletonWalkingAnimation"].Update(gameTime);
                }
                else if (_direction == new Vector2(-1, -1))
                {
                    _animations["SkeletonWalkingAnimation"].Update(gameTime);
                }
                else if (_direction == new Vector2(0, -1))
                {
                    _animations["SkeletonWalkingAnimation"].Update(gameTime);
                }
                else
                {
                    _animations["SkeletonIdleAnimation"].Update(gameTime);
                }
            }
            else if (!_playedDeadAnimation)
            {
                _animations["SkeletonDieAnimation"].Update(gameTime);

                if (_animations["SkeletonDieAnimation"].DidFullAnimation)
                {
                    _playedDeadAnimation = true;
                }
            }
        }

        public void Attack(GameTime gameTime)
        {
            Attack attack = null;

            if (DoAttack() && gameTime.TotalGameTime.TotalSeconds - _previousGameTimeTotalSecMeleeAttack > 3)
            {
                attack = new SkeletonMeleeAttack();
                _previousGameTimeTotalSecMeleeAttack = gameTime.TotalGameTime.TotalSeconds;
                _sounds["axe"].Play();
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
            Rectangle myExpandedHitBox = new Rectangle(myHitbox.X - 15, myHitbox.Y, myHitbox.Width + 15, myHitbox.Height);
            Rectangle enemyHitBox = _enemy.GetHitbox();
            Random random = new Random();

            return myExpandedHitBox.Intersects(enemyHitBox) ? random.NextDouble() > 0.6 : false;
        }

        public override Rectangle GetHitbox()
        {
            Rectangle original = base.GetHitbox();
            return new Rectangle(original.X, original.Y + 7, original.Width, original.Height);
        }
    }
}
