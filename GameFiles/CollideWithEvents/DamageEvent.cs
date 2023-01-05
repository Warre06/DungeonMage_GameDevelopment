using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warre_Gehre_GameDevelopment.GameFiles.CollideWithEvents
{
    public class DamageEvent : CollideWithEvent
    {
        public int DamageAmount { get; }

        public DamageEvent(int damageAmount)
        {
            DamageAmount = damageAmount;
        }
    }
}
