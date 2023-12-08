using Core;

namespace Services.TeamProviders
{
    public interface ITeamsProvider
    {
        Task<IReadOnlyList<ITeam>> GetTeamsAsync();
    }
}
