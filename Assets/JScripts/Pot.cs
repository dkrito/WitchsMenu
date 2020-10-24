using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : Item, IInteractable
{
    [SerializeField] List<Recipe> recipes;
    public void Interact()
    {
        print("Interacted with " + itemName);
    }

}
