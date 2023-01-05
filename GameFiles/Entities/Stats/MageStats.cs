using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warre_Gehre_GameDevelopment.GameFiles.Entities.Stats
{
    public static class MageStats
    {
        public static int TotalPoints { get; private set; }
        public static int TotalHPHealed { get; private set; }
        public static TimeSpan TimeElapsed => _end - _start;

        private static DateTime _start;
        private static DateTime _end;

        public static void Reset()
        {
            TotalPoints = 0;
            TotalHPHealed = 0;
            _start = DateTime.Now;
            _end = DateTime.Now.AddSeconds(1);
        }

        public static void AddPoints(int amount) => TotalPoints += amount;

        public static void ResetPointsToLevel1() => TotalPoints = 10;

        public static void AddHPHealed(int amount) => TotalHPHealed += amount;

        public static void SetStartTime(DateTime start) => _start = start;

        public static void SetEndTime(DateTime end) => _end = end;
    }
}
