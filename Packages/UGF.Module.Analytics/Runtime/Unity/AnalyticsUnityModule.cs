using System.Collections.Generic;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Logs.Runtime;
using Unity.Services.Analytics;
using Unity.Services.Core;

namespace UGF.Module.Analytics.Runtime.Unity
{
    public class AnalyticsUnityModule : AnalyticsModule<AnalyticsUnityModuleDescription>
    {
        public IAnalyticsService Service { get { return AnalyticsService.Instance; } }

        private readonly Dictionary<string, object> m_data = new Dictionary<string, object>();

        public AnalyticsUnityModule(AnalyticsUnityModuleDescription description, IApplication application) : base(description, application)
        {
        }

        protected override async Task<bool> OnEnableAsync()
        {
            if (UnityServices.State == ServicesInitializationState.Uninitialized)
            {
                await UnityServices.InitializeAsync();
            }

            while (UnityServices.State == ServicesInitializationState.Initializing)
            {
                await Task.Yield();
            }

            List<string> ids = await Service.CheckForRequiredConsents();

            Log.Debug("Analytics Unity module enable", new
            {
                consents = ids.Count
            });

            return ids.Count == 0;
        }

        protected override async Task OnDisableAsync()
        {
            await Service.SetAnalyticsEnabled(false);
        }

        protected override void OnSendEvent(string name, IDictionary<string, object> data)
        {
            Service.CustomData(name, data);
        }

        protected override IDictionary<string, object> OnGetEventData<T>(string name, T data)
        {
            data.GetData(m_data);

            return m_data;
        }
    }
}
