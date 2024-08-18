using System;

namespace UGF.Module.Analytics.Runtime
{
    public abstract class AnalyticsEventParameters : IAnalyticsEventParameters
    {
        public void Set(string name, object value)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            OnSet(name, value);
        }

        public void Set(string name, bool value)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            OnSet(name, value);
        }

        public void Set(string name, string value)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            OnSet(name, value);
        }

        public void Set(string name, long value)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            OnSet(name, value);
        }

        public void Set(string name, double value)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            OnSet(name, value);
        }

        public void Clear()
        {
            OnClear();
        }

        protected abstract void OnSet(string name, object value);
        protected abstract void OnSet(string name, bool value);
        protected abstract void OnSet(string name, long value);
        protected abstract void OnSet(string name, double value);
        protected abstract void OnClear();
    }
}
