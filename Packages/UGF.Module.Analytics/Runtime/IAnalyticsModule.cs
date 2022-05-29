using System.Threading.Tasks;
using UGF.Application.Runtime;

namespace UGF.Module.Analytics.Runtime
{
    public interface IAnalyticsModule : IApplicationModule
    {
        bool IsEnabled { get; }

        Task<bool> EnableAsync();
        Task DisableAsync();
        void SendEvent<T>(string name, T data) where T : IAnalyticsEventData;
        void SendEvent(string name, IAnalyticsEventData data);
    }
}
