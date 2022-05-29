using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Item> SlotsBoxes = new List<Item>();
    List<Item> InventoryItems = new List<Item>();

    void Awake()
    {
        var item = SlotsBoxes[0];
        for (int i = 1; i < 50; i++) //i = 1 because 1 slot allready exist
            SlotsBoxes.Add(item);
    }

    public void AddItem(Item item) { InventoryItems.Add(item); }
    public List<Item> GetInventory() { return InventoryItems; }
    public List<Item> GetSlotsBoxes() { return SlotsBoxes; }
}
