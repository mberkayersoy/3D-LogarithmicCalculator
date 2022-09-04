using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    private Touch touch;

    private float xMin = -5, xMax = 5;
    float deltaSwipeX, lastXPosition;
    Vector3 firstTouchPos;

    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
        SideMovingControls();
        SwipeControl();
    }

    void SwipeControl()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                firstTouchPos = touch.position;
            }

            deltaSwipeX = (touch.position.x - firstTouchPos.x) * 2;

            if (touch.phase == TouchPhase.Ended)
            {
                lastXPosition = transform.position.x;
                deltaSwipeX = 0;
            }
        }
    }

    void SideMovingControls()
    {
        transform.position = new Vector3(Mathf.Clamp((deltaSwipeX / 200 + lastXPosition), xMin, xMax), 
                                                      transform.position.y, transform.position.z);
    }
}
