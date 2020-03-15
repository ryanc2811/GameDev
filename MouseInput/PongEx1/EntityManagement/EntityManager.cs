﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PongEx1.Entities;
using PongEx1.Scene;
namespace PongEx1.EntityManagement
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