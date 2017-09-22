using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrickBreaker
{
    public class LoseCollider : MonoBehaviour
    {

        [SerializeField]
        private LevelManager levelManager = null;

        private void Start()
        {
            if (levelManager == null)
                levelManager = FindObjectOfType<LevelManager>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            levelManager.LoadLevel("BB_Lose_Screen");
        }

    }
}
