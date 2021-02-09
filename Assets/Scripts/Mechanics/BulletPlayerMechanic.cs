using Events;
using Events.Payloads;

namespace Mechanics
{
    public class BulletPlayerMechanic
    {
        private IEventBus m_eventBus { get; set; }

        public BulletPlayerMechanic(IEventBus eventBus)
        {
            m_eventBus = eventBus;
            m_eventBus.Register<PlayerUpdateBulletEventPayload>(OnPlayerUpdateBulletEvent);
        }
        
        private void OnPlayerUpdateBulletEvent(PlayerUpdateBulletEventPayload payload)
        {
            m_eventBus.Dispatch(PlayerEnableShotEventPayload.Create(payload.Amount > 0));
        }
    }

}