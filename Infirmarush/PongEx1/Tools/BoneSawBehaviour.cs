using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PongEx1.Activity;
using PongEx1.Entities;
using PongEx1.Game_Engine.Entities;
using PongEx1.Game_Engine.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Tools
{
    class BoneSawBehaviour:ToolBehaviour,IToolBehaviour<BoneSawBehaviour>,IInputListener
    {
        private IEntity QTContainer;
        private IEntity QTLine;
        private IEntity QTGreen;
        private string RedTexture = "QTLineRed";
        private string BlackTexture = "QTLine";
        bool hitGreen = false;
        bool inGreen = false;
        bool interact = false;
        bool initial = false;
        bool gotInput = false;
        //bool hasInteracted = false;
        Vector2 linePos;
        Vector2 greenPos;
        int lineWidth;
        int lineHeight;
        int greenWidth;
        int greenHeight;
        public void SetQTItems(IEntity QTContainer, IEntity QTLine, IEntity QTGreen)
        {
            this.QTContainer= QTContainer;
            this.QTLine=QTLine;
            this.QTGreen= QTGreen;
        }
        private void SetQTObjPos()
        {
            QTContainer.setPosition(100, 300);
            QTGreen.setPosition(150, 310);
            QTLine.setPosition(100, 310);
        }
        public override void Behaviour()
        {
            //isActive = true;
            if (!initial)
            {
                initial = true;
                SetQTObjPos();
            }
            //Vector2 linePos = QTLine.getPosition();
            //Vector2 greenPos = QTGreen.getPosition();
            //int lineWidth = ((IShape)QTLine).getWidth();
            //int greenWidth = ((IShape)QTGreen).getWidth();
            //int lineHeight = ((IShape)QTLine).getHeight();
            //int greenHeight = ((IShape)QTGreen).getHeight();
            //Rectangle lineHitBox = new Rectangle((int)linePos.X, (int)linePos.Y, lineWidth, lineHeight);
            //Rectangle greenHitBox = new Rectangle((int)greenPos.X, (int)greenPos.Y, greenWidth, greenHeight);
            if (((QTLine)QTLine).gethasHitGreen)
            {
                inGreen = true;
            }
            else
            {
                inGreen = false;
            }
                
            //if not it green, set texture to red
            if (!inGreen)
                ((Activity.QTLine)QTLine).setTexture(RedTexture);
            //if the line is in the green area, set texture to black
            else
            {
                ((Activity.QTLine)QTLine).setTexture(BlackTexture);
            }
            if (Keyboard.GetState().IsKeyUp(Keys.E))
            {
                interact = false;
                gotInput = false;
                hitGreen = false;
            }
        }
       /// <summary>
       /// Checks to see if the quick time line is in the green area when e is pressed
       /// </summary>
        private void hitGreenCheck()
        {
            interact = true;
            if (inGreen)
            {
                if (!hitGreen)
                {
                    hitGreen = true;
                    Console.WriteLine("ding");
                }
            }
            else
            {
                Console.WriteLine("OW"); 
                
            }
        }
        public void OnNewInput(object sender, InputEventArgs args)
        {
          
            if (args.PressedKeys.Contains(Keys.E)&&!gotInput)
            {
                gotInput = true;
                
                if (!interact&&!hitGreen)
                {
                    hitGreenCheck();
                }
            }
            
        }
    }
}
