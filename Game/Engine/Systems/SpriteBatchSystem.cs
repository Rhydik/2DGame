using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Components;
using Engine.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Systems
{
    public class SpriteBatchSystem : IRender, IUpdate
    {
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            ComponentManager cm = ComponentManager.Instance; 

            foreach (var sb in cm.GetComponentsOfType(SpriteComponent))
            {

            }
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
