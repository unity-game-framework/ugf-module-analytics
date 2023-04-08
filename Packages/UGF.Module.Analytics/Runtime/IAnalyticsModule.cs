using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Analytics.Runtime
{
    public interface IAnalyticsModule : IApplicationModule
    {
        new IAnalyticsModuleDescription Description { get; }
        bool IsEnabled { get; }

        Task<bool> EnableAsync();
        Task DisableAsync();
        void SendEvent<T>(GlobalId eventId, T data) where T : IAnalyticsEventData;
        void SendEvent(GlobalId eventId, IAnalyticsEventData data);
        void SendEvent<T>(string name, T data) where T : IAnalyticsEventData;
        void SendEvent(string name, IAnalyticsEventData data);
        T GetEventDescription<T>(GlobalId eventId) where T : class, IAnalyticsEventDescription;
        IAnalyticsEventDescription GetEventDescription(GlobalId eventId);
        bool TryGetEventDescription<T>(GlobalId eventId, out T description) where T : class, IAnalyticsEventDescription;
        bool TryGetEventDescription(GlobalId eventId, out IAnalyticsEventDescription description);
    }
}
