using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Activity
{
    public interface IQuickTimeObj
    {
        void SetActivePosition(Vector2 position);
        void SetActive(bool active);
    }
}
