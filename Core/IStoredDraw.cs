namespace Core
{
    public interface IStoredDraw
    {
        long Id { get; }
        string DrawerName { get; }
        IReadOnlyList<IGroup> Groups{ get; }
    }
}
