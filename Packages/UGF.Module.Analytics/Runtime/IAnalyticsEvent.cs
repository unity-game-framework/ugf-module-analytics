namespace UGF.Module.Analytics.Runtime
{
    public interface IAnalyticsEvent
    {
        string Name { get; }

        void GetParameters(IAnalyticsEventParameters parameters);
    }
}
