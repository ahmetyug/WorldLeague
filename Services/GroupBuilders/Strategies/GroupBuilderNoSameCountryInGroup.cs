using Core;

namespace Services.GroupBuilders.Strategies
{
    internal class GroupBuilderNoSameCountryInGroup : IGroupBuilder, IGroupValidator
    {
        public IReadOnlyList<IGroup> GenerateGroups(IReadOnlyList<ITeam> teams, int groupCount)
        {
            ValidateGroupCount(groupCount);

            var teamsGroups = new List<ITeam>[groupCount];
            for (int i = 0; i < groupCount; i++)
            {
                teamsGroups[i] = Array.Empty<ITeam>().ToList();
            }

            var teamsByCountry = teams.GroupBy(t => t.Country).ToDictionary(g => g.Key, g => g.ToList());

            var anyAvailableTeams = () => teamsByCountry.Values.SelectMany(s => s).Any();

            while (anyAvailableTeams.Invoke())
            {
                for (int i = 0; i < groupCount; i++)
                {
                    var groupTeams = teamsGroups[i];
                    if (!anyAvailableTeams.Invoke())
                    {
                        break;
                    }

                    var countriesInTheGroup = groupTeams.Select(t => t.Country).Distinct().ToHashSet();

                    var pickedCountry = teamsByCountry.Where(t => !countriesInTheGroup.Contains(t.Key) && t.Value.Any()).Select(t => t.Key).OrderBy(x => Guid.NewGuid()).FirstOrDefault();

                    if (pickedCountry == null)
                    {
                        throw new InvalidOperationException("There are still teams to pick but their countries already exist in the group.");
                    }

                    var pickedTeam = teamsByCountry[pickedCountry].OrderBy(x => Guid.NewGuid()).First();

                    teamsByCountry[pickedCountry].Remove(pickedTeam);
                    if (!teamsByCountry[pickedCountry].Any())
                    {
                        teamsByCountry.Remove(pickedCountry);
                    }

                    groupTeams.Add(pickedTeam);
                }
            }

            var groups = teamsGroups
                .Select((tg, i) => new Group(this)
                {
                    Name = $"Group {i + 1}",
                    Teams = tg
                })
                .ToList();

            groups.ForEach(g => g.Validate());

            return groups;
        }

        public void ValidateGroup(IGroup group)
        {
            var invalidCountries = group.Teams.GroupBy(t => t.Country).Where(g => g.Count() > 1).Select(g => g.Key);

            if (invalidCountries.Any())
            {
                throw new InvalidOperationException($"Same country cannot repeat. Invalid countries:{string.Join(",", invalidCountries)}");
            }
        }

        private void ValidateGroupCount(int groupCount)
        {
            var validGroupCounts = new HashSet<int>() { 4, 8};
            if (!validGroupCounts.Contains(groupCount))
            {
                throw new InvalidOperationException($"Group count cannot be other than {string.Join(",", validGroupCounts)}. Requested group count: {groupCount}");
            }
        }
    }
}
