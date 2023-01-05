using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warre_Gehre_GameDevelopment.GameFiles.Blocks.BlockTypes;
using Warre_Gehre_GameDevelopment.GameFiles.Blocks;
using Warre_Gehre_GameDevelopment.GameFiles.Entities;
using Warre_Gehre_GameDevelopment.GameFiles.Entities.Stats;
using Warre_Gehre_GameDevelopment.GameFiles.Movement;

namespace Warre_Gehre_GameDevelopment.GameFiles.CollideWithEvents
{
    public static class CollideWithEventHandler
    {
        public static void Handle(Moveable moveable, CollideableRectangle collideableRectangle)
        {
            CollideWithEvent collideWithEvent = collideableRectangle.GetCollideWithEvent();

            if (collideWithEvent is NoEvent)
            {
                return;
            }

            if (collideWithEvent is KillEvent)
            {
                moveable.Health.Kill();
                return;
            }

            if (collideWithEvent is DamageEvent)
            {
                DamageEvent damageEvent = collideWithEvent as DamageEvent;
                moveable.Health.Subtract(damageEvent.DamageAmount);

                if (moveable.Health.IsDead)
                {
                    if (moveable is Skeleton)
                    {
                        Skeleton skeleton = moveable as Skeleton;
                        skeleton._sounds["death-skeleton"].Play();
                    }
                    else if (moveable is MiniBoss)
                    {
                        MiniBoss miniBoos = moveable as MiniBoss;
                        miniBoos._sounds["death-boss"].Play();
                    }
                }

                return;
            }

            if (collideWithEvent is HealEvent && collideableRectangle.IsActive && moveable is Mage)
            {
                HealEvent healEvent = collideWithEvent as HealEvent;
                Mage mage = moveable as Mage;

                mage.Health.Add(healEvent.HealAmount);
                MageStats.AddHPHealed(healEvent.HealAmount);

                mage._sounds["heal"].Play();

                List<Block> blocks = collideableRectangle.GetBlocks();

                foreach (Block block in blocks)
                {
                    ToggleableBlock toggleableBlock = block as ToggleableBlock;
                    toggleableBlock.IsVisible = false;
                }

                return;
            }

            if (collideWithEvent is PointsEvent && collideableRectangle.IsActive && moveable is Mage)
            {
                PointsEvent pointsEvent = collideWithEvent as PointsEvent;
                Mage mage = moveable as Mage;

                mage.Points += pointsEvent.PointAmount;
                MageStats.AddPoints(pointsEvent.PointAmount);

                mage._sounds["coin"].Play();

                List<Block> blocks = collideableRectangle.GetBlocks();

                foreach (Block block in blocks)
                {
                    ToggleableBlock toggleableBlock = block as ToggleableBlock;
                    toggleableBlock.IsVisible = false;
                }

                return;
            }

            if (collideWithEvent is ToNextLevelEvent && collideableRectangle.IsActive && moveable is Mage)
            {
                Mage mage = moveable as Mage;
                mage.HasFinished = true;
                mage._sounds["level-complete"].Play();
            }
        }
    }
}
