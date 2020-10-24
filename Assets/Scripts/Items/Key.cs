using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item, ICollectible
{


    public void Collect()
    {
        GameManager.Instance.AddToInventory(this);
    }

    public ItemName GetItemName()
    {
        return itemName;
    }
}
