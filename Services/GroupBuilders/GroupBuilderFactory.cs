using Services.GroupBuilders.Strategies;

namespace Services.GroupBuilders
{
    public class GroupBuilderFactory : IGroupBuilderFactory
    {
        public IGroupBuilder GetGroupBuilder(GroupBuildingStrategies groupBuildingStrategy)
        {
            switch (groupBuildingStrategy)
            {
                case GroupBuildingStrategies.NoSameCountryInTheGroup:
                    return new GroupBuilderNoSameCountryInGroup();
                default:
                    throw new NotImplementedException("Unkown group generation strategy");
            }
        }
    }
}
