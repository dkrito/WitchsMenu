using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : Item, IInteractable
{
    
    [SerializeField] List<Recipe> recipes;




    public void Interact()
    {
        CheckIngredients();
    }


    void CheckIngredients()
    {
        foreach(Recipe rec in recipes)
        {
            if (rec.HaveAllIngredients(GameManager.Instance.GetInventory()))
            {
                print("Success! Have all ingredients");
                return;
            }
            else
            {
                print("Failed recipe");
            }
        }
    }
}
