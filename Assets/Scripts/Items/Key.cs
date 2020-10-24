using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item, ICollectible
{


    public void Collect()
    {
        GameManager.Instance.AddToInventory(this);
        gameObject.SetActive(false);
    }

    public ItemName GetItemName()
    {
        return itemName;
    }
}
