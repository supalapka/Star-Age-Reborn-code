using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scipts.Items
{

    public class InventoryPanel : MonoBehaviour
    {
        [SerializeField] Inventory Inventory;
        [SerializeField] RectTransform ItemsPanel;
        [SerializeField] RectTransform SlotViewPanel;

        public void Start()
        {
            DrawSlots();
            RedrawInventory();
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.E)) //stop moving
            {
                var item = GameInventoryItems.AllItems[0];
                var icon = new GameObject("SlotBox");
                icon.AddComponent<Image>().sprite = item.Image;
                icon.transform.SetParent(ItemsPanel);
            }
        }

        void RedrawInventory()
        {
           
        }

        void DrawSlots()
        {
            foreach (var item in Inventory.GetSlotsBoxes())
            {
                var icon = new GameObject("SlotBox");
                icon.AddComponent<Image>().sprite = item.Image;
                icon.transform.SetParent(SlotViewPanel);
                icon.transform.localScale = new Vector3(1, 1, 1); //reset scale cause its breaks
            }
        }
    }
}
