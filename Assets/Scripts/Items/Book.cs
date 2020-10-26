using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : Item, IInteractable, IPannable, IChangeable
{
    [SerializeField] private Transform targetLocation;
    [SerializeField] private bool unlocked;
    [SerializeField] private GameObject unlockedBook;
    [SerializeField] private GameObject text;
    public void Interact()
    {
        if (unlocked == false) return;
        if (targetLocation)
        {
            PanCameraTo(targetLocation.position);
        }

    }

    public void UnlockBook()
    {
        unlocked = true;
        unlockedBook.SetActive(true);
        gameObject.GetComponent<MeshFilter>().mesh = null;
        text.SetActive(true);
    }

    public void PanCameraTo(Vector3 targetLocation)
    {
        InteractionBroker.NotifyPanListeners(targetLocation, transform.position);
    }

    public bool Change(ItemName name)
    {
        if (name != ItemName.Key) return false;

        UnlockBook();
        return true;
    }
}
