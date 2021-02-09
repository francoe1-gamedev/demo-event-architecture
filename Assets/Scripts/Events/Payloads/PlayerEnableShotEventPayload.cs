namespace Events.Payloads
{
    public class PlayerEnableShotEventPayload : EventPayload
    {
        public  bool Value { get; private set; }

        public static PlayerEnableShotEventPayload Create(bool value)
        {
            return new PlayerEnableShotEventPayload
            {
                Value = value
            };
        }
    }
}