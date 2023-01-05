using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warre_Gehre_GameDevelopment.GameFiles.Entities.Attacks
{
    public class MageMeleeAttack : Attack
    {
        public MageMeleeAttack()
        {
            Damage = 20;
            Range = 20;
        }
    }
}
