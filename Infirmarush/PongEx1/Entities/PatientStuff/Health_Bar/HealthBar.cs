using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.PatientStuff.Health_Bar
{
    class HealthBar:GameXEntity,IHealthBar
    {
        Color healthBarGreen = new Color(34, 160, 76);
        public void UpdateHealth(double health)
        {
            scale = new Vector2(1f, (float)health);
            if (health > .7f)
                spriteColour = healthBarGreen;
            else if (health < .7f && health > .3f)
                spriteColour = Color.Orange;
            else if (health < .3f)
                spriteColour = Color.Red;
        }
    }
}
