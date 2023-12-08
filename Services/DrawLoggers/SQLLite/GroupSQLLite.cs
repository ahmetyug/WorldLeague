using Core;
using System.Text.Json.Serialization;

namespace Services.DrawLoggers.SQLLite
{
    internal class GroupSQLLite : IGroup
    {
        public string Name { get; init; }

        [JsonIgnore]
        public IReadOnlyList<ITeam> Teams => TeamSQLLites;

        [JsonPropertyName("Teams")]
        public IReadOnlyList<TeamSQLLite> TeamSQLLites { get; init; }

        public void Validate()
        {
            //throw new NotImplementedException();
        }
    }
}
