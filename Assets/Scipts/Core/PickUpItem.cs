using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public static bool IsPickingUpItem = false;
    public static string ItemName;
 
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            ItemName = other.name;
            IsPickingUpItem = true;
        }
        else if(!other.CompareTag("Player")) //dont set picking up to false if player here
            IsPickingUpItem = false;
    }

    public static void PickUp()
    {
        ItemsOnMap.PickUp(ItemName);
        var item = GameObject.Find(ItemName);
        Destroy(item);
    }
}
