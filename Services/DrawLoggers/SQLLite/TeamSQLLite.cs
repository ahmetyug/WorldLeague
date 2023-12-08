using Core;

namespace Services.DrawLoggers.SQLLite
{
    internal class TeamSQLLite : ITeam
    {
        public string Name { get; init; }
        public string Country { get; init; }
    }
}
