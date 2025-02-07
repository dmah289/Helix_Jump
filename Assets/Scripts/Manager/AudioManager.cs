using System;
using Framework;
using Model;
using UnityEngine;

namespace Manager
{
    public class AudioManager : Singleton<AudioManager>
    {
        public Sound[] sounds;

        private void Start()
        {
            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
        }

        public void PlaySound(string sound)
        {
            Sound s = Array.Find(sounds, item => item.name == sound);
            s.source.Play();
        }
    }
}