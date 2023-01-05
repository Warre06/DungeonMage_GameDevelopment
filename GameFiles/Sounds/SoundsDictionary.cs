using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warre_Gehre_GameDevelopment.GameFiles.Sounds
{
    public class SoundDictionary
    {
        private Dictionary<string, SoundEffect> _sounds;

        public SoundEffect this[string key] => GetAnimation(key);

        public SoundDictionary()
        {
            _sounds = new Dictionary<string, SoundEffect>();
        }

        public bool AddTexture(string key, SoundEffect value)
        {
            if (_sounds.ContainsKey(key) || _sounds.ContainsValue(value))
            {
                return false;
            }

            _sounds.Add(key, value);
            return true;
        }

        public SoundEffect GetAnimation(string key)
        {
            return !_sounds.ContainsKey(key) ? throw new ArgumentException("Key not found") : _sounds[key];
        }
    }
}
