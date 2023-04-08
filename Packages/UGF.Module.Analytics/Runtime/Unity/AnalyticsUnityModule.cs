using System.Collections.Generic;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Logs.Runtime;
using Unity.Services.Analytics;

namespace UGF.Module.Analytics.Runtime.Unity
{
    public class AnalyticsUnityModule : AnalyticsModule<AnalyticsUnityModuleDescription>
    {
        public IAnalyticsService Service { get { return AnalyticsService.Instance; } }

        public AnalyticsUnityModule(AnalyticsUnityModuleDescription description, IApplication application) : base(description, application)
        {
        }

        protected override async Task<bool> OnEnableAsync()
        {
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

        protected override void OnSendEvent(IAnalyticsEventDescription description, IDictionary<string, object> data)
        {
            Service.CustomData(description.Name, data);
        }

        protected override void OnSendEvent(IAnalyticsEventDescription description)
        {
            Service.CustomData(description.Name);
        }
    }
}
