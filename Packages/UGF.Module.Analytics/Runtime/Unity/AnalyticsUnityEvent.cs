#if UGF_MODULE_ANALYTICS_ANALYTICS_INSTALLED
using System;
using Unity.Services.Analytics;

namespace UGF.Module.Analytics.Runtime.Unity
{
    public class AnalyticsUnityEvent : Event
    {
        public AnalyticsUnityEvent(string name) : base(!string.IsNullOrEmpty(name) ? name : throw new ArgumentException("Value cannot be null or empty.", nameof(name)))
        {
        }

        public void Set(string name, object value)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            SetParameter(name, value?.ToString() ?? string.Empty);
        }

        public void Set(string name, bool value)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            SetParameter(name, value);
        }

        public void Set(string name, string value)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            SetParameter(name, value);
        }

        public void Set(string name, long value)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            SetParameter(name, value);
        }

        public void Set(string name, double value)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            SetParameter(name, value);
        }
    }
}
#endif
