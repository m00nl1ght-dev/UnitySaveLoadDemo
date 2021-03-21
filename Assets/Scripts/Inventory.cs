using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int slotCount = 20;
    public GameObject slotPrefab;
    public Color slotUnselectedColor;
    public Color slotSelectedColor;
    public ItemSlotVar selectedItemSlotVar;

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
            slot.Image.color = slotUnselectedColor;
            _slots[i] = slot;
        }
    }

    public void OnSelectionChanged()
    {
        // Update background colors of the old and new selected slots
        if (_lastSelected != null) _lastSelected.Image.color = slotUnselectedColor;
        selectedItemSlotVar.Slot.Image.color = slotSelectedColor;
        _lastSelected = selectedItemSlotVar.Slot;
    }

}
