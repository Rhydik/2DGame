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
    public class RenderSystem : IRender
    {
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            ComponentManager cm = ComponentManager.Instance;

            spriteBatch.Begin();

            foreach (var sb in cm.GetComponentsOfType<SpriteComponent>())
            {
                PositionComponent position = cm.GetComponentsOfType<PositionComponent>().First().Value as PositionComponent;
                SpriteComponent sprite = sb.Value as SpriteComponent;

                spriteBatch.Draw(sprite.Texture, position.Position, Color.White);
            }

            spriteBatch.End();
        }

    }
}
