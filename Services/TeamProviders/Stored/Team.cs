using Core;

namespace Services.TeamProviders.Stored
{
    public class Team : ITeam
    {
        public string Name { get; init; }
        public string Country { get; init; }
    }
}
