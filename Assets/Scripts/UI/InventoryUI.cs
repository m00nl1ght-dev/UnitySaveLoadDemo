using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Inspector editable fields
    public Inventory inventory;
    public IntVariable selectedSlotVar;
    public Color slotUnselectedColor;
    public Color slotSelectedColor;
    public GameObject slotPrefab;

    // Runtime fields
    private InventorySlotUI[] _slots;
    private InventorySlotUI _lastSelected;

    private void Start()
    {
        // Create all the slots using the prefab
        _slots = new InventorySlotUI[inventory.slotCount];
        for (int i = 0; i < inventory.slotCount; i++)
        {
            var slot = Instantiate(slotPrefab, Vector3.zero, Quaternion.identity, transform).GetComponent<InventorySlotUI>();
            slot.gameObject.name = "Slot_" + i;
            slot.backgroundImage.color = slotUnselectedColor;
            slot.Inventory = inventory;
            slot.SlotIdx = i;
            _slots[i] = slot;
        }
    }

    // Event listener, called when selected item slot changed
    public void OnSelectionChanged()
    {
        // Update background colors of the old and new selected slots
        if (_lastSelected != null) _lastSelected.backgroundImage.color = slotUnselectedColor;
        _lastSelected = _slots[selectedSlotVar.Value];
        _lastSelected.backgroundImage.color = slotSelectedColor;
        _lastSelected.UpdateUI();
    }
    
    // Event listener, called when the invemtory is reloaded
    public void OnRefreshInventory()
    {
        // Update all slots
        foreach (var slot in _slots) slot.UpdateUI();
    }
}
