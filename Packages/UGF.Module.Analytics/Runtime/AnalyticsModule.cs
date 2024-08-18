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

        protected ILog Logger { get; }

        IAnalyticsModuleDescription IAnalyticsModule.Description { get { return Description; } }

        private InitializeState m_state;

        protected AnalyticsModule(TDescription description, IApplication application) : base(description, application)
        {
            Logger = Log.CreateWithLabel(GetType().Name);
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

                Logger.Debug("Enabled.");

                return true;
            }

            return false;
        }

        public Task DisableAsync()
        {
            m_state = m_state.Uninitialize();

            Logger.Debug("Disabled.");

            return OnDisableAsync();
        }

        public void SendEvent<T>(GlobalId eventId, T data) where T : IAnalyticsEventData
        {
            if (!eventId.IsValid()) throw new ArgumentException("Value should be valid.", nameof(eventId));
            if (!IsEnabled) throw new InvalidOperationException("Analytics is not enabled.");

            IAnalyticsEventDescription description = GetEventDescription(eventId);
            IDictionary<string, object> parameters = OnGetEventParameters(description, data);

            OnSendEvent(description, parameters);
        }

        public void SendEvent(GlobalId eventId, IAnalyticsEventData data)
        {
            if (!eventId.IsValid()) throw new ArgumentException("Value should be valid.", nameof(eventId));
            if (!IsEnabled) throw new InvalidOperationException("Analytics is not enabled.");

            IAnalyticsEventDescription description = GetEventDescription(eventId);
            IDictionary<string, object> parameters = OnGetEventParameters(description, data);

            OnSendEvent(description, parameters);
        }

        public void SendEvent(GlobalId eventId)
        {
            if (!eventId.IsValid()) throw new ArgumentException("Value should be valid.", nameof(eventId));

            IAnalyticsEventDescription description = GetEventDescription(eventId);

            OnSendEvent(description);
        }

        public T GetEventDescription<T>(GlobalId eventId) where T : class, IAnalyticsEventDescription
        {
            return (T)GetEventDescription(eventId);
        }

        public IAnalyticsEventDescription GetEventDescription(GlobalId eventId)
        {
            return TryGetEventDescription(eventId, out IAnalyticsEventDescription description) ? description : throw new ArgumentException($"Analytics event description not found by the specified id: '{eventId}'.");
        }

        public bool TryGetEventDescription<T>(GlobalId eventId, out T description) where T : class, IAnalyticsEventDescription
        {
            if (TryGetEventDescription(eventId, out IAnalyticsEventDescription result))
            {
                description = (T)result;
                return true;
            }

            description = default;
            return false;
        }

        public bool TryGetEventDescription(GlobalId eventId, out IAnalyticsEventDescription description)
        {
            if (!eventId.IsValid()) throw new ArgumentException("Value should be valid.", nameof(eventId));

            return Description.Events.TryGetValue(eventId, out description);
        }

        protected abstract Task<bool> OnEnableAsync();
        protected abstract Task OnDisableAsync();
        protected abstract void OnSendEvent(IAnalyticsEventDescription description, IDictionary<string, object> parameters);
        protected abstract void OnSendEvent(IAnalyticsEventDescription description);

        protected virtual IDictionary<string, object> OnGetEventParameters<T>(IAnalyticsEventDescription description, T data) where T : IAnalyticsEventData
        {
            var parameters = new Dictionary<string, object>();

            data.GetParameters(description, parameters);

            return parameters;
        }
    }
}
