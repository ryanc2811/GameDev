using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PongEx1.Entities;
using PongEx1.Game_Engine.Entities;
using PongEx1.Game_Engine.Scene;
namespace PongEx1.Game_Engine.EntityManagement
{
    class EntityManager:IEntityManager
    {
        #region Variables
        //DECLARE ISceneManager
        ISceneManager sceneManager;
        #endregion

        #region Create Player
        //Creates a IEntity object with a dynamic type of ball.
        public IEntity createPlayer()
        {
            IEntity player = new Player();
            //give the object a UID
            player.id = generateID();
            return player;
        }
        #endregion
        #region Create Wall
        //Creates a IEntity object with a dynamic type of ball.
        public IEntity createWall()
        {
            IEntity wall = new Wall();
            //give the object a UID
            wall.id = generateID();
            return wall;
        }
        #endregion

        #region ID
        //Generate a unique ID for an Entity
        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }
        #endregion

        #region Terminate
        //Terminate an entity from the game world
        public void Terminate(IEntity entity, ISceneManager pSceneManager)
        {
            sceneManager = pSceneManager;
            sceneManager.removeEntity(entity);

            }
        #endregion
    }
}
