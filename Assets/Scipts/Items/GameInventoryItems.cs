using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInventoryItems : MonoBehaviour
{
    [SerializeField] List<Item> LoadItems = new List<Item>(); // from Items folder add drag and drop item in inspector
    public static List<Item> AllItems = new List<Item>();

    void Awake()
    {
     foreach(var item in LoadItems)
        {
            AllItems.Add(item);
        }   
    }

}
