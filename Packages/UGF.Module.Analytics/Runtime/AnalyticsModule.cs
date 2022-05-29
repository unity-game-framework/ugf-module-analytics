using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Initialize.Runtime;

namespace UGF.Module.Analytics.Runtime
{
    public abstract class AnalyticsModule<TDescription> : ApplicationModule<TDescription>, IAnalyticsModule where TDescription : class, IApplicationModuleDescription
    {
        public bool IsEnabled { get { return m_state; } }

        private InitializeState m_state;

        protected AnalyticsModule(TDescription description, IApplication application) : base(description, application)
        {
        }

        public async Task<bool> EnableAsync()
        {
            if (await OnEnableAsync())
            {
                m_state = m_state.Initialize();

                return true;
            }

            return false;
        }

        public Task DisableAsync()
        {
            m_state = m_state.Uninitialize();

            return OnDisableAsync();
        }

        public void SendEvent<T>(string name, T data) where T : IAnalyticsEventData
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            OnSendEvent(name, OnGetEventData(name, data));
        }

        public void SendEvent(string name, IAnalyticsEventData data)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));
            if (data == null) throw new ArgumentNullException(nameof(data));

            OnSendEvent(name, OnGetEventData(name, data));
        }

        protected abstract Task<bool> OnEnableAsync();
        protected abstract Task OnDisableAsync();
        protected abstract void OnSendEvent(string name, IDictionary<string, object> data);
        protected abstract IDictionary<string, object> OnGetEventData<T>(string name, T data) where T : IAnalyticsEventData;
    }
}
