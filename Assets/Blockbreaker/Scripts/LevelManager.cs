using UnityEngine;
using System.Collections;

namespace Blockbreaker
{
    /// <summary>
    /// 
    /// </summary>
    public class LevelManager : MonoBehaviour
    {
        private int levelIndex = 0;
        [SerializeField]
        private Level[] levelsArray;

        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            if (levelsArray.Length == 0)
            {
                for (int i = 0; i < levelsArray.Length; i++)
                {
                    levelsArray[i].gameObject.SetActive(false);
                }
                levelsArray[0].gameObject.SetActive(true);
            }
            
        }        

        /// <summary>
        /// 
        /// </summary>
        public void LoadNextLevel()
        {
            
            levelsArray[levelIndex].gameObject.SetActive(false);
            levelIndex++;
            if (levelIndex >= levelsArray.Length)
            {
                levelIndex = 0;
                GameManager.Instance.GameOver(true);

                return;
            }
            levelsArray[levelIndex].gameObject.SetActive(true);
            Brick.breakableCount =  levelsArray[levelIndex].NumberOfBricks;
            Debug.Log("Breakablecount = " + Brick.breakableCount);

        }

        /// <summary>
        /// 
        /// </summary>
        private void Reset()
        {
            levelsArray = new Level[transform.childCount];
            for (int i = 0; i < levelsArray.Length; i++)
            {
                levelsArray[i] = transform.GetChild(i).GetComponent<Level>();
                levelsArray[i].gameObject.SetActive(false);
            }
            levelsArray[0].gameObject.SetActive(true);
        }

    }
}
