using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;

namespace UGF.Module.Analytics.Runtime.Unity
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Analytics/Analytics Unity Module", order = 2000)]
    public class AnalyticsUnityModuleAsset : ApplicationModuleAsset<AnalyticsUnityModule, AnalyticsUnityModuleDescription>
    {
        [SerializeField] private bool m_enableOnInitializeAsync;
        [SerializeField] private List<AssetIdReference<AnalyticsEventDescriptionAsset>> m_events = new List<AssetIdReference<AnalyticsEventDescriptionAsset>>();

        public bool EnableOnInitializeAsync { get { return m_enableOnInitializeAsync; } set { m_enableOnInitializeAsync = value; } }
        public List<AssetIdReference<AnalyticsEventDescriptionAsset>> Events { get { return m_events; } }

        protected override IApplicationModuleDescription OnBuildDescription()
        {
            var events = new Dictionary<GlobalId, AnalyticsEventDescription>();

            for (int i = 0; i < m_events.Count; i++)
            {
                AssetIdReference<AnalyticsEventDescriptionAsset> reference = m_events[i];

                events.Add(reference.Guid, reference.Asset.Build());
            }

            return new AnalyticsModuleDescription(
                typeof(IAnalyticsModule),
                m_enableOnInitializeAsync,
                events
            );
        }

        protected override AnalyticsUnityModule OnBuild(AnalyticsUnityModuleDescription description, IApplication application)
        {
            return new AnalyticsUnityModule(description, application);
        }
    }
}
