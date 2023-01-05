using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warre_Gehre_GameDevelopment.GameFiles.CollideWithEvents;
using Warre_Gehre_GameDevelopment.GameFiles.Entities.Health;
using Warre_Gehre_GameDevelopment.GameFiles.Inputs;

namespace Warre_Gehre_GameDevelopment.GameFiles.Movement
{
    public abstract class Moveable : IGameObject, ICollideable
    {
        public IInputProvider _inputReader;
        private readonly List<ICollideable> _collideables;

        public Vector2 _position;
        protected Vector2 _velocity;
        protected Vector2 _direction;
        protected Vector2 _compareRight = new Vector2(1, 0);
        protected Vector2 _compareLeft = new Vector2(-1, 0);
        protected Vector2 _compareUp = new Vector2(0, -1);

        protected bool jumping = false;
        protected bool falling = false;
        protected float jumpSpeed = 0;

        private float _width;
        private float _height;

        public Rectangle BoundingBox { get; set; }

        public Health Health { get; }
        public bool CanBeWalkedOn { get; set; } = false;

        public Moveable(Health health, IInputProvider inputreader, List<ICollideable> collideables, float width, float height)
        {
            _inputReader = inputreader;
            _collideables = collideables;

            _position = new Vector2(0, 765);
            _velocity = new Vector2(3.5f, 3.5f);
            _width = width;
            _height = height;

            Health = health;
        }

        protected void Move()
        {
            _direction = _inputReader.GetInput();
            Vector2 newPosition = _position + (_velocity * _direction);

            if (jumping)
            {
                newPosition.Y += jumpSpeed;
                jumpSpeed += 1;
            }
            else
            {
                if (_direction == new Vector2(0, -1) || _direction == new Vector2(1, -1) || _direction == new Vector2(-1, -1))
                {
                    jumping = true;
                    jumpSpeed = -15f; //jumpforce
                }
            }

            bool isColliding = false;
            if (newPosition.X < -25 || newPosition.X > 1600 - (_width + 10))
            {
                isColliding = true;
            }

            foreach (ICollideable collideable in _collideables)
            {
                Rectangle collideableHitbox = collideable.GetHitbox();
                Rectangle myHitbox = this.GetHitbox();
                Rectangle myHurtBox = new Rectangle(myHitbox.X, myHitbox.Y, myHitbox.Width, myHitbox.Height + 5);

                if (myHitbox.Intersects(collideableHitbox) && collideable.CanBeWalkedOn)
                {
                    isColliding = true;
                    CollisionPosition collisionPosition = new CollisionPosition();

                    if (myHitbox.Top <= collideableHitbox.Bottom && myHitbox.Bottom > collideableHitbox.Bottom && _direction.Y == -1)
                    {
                        //Bottom
                        _position.Y = collideableHitbox.Bottom + 3;
                        collisionPosition.IsCollidingBottom = true;
                    }
                    else if (myHitbox.Bottom >= collideableHitbox.Top && myHitbox.Y < collideableHitbox.Y)
                    {
                        //Top
                        _position.Y = collideableHitbox.Top - _height;
                        collisionPosition.IsCollidingTop = true;
                    }
                    if (myHitbox.Right >= collideableHitbox.Left && _direction.X == 1 &&
                        myHitbox.Y >= collideableHitbox.Y && !collisionPosition.IsCollidingBottom)
                    {
                        //Left
                        collisionPosition.IsCollidingLeft = true;
                        _position.X = collideableHitbox.Left - _width - 30;

                        if (jumping && jumpSpeed > 0)
                        {
                            _position.Y += 3;
                        }
                    }
                    else if (myHitbox.Left <= collideableHitbox.Right && _direction.X == -1 &&
                        myHitbox.Y >= collideableHitbox.Y && !collisionPosition.IsCollidingBottom)
                    {
                        //Right
                        collisionPosition.IsCollidingRight = true;
                        _position.X = collideableHitbox.Right + 4;

                        if (jumping && jumpSpeed > 0)
                        {
                            _position.Y += 3;
                        }
                    }

                    if (collisionPosition.IsNotColliding)
                    {
                        if (myHitbox.Top <= collideableHitbox.Bottom)
                        {
                            //Bottom
                            _position.Y = collideableHitbox.Bottom + 4;
                        }
                    }
                }

                if (myHurtBox.Intersects(collideableHitbox))
                {
                    CollideWithEventHandler.Handle(this, collideable as CollideableRectangle);
                }
            }

            if (isColliding)
            {
                jumping = false;
            }
            else
            {
                _position = newPosition;
            }

            Rectangle myFallingBox = new Rectangle(this.GetHitbox().X, this.GetHitbox().Y, this.GetHitbox().Width, this.GetHitbox().Height + 5);
            if (!jumping && !_collideables.Any(v => v.GetHitbox().Intersects(myFallingBox)))
            {
                jumping = true;
                jumpSpeed = 1f;
            }

            if (_position.Y > 765 && jumping)
            {
                jumping = false;
                _position.Y = 765;
            }

            //Debug.WriteLine($"position: {_position}");
        }

        public abstract void Draw(SpriteBatch sprite);

        public virtual void Update(GameTime gametime)
        {

        }

        public virtual Rectangle GetHitbox() => new Rectangle((int)_position.X, (int)_position.Y, (int)_width, (int)_height);

        public virtual CollideWithEvent GetCollideWithEvent() => new NoEvent();

        internal class CollisionPosition
        {
            public bool IsCollidingTop { get; set; }
            public bool IsCollidingBottom { get; set; }
            public bool IsCollidingLeft { get; set; }
            public bool IsCollidingRight { get; set; }

            public bool IsNotColliding => !IsCollidingTop && !IsCollidingBottom && !IsCollidingLeft && !IsCollidingRight;

            public CollisionPosition()
            {
                IsCollidingTop = false;
                IsCollidingBottom = false;
                IsCollidingLeft = false;
                IsCollidingRight = false;
            }
        }
    }
}
