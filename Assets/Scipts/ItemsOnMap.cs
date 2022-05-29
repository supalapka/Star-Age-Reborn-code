using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets
{
    public static class ItemsOnMap
    {
        public static List<GameObject> Items = new List<GameObject>();

        public static void Remove(string itemName)
        {
            var removeItem = Items.Where(x => x.name == itemName).SingleOrDefault();
            Items.Remove(removeItem);
        }

        public static void Add(GameObject item) { Items.Add(item); }

    }
}
