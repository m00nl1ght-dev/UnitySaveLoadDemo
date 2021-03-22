public class Item : IPersistent<ItemData>
{
    // The item definition and current stack size of this item.
    public ItemDef Def;
    public int StackSize = 1;
    
    // The inventory this item is a part of.
    public readonly Inventory Inventory;

    public Item(Inventory inventory)
    {
        Inventory = inventory;
    }

    // Capture a snapshot of this item's persistent data.
    public ItemData Save()
    {
        return new ItemData
        {
            DefId = Def.DefId, 
            StackSize = StackSize
        };
    }

    // Restore a previously saved snapshot of this item's persistent data.
    public void Load(ItemData data)
    {
        Def = Inventory.itemDefList.LookupById[data.DefId];
        StackSize = data.StackSize;
    }
}