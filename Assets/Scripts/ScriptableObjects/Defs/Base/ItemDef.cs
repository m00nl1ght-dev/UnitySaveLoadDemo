using UnityEngine;

[CreateAssetMenu(menuName = "Defs/ItemDef", order = 1)]
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
    [SerializeField] 
    private float weight = 1;

    public string DefId => defId;
    public string ItemName => itemName;
    public string Description => description;
    public Sprite ItemSprite => itemSprite;
    public int MaxStackSize => maxStackSize;
    public float Weight => weight;

    public virtual string PrintAdditionalInfo()
    {
        return "Weight: " + Weight + "\n\n";
    }
}