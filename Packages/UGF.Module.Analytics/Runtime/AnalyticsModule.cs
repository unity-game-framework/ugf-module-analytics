using System;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Initialize.Runtime;
using UGF.Logs.Runtime;

namespace UGF.Module.Analytics.Runtime
{
    public abstract class AnalyticsModule<TDescription> : ApplicationModuleAsync<TDescription>, IAnalyticsModule where TDescription : AnalyticsModuleDescription
    {
        public bool IsEnabled { get { return m_state; } }

        protected ILog Logger { get; }

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

        public void SendEvent(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            OnSendEvent(name);
        }

        public void SendEvent(IAnalyticsEvent analyticsEvent)
        {
            if (analyticsEvent == null) throw new ArgumentNullException(nameof(analyticsEvent));

            OnSendEvent(analyticsEvent);
        }

        public void SendEvent<T>(T analyticsEvent) where T : IAnalyticsEvent
        {
            OnSendEvent(analyticsEvent);
        }

        protected abstract Task<bool> OnEnableAsync();
        protected abstract Task OnDisableAsync();
        protected abstract void OnSendEvent(string name);
        protected abstract void OnSendEvent(IAnalyticsEvent analyticsEvent);
        protected abstract void OnSendEvent<T>(T analyticsEvent) where T : IAnalyticsEvent;
    }
}
