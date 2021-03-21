using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    // Inspector editable fields
    public Image image;
    
    // Runtime fields
    public ItemDef Def { get; set; }
}
