using UnityEngine;

[CreateAssetMenu(fileName = "NewHotdogData", menuName = "Hotdogs/Hotdog Data")]
public class HotdogDataSO : ScriptableObject
{
    [SerializeField] string _name;
    [SerializeField] int _baseCost;
    [SerializeField] int _baseWeight;
    public string Name => _name;
    public int BaseCost => _baseCost;
    public int BaseWeight => _baseWeight;
}
