using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTurner : MonoBehaviour
{
    [SerializeField] private float cameraVerticalRotationSpeed;
    [SerializeField] private float panSpeed;
    [SerializeField] private float camBound;

    private Vector3 originalPosition;
    private float maxValue;
    private bool canMoveCamera;


    private void Start()
    {
        InteractionBroker.PanHandle += GoToLocation;
        originalPosition = transform.parent.position;
        canMoveCamera = true;   
    }

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReturnToOrigin();
        }
    }
    private void LateUpdate()
    {
        if (canMoveCamera == false) return;
        cameraVerticalRotationSpeed = -Input.GetAxis("Mouse Y") * Time.deltaTime * 270;
        maxValue += cameraVerticalRotationSpeed;

        if(maxValue >= camBound)
        {
            maxValue = camBound;
            cameraVerticalRotationSpeed = 0;
        }else if(maxValue < -camBound)
        {
            maxValue = -camBound;
            cameraVerticalRotationSpeed = 0;
        }
        transform.Rotate(cameraVerticalRotationSpeed, 0, 0);

    }


    //Call this when you want to return to scene
    public void ReturnToOrigin()
    {
        transform.localPosition = Vector3.zero;
        transform.rotation = transform.parent.rotation;
        InteractionBroker.NotifyCameraMovement(true);
        canMoveCamera = true;
        //Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = false;

        InteractionBroker.TogglePannerHandle(true);
        print("returning");
    }


    //Pan to the location
    void GoToLocation(Vector3 location, Vector3 targetToLookAt)
    {
        canMoveCamera = false;
        InteractionBroker.NotifyCameraMovement(false);
        StartCoroutine(BeginPan(location, targetToLookAt));
    }


    //Moves camera to target position
    //Disable camera turning while moving
    IEnumerator BeginPan(Vector3 target, Vector3 targetToLookAt)
    {
        while(Vector3.Distance(transform.position, target) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, panSpeed);
            transform.LookAt(targetToLookAt, Vector3.up);
            yield return null;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        print("arrived at destination");
    }


    private void OnDisable()
    {
        InteractionBroker.PanHandle -= GoToLocation;
    }
}
