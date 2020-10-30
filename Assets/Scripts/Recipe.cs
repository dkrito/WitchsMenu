using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recipe
{

    [SerializeField] private ItemName[] itemsRequired;
    public bool HaveAllIngredients(List<ItemName> itemList)
    {
        if (itemsRequired.Length != itemList.Count) return false;
        for(int i = 0; i < itemsRequired.Length; ++i)
        {
            if (itemList.Contains(itemsRequired[i]) == false) return false;

        }

        return true;
    }
}
