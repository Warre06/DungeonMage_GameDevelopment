using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warre_Gehre_GameDevelopment.GameFiles.Animations
{
    public class AnimationCollection
    {
        private Dictionary<string, Animation> _animations;

        public Animation this[string key] => GetAnimation(key);

        public AnimationCollection()
        {
            _animations = new Dictionary<string, Animation>();
        }

        public bool AddAnimation(string key, Animation value)
        {
            if (_animations.ContainsKey(key) || _animations.ContainsValue(value))
            {
                return false;
            }

            _animations.Add(key, value);
            return true;
        }

        public Animation GetAnimation(string key)
        {
            return !_animations.ContainsKey(key) ? throw new ArgumentException("Key not found") : _animations[key];
        }
    }
}
