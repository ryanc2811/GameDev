﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Input
{
    interface IInputManager
    {
        void addEventListener(InputDevice inputDevice, EventHandler<InputEventArgs> handler);
        void removeEventListener(InputDevice inputDevice,EventHandler<InputEventArgs> handler);
        void Update();
    }
}
