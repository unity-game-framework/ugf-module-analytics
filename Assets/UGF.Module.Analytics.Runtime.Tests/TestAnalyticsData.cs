using System;
using System.Collections.Generic;

namespace UGF.Module.Analytics.Runtime.Tests
{
    public readonly struct TestAnalyticsData : IAnalyticsEventData
    {
        public string Name { get; }
        public int Value { get; }

        public TestAnalyticsData(string name, int value)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            Name = name;
            Value = value;
        }

        public void GetData(IDictionary<string, object> data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            data["name"] = Name;
            data["value"] = Value;
        }
    }
}
