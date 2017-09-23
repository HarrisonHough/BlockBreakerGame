using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BrickBreaker;

public class TouchJoystick : MonoBehaviour
{

    private Vector3 startMousePos;

    [SerializeField]
    private Paddle objectToMove;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckMouseInput();
        CheckTouchInput();
    }


    void CheckTouchInput()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                TouchBegan();
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                objectToMove.Move(touch.deltaPosition);
                //TouchMoved(touch.deltaPosition);

            }
        }
    }

    //TODO remove this
    void TouchBegan()
    {

    }

    void CheckMouseInput()
    {
        if (Input.mousePosition.y < Screen.height * 0.8)
        {
            if (Input.GetMouseButtonDown(0))
            {
                MouseDown();
            }
            else if (Input.GetMouseButton(0))
            {
                MouseHold();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                MouseUp();
            }
        }
    }

    void MouseDown()
    {
        startMousePos = Input.mousePosition;
    }

    void MouseHold()
    {
        float deltaX = Input.mousePosition.x - startMousePos.x;
        deltaX = Mathf.Clamp(deltaX, -2, 2);
        Vector2 delta = new Vector2(deltaX, 0f);
        objectToMove.Move(delta);
        Debug.Log("moving with mouse");
    }

    void MouseUp()
    {

    }
}
