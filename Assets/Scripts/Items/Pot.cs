using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : Item, IInteractable, IChangeable
{
    [SerializeField] private Transform targetLocation;
    [SerializeField] private Recipe recipe;
    [SerializeField] private GameObject potion;
    [SerializeField] private List<ItemName> itemNames;

    private void Start()
    {
        itemNames = new List<ItemName>();
    }

    public bool Change(ItemName name)
    {
        if (name == ItemName.Key) return false;
        if (name == ItemName.SleepPotion) return false;
        if (name == ItemName.Spider) return false;

        itemNames.Add(name);
        if (recipe.HaveAllIngredients(itemNames))
        {
            if (potion) potion.SetActive(true);
            gameObject.GetComponent<Collider>().enabled = false;
        }


        return true;
    }

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
