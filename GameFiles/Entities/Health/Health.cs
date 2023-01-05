using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warre_Gehre_GameDevelopment.GameFiles.Entities.Health
{
    public abstract class Health
    {
        public int HP { get; protected set; }

        public virtual bool IsDead => HP <= 0;

        public virtual void Add(int amount) => HP += amount;

        public virtual void Subtract(int amount) => HP -= amount;

        public virtual void Kill() => HP = 0;
    }
}
