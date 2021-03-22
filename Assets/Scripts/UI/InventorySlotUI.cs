using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    // Inspector editable fields
    public IntVariable selectedInventorySlotVar;
    public GameEvent selectionChangedEvent;
    public GameObject itemPrefab;
    public Image backgroundImage;

    // Runtime fields
    public int SlotIdx { get; set; }
    public Inventory Inventory { get; set; }
    public ItemUI ItemUI { get; private set; }

    private void OnMouseDown()
    {
        // If this is not already the selected slot, update it and trigger event
        if (selectedInventorySlotVar.Value != SlotIdx)
        {
            selectedInventorySlotVar.Value = SlotIdx;
            selectionChangedEvent.Raise();
        }
    }
    
    public void UpdateUI()
    {
        var currentItem = Inventory.GetItemInSlot(SlotIdx);
        if (currentItem != null)
        {
            // Slot is not empty, create item and set item values
            CreateItemUI();
            ItemUI.image.sprite = currentItem.Def.ItemSprite;
            ItemUI.stackSizeText.text = currentItem.StackSize > 1 ? ("x" + currentItem.StackSize) : "";
        }
        else
        {
            // Slot is empty, remove item
            RemoveItemUI();
        }
    }

    private void CreateItemUI()
    {
        if (ItemUI == null)
        {
            ItemUI = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity, transform).GetComponent<ItemUI>();
            ItemUI.transform.localPosition = Vector3.zero;
        }
    }
    
    private void RemoveItemUI()
    {
        if (ItemUI != null)
        {
            Destroy(ItemUI);
            ItemUI = null;
        }
    }
}
