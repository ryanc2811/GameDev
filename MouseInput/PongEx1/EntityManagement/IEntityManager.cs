using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PongEx1.Entities;
using PongEx1.Scene;
namespace PongEx1.EntityManagement
{
    interface IEntityManager
    {
        IEntity createBall();
        IEntity createPaddle();
        void Terminate(IEntity entity, ISceneManager sceneManager);
    }
}
