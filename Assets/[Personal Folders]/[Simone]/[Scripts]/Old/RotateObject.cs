using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class RotateObject : MonoBehaviour
{

    [SerializeField] private Transform corsetTransform;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float minFov = 20f;
    [SerializeField] private float maxFov = 50f;
    public float rotationSpeed = 1f;

    
// Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            float xDirection = touch.deltaPosition.x * rotationSpeed * Time.deltaTime;
            //float yDirection = touch.deltaPosition.y * rotationSpeed * Time.deltaTime;
            
            if (touch.phase == TouchPhase.Moved)
            {
                corsetTransform.Rotate(0f, xDirection, 0f, relativeTo:Space.Self);
            } else if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("Not Touching");
            }
        } else if (Input.touchCount == 2)
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

        void Zoom(float increment)
        {
            mainCamera.fieldOfView = Mathf.Clamp(mainCamera.fieldOfView - increment, minFov, maxFov);
        }
        
    }
}
