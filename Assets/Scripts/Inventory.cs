using System;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour, IPersistent<InventoryData>
{
    // Inspector editable fields
    public int slotCount = 20;
    public Color slotUnselectedColor;
    public Color slotSelectedColor;
    public GameObject slotPrefab;
    public InventorySlotVar selectedInventorySlotVar;

    // Runtime fields
    private InventorySlot[] _slots;
    private InventorySlot _lastSelected;

    private void Start()
    {
        // Create all the slots using the prefab
        _slots = new InventorySlot[slotCount];
        for (int i = 0; i < slotCount; i++)
        {
            var slot = Instantiate(slotPrefab, Vector3.zero, Quaternion.identity, transform).GetComponent<InventorySlot>();
            slot.gameObject.name = "Slot_" + i;
            slot.image.color = slotUnselectedColor;
            _slots[i] = slot;
        }
    }

    // Event listener, called when selected item slot changed
    public void OnSelectionChanged()
    {
        // Update background colors of the old and new selected slots
        if (_lastSelected != null) _lastSelected.image.color = slotUnselectedColor;
        selectedInventorySlotVar.Slot.image.color = slotSelectedColor;
        _lastSelected = selectedInventorySlotVar.Slot;
    }

    public InventoryData Save()
    {
        return new InventoryData
        {
            // Fetch the save data for each item and put it into the inventory data
            InventorySlots = _slots.Select(i => i.Item == null ? null : i.Item.Save()).ToArray()
        };
    }

    public void Load(InventoryData data)
    {
        // First, clear the inventory by removing all existing items
        foreach (var slot in _slots) slot.RemoveItem();

        // Put new items into each slot and restore the saved item data
        for (int i = 0; i < Math.Min(slotCount, data.InventorySlots.Length); i++)
        {
            var itemData = data.InventorySlots[i];
            var slot = _slots[i];
            if (itemData != null)
            {
                slot.PutNewItem();
                slot.Item.Load(itemData);
            }
        }
    }
}
