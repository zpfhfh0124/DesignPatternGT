namespace ServiceLocator
{
    public interface IAnalyticsService
    {
        void SendEvent(string eventName);
    }
}