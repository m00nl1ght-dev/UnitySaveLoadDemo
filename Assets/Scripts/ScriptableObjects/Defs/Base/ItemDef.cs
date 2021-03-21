using UnityEngine;

[CreateAssetMenu(menuName = "Defs/ItemDef")]
public class ItemDef : ScriptableObject
{
    public string defId;
    public string itemName;
    public string description;
    public Sprite itemSprite;
    public int maxStackSize = 1;
}