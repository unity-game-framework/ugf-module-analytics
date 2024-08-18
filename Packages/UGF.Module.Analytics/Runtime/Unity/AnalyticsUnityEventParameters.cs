#if UGF_MODULE_ANALYTICS_ANALYTICS_INSTALLED
using System;

namespace UGF.Module.Analytics.Runtime.Unity
{
    public class AnalyticsUnityEventParameters : AnalyticsEventParameters
    {
        public AnalyticsUnityEvent UnityEvent { get; }

        public AnalyticsUnityEventParameters(string name) : this(new AnalyticsUnityEvent(name))
        {
        }

        public AnalyticsUnityEventParameters(AnalyticsUnityEvent unityEvent)
        {
            UnityEvent = unityEvent ?? throw new ArgumentNullException(nameof(unityEvent));
        }

        protected override void OnSet(string name, object value)
        {
            UnityEvent.Set(name, value);
        }

        protected override void OnSet(string name, bool value)
        {
            UnityEvent.Set(name, value);
        }

        protected override void OnSet(string name, long value)
        {
            UnityEvent.Set(name, value);
        }

        protected override void OnSet(string name, double value)
        {
            UnityEvent.Set(name, value);
        }

        protected override void OnClear()
        {
            UnityEvent.Reset();
        }
    }
}
#endif
