using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float turnSpeed;

    [Header("Camera Settings")]
    [SerializeField] private float boundBeforeCameraTurns;
    private float rotationValueX = 0;
    private float rotationValueY = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;


        rotationValueX = Input.GetAxis("Mouse X") * Time.deltaTime * turnSpeed * 360;

        transform.Translate(h, 0, v);
        transform.Rotate(0, rotationValueX, 0, Space.Self);
    }
}
