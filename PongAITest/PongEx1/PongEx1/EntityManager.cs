using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1
{
    class EntityManager:IEntityManager
    {
        ISceneManager sceneManager;
        //Creates a IEntity object with a dynamic type of ball.
        public IEntity createBall()
        {
            IEntity ball = new Ball();
            //give the object a UID
            ball.id = generateID();
            return ball;
        }
        //Creates a IEntity object with a dynamic type of paddle.
        public IEntity createPaddle()
        {
            IEntity paddle = new Paddle();
            //give the object a UID
            paddle.id = generateID();
            return paddle;
        }
        //Creates a IEntity object with a dynamic type of paddle.
        public IEntity createAI(IBall ball)
        {
            IEntity AI = new AI(ball);
            //give the object a UID
            AI.id = generateID();
            return AI;
        }
        //Generate a unique ID for an Entity
        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }
        //Terminate an entity from the game world
        public void Terminate(IEntity entity, ISceneManager pSceneManager)
        {
            sceneManager = pSceneManager;
            sceneManager.removeEntity(entity);

            }
        }
}
