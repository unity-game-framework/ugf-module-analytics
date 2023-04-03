using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;
using UGF.Initialize.Runtime;
using UGF.Logs.Runtime;

namespace UGF.Module.Analytics.Runtime
{
    public abstract class AnalyticsModule<TDescription> : ApplicationModuleAsync<TDescription>, IAnalyticsModule where TDescription : AnalyticsModuleDescription
    {
        public bool IsEnabled { get { return m_state; } }

        private InitializeState m_state;

        protected AnalyticsModule(TDescription description, IApplication application) : base(description, application)
        {
        }

        protected override async Task OnInitializeAsync()
        {
            await base.OnInitializeAsync();

            if (Description.EnableOnInitializeAsync)
            {
                await EnableAsync();
            }
        }

        public async Task<bool> EnableAsync()
        {
            if (await OnEnableAsync())
            {
                m_state = m_state.Initialize();

                Log.Debug("Analytics module enabled.");

                return true;
            }

            return false;
        }

        public Task DisableAsync()
        {
            m_state = m_state.Uninitialize();

            Log.Debug("Analytics module disabled.");

            return OnDisableAsync();
        }

        public void SendEvent<T>(GlobalId eventId, T data) where T : IAnalyticsEventData
        {
            if (!eventId.IsValid()) throw new ArgumentException("Value should be valid.", nameof(eventId));
            if (!IsEnabled) throw new InvalidOperationException("Analytics is not enabled.");

            AnalyticsEventDescription description = GetEventDescription(eventId);

            OnSendEvent(description.Name, OnGetEventData(description.Name, data));
        }

        public void SendEvent(GlobalId eventId, IAnalyticsEventData data)
        {
            if (!eventId.IsValid()) throw new ArgumentException("Value should be valid.", nameof(eventId));
            if (!IsEnabled) throw new InvalidOperationException("Analytics is not enabled.");

            AnalyticsEventDescription description = GetEventDescription(eventId);

            OnSendEvent(description.Name, OnGetEventData(description.Name, data));
        }

        public void SendEvent<T>(string name, T data) where T : IAnalyticsEventData
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));
            if (!IsEnabled) throw new InvalidOperationException("Analytics is not enabled.");

            OnSendEvent(name, OnGetEventData(name, data));
        }

        public void SendEvent(string name, IAnalyticsEventData data)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));
            if (data == null) throw new ArgumentNullException(nameof(data));
            if (!IsEnabled) throw new InvalidOperationException("Analytics is not enabled.");

            OnSendEvent(name, OnGetEventData(name, data));
        }

        public AnalyticsEventDescription GetEventDescription(GlobalId eventId)
        {
            return TryGetEventDescription(eventId, out AnalyticsEventDescription description) ? description : throw new ArgumentException($"Analytics event description not found by the specified id: '{eventId}'.");
        }

        public bool TryGetEventDescription(GlobalId eventId, out AnalyticsEventDescription description)
        {
            return Description.EventDescriptions.TryGetValue(eventId, out description);
        }

        protected abstract Task<bool> OnEnableAsync();
        protected abstract Task OnDisableAsync();
        protected abstract void OnSendEvent(string name, IDictionary<string, object> data);
        protected abstract IDictionary<string, object> OnGetEventData<T>(string name, T data) where T : IAnalyticsEventData;
    }
}
