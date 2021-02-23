using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Sound_Stuff
{
    class SoundManager:ISoundManager
    {
        //DECLARE An IDictionary for storing references to Sounds
        private IDictionary<string,ISound> sounds;

        public SoundManager(IDictionary<string, ISound> pSounds)
        {
            sounds = pSounds;
        }
        /// <summary>
        /// Adds a new sound to the sounds dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <param name="sound"></param>
        public void AddSound(string key,ISound sound)
        {
            sounds.Add(key, sound);
        }
        /// <summary>
        /// Play the sound at the passed key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="volume"></param>
        public void Play(string key, float volume)
        {
            sounds[key].Play(volume);
        }
        /// <summary>
        /// Play the sound at the passed key and apply 3D sound
        /// </summary>
        /// <param name="key"></param>
        /// <param name="listener"></param>
        /// <param name="emitter"></param>
        /// <param name="volume"></param>
        public void Play(string key, AudioListener listener,AudioEmitter emitter, float volume)
        {
            sounds[key].Play(listener,emitter,volume);
        }
    }
}
