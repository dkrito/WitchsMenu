using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quill : Item, ICollectible
{
    public void Collect()
    {
        print("collectign");
        gameObject.SetActive(false);
        //GameManager.Instance.AddToInventory(this);
    }

    public ItemName GetItemName()
    {
        return itemName;
    }
}
