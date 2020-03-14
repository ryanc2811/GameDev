using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PongEx1.Entities;
namespace PongEx1.Scene
{
    public interface ISceneManager
    {
        void Draw();
        void addEntity(IEntity entity);
        void removeEntity(IEntity entity);
        void Update();
    }
}
