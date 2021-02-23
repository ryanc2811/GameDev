using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Sound_Stuff
{
    public interface ISoundEmitter
    {
        void AddSounds(IDictionary<string, ISound> sounds);
        ISoundManager GetSoundManager();
    }
}
