using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scipts.Items
{

    public class InventoryPanel : MonoBehaviour
    {
        [SerializeField] Inventory Inventory;
        [SerializeField] RectTransform ItemsPanel;

        public void Start()
        {
            Redraw();
        }

        void Redraw()
        {
            foreach (var item in Inventory.GetInventory())
            {
                var icon = new GameObject("icon");
                icon.AddComponent<Image>().sprite = item.Image;
                icon.transform.SetParent(ItemsPanel);
                icon.transform.localScale = new Vector3(1, 1, 1); //reset scale cause its breaks
            }
        }
    }
}
