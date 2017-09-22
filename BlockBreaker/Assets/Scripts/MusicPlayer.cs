using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrickBreaker
{
    public class MusicPlayer : MonoBehaviour
    {

        private static MusicPlayer instance = null;
        public static MusicPlayer Instance { get { return instance; } }


        // Use this for initialization
        void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;

            }
            else
            {
                instance = this;
            }
            GameObject.DontDestroyOnLoad(gameObject);

        }
    }
}
