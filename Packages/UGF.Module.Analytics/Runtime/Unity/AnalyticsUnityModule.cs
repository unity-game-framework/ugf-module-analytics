using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using Unity.Services.Analytics;

namespace UGF.Module.Analytics.Runtime.Unity
{
    public class AnalyticsUnityModule : AnalyticsModule<AnalyticsUnityModuleDescription>
    {
        public IAnalyticsService Service { get { return AnalyticsService.Instance; } }

        private readonly Dictionary<string, AnalyticsUnityEventParameters> m_parameters = new Dictionary<string, AnalyticsUnityEventParameters>();

        public AnalyticsUnityModule(AnalyticsUnityModuleDescription description, IApplication application) : base(description, application)
        {
        }

        protected override Task<bool> OnEnableAsync()
        {
            Service.StartDataCollection();

            return Task.FromResult(true);
        }

        protected override Task OnDisableAsync()
        {
            Service.StopDataCollection();

            return Task.CompletedTask;
        }

        protected override void OnSendEvent(string name)
        {
            Service.RecordEvent(name);
        }

        protected override void OnSendEvent(IAnalyticsEvent analyticsEvent)
        {
            AnalyticsUnityEventParameters parameters = GetParameters(analyticsEvent.Name);

            analyticsEvent.GetParameters(parameters);

            Service.RecordEvent(parameters.UnityEvent);

            parameters.Clear();
        }

        protected override void OnSendEvent<T>(T analyticsEvent)
        {
            AnalyticsUnityEventParameters parameters = GetParameters(analyticsEvent.Name);

            analyticsEvent.GetParameters(parameters);

            Service.RecordEvent(parameters.UnityEvent);

            parameters.Clear();
        }

        private AnalyticsUnityEventParameters GetParameters(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            if (!m_parameters.TryGetValue(name, out AnalyticsUnityEventParameters parameters))
            {
                parameters = new AnalyticsUnityEventParameters(name);

                m_parameters.Add(name, parameters);
            }

            return parameters;
        }
    }
}
