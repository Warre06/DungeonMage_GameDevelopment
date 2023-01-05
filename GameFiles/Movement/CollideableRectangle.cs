using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warre_Gehre_GameDevelopment.GameFiles.Blocks.BlockTypes;
using Warre_Gehre_GameDevelopment.GameFiles.Blocks;
using Warre_Gehre_GameDevelopment.GameFiles.CollideWithEvents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Warre_Gehre_GameDevelopment.GameFiles.Movement
{
    public class CollideableRectangle : ICollideable
    {
        private Rectangle _hitbox;
        private CollideWithEvent _collideWithEvent;
        private List<Block> _blocksInsideCollideableRectangle;

        public bool CanBeWalkedOn { get; set; }
        public bool IsActive => _blocksInsideCollideableRectangle.Count == 0 ? true : GetBlocks().Where(v => v is ToggleableBlock).Select(v => v as ToggleableBlock).Any(v => v.IsVisible);

        public CollideableRectangle(Rectangle hitbox, CollideWithEvent collideWithEvent)
        {
            _hitbox = hitbox;
            _collideWithEvent = collideWithEvent;
            CanBeWalkedOn = true;
            _blocksInsideCollideableRectangle = new List<Block>();
        }

        public void AddBlock(Block block) => _blocksInsideCollideableRectangle.Add(block);
        public List<Block> GetBlocks() => _blocksInsideCollideableRectangle;
        public CollideWithEvent GetCollideWithEvent() => _collideWithEvent;
        public Rectangle GetHitbox() => _hitbox;

        public override string ToString() => $"Hitbox: {_hitbox}";
    }
}
