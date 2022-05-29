using System.Collections.Generic;
using UGF.Application.Runtime;

namespace UGF.Module.Analytics.Runtime
{
    public static class AnalyticsEvents
    {
        public static void Send<T>(T data) where T : IAnalyticsEventData
        {
            Send(typeof(T).Name, data);
        }

        public static void Send<T>(string name, T data) where T : IAnalyticsEventData
        {
            ApplicationInstance.Application.SendAnalytics(name, data);
        }

        public static void Send(IAnalyticsEventData data)
        {
            Send(data.GetType().Name, data);
        }

        public static void Send(string name, IDictionary<string, object> data)
        {
            Send(name, new AnalyticsEventData(data));
        }

        public static void Send(string name, IAnalyticsEventData data)
        {
            ApplicationInstance.Application.SendAnalytics(name, data);
        }
    }
}
