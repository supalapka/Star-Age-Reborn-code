using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets
{
    public static class ItemsOnMap
    {
        public static List<UnityEngine.GameObject> Items = new List<UnityEngine.GameObject>();

        public static void Remove(string itemName)
        {
            var removeItem = Items.Where(x => x.name == itemName).SingleOrDefault();
            Items.Remove(removeItem);
        }

        public static void Add(UnityEngine.GameObject item) { Items.Add(item); }

    }
}
