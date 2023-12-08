using Core;

namespace Services.GroupBuilders.Strategies
{
    internal class Group : IGroup
    {
        private readonly IGroupValidator groupValidator;

        public Group(IGroupValidator groupValidator)
        {
            this.groupValidator = groupValidator;
        }

        public string Name { get; init; }

        public IReadOnlyList<ITeam> Teams { get; init; }

        public void Validate()
        {
            groupValidator.ValidateGroup(this);
        }
    }
}
