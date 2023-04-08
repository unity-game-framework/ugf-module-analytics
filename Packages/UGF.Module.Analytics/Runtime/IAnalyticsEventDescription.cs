using UGF.Description.Runtime;

namespace UGF.Module.Analytics.Runtime
{
    public interface IAnalyticsEventDescription : IDescription
    {
        string Name { get; }
    }
}
