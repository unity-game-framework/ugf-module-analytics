namespace UGF.Module.Analytics.Runtime
{
    public interface IAnalyticsEventParameters
    {
        void Set(string name, object value);
        void Set(string name, bool value);
        void Set(string name, string value);
        void Set(string name, long value);
        void Set(string name, double value);
        void Clear();
    }
}
