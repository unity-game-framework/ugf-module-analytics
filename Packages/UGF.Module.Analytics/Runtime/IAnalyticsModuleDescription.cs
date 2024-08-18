using System.Collections.Generic;
using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Analytics.Runtime
{
    public interface IAnalyticsModuleDescription : IDescription
    {
        IReadOnlyDictionary<GlobalId, IAnalyticsEventDescription> Events { get; }
    }
}
