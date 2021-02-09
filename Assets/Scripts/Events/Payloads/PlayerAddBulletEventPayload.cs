namespace Events.Payloads
{
    public class PlayerAddBulletEventPayload : EventPayload
    {
        public  int Value { get; private set; }

        public static PlayerAddBulletEventPayload Create(int value)
        {
            return new PlayerAddBulletEventPayload
            {
                Value = value
            };
        }
    }
}