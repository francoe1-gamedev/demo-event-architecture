using UnityEngine;

namespace Events.Payloads
{
    public class InputActionAEventPayload : EventPayload
    {
        public InputActionStateEnum State { get; private set; }

        public static InputActionAEventPayload Create(InputActionStateEnum state)
        {
            return new InputActionAEventPayload
            {
                State = state
            };
        }
    }
}