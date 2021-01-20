using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.PatientStuff.Health_Bar
{
    /// <summary>
    /// Represents the current health of a patient
    /// </summary>
    class HealthBar:GameXEntity,IHealthBar
    {
        //DECLARE A Color for the green health bar colour
        Color healthBarGreen = new Color(34, 160, 76);
        //DECLARE A BOOLEAN FOR FLAGGING WHEN THE GAME HAS BEEN FIRST EXECUTED
        private bool initial;
        //DECLARE A VECTOR2 FOR STORING THE START POSITION OF THE HEALTHBAR
        private Vector2 startPos;
        //PROPERTY FOR GETTING THE START POSITION OF THE HEALTH BAR
        public Vector2 StartPos { get { return startPos; } }
        public override void Update()
        {
            //ON THE FIRST FRAME OF UPDATE
            if (!initial)
            {
                initial = true;
                //SET THE START POSITION TO THE CURRENT POSITION
                startPos = entityLocn;
            }
        }
        /// <summary>
        /// UPDATES THE CAPACITY OF THE HEALTH BAR WITH THE PASSED VALUE
        /// </summary>
        /// <param name="health"></param>
        public void UpdateHealth(double health)
        {
            //SET THE SCALE OF THE HEALTH BAR TO THE HEALTH VALUE THAT HAS BEEN PASSED, GIVING IT THE EFFECT OF GETTING SMALLER, THE LOWER THE HEALTH VALUE IS
            scale = new Vector2(1f, (float)health);
            //IF THE HEALTH IS HIGHER THAT 70%, THE HEALTH BAR WILL BE GREEN
            if (health > .7f)
                spriteColour = healthBarGreen;
            //IF THE HEALTH BAR IS LESS THAN 70%,BUT HIGHER THAN 30%, THE COLOUR OF THE HEALTH BAR WILL BE ORANGE
            else if (health < .7f && health > .3f)
                spriteColour = Color.Orange;
            //IF THE HEALTH IS LESS THAN 30%, THE HEALTH BAR WILL BE RED
            else if (health < .3f)
                spriteColour = Color.Red;
        }
    }
}
