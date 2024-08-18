using UGF.Application.Runtime;
using UnityEngine;

namespace UGF.Module.Analytics.Runtime.Unity
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Analytics/Analytics Unity Module", order = 2000)]
    public class AnalyticsUnityModuleAsset
#if UGF_MODULE_ANALYTICS_ANALYTICS_INSTALLED
        : ApplicationModuleAsset<AnalyticsUnityModule, AnalyticsUnityModuleDescription>
#else
        : ApplicationModuleAsset<IApplicationModule, AnalyticsUnityModuleDescription>
#endif
    {
        [SerializeField] private bool m_enableOnInitializeAsync;

        public bool EnableOnInitializeAsync { get { return m_enableOnInitializeAsync; } set { m_enableOnInitializeAsync = value; } }

        protected override AnalyticsUnityModuleDescription OnBuildDescription()
        {
            return new AnalyticsUnityModuleDescription(m_enableOnInitializeAsync);
        }

#if UGF_MODULE_ANALYTICS_ANALYTICS_INSTALLED
        protected override AnalyticsUnityModule OnBuild(AnalyticsUnityModuleDescription description, IApplication application)
        {
            return new AnalyticsUnityModule(description, application);
        }
#else
        protected override IApplicationModule OnBuild(AnalyticsUnityModuleDescription description, IApplication application)
        {
            throw new System.NotSupportedException("Analytics Unity Module: Analytics package required.");
        }
#endif
    }
}
