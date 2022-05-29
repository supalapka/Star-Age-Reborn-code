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
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            IsPickingUpItem = false;
        }
    }

    public static void PickUp()
    {
        ItemsOnMap.Remove(ItemName);
        var item = GameObject.Find(ItemName);
        Debug.Log("picked up " + item.name);
        Destroy(item);
    }
}
