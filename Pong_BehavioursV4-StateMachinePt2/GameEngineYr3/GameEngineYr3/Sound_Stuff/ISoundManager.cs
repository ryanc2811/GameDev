using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Sound_Stuff
{
    public interface ISoundManager
    {
        void AddSound(string key, ISound sound);
        void Play(string key, float volume);
    }
}
