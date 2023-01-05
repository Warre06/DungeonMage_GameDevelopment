using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warre_Gehre_GameDevelopment.GameFiles.CollideWithEvents;
using Microsoft.Xna.Framework;

namespace Warre_Gehre_GameDevelopment.GameFiles.Movement
{
    public interface ICollideable
    {
        public bool CanBeWalkedOn { get; set; }

        Rectangle GetHitbox();

        CollideWithEvent GetCollideWithEvent();
    }
}
