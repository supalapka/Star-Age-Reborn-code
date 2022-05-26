using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Item> StartItems = new List<Item>();
    List<Item> InventoryItems = new List<Item>();

    void Awake()
    {
        var item = StartItems[0];
       for(int i = 0; i < 50; i++)
            AddItem(item);
    }

    public void AddItem(Item item) { InventoryItems.Add(item); }
    public List<Item> GetInventory() { return InventoryItems; }
    public List<Item> GetStartItems() { return StartItems; }
}
