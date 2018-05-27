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
    public class CollisionDetectionSystem : IUpdate
    {
        public bool CollisionOccured { get; set; } = false;

        public void Update(GameTime gameTime)
        {
            ComponentManager cm = ComponentManager.Instance;

            foreach (var player in cm.GetComponentsOfType<CollisionComponent>())
            {
                var playerCollision = cm.GetComponentsOfType<CollisionComponent>().First().Value as CollisionComponent;
                var playerSprite = cm.GetComponentsOfType<SpriteComponent>().First().Value as SpriteComponent;

                playerCollision.BoundingRectangle = new Rectangle(playerSprite.Rectangle.X,
                                                                  playerSprite.Rectangle.Y,
                                                                  playerSprite.Rectangle.Width,
                                                                  playerSprite.Rectangle.Height);

                foreach (var enemy in cm.GetComponentsOfType<EnemyComponent>())
                {
                    var enemyCollision = cm.GetComponentsOfType<CollisionComponent>().First().Value as CollisionComponent;
                    var enemySprite = cm.GetComponentsOfType<SpriteComponent>().First().Value as SpriteComponent;

                    playerCollision.Collided = false;
                    CollisionOccured = false;

                    enemyCollision.BoundingRectangle = new Rectangle(enemySprite.Rectangle.X,
                                                                      enemySprite.Rectangle.Y,
                                                                      enemySprite.Rectangle.Width,
                                                                      enemySprite.Rectangle.Height);

                    if (playerCollision.BoundingRectangle.Intersects(enemyCollision.BoundingRectangle))
                    {
                        playerCollision.Collided = true;
                        CollisionOccured = true;
                    }

                }
            }
        }
    }
}
