using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private List<ICollectible> playerInventory;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        if(playerInventory == null) playerInventory = new List<ICollectible>();

    }

    public void AddToInventory(ICollectible collectible)
    {
        playerInventory.Add(collectible);
    }

    public void RemoveFromInventory(ICollectible collectible)
    {
        playerInventory.Remove(collectible);
    }

    public List<ICollectible> GetInventory()
    {
        return playerInventory;
    }

    public void PrintInventory()
    {
        foreach(ICollectible col in playerInventory)
        {
            print(col.GetItemName());
        }

        print("Done printing inventory");
    }
}
