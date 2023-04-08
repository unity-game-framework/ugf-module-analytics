using UGF.Description.Runtime;
using UnityEngine;

namespace UGF.Module.Analytics.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Analytics/Analytics Event Description", order = 2000)]
    public class AnalyticsEventDescriptionAsset : DescriptionBuilderAsset<IAnalyticsEventDescription>
    {
        [SerializeField] private string m_name;

        public string Name { get { return m_name; } set { m_name = value; } }

        protected override IAnalyticsEventDescription OnBuild()
        {
            return new AnalyticsEventDescription(m_name);
        }
    }
}
