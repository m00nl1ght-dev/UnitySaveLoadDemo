using UnityEngine;

[CreateAssetMenu(menuName = "Defs/WeaponItemDef", order = 2)]
public class WeaponItemDef : ItemDef
{
    [SerializeField] 
    private float attackDamage;
    [SerializeField] 
    private float attackSpeed;

    public float AttackDamage => attackDamage;
    public float AttackSpeed => attackSpeed;
    
    public override string PrintAdditionalInfo()
    {
        var text = base.PrintAdditionalInfo();
        text += "Attack Damage: " + AttackDamage + "\n";
        text += "Attack Speed: " + AttackSpeed + "\n\n";
        return text;
    }
}