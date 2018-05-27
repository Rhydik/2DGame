using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Components
{
    public class CollisionComponent : IComponent
    {
        public Rectangle BoundingRectangle;

        public bool Collided = false;
    }
}
