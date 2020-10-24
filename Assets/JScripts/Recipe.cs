using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recipe
{

    [SerializeField] private ItemName[] itemsRequired;
    public bool CheckRecipe(List<Item> itemList)
    {
        return false;
    }
}
