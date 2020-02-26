﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1
{
    interface IInputManager
    {
        void addEventListener(InputDevice inputDevice, EventHandler<InputEventArgs> handler);
        void removeEventLister(EventHandler<InputEventArgs> handler);
        void Update();
    }
}
