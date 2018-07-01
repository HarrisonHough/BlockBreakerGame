using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blockbreaker
{
    /// <summary>
    /// 
    /// </summary>
    public class AudioController : GenericSingleton<AudioController>
    {
        
        [SerializeField]
        private AudioSource musicAudio;
        [SerializeField]
        private AudioSource sfxAudio;

        /// <summary>
        /// Use this for initialization
        /// </summary>
        void Start()
        {
            
            if (musicAudio == null)
            {
                musicAudio = transform.GetChild(0).GetComponent<AudioSource>();
            }
            if (sfxAudio == null)
            {
                sfxAudio = transform.GetChild(1).GetComponent<AudioSource>();
            }

            PlayMusic();
        }

        /// <summary>
        /// 
        /// </summary>
        void PlayMusic()
        {
            musicAudio.Play();
        }

    }
}
