using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Components
{
    public class InputComponent : IComponent
    {
        public Keys Up;
        public Keys Down;
        public Keys Left;
        public Keys Right;
        public bool UpKeyPressed = false;
        public bool DownKeyPressed = false;
        public bool LeftKeyPressed = false;
        public bool RightKeyPressed = false;


    }
}
