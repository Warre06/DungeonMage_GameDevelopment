using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warre_Gehre_GameDevelopment.GameFiles.Entities.Health
{
    public class BossHealth : Health
    {
        private const int MAX_HEALTH = 500;

        public BossHealth()
        {
            HP = MAX_HEALTH;
        }

        public override void Add(int amount) => HP = (HP + amount > MAX_HEALTH) ? MAX_HEALTH : HP + amount;
    }
}
