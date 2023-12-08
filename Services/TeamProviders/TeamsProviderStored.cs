using Core;
using Services.TeamProviders.Stored;

namespace Services.TeamProviders
{
    public class TeamsProviderStored : ITeamsProvider
    {
        private readonly IReadOnlyList<ITeam> teams;

        public TeamsProviderStored()
        {
            teams = GetInitialTeams();
        }

        public Task<IReadOnlyList<ITeam>> GetTeamsAsync()
        {
            return Task.FromResult(teams);
        }

        private IReadOnlyList<ITeam> GetInitialTeams()
        {
            return new List<ITeam>()
            {
                new Team()
                {
                    Country = "Türkiye",
                    Name = "Adesso İstanbul",
                },
                new Team()
                {
                    Country = "Türkiye",
                    Name = "Adesso Ankara",
                },
                new Team()
                {
                    Country = "Türkiye",
                    Name = "Adesso İzmir",
                },
                new Team()
                {
                    Country = "Türkiye",
                    Name = "Adesso Antalya",
                },
                new Team()
                {
                    Country = "Almanya",
                    Name = "Adesso Berlin",
                },
                new Team()
                {
                    Country = "Almanya",
                    Name = "Adesso Frankfurt",
                },
                new Team()
                {
                    Country = "Almanya",
                    Name = "Adesso Münih",
                },
                new Team()
                {
                    Country = "Almanya",
                    Name = "Adesso Dortmund",
                },
                new Team()
                {
                    Country = "Fransa",
                    Name = "Adesso Paris",
                },
                new Team()
                {
                    Country = "Fransa",
                    Name = "Adesso Marsilya",
                },
                new Team()
                {
                    Country = "Fransa",
                    Name = "Adesso Nice",
                },
                new Team()
                {
                    Country = "Fransa",
                    Name = "Adesso Lyon",
                },
                new Team()
                {
                    Country = "Hollanda",
                    Name = "Adesso Amsterdam",
                },
                new Team()
                {
                    Country = "Hollanda",
                    Name = "Adesso Rotterdam",
                },
                new Team()
                {
                    Country = "Hollanda",
                    Name = "Adesso Lahey",
                },
                new Team()
                {
                    Country = "Hollanda",
                    Name = "Adesso Eindhoven",
                },
                new Team()
                {
                    Country = "Portekiz",
                    Name = "Adesso Lisbon",
                },
                new Team()
                {
                    Country = "Portekiz",
                    Name = "Adesso Porto",
                },
                new Team()
                {
                    Country = "Portekiz",
                    Name = "Adesso Braga",
                },
                new Team()
                {
                    Country = "Portekiz",
                    Name = "Adesso Coimbra",
                },
                new Team()
                {
                    Country = "İtalya",
                    Name = "Adesso Roma",
                },
                new Team()
                {
                    Country = "İtalya",
                    Name = "Adesso Milano",
                },
                new Team()
                {
                    Country = "İtalya",
                    Name = "Adesso Venedik",
                },
                new Team()
                {
                    Country = "İtalya",
                    Name = "Adesso Napoli",
                },
                new Team()
                {
                    Country = "İspanya",
                    Name = "Adesso Sevilla",
                },
                new Team()
                {
                    Country = "İspanya",
                    Name = "Adesso Madrid",
                },
                new Team()
                {
                    Country = "İspanya",
                    Name = "Adesso Barselona",
                },
                new Team()
                {
                    Country = "İspanya",
                    Name = "Adesso Granada",
                },
                new Team()
                {
                    Country = "Belçika",
                    Name = "Adesso Brüksel",
                },
                new Team()
                {
                    Country = "Belçika",
                    Name = "Adesso Brugge",
                },
                new Team()
                {
                    Country = "Belçika",
                    Name = "Adesso Gent",
                },
                new Team()
                {
                    Country = "Belçika",
                    Name = "Adesso Anvers",
                }
            };
        }
    }
}
