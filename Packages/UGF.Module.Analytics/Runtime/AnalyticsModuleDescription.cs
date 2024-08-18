using UGF.Application.Runtime;

namespace UGF.Module.Analytics.Runtime
{
    public class AnalyticsModuleDescription : ApplicationModuleDescription
    {
        public bool EnableOnInitializeAsync { get; }

        public AnalyticsModuleDescription(bool enableOnInitializeAsync)
        {
            EnableOnInitializeAsync = enableOnInitializeAsync;
        }
    }
}
