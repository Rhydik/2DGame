﻿using Microsoft.Xna.Framework;
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
        public Texture2D Texture;
        public Rectangle Rectangle;
    }
}
