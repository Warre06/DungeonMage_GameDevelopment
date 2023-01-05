using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Warre_Gehre_GameDevelopment.GameFiles.Entities.Attacks
{
    public abstract class Attack
    {
        public int Damage { get; protected set; }
        public int Range { get; set; }

        public Attack()
        {
            Damage = 1;
            Range = 5;
        }

        public Rectangle GetHurtBox(Rectangle hitbox, bool isLookingRight) => new Rectangle(isLookingRight ? hitbox.X + Range : hitbox.X - Range, hitbox.Y, hitbox.Width, hitbox.Height);
    }
}
