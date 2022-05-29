using UGF.Application.Runtime;
using UnityEngine;

namespace UGF.Module.Analytics.Runtime.Unity
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Analytics/Analytics Unity Module", order = 2000)]
    public class AnalyticsUnityModuleAsset : ApplicationModuleAsset<AnalyticsUnityModule, AnalyticsUnityModuleDescription>
    {
        protected override IApplicationModuleDescription OnBuildDescription()
        {
            var description = new AnalyticsUnityModuleDescription
            {
                RegisterType = typeof(IAnalyticsModule)
            };

            return description;
        }

        protected override AnalyticsUnityModule OnBuild(AnalyticsUnityModuleDescription description, IApplication application)
        {
            return new AnalyticsUnityModule(description, application);
        }
    }
}
