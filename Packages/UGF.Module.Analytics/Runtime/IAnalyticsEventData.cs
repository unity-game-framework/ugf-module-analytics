using System.Collections.Generic;

namespace UGF.Module.Analytics.Runtime
{
    public interface IAnalyticsEventData
    {
        void GetParameters(IAnalyticsEventDescription description, IDictionary<string, object> parameters);
    }
}
