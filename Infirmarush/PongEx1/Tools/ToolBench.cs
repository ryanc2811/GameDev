using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using PongEx1.Entities;
using PongEx1.Entities.Button;
using PongEx1.Game_Engine.Collision;
using PongEx1.Game_Engine.Entities;

namespace PongEx1.Tools
{
    class ToolBench : GameXEntity,ICollidable,IToolBench,IImmovable
    {
        #region DATA MEMBERS
        //DECLARE AN ILIST FOR STORING ALL THE TOOLS IN THE TOOL BENCH
        private IList<ITool> tools;
        //DECLARE A IBUTTON FOR ADDING THE TOOL TO THE PLAYER
        private IButton boneSawButton,leechButton;
        //DECLARE A REFERENCE TO THE PLAYER
        private IEntity player;
        #endregion
        #region CONSTRUCTOR
        public ToolBench()
        {
            //INSTANTIATE A LIST OF TOOLS
            tools = new List<ITool>();
            //SET THE LAYER DEPTH
            layerDepth = 0.2f;
        }
        #endregion
        #region PROPERTIES
        /// <summary>
        /// GETTER FOR THE TOOL BENCH HITBOX
        /// </summary>
        /// <returns></returns>
        public Rectangle getHitBox()
        {
            return new Rectangle((int)entityLocn.X+25, (int)entityLocn.Y+25, texture.Width, texture.Height);
        }
        /// <summary>
        /// SETTER FOR THE TOOLS
        /// </summary>
        /// <param name="tool"></param>
        public void addTool(ITool tool)
        {
            tools.Add(tool);
        }
        /// <summary>
        /// ADDS A BUTTON FOR EACH TOOL
        /// </summary>
        /// <param name="BoneSawButton"></param>
        /// <param name="LeechButton"></param>
        public void SetToolButtons(IButton BoneSawButton, IButton LeechButton)
        {
            boneSawButton = BoneSawButton;
            leechButton = LeechButton;
        }
        #endregion
        #region COLLISION
        /// <summary>
        /// LISTENS FOR ENTITY THAT COLLIDES WITH TOOL BENCH
        /// </summary>
        /// <param name="entity"></param>
        public void onCollide(IEntity entity)
        {
            //IF THE ENTITY IS PLAYER
            if(entity is Player)
            {
                //SET THE PLAYER LOCALLY
                player = entity;
                //SET THE POSITION OF THE BUTTONS TO BE ONSCREEN
                ((IEntity)boneSawButton).setPosition(entityLocn.X, entityLocn.Y - 75);
                ((IEntity)leechButton).setPosition(entityLocn.X+85, entityLocn.Y - 75);
            }
        }
        #endregion
        #region SEARCH FOR TOOL
        /// <summary>
        /// SEARCH FOR AND RETURNS THE TOOL WITH THE NAME THAT HAS BEEN PASSED THROUGH THE PARAMETERS
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ITool getTool(string name)
        {
            for (int i = 0; i < tools.Count; i++)
            {
                if (tools[i].GetName == name)
                {
                    return tools[i];
                }
            }
            return null;
        }
        #endregion
        #region UPDATE
        /// <summary>
        /// UPDATES THE TOOLS
        /// </summary>
        public override void Update()
        {
            //UPDATES ALL THE TOOLS IN THE TOOL BENCH
            for (int i = 0; i < tools.Count; i++)
            {
                tools[i].Update();
            }
            //IF THE PLAYER IS NOT NULL
            if (player != null)
            {
                //STORE THE PLAYERS POSITION
                Vector2 playerPos = player.getPosition();
                //CALCULATE THE DISTANCE FROM THE PLAYER
                Vector2 distanceFromPlayer = playerPos - entityLocn;
                //IF THE DISTANCE ON THE Y AXIS IS GREATER THAN A 100
                if (distanceFromPlayer.Y > 100f)
                {
                    //SET THE POSITION OF THE BUTTONS OFF SCREEN
                    ((IEntity)boneSawButton).setPosition(1700, 1125);
                    ((IEntity)leechButton).setPosition(1700, 1125);
                }
                //IF THE BONESAW BUTTON IS CLICK
                if (boneSawButton.Clicked)
                {
                    //IF THE PLAYER DOES NOT HAVE A TOOL
                    if(((IPlayer)player).currentTool == null)
                    {
                        //ADD THE BONE SAW TO THE PLAYER
                        ((IPlayer)player).currentTool = getTool("BoneSaw");
                        Console.WriteLine("Bone Saw Tool Added");
                    }
                    //IF THE PLAYERS CURRENT TOOL IS NOT THE BONESAW AND THE PLAYER DOES HAVE A TOOL
                    else if (((IPlayer)player).currentTool.GetName != "BoneSaw"&& ((IPlayer)player).currentTool!= null)
                    {
                        //ADD THE BONESAW TO THE PLAYER
                        ((IPlayer)player).currentTool = getTool("BoneSaw");
                        Console.WriteLine("Bone Saw Tool Added");
                    }
                }
                //IF THE LEECH BUTTON IS CLICKED
                if (leechButton.Clicked)
                {
                    //IF THE PLAYER DOES NOT HAVE A TOOL
                    if (((IPlayer)player).currentTool == null)
                    {
                        //SET THE PLAYERS CURRENT TOOL TO A LEECH
                        ((IPlayer)player).currentTool = getTool("Leech");
                        Console.WriteLine("Leeches Added");
                    }
                    //IF THE PLAYERS CURRENT TOOL IS NOT A LEECH
                    else if (((IPlayer)player).currentTool.GetName != "Leech" && ((IPlayer)player).currentTool != null)
                    {
                        //ADD THE LEECH TO THE PLAYERS CURREN TOOL
                        ((IPlayer)player).currentTool = getTool("Leech");
                        Console.WriteLine("Leeches Added");
                    }
                }
            }
        }
        #endregion
    }
}
