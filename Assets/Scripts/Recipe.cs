using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recipe
{

    [SerializeField] private ItemName[] itemsRequired;
    public bool HaveAllIngredients(List<ICollectible> itemList)
    {
        if (itemList.Count < itemsRequired.Length) return false;

        for(int i = 0; i < itemsRequired.Length; ++i)
        {
            bool cleared = false;
            for(int j = 0; j < itemList.Count; ++j)
            {
                if (itemsRequired[i] == itemList[j].GetItemName())
                {
                    cleared = true;
                    break;
                }

                
            }

            if (cleared == false) return false;

        }


        return true;
    }
}
