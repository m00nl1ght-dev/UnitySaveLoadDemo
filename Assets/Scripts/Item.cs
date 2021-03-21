using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    // Inspector editable fields
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
}
