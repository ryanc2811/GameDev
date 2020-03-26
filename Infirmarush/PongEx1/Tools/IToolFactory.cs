using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Tools
{
   public interface IToolFactory
    {
        ITool create(string name);
    }
}
