using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargementPotion : Item, ICollectible
{
    public void Collect()
    {
        GameManager.Instance.AddToInventory(gameObject, icon, tex);
        gameObject.SetActive(false);
    }

    public ItemName GetItemName()
    {
        return itemName;
    }


}

