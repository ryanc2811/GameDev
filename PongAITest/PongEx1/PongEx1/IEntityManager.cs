using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1
{
    interface IEntityManager
    {
        IEntity createBall();
        IEntity createPaddle();
        IEntity createAI(IBall ball);
        void Terminate(IEntity entity, ISceneManager sceneManager);
    }
}
