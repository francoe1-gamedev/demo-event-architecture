namespace Events.Payloads
{
    public class PlayerUpdateBulletEventPayload : EventPayload
    {
        public  int Amount { get; private set; }

        public static PlayerUpdateBulletEventPayload Create(int amout)
        {
            return new PlayerUpdateBulletEventPayload
            {
                Amount = amout
            };
        }
    }
}