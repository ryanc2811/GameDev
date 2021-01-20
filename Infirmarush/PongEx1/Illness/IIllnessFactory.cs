using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Illness
{
    /// <summary>
    /// INTERFACE FOR THE ILLESS FACTORY, CREATES A NEW ILLNESS
    /// </summary>
    public interface IIllnessFactory
    {
        /// <summary>
        /// CREATES A NEW ILLNESS
        /// </summary>
        /// <returns></returns>
        IIllness create();
    }
}
