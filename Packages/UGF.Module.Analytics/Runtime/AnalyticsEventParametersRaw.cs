using System;
using System.Collections.Generic;

namespace UGF.Module.Analytics.Runtime
{
    public class AnalyticsEventParametersRaw : AnalyticsEventParameters
    {
        public IDictionary<string, object> Parameters { get; }

        public AnalyticsEventParametersRaw() : this(new Dictionary<string, object>())
        {
        }

        public AnalyticsEventParametersRaw(IDictionary<string, object> parameters)
        {
            Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }

        protected override void OnSet(string name, object value)
        {
            Parameters[name] = value;
        }

        protected override void OnSet(string name, bool value)
        {
            Parameters[name] = value;
        }

        protected override void OnSet(string name, long value)
        {
            Parameters[name] = value;
        }

        protected override void OnSet(string name, double value)
        {
            Parameters[name] = value;
        }

        protected override void OnClear()
        {
            Parameters.Clear();
        }
    }
}
