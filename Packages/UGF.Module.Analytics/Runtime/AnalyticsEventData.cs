using System;
using System.Collections.Generic;

namespace UGF.Module.Analytics.Runtime
{
    public readonly struct AnalyticsEventData : IAnalyticsEventData
    {
        public IDictionary<string, object> Parameters { get; }

        public AnalyticsEventData(IDictionary<string, object> parameters)
        {
            Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }

        public void GetParameters(IAnalyticsEventDescription description, IDictionary<string, object> parameters)
        {
            if (description == null) throw new ArgumentNullException(nameof(description));
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));

            foreach ((string key, object value) in Parameters)
            {
                parameters.Add(key, value);
            }
        }
    }
}
