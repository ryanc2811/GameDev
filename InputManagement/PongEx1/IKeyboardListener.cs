﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1
{
    public interface IKeyboardListener
    {
        void OnNewInput(object sender, InputEventArgs args);
        
    }
}
