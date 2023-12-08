using Core;

namespace Services.GroupBuilders
{
    public interface IGroupBuilder
    {
        IReadOnlyList<IGroup> GenerateGroups(IReadOnlyList<ITeam> teams, int groupCount);
    }
}
