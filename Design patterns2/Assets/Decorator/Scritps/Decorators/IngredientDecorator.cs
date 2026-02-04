public class IngredientDecorator : HotdogDecorator
{
    IngredientDataSO _data;
    public IngredientDecorator(Hotdog hotdog, IngredientDataSO data) : base(hotdog.GetName(), hotdog) => _data = data;
    public override string GetName() => _hotdog.GetName() + " " + _data.IngredientNameSuffix;
    public override int GetCost() => _hotdog.GetCost() + _data.AddedCost;
    public override int GetWeight() => _hotdog.GetWeight() + _data.AddedWeight;
}
