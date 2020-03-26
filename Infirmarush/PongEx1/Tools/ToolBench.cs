using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using PongEx1.Game_Engine.Collision;
using PongEx1.Game_Engine.Entities;

namespace PongEx1.Tools
{
    class ToolBench : GameXEntity,ICollidable,IToolBench
    {
        IList<ITool> tools;
        public ToolBench()
        {
            tools = new List<ITool>();
        }
        public Rectangle getHitBox()
        {
            return new Rectangle((int)entityLocn.X+25, (int)entityLocn.Y+25, texture.Width, texture.Height);
        }

        public void onCollide(IEntity entity)
        {
            
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
        }
    }
}
