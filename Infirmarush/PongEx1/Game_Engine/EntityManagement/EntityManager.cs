﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PongEx1.Activity;
using PongEx1.Entities;
using PongEx1.Game_Engine.Entities;
using PongEx1.Game_Engine.Scene;
using PongEx1.Tools;
using PongEx1.Entities.Button;
using PongEx1.Entities._Mouse;
using PongEx1.Entities.PatientStuff;
namespace PongEx1.Game_Engine.EntityManagement
{
    /// <summary>
    /// 
    /// </summary>
    class EntityManager:IEntityManager
    {
        #region Variables
        //DECLARE ISceneManager
        ISceneManager sceneManager;
        #endregion
        #region Adds the Scenemanager to entity manager
        /// <summary>
        /// Adds the scenemanager to the entity manager so that the entity manager-
        /// can tell the scene manager to remove the entity from the scene
        /// </summary>
        /// <param name="pSceneManager"></param>
        public void AddSceneManager(ISceneManager pSceneManager)
        {
            sceneManager = pSceneManager;
        }
        #endregion
        #region Create Entity

        /// <summary>
        /// Generic Factory for IEntity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEntity createEntity<T>() where T : IEntity, new()
        {
            IEntity entity = new T();
            entity.id = generateID();
            return entity;
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
        public void Terminate(IEntity entity)
        {
            
            sceneManager.removeEntity(entity);
        }
        #endregion
    }
}
