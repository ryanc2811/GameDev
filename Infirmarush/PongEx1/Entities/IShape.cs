using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities
{
    /// <summary>
    /// INTERFACE FOR ENTITIES THAT WANT TO LEAVE THEIR WIDTH VALUE OPEN TO READ
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// GETS THE WIDTH OF AN ENTITY
        /// </summary>
        /// <returns></returns>
        int getWidth();
    }
}
