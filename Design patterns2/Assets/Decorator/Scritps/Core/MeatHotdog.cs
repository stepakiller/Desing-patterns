public class MeatHotdog : Hotdog
{
    HotdogDataSO _data;
    public MeatHotdog(HotdogDataSO data) : base(data.Name) => _data = data;
    public override int GetCost() => _data.BaseCost;
    public override int GetWeight() => _data.BaseWeight;
}
