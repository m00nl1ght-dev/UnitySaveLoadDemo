using UnityEngine;

[CreateAssetMenu(menuName = "Shared Variable/ItemSlotVar")]
public class ItemSlotVar : ScriptableObject
{
    public Slot Slot { get; set; }
}