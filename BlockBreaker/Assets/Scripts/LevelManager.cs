using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace BrickBreaker
{
    public class LevelManager : MonoBehaviour
    {

        public void LoadLevel(string name)
        {
            Brick.breakableCount = 0;
            Debug.Log("New Level load: " + name);
            SceneManager.LoadScene(name);
        }

        public void QuitRequest()
        {
            Debug.Log("Quit requested");
            Application.Quit();
        }

        public void LoadNextLevel()
        {
            Brick.breakableCount = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void BrickDestroyed()
        {
            if (Brick.breakableCount <= 0)
            {
                LoadNextLevel();
            }
        }
    }
}
