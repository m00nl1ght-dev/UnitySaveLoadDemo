using UnityEngine;

[CreateAssetMenu(menuName = "Shared Variable/ItemSlotVar")]
public class InventorySlotVar : ScriptableObject
{
    public InventorySlot Slot { get; set; }
}