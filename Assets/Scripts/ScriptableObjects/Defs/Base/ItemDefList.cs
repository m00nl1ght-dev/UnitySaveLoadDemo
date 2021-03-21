using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[CreateAssetMenu(menuName = "Defs/ItemDefList")]
public class ItemDefList : ScriptableObject
{
    // Inspector editable list of all item definitions
    [SerializeField] 
    private List<ItemDef> itemDefs;

    // For runtime access (read-only)
    public IList<ItemDef> ItemDefs { get; private set; }
    public IDictionary<string, ItemDef> LookupById { get; private set; }

    private void OnEnable()
    {
        // Create read-only list for runtime access
        ItemDefs = new ReadOnlyCollection<ItemDef>(itemDefs);
        
        // Map all defs to IDs for faster lookup
        var dict = new Dictionary<string, ItemDef>();
        LookupById = new ReadOnlyDictionary<string, ItemDef>(dict);
        foreach (var itemDef in itemDefs)
        {
            dict.Add(itemDef.DefId, itemDef);
        }
    }
}