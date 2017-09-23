using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrickBreaker
{
    public class TouchInput : MonoBehaviour
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
        void Update()
        {
            if (paddle.autoPlay)
                return;
            InputCheck();
        }

        void InputCheck()
        {
            if (Input.touchCount > 0)
            {

                paddle.Move(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position));
                //Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                //paddle.transform.position = Vector3.Lerp(paddle.transform.position, targetPosition, );
            }
            else
            {
                paddle.Stop();
            }

            
        }
    }
}
