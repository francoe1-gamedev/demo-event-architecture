namespace Events.Payloads
{
    public class PlayerSetBulletEventPayload : EventPayload
    {
        public  int Value { get; private set; }

        public static PlayerSetBulletEventPayload Create(int value)
        {
            return new PlayerSetBulletEventPayload
            {
                Value = value
            };
        }
    }
}