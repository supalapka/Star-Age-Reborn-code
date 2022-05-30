using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scipts.Items
{

    public class InventoryPanel : MonoBehaviour
    {
        public void Start()
        {
            DrawSlots(); //just slots where to contain items
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.E)) //add item to inventory test
            {
                var item = GameInventoryItems.AllItems[0];
                var icon = new GameObject("SlotBox");
                icon.AddComponent<Image>().sprite = item.Image;

                var player = PlayersOnMap.GetPlayer(0); //fix later
                icon.transform.SetParent(player.ItemsPanel);
            }
        }

        public static void AddItem(GameObject _item)
        {
            var player = PlayersOnMap.GetPlayer(0); //fix later

            var item = GameInventoryItems.AllItems.Where(x => _item.name.Contains(x.name)).FirstOrDefault();
            var icon = new GameObject(item.name + "SlotBox");
            icon.AddComponent<Image>().sprite = item.Image;
            icon.transform.SetParent(player.ItemsPanel);  //fix later
        }

        void DrawSlots() //just slots where to contain items
        {
            var player = PlayersOnMap.GetPlayer(0); //fix later
            foreach (var item in player._Inventory.GetSlotsBoxes())
            {
                var icon = new GameObject("SlotBox");
                icon.AddComponent<Image>().sprite = item.Image;
                icon.transform.SetParent(player.SlotViewPanel);
                icon.transform.localScale = Vector3.one; //reset scale cause its breaks
            }
        }
    }
}
