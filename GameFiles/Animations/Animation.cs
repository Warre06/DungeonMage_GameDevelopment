using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warre_Gehre_GameDevelopment.GameFiles.Animations
{
    public class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }

        protected List<AnimationFrame> frames;
        private int counter;
        private double secondCounter = 0;

        public bool DidFullAnimation { get; set; }

        public Animation()
        {
            frames = new List<AnimationFrame>();
            DidFullAnimation = false;
        }

        public void AddFrame(AnimationFrame frame)
        {
            frames.Add(frame);
            CurrentFrame = frames[0];
        }

        public void Update(GameTime gameTime)
        {
            CurrentFrame = frames[counter];
            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            int fps = 8;

            if (secondCounter >= 1d / fps)
            {
                counter++;
                secondCounter = 0;
            }
            if (counter >= frames.Count)
            {
                counter = 0;
                DidFullAnimation = true;
            }
        }
    }
}
