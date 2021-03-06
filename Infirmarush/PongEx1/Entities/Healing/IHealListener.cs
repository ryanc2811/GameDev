﻿using PongEx1._Game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.Healing
{
    /// <summary>
    /// Listens for the heal event to be triggered
    /// </summary>
    public interface IHealListener
    {
        //On Heal event
        void OnHeal(object sender, IEvent args);
    }
}
