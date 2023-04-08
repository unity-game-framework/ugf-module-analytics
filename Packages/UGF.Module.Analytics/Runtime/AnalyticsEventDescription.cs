using System;
using UGF.Description.Runtime;

namespace UGF.Module.Analytics.Runtime
{
    public class AnalyticsEventDescription : DescriptionBase, IAnalyticsEventDescription
    {
        public string Name { get; }

        public AnalyticsEventDescription(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            Name = name;
        }
    }
}
