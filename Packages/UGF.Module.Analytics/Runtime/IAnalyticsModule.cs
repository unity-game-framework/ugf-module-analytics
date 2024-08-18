using System.Threading.Tasks;
using UGF.Application.Runtime;

namespace UGF.Module.Analytics.Runtime
{
    public interface IAnalyticsModule : IApplicationModule
    {
        bool IsEnabled { get; }

        Task<bool> EnableAsync();
        Task DisableAsync();
        void SendEvent(string name);
        void SendEvent(IAnalyticsEvent analyticsEvent);
        void SendEvent<T>(T analyticsEvent) where T : IAnalyticsEvent;
    }
}
