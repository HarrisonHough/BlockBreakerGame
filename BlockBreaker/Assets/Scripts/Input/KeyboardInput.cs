using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrickBreaker
{
    public class KeyboardInput : MonoBehaviour
    {

        [SerializeField]
        private Paddle paddle;

        // Use this for initialization
        void Start()
        {
            if (paddle == null)
                paddle = FindObjectOfType<Paddle>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (paddle.autoPlay)
                return;
            InputCheck();
        }

        private void InputCheck()
        {
            paddle.Move( Input.GetAxis("Horizontal"));
        }
    }
}
