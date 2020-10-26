using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemName
{
    Hat,
    Cauldron,
    Broom,
    Crow,
    Book,
    Gate,
    Skull,
    Quill,
    LargeSpider,
    WitchHair,
    SleepPotion,
    EnlargePotion,
    CrowTear,
    Key,
    Spider,
    None
}

public class Item : MonoBehaviour
{
    [SerializeField] protected ItemName itemName;
    
    public Sprite icon;
    public Texture2D tex;
    public bool pickedUp;

    public ItemName GetItemName()
    {
        return itemName;
    }
}
