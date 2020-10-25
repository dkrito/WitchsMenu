using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : Item, IInteractable
{
    [SerializeField] private Transform targetLocation;
    [SerializeField] private List<Recipe> recipes;



    public void Interact()
    {
        print("Interacting with pot");
        
    }

    //public void PanCameraTo(Vector3 targetLocation)
    //{
    //    InteractionBroker.NotifyPanListeners(targetLocation, transform.position);
    //}


    //void CheckIngredients()
    //{
    //    foreach(Recipe rec in recipes)
    //    {
    //        if (rec.HaveAllIngredients(GameManager.Instance.GetInventory()))
    //        {
    //            print("Success! Have all ingredients");
    //            return;
    //        }
    //        else
    //        {
    //            print("Failed recipe");
    //        }
    //    }
    //}
}
