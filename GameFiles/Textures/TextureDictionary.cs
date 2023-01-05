using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Warre_Gehre_GameDevelopment.GameFiles.Textures
{
    public class TextureDictionary
    {
        private Dictionary<string, Texture2D> _textures;

        public Texture2D this[string key] => GetAnimation(key);

        public TextureDictionary()
        {
            _textures = new Dictionary<string, Texture2D>();
        }

        public bool AddTexture(string key, Texture2D value)
        {
            if (_textures.ContainsKey(key) || _textures.ContainsValue(value))
            {
                return false;
            }

            _textures.Add(key, value);
            return true;
        }

        public Texture2D GetAnimation(string key)
        {
            return !_textures.ContainsKey(key) ? throw new ArgumentException("Key not found") : _textures[key];
        }
    }
}
