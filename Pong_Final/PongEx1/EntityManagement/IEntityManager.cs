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
        //Create Ball
        IEntity createBall();
        //Create Paddle
        IEntity createPaddle();
        //Terminate
        void Terminate(IEntity entity, ISceneManager sceneManager);
    }
}
