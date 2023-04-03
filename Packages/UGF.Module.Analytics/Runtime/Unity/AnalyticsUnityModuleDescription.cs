using System;
using System.Collections.Generic;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Analytics.Runtime.Unity
{
    public class AnalyticsUnityModuleDescription : AnalyticsModuleDescription
    {
        public AnalyticsUnityModuleDescription(
            Type registerType,
            bool enableOnInitializeAsync,
            IReadOnlyDictionary<GlobalId, AnalyticsEventDescription> eventDescriptions) : base(registerType, enableOnInitializeAsync, eventDescriptions)
        {
        }
    }
}
