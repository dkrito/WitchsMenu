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
    Spider
}

public class Item : MonoBehaviour
{
    [SerializeField] protected ItemName itemName;

}
