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
        IList<ITool> tools;
        IButton boneSawButton;
        IButton leechButton;
        IEntity player;
        
        public ToolBench()
        {
            tools = new List<ITool>();
            layerDepth = 0.2f;
        }
        public Rectangle getHitBox()
        {
            return new Rectangle((int)entityLocn.X+25, (int)entityLocn.Y+25, texture.Width, texture.Height);
        }

        public void onCollide(IEntity entity)
        {
            if(entity is Player)
            {
                player = entity;
                ((IEntity)boneSawButton).setPosition(entityLocn.X, entityLocn.Y - 75);
                ((IEntity)leechButton).setPosition(entityLocn.X+85, entityLocn.Y - 75);
            }
        }
        public void addTool(ITool tool)
        {
            tools.Add(tool);
        }
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
        public override void Update()
        {
            for (int i = 0; i < tools.Count; i++)
            {
                tools[i].Update();
            }
            if (player != null)
            {
                Vector2 playerPos = player.getPosition();
                Vector2 distanceFromPlayer = playerPos - entityLocn;
                if (distanceFromPlayer.Y > 100f)
                {
                    ((IEntity)boneSawButton).setPosition(1700, 1125);
                    ((IEntity)leechButton).setPosition(1700, 1125);
                }
                if (boneSawButton.Clicked)
                {
                    if(((IPlayer)player).currentTool == null)
                    {
                        ((IPlayer)player).currentTool = getTool("BoneSaw");
                        Console.WriteLine("Bone Saw Tool Added");
                    }
                    else if (((IPlayer)player).currentTool.GetName != "BoneSaw"&& ((IPlayer)player).currentTool!= null)
                    {
                        ((IPlayer)player).currentTool = getTool("BoneSaw");
                        Console.WriteLine("Bone Saw Tool Added");
                    }
                }
                if (leechButton.Clicked)
                {
                    if (((IPlayer)player).currentTool == null)
                    {
                        ((IPlayer)player).currentTool = getTool("Leech");
                        Console.WriteLine("Leeches Added");
                    }
                    else if (((IPlayer)player).currentTool.GetName != "Leech" && ((IPlayer)player).currentTool != null)
                    {
                        ((IPlayer)player).currentTool = getTool("Leech");
                        Console.WriteLine("Leeches Added");
                    }
                }
            }
        }

        public void SetToolButtons(IButton BoneSawButton,IButton LeechButton)
        {
            boneSawButton = BoneSawButton;
            leechButton = LeechButton;
        }
    }
}
