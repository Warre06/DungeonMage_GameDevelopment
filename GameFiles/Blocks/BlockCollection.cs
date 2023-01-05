using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warre_Gehre_GameDevelopment.GameFiles.Blocks.BlockTypes;
using Microsoft.Xna.Framework;
using Warre_Gehre_GameDevelopment.GameFiles.Movement;

namespace Warre_Gehre_GameDevelopment.GameFiles.Blocks
{
    public class BlockCollection
    {
        private List<Block> _blocks;
        private List<Block> _specialBlocks;
        private List<CollideableRectangle> _collideableRectangles;

        public List<Block> AllBlocks => this.GetAllBlocks();
        public List<Block> SpecialBlocks => _specialBlocks;
        public List<CollideableRectangle> CollideableRectangles => _collideableRectangles;

        public BlockCollection()
        {
            _blocks = new List<Block>();
            _specialBlocks = new List<Block>();
            _collideableRectangles = new List<CollideableRectangle>();
        }

        public void AddBlock(Block block)
        {
            if (block is WaterBlock || block is ToggleableBlock)
            {
                AddSpecialBlock(block);
            }
            else
            {
                _specialBlocks.Add(block);
            }
        }

        private void AddSpecialBlock(Block block)
        {
            _specialBlocks.Add(block);
        }

        public void AddCollideableRectangle(CollideableRectangle collideableRectangle)
        {
            _collideableRectangles.Add(collideableRectangle);
        }

        public List<ICollideable> GetAllBlocksAsCollideables()
        {
            List<ICollideable> result = new List<ICollideable>();

            foreach (CollideableRectangle cr in _collideableRectangles)
            {
                result.Add(cr);
            }

            return result;
        }

        private List<Block> GetAllBlocks()
        {
            List<Block> result = new List<Block>(_blocks);

            foreach (Block block in _specialBlocks)
            {
                result.Add(block);
            }

            return result;
        }
    }
}
