using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Analytics.Runtime
{
    public interface IAnalyticsModuleDescription : IApplicationModuleDescription
    {
        IReadOnlyDictionary<GlobalId, IAnalyticsEventDescription> Events { get; }
    }
}
