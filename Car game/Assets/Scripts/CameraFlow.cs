using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlow : MonoBehaviour
{
    public Transform target;  // The target object to follow (araba)
    public float smoothSpeed = 0.125f;  // Smoothing factor for the camera movement
    public float yOffset = 2f;  // Yükseklik offset'i

    void LateUpdate()
    {
        if (target != null)
        {
            float desiredX = target.position.x;
            float desiredY = target.position.y + yOffset;
            float desiredZ = transform.position.z;

            Vector3 desiredPosition = new Vector3(desiredX, 2.240944f, -11.71272f);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(target.position);  // Make the camera always look at the target
        }
    }
}
