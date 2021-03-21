using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPersistent<ItemData>
{
    // Inspector editable fields
    public ItemDefList itemDefList;
    public Image image;
    public Text stackSizeText;
    
    // Runtime fields
    private ItemDef _def;
    private int _stackSize = 1;

    public ItemDef Def
    {
        get => _def;
        set
        {
            _def = value;
            image.sprite = value.itemSprite;
        }
    }

    public int StackSize
    {
        get => _stackSize;
        set
        {
            _stackSize = value;
            stackSizeText.text = value > 1 ? ("x" + value) : "";
        }
    }

    public ItemData Save()
    {
        return new ItemData
        {
            DefId = _def.defId, 
            StackSize = _stackSize
        };
    }

    public void Load(ItemData data)
    {
        Def = itemDefList.LookupById[data.DefId];
        StackSize = data.StackSize;
    }
}
