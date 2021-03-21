using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[CreateAssetMenu(menuName = "Defs/ItemDefList")]
public class ItemDefList : ScriptableObject
{
    // Inspector editable list of all item definitions
    public List<ItemDef> itemDefs;

    // Runtime only, mapped to IDs for faster lookup
    public IReadOnlyDictionary<string, ItemDef> LookupById { get; private set; }

    private void OnEnable()
    {
        // Create the id map on start
        var dict = new Dictionary<string, ItemDef>();
        LookupById = new ReadOnlyDictionary<string, ItemDef>(dict);
        foreach (var itemDef in itemDefs)
        {
            dict.Add(itemDef.defId, itemDef);
        }
    }
}