﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1
{
    interface ICollisionSubscriber
    {
        void Subscribe(ICollidable collidable);
        void Unsubscribe(ICollidable collidable);
    }
}