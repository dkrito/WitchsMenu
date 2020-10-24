using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : Item, IInteractable
{


    public void Interact()
    {
        print("Interacted with " + itemName);
    }
}
