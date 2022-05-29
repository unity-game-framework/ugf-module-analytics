using System;
using System.Collections.Generic;

namespace UGF.Module.Analytics.Runtime
{
    public readonly struct AnalyticsEventData : IAnalyticsEventData
    {
        public IDictionary<string, object> Data { get; }

        public AnalyticsEventData(IDictionary<string, object> data)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public void GetData(IDictionary<string, object> data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            foreach (KeyValuePair<string, object> pair in Data)
            {
                data.Add(pair.Key, pair.Value);
            }
        }
    }
}
