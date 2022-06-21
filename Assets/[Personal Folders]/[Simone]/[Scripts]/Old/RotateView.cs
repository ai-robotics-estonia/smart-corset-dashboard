using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateView : MonoBehaviour
{
    private float startPositionX;
    private float startPositionY;
    public float rotateSpeed = 40f;
    [SerializeField] private Transform corsetTransform;
    
    
    // Start is called before the first frame update
    void Start()
    {
        startPositionX = corsetTransform.position.x;
        startPositionY = corsetTransform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPositionX = touch.position.x;
                    startPositionY = touch.position.y;
                    break;
                case TouchPhase.Moved:    
                    // if (startPositionX > touch.position.x)
                    // {
                    //     corsetTransform.Rotate(Vector3.down, rotateSpeed * Time.deltaTime);
                    // } else if (startPositionX < touch.position.x)
                    // {
                    //     corsetTransform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
                    // } 
                    if (startPositionY > touch.position.y)
                    {
                        corsetTransform.Rotate(Vector3.down, rotateSpeed * Time.deltaTime);
                    } else if (startPositionY < touch.position.y)
                    {
                        corsetTransform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
                    }
                    break;
                case TouchPhase.Ended:
                    Debug.Log("Touch Ended");
                    break;
            }
        }
    }
}
