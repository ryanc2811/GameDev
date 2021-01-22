using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Entities;
namespace GameEngine.Scene
{
    public interface ISceneManager
    {
        //Draw 
        void Draw();
        //Add entity to the array
        void AddEntity(IEntity entity);
        //Remove entity from the array
        void removeEntity(IEntity entity);
        //Update
        void Update();
    }
}
