using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float maxXRotation;


    private float currentRotationValueX = 0;
    private float accumulatedRotationValue;
    private bool canRotateCamera;
    // Start is called before the first frame update
    void Start()
    {
        canRotateCamera = true;
        InteractionBroker.CameraMovementHandle += ToggleCamera;
    }

    // Update is called once per frame
    void Update()
    {
        if (canRotateCamera == false) return;

        float h = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;


        

        transform.Translate(h, 0, v);

        currentRotationValueX = Input.GetAxis("Mouse X") * Time.deltaTime * turnSpeed * 270;
        accumulatedRotationValue += currentRotationValueX;


        //if outside of bounds, stop rotating
        if(accumulatedRotationValue >= maxXRotation)
        {
            accumulatedRotationValue = maxXRotation;
            currentRotationValueX = 0;
        }
        else if(accumulatedRotationValue <= -maxXRotation)
        {
            accumulatedRotationValue = -maxXRotation;
            currentRotationValueX = 0;
        }

        transform.Rotate(0, currentRotationValueX, 0, Space.Self);
    }

    private void OnDisable()
    {
        InteractionBroker.CameraMovementHandle -= ToggleCamera;
    }

    void ToggleCamera(bool state)
    {
        canRotateCamera = state;
    }
}
