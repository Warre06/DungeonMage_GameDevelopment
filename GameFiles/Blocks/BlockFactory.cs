using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Warre_Gehre_GameDevelopment.GameFiles.Blocks.BlockTypes;
using Warre_Gehre_GameDevelopment.GameFiles.CollideWithEvents;
using Warre_Gehre_GameDevelopment.GameFiles.Movement;

namespace Warre_Gehre_GameDevelopment.GameFiles.Blocks
{
    public class BlockFactory
    {
        public static BlockCollection CreateIceBlocks(Texture2D texture)
        {
            BlockCollection blockCollection = new BlockCollection();

            #region Floor

            for (int i = 0; i < 1600; i += 32)
            {
                if ((i >= 352 && i <= 480) || (i >= 1000 && i <= 1192))
                {
                    blockCollection.AddBlock(CreateBlock(BlockType.WATER, i, 838, texture));
                }
                else if (i >= 1350 && i <= 1450)
                {
                    blockCollection.AddBlock(CreateBlock(BlockType.SPIKE, i, 838, texture));
                    blockCollection.AddBlock(CreateBlock(BlockType.NORMAL, i, 860, texture));
                }
                else
                {
                    blockCollection.AddBlock(CreateBlock(BlockType.NORMAL, i, 838, texture));
                }
            }

            //Floor
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(0, 838, 352, 62), new NoEvent()));
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(512, 838, 513, 62), new NoEvent()));
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(1217, 838, 159, 62), new NoEvent()));
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(1472, 838, 128, 62), new NoEvent()));

            //Water
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(352, 838, 160, 62), new KillEvent()));
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(1025, 838, 192, 62), new KillEvent()));

            //Spikes
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(1380, 838, 88, 32), new DamageEvent(2)));

            #endregion

            #region Platforms

            for (int i = 370; i < 370 + (3 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM, i, 700, texture));
            }

            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(370, 700, 96, 27), new NoEvent()));

            for (int i = 1070; i < 1070 + (3 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM, i, 700, texture));
            }

            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(1070, 700, 96, 27), new NoEvent()));

            for (int i = 570; i < 570 + (12 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM, i, 590, texture));
            }

            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(570, 590, 384, 27), new NoEvent()));

            for (int i = 25; i < 50 + (5 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM, i, 480, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(25, 480, 192, 27), new NoEvent()));

            for (int i = 242; i < 242 + (2 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM, i, 580, texture));
            }

            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(242, 580, 64, 27), new NoEvent()));

            for (int i = 1030; i < 1030 + (2 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM, i, 480, texture));
            }

            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(1030, 480, 64, 27), new NoEvent()));

            for (int i = 1200; i < 1200 + (2 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM, i, 430, texture));
            }

            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(1200, 430, 64, 27), new NoEvent()));

            for (int i = 1350; i < 1350 + (1 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM1, i, 390, texture));
            }

            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(1350, 390, 32, 27), new NoEvent()));

            for (int i = 1490; i < 1490 + (4 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM, i, 430, texture));
            }

            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(1490, 430, 128, 27), new NoEvent()));

            for (int i = 320; i < 320 + (30 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM, i, 200, texture));
            }

            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(320, 200, 960, 27), new NoEvent()));

            for (int i = 1536; i < 1536 + (2 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM, i, 290, texture));
            }

            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(1536, 290, 64, 27), new NoEvent()));

            for (int i = 1420; i < 1420 + (2 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM, i, 140, texture));
            }

            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(1420, 140, 64, 27), new NoEvent()));

            for (int i = 25; i < 0 + (5 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM, i, 120, texture));
            }

            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(25, 120, 160, 27), new NoEvent()));

            #endregion

            #region Walls         

            //Wall 1
            blockCollection.AddBlock(CreateBlock(BlockType.WALL, 565, 800, texture));
            blockCollection.AddBlock(CreateBlock(BlockType.WALL, 565, 750, texture));
            blockCollection.AddBlock(CreateBlock(BlockType.WALL, 585, 800, texture));
            blockCollection.AddBlock(CreateBlock(BlockType.WALL, 585, 750, texture));

            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(565, 750, 52, 120), new NoEvent()));

            //Wall 2
            blockCollection.AddBlock(CreateBlock(BlockType.WALL, 925, 800, texture));
            blockCollection.AddBlock(CreateBlock(BlockType.WALL, 925, 750, texture));
            blockCollection.AddBlock(CreateBlock(BlockType.WALL, 945, 800, texture));
            blockCollection.AddBlock(CreateBlock(BlockType.WALL, 945, 750, texture));

            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(925, 750, 52, 120), new NoEvent()));

            //Wall 3
            blockCollection.AddBlock(CreateBlock(BlockType.WALL, 900, 542, texture));


            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(900, 542, 32, 52), new NoEvent()));

            //Wall 4

            blockCollection.AddBlock(CreateBlock(BlockType.WALL, 590, 542, texture));

            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(590, 542, 32, 52), new NoEvent()));

            #endregion

            #region Coins

            //Coin 1
            Block coin1Block = CreateBlock(BlockType.COIN, 620, 815, texture);
            blockCollection.AddBlock(coin1Block);

            CollideableRectangle coin1CR = new CollideableRectangle(new Rectangle(620, 815, 19, 18), new PointsEvent(1)) { CanBeWalkedOn = false };
            coin1CR.AddBlock(coin1Block);
            blockCollection.AddCollideableRectangle(coin1CR);

            //Coin 2
            Block coin2Block = CreateBlock(BlockType.COIN, 770, 815, texture);
            blockCollection.AddBlock(coin2Block);

            CollideableRectangle coin2CR = new CollideableRectangle(new Rectangle(770, 815, 19, 18), new PointsEvent(1)) { CanBeWalkedOn = false };
            coin2CR.AddBlock(coin2Block);
            blockCollection.AddCollideableRectangle(coin2CR);

            //Coin 3
            Block coin3Block = CreateBlock(BlockType.COIN, 900, 815, texture);
            blockCollection.AddBlock(coin3Block);

            CollideableRectangle coin3CR = new CollideableRectangle(new Rectangle(900, 815, 19, 18), new PointsEvent(1)) { CanBeWalkedOn = false };
            coin3CR.AddBlock(coin3Block);
            blockCollection.AddCollideableRectangle(coin3CR);

            //Coin 4
            Block coin4Block = CreateBlock(BlockType.COIN, 1550, 815, texture);
            blockCollection.AddBlock(coin4Block);

            CollideableRectangle coin4CR = new CollideableRectangle(new Rectangle(1550, 815, 19, 18), new PointsEvent(1)) { CanBeWalkedOn = false };
            coin4CR.AddBlock(coin4Block);
            blockCollection.AddCollideableRectangle(coin4CR);

            //Coin 5
            Block coin5Block = CreateBlock(BlockType.COIN, 45, 460, texture);
            blockCollection.AddBlock(coin5Block);

            CollideableRectangle coin5CR = new CollideableRectangle(new Rectangle(45, 460, 19, 18), new PointsEvent(1)) { CanBeWalkedOn = false };
            coin5CR.AddBlock(coin5Block);
            blockCollection.AddCollideableRectangle(coin5CR);

            //Coin 6
            Block coin6Block = CreateBlock(BlockType.COIN, 65, 460, texture);
            blockCollection.AddBlock(coin6Block);

            CollideableRectangle coin6CR = new CollideableRectangle(new Rectangle(65, 460, 19, 18), new PointsEvent(1)) { CanBeWalkedOn = false };
            coin6CR.AddBlock(coin6Block);
            blockCollection.AddCollideableRectangle(coin6CR);

            //Coin 7
            Block coin7Block = CreateBlock(BlockType.COIN, 625, 570, texture);
            blockCollection.AddBlock(coin7Block);

            CollideableRectangle coin7CR = new CollideableRectangle(new Rectangle(625, 570, 19, 18), new PointsEvent(1)) { CanBeWalkedOn = false };
            coin7CR.AddBlock(coin7Block);
            blockCollection.AddCollideableRectangle(coin7CR);

            //Coin 8
            Block coin8Block = CreateBlock(BlockType.COIN, 880, 570, texture);
            blockCollection.AddBlock(coin8Block);

            CollideableRectangle coin8CR = new CollideableRectangle(new Rectangle(880, 570, 19, 18), new PointsEvent(1)) { CanBeWalkedOn = false };
            coin8CR.AddBlock(coin8Block);
            blockCollection.AddCollideableRectangle(coin8CR);

            //Coin 9
            Block coin9Block = CreateBlock(BlockType.COIN, 1570, 410, texture);
            blockCollection.AddBlock(coin9Block);

            CollideableRectangle coin9CR = new CollideableRectangle(new Rectangle(1570, 410, 19, 18), new PointsEvent(1)) { CanBeWalkedOn = false };
            coin9CR.AddBlock(coin9Block);
            blockCollection.AddCollideableRectangle(coin9CR);

            //Coin 10
            Block coin10Block = CreateBlock(BlockType.COIN, 32, 100, texture);
            blockCollection.AddBlock(coin10Block);

            CollideableRectangle coin10CR = new CollideableRectangle(new Rectangle(32, 100, 19, 18), new PointsEvent(1)) { CanBeWalkedOn = false };
            coin10CR.AddBlock(coin10Block);
            blockCollection.AddCollideableRectangle(coin10CR);

            #endregion 

            #region Apples

            //Apple 1
            Block appleBlock = CreateBlock(BlockType.APPLE, 1580, 810, texture);
            blockCollection.AddBlock(appleBlock);

            CollideableRectangle appleCR = new CollideableRectangle(new Rectangle(1580, 815, 16, 20), new HealEvent(10)) { CanBeWalkedOn = false };
            appleCR.AddBlock(appleBlock);
            blockCollection.AddCollideableRectangle(appleCR);

            //Apple 2
            Block apple2Block = CreateBlock(BlockType.APPLE, 1550, 410, texture);
            blockCollection.AddBlock(apple2Block);

            CollideableRectangle app2leCR = new CollideableRectangle(new Rectangle(1550, 410, 16, 20), new HealEvent(10)) { CanBeWalkedOn = false };
            app2leCR.AddBlock(apple2Block);
            blockCollection.AddCollideableRectangle(app2leCR);

            #endregion

            #region Cherries

            Block cherryBlock = CreateBlock(BlockType.CHERRY, 100, 460, texture);
            blockCollection.AddBlock(cherryBlock);

            CollideableRectangle cherryCR = new CollideableRectangle(new Rectangle(100, 460, 20, 18), new HealEvent(25)) { CanBeWalkedOn = false };
            cherryCR.AddBlock(cherryBlock);
            blockCollection.AddCollideableRectangle(cherryCR);

            #endregion

            #region Next Level Sign

            ToggleableBlock nextLevelBlock = CreateBlock(BlockType.NEXT_LEVEL_SIGN, 1200, 170, texture) as ToggleableBlock;
            nextLevelBlock.IsVisible = false;
            blockCollection.AddBlock(nextLevelBlock);

            CollideableRectangle nextLevelCR = new CollideableRectangle(new Rectangle(1200, 170, 32, 32), new ToNextLevelEvent()) { CanBeWalkedOn = false };
            nextLevelCR.AddBlock(nextLevelBlock);
            blockCollection.AddCollideableRectangle(nextLevelCR);

            #endregion

            return blockCollection;
        }

        public static BlockCollection CreateParkourBlocks(Texture2D texture)
        {
            BlockCollection blockCollection = new BlockCollection();

            #region Floor

            for (int i = 0; i < 1600; i += 32)
            {
                if (i >= 0 && i <= 92 || i >= 1500 && i <= 1600)
                {
                    blockCollection.AddBlock(CreateBlock(BlockType.NORMAL, i, 838, texture));
                }
                else
                {
                    blockCollection.AddBlock(CreateBlock(BlockType.SPIKE, i, 838, texture));
                    blockCollection.AddBlock(CreateBlock(BlockType.NORMAL, i, 860, texture));
                }
            }
            //Floor
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(0, 838, 100, 32), new NoEvent()));
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(1500, 838, 100, 32), new NoEvent()));

            //Spike
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(100, 838, 1400, 32), new KillEvent()));

            #endregion

            #region Platforms
            //platform 1
            for (int i = 150; i < 150 + (1 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM1, i, 700, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(150, 700, 32, 27), new NoEvent()));

            //platform 2
            for (int i = 235; i < 235 + (1 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM1, i, 600, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(235, 600, 32, 27), new NoEvent()));

            //platform 3
            for (int i = 525; i < 525 + (1 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM1, i, 620, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(525, 620, 32, 27), new NoEvent()));

            //platform 4
            for (int i = 650; i < 650 + (1 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM1, i, 700, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(650, 700, 32, 27), new NoEvent()));

            //platform 5
            for (int i = 750; i < 750 + (1 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM1, i, 570, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(750, 570, 32, 27), new NoEvent()));

            //platform 6
            for (int i = 925; i < 925 + (3 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM, i, 790, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(925, 790, 96, 27), new NoEvent()));

            //platform 7
            for (int i = 1150; i < 1150 + (2 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM, i, 790, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(1150, 790, 64, 27), new NoEvent()));

            //platform 8
            for (int i = 1315; i < 1315 + (2 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM, i, 610, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(1315, 610, 64, 27), new NoEvent()));

            //platform 9
            for (int i = 1575; i < 1575 + (1 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM1, i, 670, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(1575, 670, 32, 27), new NoEvent()));

            //platform 10
            for (int i = 1590; i < 1590 + (1 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM1, i, 500, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(1590, 500, 32, 27), new NoEvent()));

            // platform 11
            for (int i = 1450; i < 1450 + (1 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM1, i, 375, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(1450, 375, 32, 27), new NoEvent()));

            // platform 12
            for (int i = 1550; i < 1550 + (2 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM, i, 100, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(1550, 100, 64, 27), new NoEvent()));

            // platform 13
            for (int i = 50; i < 50 + (1 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM1, i, 535, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(50, 535, 32, 27), new NoEvent()));

            // platform 14
            for (int i = 2; i < 2 + (1 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM1, i, 370, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(2, 370, 32, 27), new NoEvent()));

            // platform 15
            for (int i = 205; i < 205 + (2 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM, i, 370, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(205, 370, 64, 27), new NoEvent()));

            // platform 16
            for (int i = 415; i < 415 + (1 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM1, i, 350, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(415, 350, 32, 27), new NoEvent()));

            // platform 17
            for (int i = 600; i < 600 + (1 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM1, i, 380, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(600, 380, 32, 27), new NoEvent()));

            // platform 18
            for (int i = 500; i < 500 + (1 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM1, i, 100, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(500, 100, 32, 27), new NoEvent()));

            // platform 19
            for (int i = 650; i < 650 + (1 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM1, i, 200, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(650, 200, 32, 27), new NoEvent()));

            // platform 20
            for (int i = 225; i < 225 + (4 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM, i, 90, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(225, 90, 128, 27), new NoEvent()));

            // platform 21
            for (int i = 850; i < 850 + (3 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM, i, 250, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(850, 250, 96, 27), new NoEvent()));

            // platform 22
            for (int i = 1300; i < 1300 + (1 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM1, i, 320, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(1300, 320, 32, 27), new NoEvent()));

            // platform 23
            for (int i = 1200; i < 1200 + (1 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM1, i, 200, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(1200, 200, 32, 27), new NoEvent()));

            // platform 23
            for (int i = 1350; i < 1350 + (2 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM, i, 100, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(1350, 100, 64, 27), new NoEvent()));
            // platform 24 miss
            for (int i = 1025; i < 1025 + (2 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM, i, 150, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(1025, 150, 64, 27), new NoEvent()));

            //Coin platform 1
            for (int i = 1000; i < 1000 + (6 * 32); i += 32)
            {
                if (i >= 1064 && i <= 1127)
                {
                    blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM, i, 500, texture));
                }
                else
                {
                    blockCollection.AddBlock(CreateBlock(BlockType.SPIKE, i, 500, texture));
                }
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(1000, 500, 57, 27), new KillEvent()));
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(1057, 500, 78, 27), new NoEvent()));
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(1135, 500, 57, 27), new KillEvent()));

            //Coin platform 2
            for (int i = 2; i < 2 + (2 * 32); i += 32)
            {
                blockCollection.AddBlock(CreateBlock(BlockType.PLATFORM, i, 100, texture));
            }
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(2, 100, 64, 27), new NoEvent()));


            #endregion

            #region Walls

            blockCollection.AddBlock(CreateBlock(BlockType.WALL, 400, 800, texture));
            blockCollection.AddCollideableRectangle(new CollideableRectangle(new Rectangle(400, 800, 32, 60), new NoEvent()));

            #endregion

            #region Coins

            //Coin1
            CoinBlock coin1Block = CreateBlock(BlockType.COIN, 1540, 790, texture) as CoinBlock;
            coin1Block.Scale = 2.5f;
            blockCollection.AddBlock(coin1Block);

            CollideableRectangle coin1CR = new CollideableRectangle(new Rectangle(1540, 790, 32, 31), new PointsEvent(5)) { CanBeWalkedOn = false };
            coin1CR.AddBlock(coin1Block);
            blockCollection.AddCollideableRectangle(coin1CR);

            //Coin2
            CoinBlock coin2Block = CreateBlock(BlockType.COIN, 12, 55, texture) as CoinBlock;
            coin2Block.Scale = 2.5f;
            blockCollection.AddBlock(coin2Block);

            CollideableRectangle coin2CR = new CollideableRectangle(new Rectangle(12, 55, 32, 31), new PointsEvent(5)) { CanBeWalkedOn = false };
            coin2CR.AddBlock(coin2Block);
            blockCollection.AddCollideableRectangle(coin2CR);

            //Coin3
            CoinBlock coin3Block = CreateBlock(BlockType.COIN, 1080, 460, texture) as CoinBlock;
            coin3Block.Scale = 2.5f;
            blockCollection.AddBlock(coin3Block);

            CollideableRectangle coin3CR = new CollideableRectangle(new Rectangle(1080, 460, 32, 31), new PointsEvent(5)) { CanBeWalkedOn = false };
            coin3CR.AddBlock(coin3Block);
            blockCollection.AddCollideableRectangle(coin3CR);

            #endregion

            #region Sign

            ToggleableBlock endBlock = CreateBlock(BlockType.NEXT_LEVEL_SIGN, 1560, 65, texture) as ToggleableBlock;
            endBlock.IsVisible = true;
            blockCollection.AddBlock(endBlock);

            CollideableRectangle endBlockCR = new CollideableRectangle(new Rectangle(1560, 65, 32, 32), new ToNextLevelEvent()) { CanBeWalkedOn = false };
            endBlockCR.AddBlock(endBlock);
            blockCollection.AddCollideableRectangle(endBlockCR);


            #endregion

            return blockCollection;
        }

        private static Block CreateBlock(BlockType type, int x, int y, Texture2D texture)
        {
            return type switch
            {
                BlockType.NORMAL => new Block(x, y, texture),
                BlockType.WALL => new WallBlock(x, y, texture),
                BlockType.WATER => new WaterBlock(x, y, texture),
                BlockType.SPIKE => new SpikeBlock(x, y, texture),
                BlockType.COIN => new CoinBlock(x, y, texture),
                BlockType.APPLE => new AppleBlock(x, y, texture),
                BlockType.CHERRY => new CherryBlock(x, y, texture),
                BlockType.NEXT_LEVEL_SIGN => new NextLevelSign(x, y, texture),
                BlockType.PLATFORM => new Platform(x, y, texture),
                BlockType.PLATFORM1 => new Platform1(x, y, texture),

                _ => throw new Exception($"Unknown type: {type}"),
            };
        }
    }
}
