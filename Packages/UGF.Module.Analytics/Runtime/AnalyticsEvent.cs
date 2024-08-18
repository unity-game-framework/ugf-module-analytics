using System;
using System.Collections.Generic;

namespace UGF.Module.Analytics.Runtime
{
    public readonly struct AnalyticsEvent : IAnalyticsEvent
    {
        public string Name { get; }
        public IDictionary<string, object> Parameters { get; }

        public AnalyticsEvent(string name) : this(name, new Dictionary<string, object>())
        {
        }

        public AnalyticsEvent(string name, IDictionary<string, object> parameters)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            Name = name;
            Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }

        public void GetParameters(IAnalyticsEventParameters parameters)
        {
            foreach ((string name, object value) in Parameters)
            {
                parameters.Set(name, value);
            }
        }
    }
}
