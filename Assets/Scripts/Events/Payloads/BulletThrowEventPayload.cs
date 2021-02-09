using UnityEngine;

namespace Events.Payloads
{
    public class BulletThrowEventPayload : EventPayload
    {
        public Transform Sender { get; private set; }
        public Vector2 FromPosition { get; private set; }
        public Vector2 ToDirection { get; private set; }
        public float Force { get; private set; }

        public static BulletThrowEventPayload Create(Transform sender, Vector2 fromPosition, Vector2 toDirection, float force)
        {
            return new BulletThrowEventPayload
            {
                Sender = sender,
                FromPosition =  fromPosition,
                ToDirection = toDirection,
                Force = force
            };
        }
    }
}