namespace Events
{
    public delegate void EventDelegate<T>(T payload) where T : EventPayload, new();
    public interface IEventBus
    {
        void Register<T>(EventDelegate<T> eventHandle) where T : EventPayload, new();
        void Unregister<T>(EventDelegate<T> eventHandle) where T : EventPayload, new();
        void Dispatch<T>(T payload) where T : EventPayload, new();
        void RemoveNullReference();
    }
}
