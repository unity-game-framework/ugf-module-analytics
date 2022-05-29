using System.Collections.Generic;

namespace UGF.Module.Analytics.Runtime
{
    public interface IAnalyticsEventData
    {
        void GetData(IDictionary<string, object> data);
    }
}
