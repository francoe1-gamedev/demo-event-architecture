using System;
using Events;
using UnityEngine;

namespace Entities
{
    public abstract class Entity : MonoBehaviour
    {
        public Transform Owner { get; private set; }
        protected IEventBus EventBus { get; private set; }

        public Entity SetEventBus(IEventBus eventBus)
        {
            EventBus = eventBus;
            return this;
        }

        public void SetOwner(Transform owner)
        {
            Owner = owner;
        }
    }
}