using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PongEx1.Game_Engine.Entities;
using PongEx1.Game_Engine.Scene;
namespace PongEx1.Game_Engine.EntityManagement
{
   public interface IEntityManager
    {
        IEntity createEntity<T>() where T : IEntity, new();
        //Terminate
        void Terminate(IEntity entity);
        void AddSceneManager(ISceneManager pSceneManager);
    }
}
