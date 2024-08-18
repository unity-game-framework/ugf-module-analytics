using System;

namespace UGF.Module.Analytics.Runtime.Tests
{
    public readonly struct TestAnalyticsData : IAnalyticsEvent
    {
        public string Name { get; }
        public int Value { get; }

        public TestAnalyticsData(int value) : this("TestEvent", value)
        {
        }

        public TestAnalyticsData(string name, int value)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            Name = name;
            Value = value;
        }

        public void GetParameters(IAnalyticsEventParameters parameters)
        {
            parameters.Set("Value", Value);
        }
    }
}
