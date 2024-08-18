using System.Collections.Generic;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Analytics.Runtime.Unity
{
    public class AnalyticsUnityModuleDescription : AnalyticsModuleDescription
    {
        public AnalyticsUnityModuleDescription(
            bool enableOnInitializeAsync,
            IReadOnlyDictionary<GlobalId, IAnalyticsEventDescription> eventDescriptions) : base(enableOnInitializeAsync, eventDescriptions)
        {
        }
    }
}
