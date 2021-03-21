using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    // Inspector editable fields
    public Image image;
    
    // Runtime fields
    public ItemDef Def { get; private set; }

    public void UpdateDef(ItemDef def)
    {
        Def = def;
        image.sprite = def.itemSprite;
    }
}
