using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1
{
    public interface ISceneManager
    {
        void Draw();
        void addEntity(IEntity entity);
        void removeEntity(IEntity entity);
        void Update();
    }
}
