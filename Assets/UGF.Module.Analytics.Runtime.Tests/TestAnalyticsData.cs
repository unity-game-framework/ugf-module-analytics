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

        public void GetData(IAnalyticsEventDescription description, IDictionary<string, object> data)
        {
            if (description is not TestAnalyticsDataDescription eventDescription) throw new ArgumentException("Event description type mismatch.");
            if (data == null) throw new ArgumentNullException(nameof(data));

            data.Add(eventDescription.NameParameterName, Name);
            data.Add(eventDescription.ValueParameterName, Value);
        }
    }

    public class TestAnalyticsDataDescription : AnalyticsEventDescription
    {
        public string NameParameterName { get; }
        public string ValueParameterName { get; }

        public TestAnalyticsDataDescription(string name, string nameParameterName, string valueParameterName) : base(name)
        {
            if (string.IsNullOrEmpty(nameParameterName)) throw new ArgumentException("Value cannot be null or empty.", nameof(nameParameterName));
            if (string.IsNullOrEmpty(valueParameterName)) throw new ArgumentException("Value cannot be null or empty.", nameof(valueParameterName));

            NameParameterName = nameParameterName;
            ValueParameterName = valueParameterName;
        }
    }
}
