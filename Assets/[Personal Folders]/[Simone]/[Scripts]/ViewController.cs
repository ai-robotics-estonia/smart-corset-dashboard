using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class ViewController : MonoBehaviour
{

    [SerializeField] private Transform corsetTransform;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float maxOrtoValue = 2f;
    [SerializeField] private float minOrtoValue = 0.3f;
    [SerializeField] private GameObject humanoidAvatar;
    private float rotationSpeed = 10f;
    private float zoomSpeed = 0.1f;

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                //Debug.Log("Something Hit");
                if (raycastHit.transform.CompareTag("RotatingObjects"))
                {
                    if (Input.touchCount == 1)
                    {
                        Touch touch = Input.GetTouch(0);
                        float xDirection = touch.deltaPosition.x * rotationSpeed * Time.deltaTime;
                        //float yDirection = touch.deltaPosition.y * rotationSpeed * Time.deltaTime;

                        if (touch.phase == TouchPhase.Moved)
                        {
                            corsetTransform.Rotate(0f, xDirection, 0f, relativeTo: Space.Self);
                        }
                        else if (touch.phase == TouchPhase.Ended)
                        {
                            Debug.Log("Not Touching");
                        }
                    }
                    else if (Input.touchCount == 2)
                    {
                        var touch0 = Input.GetTouch(0);
                        var touch1 = Input.GetTouch(1);

                        var touch0Position = touch0.position;
                        var touch1Position = touch1.position;

                        float initialMagnitude = (touch0Position - touch1Position).magnitude;

                        var touch0PrevPosition = touch0Position - touch0.deltaPosition;
                        var touch1PrevPosition = touch1Position - touch1.deltaPosition;

                        float finalMagnitude = (touch0PrevPosition - touch1PrevPosition).magnitude;

                        var distance = finalMagnitude - initialMagnitude;

                        Zoom(distance);
                    }
                }
            }
            void Zoom(float increment)
            {
                mainCamera.orthographicSize =
                    Mathf.Clamp(mainCamera.orthographicSize + increment * zoomSpeed* Time.deltaTime, minOrtoValue,
                        maxOrtoValue);

            }
        }
    }
}
