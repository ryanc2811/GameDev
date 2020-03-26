using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PongEx1.Activity;
using PongEx1.Entities;
using PongEx1.Game_Engine.Entities;
using PongEx1.Game_Engine.Scene;
using PongEx1.Tools;
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
        #region Create HitCheck
        //Creates a IEntity object with a dynamic type of ball.
        public IEntity createPlayerHitCheck()
        {
            IEntity HitCheck = new PlayerHitCheck();
            //give the object a UID
            HitCheck.id = generateID();
            return HitCheck;
        }
        #endregion
        #region Create Patient
        //Creates a IEntity object with a dynamic type of ball.
        public IEntity createPatient()
        {
            IEntity patient = new Patient();
            //give the object a UID
            patient.id = generateID();
            return patient;
        }
        #endregion
        #region Create ToolBench
        //Creates a IEntity object with a dynamic type of ball.
        public IEntity createToolBench()
        {
            IEntity toolBench = new ToolBench();
            //give the object a UID
            toolBench.id = generateID();
            return toolBench;
        }
        #endregion
        #region QuickTime
        public IEntity createContainer()
        {
            IEntity container = new Container();
            //give the object a UID
            container.id = generateID();
            return container;
        }

        public IEntity createQTLine()
        {
            IEntity QTLine = new QTLine();
            //give the object a UID
            QTLine.id = generateID();
            return QTLine;
        }

        public IEntity createQTGreen()
        {
            IEntity QTGreen = new QTGreen();
            //give the object a UID
            QTGreen.id = generateID();
            return QTGreen;
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
