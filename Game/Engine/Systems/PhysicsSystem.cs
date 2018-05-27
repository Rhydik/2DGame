using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Components;
using Engine.Manager;
using Microsoft.Xna.Framework;

namespace Engine.Systems
{
    public class PhysicsSystem : IUpdate
    {
        public void Update(GameTime gameTime)
        {
            ComponentManager cm = ComponentManager.Instance;

            foreach (var ps in cm.GetComponentsOfType<InputComponent>())
            {
                SpriteComponent sprite = cm.GetComponentsOfType<SpriteComponent>().First().Value as SpriteComponent;
                InputComponent input = ps.Value as InputComponent;

                if (input != null)
                {
                    if (input.UpKeyPressed)
                    {
                        sprite.Rectangle.Y--;
                    }
                    else if (input.DownKeyPressed)
                    {
                        sprite.Rectangle.Y++;
                    }
                    else if (input.LeftKeyPressed)
                    {
                        sprite.Rectangle.X--;
                    }
                    else if (input.RightKeyPressed)
                    {
                        sprite.Rectangle.X++;
                    }
                }
            }
        }
    }
}
