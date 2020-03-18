using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PongEx1.Entities;
namespace PongEx1.Scene
{
    public interface ISceneManager
    {
        //Draw 
        void Draw();
        //Add entity to the array
        void addEntity(IEntity entity);
        //Remove entity from the array
        void removeEntity(IEntity entity);
        //Update
        void Update();
    }
}
