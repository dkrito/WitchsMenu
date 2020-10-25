using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanner : MonoBehaviour, IPannable, IInteractable
{
    [SerializeField] private Transform targetLocation;


    private void OnEnable()
    {
        InteractionBroker.TogglePannerHandle += TogglePanner;
    }

    private void OnDisable()
    {
        InteractionBroker.TogglePannerHandle -= TogglePanner;
    }

    public void PanCameraTo(Vector3 targetLocation)
    {
        print(gameObject.name);
        print(this.enabled);
        InteractionBroker.NotifyPanListeners(targetLocation, transform.position);
        InteractionBroker.TogglePanningCameras(false);
        
    }

    public void TogglePanner(bool state)
    {
        gameObject.GetComponent<Collider>().enabled = state;

    }

    public void Interact()
    {
        PanCameraTo(targetLocation.position);
    }
}
