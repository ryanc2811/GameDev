using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Sound_Stuff
{
    public interface ISound
    {
        SoundEffect GetSound { get; }
        bool IsLooped { get; set; }
        void Play(float volume);
        void Play(AudioListener listener, AudioEmitter emitter, float volume);
    }
}
