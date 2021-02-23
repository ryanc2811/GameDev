using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Sound_Stuff
{
    class Sound : ISound
    {
        //DECLARE A SoundEffect for storing a reference to the SoundEffect
        public SoundEffect GetSound { get; private set; }

        //DECLARE A bool for checking if the sound should be looped
        public bool IsLooped { get; set; }

        public Sound(SoundEffect soundEffect)
        {
            GetSound = soundEffect;
            IsLooped = false;
        }
        /// <summary>
        /// Plays the sound effect at the 3D space
        /// </summary>
        /// <param name="listener"></param>
        /// <param name="emitter"></param>
        /// <param name="volume"></param>
        public void Play(AudioListener listener,AudioEmitter emitter,float volume)
        {
            var instance= GetSound.CreateInstance();
            instance.IsLooped = IsLooped;
            instance.Apply3D(listener, emitter);
            instance.Volume = volume;
            instance.Play();
        }
        /// <summary>
        /// Play the sound effect at the passed volume setting
        /// </summary>
        /// <param name="volume"></param>
        public void Play(float volume)
        {
            var instance = GetSound.CreateInstance();
            instance.IsLooped = IsLooped;
            instance.Volume = volume;
            instance.Play();
        }
    }
}
