using System;
using Entities;
using Events;
using Events.Payloads;

namespace Mechanics
{
    public class DestroyObjectEntityAddPlayerBulletMechanic : IDisposable
    {
        private PlayerEntity m_playerEntity { get; set; }
        private IEventBus m_eventBus { get; set; }
        
        public DestroyObjectEntityAddPlayerBulletMechanic(IEventBus eventBus, PlayerEntity playerEntity)
        {
            m_eventBus = eventBus;
            m_playerEntity = playerEntity;
            m_eventBus.Register<DestroyObjectEntityEventPayload>(OnDestroyObjectEntityEvent);
        }

        private void OnDestroyObjectEntityEvent(DestroyObjectEntityEventPayload payload)
        {
            if (payload.Sender.TryGetComponent(out Entity entity) && entity.Owner == m_playerEntity.transform)
                m_eventBus.Dispatch(PlayerAddBulletEventPayload.Create(5));
        }
        
        public void Dispose()
        {
            m_eventBus.Unregister<DestroyObjectEntityEventPayload>(OnDestroyObjectEntityEvent);
        }
    }
}