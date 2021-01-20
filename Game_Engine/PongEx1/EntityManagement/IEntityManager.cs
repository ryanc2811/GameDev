using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PongEx1.Entities;
using PongEx1.Scene;
namespace PongEx1.EntityManagement
{
   public interface IEntityManager
    {
        IEntity createEntity<T>() where T : IEntity, new();
        //Terminate
        void Terminate(IEntity entity);
        void AddSceneManager(ISceneManager pSceneManager);
    }
}
