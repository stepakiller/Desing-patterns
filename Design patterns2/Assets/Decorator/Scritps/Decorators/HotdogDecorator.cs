public abstract class HotdogDecorator : Hotdog
{
    protected Hotdog _hotdog;
    public HotdogDecorator(string name, Hotdog hotdog) : base(name) => _hotdog = hotdog;
}
