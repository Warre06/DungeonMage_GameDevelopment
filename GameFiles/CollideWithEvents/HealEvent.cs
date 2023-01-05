using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warre_Gehre_GameDevelopment.GameFiles.CollideWithEvents
{
    public class HealEvent : CollideWithEvent
    {
        public int HealAmount { get; }

        public HealEvent(int healAmount)
        {
            HealAmount = healAmount;
        }
    }
}
