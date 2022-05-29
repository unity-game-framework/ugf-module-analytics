using System;
using System.Collections.Generic;
using UGF.Application.Runtime;

namespace UGF.Module.Analytics.Runtime
{
    public static class AnalyticsApplicationExtensions
    {
        public static void SendAnalytics<T>(this IApplication application, T data) where T : IAnalyticsEventData
        {
            SendAnalytics(application, typeof(T).Name, data);
        }

        public static void SendAnalytics<T>(this IApplication application, string name, T data) where T : IAnalyticsEventData
        {
            if (application == null) throw new ArgumentNullException(nameof(application));

            application.GetModule<IAnalyticsModule>().SendEvent(name, data);
        }

        public static void SendAnalytics(this IApplication application, IAnalyticsEventData data)
        {
            SendAnalytics(application, data.GetType().Name, data);
        }

        public static void SendAnalytics(this IApplication application, string name, IDictionary<string, object> data)
        {
            SendAnalytics(application, name, new AnalyticsEventData(data));
        }

        public static void SendAnalytics(this IApplication application, string name, IAnalyticsEventData data)
        {
            if (application == null) throw new ArgumentNullException(nameof(application));

            application.GetModule<IAnalyticsModule>().SendEvent(name, data);
        }
    }
}
