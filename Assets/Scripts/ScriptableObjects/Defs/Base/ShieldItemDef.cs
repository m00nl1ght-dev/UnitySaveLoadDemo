using UnityEngine;

[CreateAssetMenu(menuName = "Defs/ShieldItemDef", order = 3)]
public class ShieldItemDef : ItemDef
{
    [SerializeField] 
    private float protectionMelee;
    [SerializeField] 
    private float protectionRanged;

    public float ProtectionMelee => protectionMelee;
    public float ProtectionRanged => protectionRanged;
    
    public override string PrintAdditionalInfo()
    {
        var text = base.PrintAdditionalInfo();
        text += "Protection Melee: " + ProtectionMelee + "\n";
        text += "Protection Ranged: " + ProtectionRanged + "\n\n";
        return text;
    }
}