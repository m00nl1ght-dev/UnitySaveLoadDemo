using UnityEngine;

[CreateAssetMenu(menuName = "Shared Variable/InventorySlotVar")]
public class InventorySlotVar : ScriptableObject
{
    public InventorySlot Slot { get; set; }
}