using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warre_Gehre_GameDevelopment.GameFiles.Blocks.BlockTypes;
using Warre_Gehre_GameDevelopment.GameFiles.Blocks;
using Warre_Gehre_GameDevelopment.GameFiles.Entities;
using Warre_Gehre_GameDevelopment.GameFiles.Inputs;
using Warre_Gehre_GameDevelopment.GameFiles.Sounds;
using Warre_Gehre_GameDevelopment.GameFiles.Textures;

namespace Warre_Gehre_GameDevelopment.GameFiles.Levels
{
    public class IceLevel : IGameObject
    {
        public readonly Mage _mage;
        public readonly Skeleton _skeleton;
        public readonly Skeleton _skeleton2;
        public readonly MiniBoss _miniBoss;

        public readonly BlockCollection _blockCollection;
        private readonly Texture2D _background;

        public IceLevel(TextureDictionary iceTextures, SoundDictionary sounds)
        {
            _blockCollection = BlockFactory.CreateIceBlocks(iceTextures["iceAssets"]);

            SoundDictionary mageSounds = new SoundDictionary();
            mageSounds.AddTexture("orb", sounds["orb"]);
            mageSounds.AddTexture("sword-slash", sounds["sword-slash"]);
            mageSounds.AddTexture("coin", sounds["coin"]);
            mageSounds.AddTexture("heal", sounds["heal"]);
            mageSounds.AddTexture("level-complete", sounds["level-complete"]);

            SoundDictionary skeletonSounds = new SoundDictionary();
            skeletonSounds.AddTexture("axe", sounds["axe"]);
            skeletonSounds.AddTexture("death-skeleton", sounds["death-skeleton"]);

            SoundDictionary miniBossSounds = new SoundDictionary();
            miniBossSounds.AddTexture("double-axe", sounds["double-axe"]);
            miniBossSounds.AddTexture("death-boss", sounds["death-boss"]);

            _mage = new Mage(iceTextures["mage"], mageSounds, new KeyboardInputProvider(), _blockCollection.GetAllBlocksAsCollideables());

            _skeleton = new Skeleton(iceTextures["skeleton"], iceTextures["healthBar"], skeletonSounds, new Vector2(770, 765), new ComputerInputProvider(_skeleton, _mage), _blockCollection.GetAllBlocksAsCollideables()) { _enemy = _mage };
            _skeleton2 = new Skeleton(iceTextures["skeleton"], iceTextures["healthBar"], skeletonSounds, new Vector2(768, 518), new ComputerInputProvider(_skeleton2, _mage), _blockCollection.GetAllBlocksAsCollideables()) { _enemy = _mage };
            _miniBoss = new MiniBoss(iceTextures["miniBoss"], iceTextures["healthBar"], miniBossSounds, new ComputerInputProvider(_miniBoss, _mage), _blockCollection.GetAllBlocksAsCollideables()) { _enemy = _mage };

            _mage._enemies.Add(_skeleton);
            _mage._enemies.Add(_skeleton2);
            _mage._enemies.Add(_miniBoss);

            _skeleton._inputReader = new ComputerInputProvider(_skeleton, _mage);
            _skeleton2._inputReader = new ComputerInputProvider(_skeleton2, _mage);
            _miniBoss._inputReader = new ComputerInputProvider(_miniBoss, _mage);

            _skeleton2.BoundingBox = new Rectangle(625, 350, 275, 250);
            _skeleton.BoundingBox = new Rectangle(625, 640, 290, 200);

            _background = iceTextures["background"];
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(_background, new Vector2(0, 0), Color.White);
            foreach (Block block in _blockCollection.AllBlocks)
            {
                block.Draw(sprite);
            }

            _skeleton.Draw(sprite);
            _skeleton2.Draw(sprite);
            _miniBoss.Draw(sprite);
            _mage.Draw(sprite);
        }

        public void Update(GameTime gameTime)
        {
            _mage.Update(gameTime);
            _skeleton.Update(gameTime);
            _skeleton2.Update(gameTime);
            _miniBoss.Update(gameTime);

            foreach (Block block in _blockCollection.SpecialBlocks)
            {
                block.Update(gameTime);
            }

            int maxPoints = _blockCollection.SpecialBlocks.Where(v => v is CoinBlock).Count();

            if (_skeleton.Health.IsDead && _skeleton2.Health.IsDead && _miniBoss.Health.IsDead && _mage.Points == maxPoints)
            {
                NextLevelSign nextLevelSign = _blockCollection.SpecialBlocks.Where(v => v is NextLevelSign).Select(v => v as NextLevelSign).First();
                nextLevelSign.IsVisible = true;
            }
        }
    }
}
