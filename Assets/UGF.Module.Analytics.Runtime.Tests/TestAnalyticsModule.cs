namespace UGF.Module.Analytics.Runtime.Tests
{
    public class TestAnalyticsModule
    {
        public void Send()
        {
            AnalyticsEvents.Send(new TestAnalyticsData("Test", 10));
        }
    }
}
