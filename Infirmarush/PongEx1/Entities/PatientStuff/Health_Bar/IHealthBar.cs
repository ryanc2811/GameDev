using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.PatientStuff.Health_Bar
{
    public interface IHealthBar
    {
        void UpdateHealth(double health);
        Vector2 StartPos { get; }
    }
}
