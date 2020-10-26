using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameActive;
    public Text gameOverText;
    public GameObject inventoryHolder;
    private bool inventoryEnabled;
    private int allSlots = 6;
    [SerializeField] private GameObject[] slots;

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
//        gameOverText = GameObject.Find("Success").GetComponent<Text>();
        
        for(int i = 0; i < allSlots; i++)
        {
            if(slots[i].GetComponent<Slot>().item == null)
            {
                slots[i].GetComponent<Slot>().empty = true;
            }
        }

        DontDestroyOnLoad(gameObject);
        if(playerInventory == null) playerInventory = new List<ICollectible>();

    }

    public void AddToInventory(GameObject itemObj, Sprite itemIcon, Texture2D tex)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if(slots[i].GetComponent<Slot>().empty)
            {
                itemObj.GetComponent<Item>().pickedUp = true;

                slots[i].GetComponent<Slot>().tex = tex;
                slots[i].GetComponent<Slot>().item = itemObj;
                slots[i].GetComponent<Slot>().icon = itemIcon;
                slots[i].GetComponent<Image>().sprite = itemIcon;
                itemObj.transform.parent = slots[i].transform;
                itemObj.SetActive(false);

                slots[i].GetComponent<Slot>().empty = false;
                break;
            }
        }

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
