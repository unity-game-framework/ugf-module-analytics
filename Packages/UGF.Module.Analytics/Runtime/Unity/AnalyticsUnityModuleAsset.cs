using UGF.Application.Runtime;
using UnityEngine;

namespace UGF.Module.Analytics.Runtime.Unity
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Analytics/Analytics Unity Module", order = 2000)]
    public class AnalyticsUnityModuleAsset : ApplicationModuleAsset<AnalyticsUnityModule, AnalyticsUnityModuleDescription>
    {
        [SerializeField] private bool m_enableOnInitializeAsync;

        public bool EnableOnInitializeAsync { get { return m_enableOnInitializeAsync; } set { m_enableOnInitializeAsync = value; } }

        protected override AnalyticsUnityModuleDescription OnBuildDescription()
        {
            return new AnalyticsUnityModuleDescription(m_enableOnInitializeAsync);
        }

        protected override AnalyticsUnityModule OnBuild(AnalyticsUnityModuleDescription description, IApplication application)
        {
            return new AnalyticsUnityModule(description, application);
        }
    }
}
