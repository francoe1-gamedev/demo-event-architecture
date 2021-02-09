using UnityEngine;

namespace Events.Payloads
{
    public class InputLeftAxisEventPayload : EventPayload
    {
        public Vector2 Value { get; private set; }

        public static InputLeftAxisEventPayload Create(Vector2 value)
        {
            return new InputLeftAxisEventPayload
            {
                Value = value
            };
        }
    }
}