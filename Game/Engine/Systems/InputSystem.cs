using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Components;
using Engine.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine.Systems
{
    public class InputSystem : IUpdate
    {
        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            ComponentManager cm = ComponentManager.Instance;

            foreach (var ic in cm.GetComponentsOfType<InputComponent>())
            {
                var input = ic.Value as InputComponent;

                input.UpKeyPressed = false;
                input.DownKeyPressed = false;
                input.LeftKeyPressed = false;
                input.RightKeyPressed = false;

                if (keyboardState.IsKeyDown(input.Up))
                {
                    input.UpKeyPressed = true;
                }
                else if (keyboardState.IsKeyDown(input.Down))
                {
                    input.DownKeyPressed = true;
                }
                else if (keyboardState.IsKeyDown(input.Left))
                {
                    input.LeftKeyPressed = true;
                }
                else if (keyboardState.IsKeyDown(input.Right))
                {
                    input.RightKeyPressed = true;
                }
            }
        }
    }
}
