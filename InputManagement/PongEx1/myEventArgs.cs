using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1
{
    
    public class myEventArgs:EventArgs
    {
        public string currentArg;

        public myEventArgs(string newArg)
        {
            currentArg = newArg;
        }
    }
}
