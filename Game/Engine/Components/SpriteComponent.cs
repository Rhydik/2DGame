using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Components
{
    public class SpriteComponent : IComponent
    {
        public int Height;
        public int Width;
        public SpriteBatch SpriteBatch;
        public string Image;
    }
}
