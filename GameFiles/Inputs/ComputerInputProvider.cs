using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Warre_Gehre_GameDevelopment.GameFiles.Movement;

namespace Warre_Gehre_GameDevelopment.GameFiles.Inputs
{
    public class ComputerInputProvider : IInputProvider
    {
        private Moveable _subject;
        private Moveable _enemy;

        private Random _random;

        public ComputerInputProvider(Moveable subject, Moveable enemy)
        {
            _subject = subject;
            _enemy = enemy;
            _random = new Random();
        }

        public Vector2 GetInput()
        {
            Vector2 direction = Vector2.Zero;

            Rectangle myHitBox = _subject.GetHitbox();
            Rectangle myBoundingBox = _subject.BoundingBox;
            Rectangle enemyHitBox = _enemy.GetHitbox();

            if (enemyHitBox.Intersects(myBoundingBox))
            {
                if (myHitBox.X < enemyHitBox.X)
                {
                    //Right
                    direction.X += 1;
                }
                else if (myHitBox.X > enemyHitBox.X)
                {
                    //Left
                    direction.X -= 1;
                }
            }

            return direction;
        }
    }
}
