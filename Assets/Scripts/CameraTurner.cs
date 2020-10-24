using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTurner : MonoBehaviour
{
    [SerializeField] private float cameraVerticalRotationSpeed;

    private float maxValue;
    private void LateUpdate()
    {
        cameraVerticalRotationSpeed = -Input.GetAxis("Mouse Y") * Time.deltaTime * 360;
        maxValue += cameraVerticalRotationSpeed;

        if(maxValue >= 90f)
        {
            maxValue = 90;
            cameraVerticalRotationSpeed = 0;
        }else if(maxValue < -90f)
        {
            maxValue = -90f;
            cameraVerticalRotationSpeed = 0;
        }
        transform.Rotate(cameraVerticalRotationSpeed, 0, 0);
    }
}
