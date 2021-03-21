using UnityEngine;

[CreateAssetMenu(menuName = "Defs/ItemDef")]
public class ItemDef : ScriptableObject
{
    [SerializeField] 
    private string defId;
    [SerializeField] 
    private string itemName;
    [SerializeField] 
    private string description;
    [SerializeField] 
    private Sprite itemSprite;
    [SerializeField] 
    private int maxStackSize = 1;

    public string DefId => defId;
    public string ItemName => itemName;
    public string Description => description;
    public Sprite ItemSprite => itemSprite;
    public int MaxStackSize => maxStackSize;
}