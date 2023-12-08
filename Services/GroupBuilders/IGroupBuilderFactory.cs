namespace Services.GroupBuilders
{
    public interface IGroupBuilderFactory
    {
        IGroupBuilder GetGroupBuilder(GroupBuildingStrategies groupBuildingStrategy);
    }
}
