using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warre_Gehre_GameDevelopment.GameFiles.Blocks;
using Warre_Gehre_GameDevelopment.GameFiles.Entities;
using Warre_Gehre_GameDevelopment.GameFiles.Inputs;
using Warre_Gehre_GameDevelopment.GameFiles.Sounds;
using Warre_Gehre_GameDevelopment.GameFiles.Textures;

namespace Warre_Gehre_GameDevelopment.GameFiles.Levels
{
    public class ParkourLevel
    {
        public readonly Mage _mage;

        public readonly BlockCollection _blockCollection;
        private readonly Texture2D _background;

        public ParkourLevel(TextureDictionary parkourTextures, SoundDictionary sounds)
        {
            _blockCollection = BlockFactory.CreateParkourBlocks(parkourTextures["caveAssets"]);
            _mage = new Mage(parkourTextures["mage"], sounds, new KeyboardInputProvider(), _blockCollection.GetAllBlocksAsCollideables());
            _mage.CanAttack = false;
            _background = parkourTextures["background"];
        }
        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(_background, new Vector2(0, 0), Color.White);
            foreach (Block block in _blockCollection.AllBlocks)
            {
                block.Draw(sprite);
            }
            _mage.Draw(sprite);
        }

        public void Update(GameTime gameTime)
        {
            _mage.Update(gameTime);

            foreach (Block block in _blockCollection.SpecialBlocks)
            {
                block.Update(gameTime);
            }
        }
    }
}
