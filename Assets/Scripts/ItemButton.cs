using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
    [SerializeField] private PlayerInteractor interactor;

    private void Start()
    {
    }
    public void Clicked()
    {
        if (interactor)
        {
            if (GetComponent<Slot>() == null) return;
            interactor.ChangeCursor(GetComponent<Slot>().tex, GetComponent<Slot>().item.GetComponent<Item>().GetItemName());
        }   
        
    }
}
