﻿using System;
using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Analytics.Runtime
{
    public class AnalyticsModuleDescription : ApplicationModuleDescription, IAnalyticsModuleDescription
    {
        public bool EnableOnInitializeAsync { get; }
        public IReadOnlyDictionary<GlobalId, IAnalyticsEventDescription> Events { get; }

        public AnalyticsModuleDescription(bool enableOnInitializeAsync, IReadOnlyDictionary<GlobalId, IAnalyticsEventDescription> events)
        {
            EnableOnInitializeAsync = enableOnInitializeAsync;
            Events = events ?? throw new ArgumentNullException(nameof(events));
        }
    }
}
