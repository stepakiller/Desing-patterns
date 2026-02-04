public abstract class Hotdog
{
    protected string _name;
    public Hotdog(string name) => _name = name;
    public virtual string GetName() => _name;
    public abstract int GetCost();
    public abstract int GetWeight();
}
