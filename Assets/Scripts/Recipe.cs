using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recipe
{

    [SerializeField] private ItemName[] itemsRequired;
    public bool HaveAllIngredients(List<ItemName> itemList)
    {
        if (itemList.Count == 3) return true;
        for(int i = 0; i < itemsRequired.Length; ++i)
        {
            bool cleared = false;
            for (int j = 0; j < itemList.Count; ++j)
            {
                if (itemsRequired[i] == itemList[j])
                {
                    cleared = true;
                    break;
                }

                if (cleared == false) return false;
            }
        }

        return true;
    }
}
