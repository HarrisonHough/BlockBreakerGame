using UnityEngine;

namespace BrickBreaker
{

    public class MusicPlayerRemover : MonoBehaviour
    {

        public void RemoveMusicPlayer()
        {
            if (MusicPlayer.Instance != null)
            {
                Destroy(MusicPlayer.Instance.gameObject);
            }
        }
    }
}
