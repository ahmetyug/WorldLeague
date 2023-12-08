using Core;

namespace Services.GroupBuilders.Strategies
{
    internal interface IGroupValidator
    {
        void ValidateGroup(IGroup group);
    }
}
