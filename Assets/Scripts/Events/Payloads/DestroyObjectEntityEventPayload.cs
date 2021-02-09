using Entities;
using UnityEngine;

namespace Events.Payloads
{
    public class DestroyObjectEntityEventPayload : EventPayload
    {
        public ObjectEntity ObjectEntity { get; private set; }
        public Transform Sender { get; private set; }

        public static DestroyObjectEntityEventPayload Create(ObjectEntity objectEntity, Transform sender)
        {
            return new DestroyObjectEntityEventPayload
            {
                ObjectEntity = objectEntity,
                Sender = sender
            };
        }
    }
}