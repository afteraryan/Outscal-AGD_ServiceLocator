using System;
using UnityEngine;

namespace ServiceLocator.Sound
{
    public class SoundService : GenericMonoSingleton<SoundService>
    {
        [SerializeField] private SoundScriptableObject soundScriptableObject;
        [SerializeField] private AudioSource audioEffects;
        [SerializeField] private AudioSource backgroundMusic;
        
        //Singleton Declarations
        public static SoundService Instance {get{return _instance;}}
        private static SoundService _instance;

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
            {
                Destroy(this);
                Debug.LogError("Singleton of SoundService is trying to create another instance.");
            }
        }

        private void Start()
        {
            PlaybackgroundMusic(SoundType.BackgroundMusic, true);
        }

        public void PlaySoundEffects(SoundType soundType, bool loopSound = false)
        {
            AudioClip clip = GetSoundClip(soundType);
            if (clip != null)
            {
                audioEffects.loop = loopSound;
                audioEffects.clip = clip;
                audioEffects.PlayOneShot(clip);
            }
            else
                Debug.LogError("No Audio Clip selected.");
        }

        private void PlaybackgroundMusic(SoundType soundType, bool loopSound = false)
        {
            AudioClip clip = GetSoundClip(soundType);
            if (clip != null)
            {
                backgroundMusic.loop = loopSound;
                backgroundMusic.clip = clip;
                backgroundMusic.Play();
            }
            else
                Debug.LogError("No Audio Clip selected.");
        }

        private AudioClip GetSoundClip(SoundType soundType)
        {
            Sounds sound = Array.Find(soundScriptableObject.audioList, item => item.soundType == soundType);
            if (sound.audio != null)
                return sound.audio;
            return null;
        }
    }
}