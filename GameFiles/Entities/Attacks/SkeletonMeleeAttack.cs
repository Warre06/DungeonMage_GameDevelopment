using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warre_Gehre_GameDevelopment.GameFiles.Entities.Attacks
{
    public class SkeletonMeleeAttack : Attack
    {
        public SkeletonMeleeAttack()
        {
            Damage = 15;
            Range = 15;
        }
    }
}
