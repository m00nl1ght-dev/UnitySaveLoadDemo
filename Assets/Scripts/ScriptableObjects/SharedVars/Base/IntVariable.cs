using UnityEngine;

[CreateAssetMenu(menuName = "Shared Variable/Int")]
public class IntVariable : ScriptableObject
{
    [SerializeField]
    private int initialValue = -1;

    public int Value { get; set; }

    private void OnEnable()
    {
        Value = initialValue;
    }
}