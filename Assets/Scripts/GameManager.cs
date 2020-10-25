using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameActive;
    public Text gameOverText;

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
        
        isGameActive = true;
        gameOverText = GameObject.Find("Success").GetComponent<Text>();

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

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.GetComponent<Text>().enabled = true;
    }
}
