using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IChangeable
{
    public bool Change(ItemName name)
    {
        print("Cheeeck");
        if(name == ItemName.SleepPotion)
        {
            SceneManager.LoadScene(0);
            return true;
        }

        return false;
    }
}
