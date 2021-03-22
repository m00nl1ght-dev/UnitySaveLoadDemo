using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory")]
public class Inventory : ScriptableObject, IPersistent<InventoryData>
{
    // Inspector editable fields
    public ItemDefList itemDefList;
    public int slotCount = 20;

    // Runtime fields
    private Item[] _storedItems;

    private void OnEnable()
    {
        // Start with new, empty inventory
        _storedItems = new Item[slotCount];
    }

    public Item GetItemInSlot(int idx)
    {
        return _storedItems[idx];
    }

    public void PutNewItemIntoSlot(int idx, ItemDef itemDef)
    {
        _storedItems[idx] = new Item(this) {Def = itemDef};
    }

    public void RemoveItemInSlot(int idx)
    {
        _storedItems[idx] = null;
    }

    // Capture a snapshot of this inventory's persistent data.
    public InventoryData Save()
    {
        return new InventoryData
        {
            // Fetch the save data for each item and put it into the inventory data
            inventorySlots = _storedItems.Select(i => i?.Save()).ToArray()
        };
    }

    // Restore a previously saved snapshot of this inventory's persistent data.
    public void Load(InventoryData data)
    {
        // Get rid of existing items by creating a new array
        _storedItems = new Item[slotCount];
        // Put new items and restore the saved item data for each
        for (int i = 0; i < Math.Min(slotCount, data.inventorySlots.Length); i++)
        {
            var itemData = data.inventorySlots[i];
            if (itemData != null)
            {
                var item = new Item(this);
                item.Load(itemData);
                _storedItems[i] = item;
            }
        }
    }
}
