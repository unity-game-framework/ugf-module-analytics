using System.Collections.Generic;

namespace UGF.Module.Analytics.Runtime
{
    public interface IAnalyticsEventData
    {
        void GetData(IAnalyticsEventDescription description, IDictionary<string, object> data);
    }
}
