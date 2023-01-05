using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warre_Gehre_GameDevelopment.GameFiles.CollideWithEvents
{
    public class PointsEvent : CollideWithEvent
    {
        public int PointAmount { get; }

        public PointsEvent(int pointAmount)
        {
            PointAmount = pointAmount;
        }
    }
}
