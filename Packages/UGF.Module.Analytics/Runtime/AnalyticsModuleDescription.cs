using System;
using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Analytics.Runtime
{
    public class AnalyticsModuleDescription : ApplicationModuleDescription
    {
        public bool EnableOnInitializeAsync { get; }
        public IReadOnlyDictionary<GlobalId, AnalyticsEventDescription> EventDescriptions { get; }

        public AnalyticsModuleDescription(Type registerType, bool enableOnInitializeAsync, IReadOnlyDictionary<GlobalId, AnalyticsEventDescription> eventDescriptions)
        {
            RegisterType = registerType ?? throw new ArgumentNullException(nameof(registerType));
            EnableOnInitializeAsync = enableOnInitializeAsync;
            EventDescriptions = eventDescriptions ?? throw new ArgumentNullException(nameof(eventDescriptions));
        }
    }
}
