using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blockbreaker
{
    /// <summary>
    /// 
    /// </summary>
    public class Level : MonoBehaviour
    {

        private int numberOfBricks;
        public int NumberOfBricks { get { return numberOfBricks; } }

        /// <summary>
        /// Use this for initialization
        /// Called on game start
        /// </summary>
        void Start()
        {
            if (numberOfBricks == 0)
            {
                numberOfBricks = transform.childCount;
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnEnable()
        {
            if (numberOfBricks == 0)
            {
                numberOfBricks = transform.childCount;
            }
            Debug.Log("Bricks to break = " + numberOfBricks);
            Brick.breakableCount = numberOfBricks;
        }

        /// <summary>
        /// 
        /// </summary>
        private void Reset()
        {
            numberOfBricks = transform.childCount;
        }

    }
}
