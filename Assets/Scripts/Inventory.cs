using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Inspector editable fields
    public int slotCount = 20;
    public Color slotUnselectedColor;
    public Color slotSelectedColor;
    public GameObject slotPrefab;
    public ItemSlotVar selectedItemSlotVar;

    // Runtime fields
    private Slot[] _slots;
    private Slot _lastSelected;

    private void Start()
    {
        // Create all the slots using the prefab
        _slots = new Slot[slotCount];
        for (int i = 0; i < slotCount; i++)
        {
            var slot = Instantiate(slotPrefab, Vector3.zero, Quaternion.identity, transform).GetComponent<Slot>();
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
        selectedItemSlotVar.Slot.image.color = slotSelectedColor;
        _lastSelected = selectedItemSlotVar.Slot;
    }

}
