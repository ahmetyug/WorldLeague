namespace Core
{
    public interface IGroup : IValidatable
    {
        string Name { get; }
        IReadOnlyList<ITeam> Teams { get; }
    }
}
