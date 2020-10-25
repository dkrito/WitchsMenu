using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : Item, IInteractable, IPannable
{
    [SerializeField] private Transform targetLocation;


    public void Interact()
    {
        if (targetLocation)
        {
            PanCameraTo(targetLocation.position);
        }

    }

    public void PanCameraTo(Vector3 targetLocation)
    {
        InteractionBroker.NotifyPanListeners(targetLocation, transform.position);
    }


}
