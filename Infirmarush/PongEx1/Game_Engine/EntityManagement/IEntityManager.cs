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
        //Create Ball
        IEntity createPlayer();
        IEntity createWall();
        IEntity createPlayerHitCheck();
        //Terminate
        void Terminate(IEntity entity, ISceneManager sceneManager);
    }
}
