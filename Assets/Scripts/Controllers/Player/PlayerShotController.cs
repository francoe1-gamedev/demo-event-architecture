using Entities;
using Events;
using Events.Payloads;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerShotController
    {
        private PlayerEntity m_playerEntity { get; set; }
        private int m_currentBullets { get; set; }
        private IEventBus m_eventBus { get; set; }
        private bool m_enable { get; set; }

        public PlayerShotController(IEventBus eventBus, PlayerEntity playerEntity)
        {
            m_playerEntity = playerEntity;
            m_eventBus = eventBus;
            eventBus.Register<PlayerSetBulletEventPayload>(OnPlayerSetBulletEvent);
            eventBus.Register<PlayerAddBulletEventPayload>(OnPlayerAddBulletEvent);
            
            eventBus.Register<PlayerEnableShotEventPayload>(OnPlayerEnableShotEvent);
            
            eventBus.Register<BulletThrowEventPayload>(OnBulletThrowEvent);
            eventBus.Register<InputActionAEventPayload>(OnActionAEvent);
        }

        private void OnPlayerSetBulletEvent(PlayerSetBulletEventPayload payload)
        {
            m_currentBullets = payload.Value;
            m_eventBus.Dispatch(PlayerUpdateBulletEventPayload.Create(m_currentBullets));
        }
        
        private void OnPlayerAddBulletEvent(PlayerAddBulletEventPayload payload)
        {
            m_currentBullets += payload.Value;
            m_eventBus.Dispatch(PlayerUpdateBulletEventPayload.Create(m_currentBullets));
        }
        
        private void OnPlayerEnableShotEvent(PlayerEnableShotEventPayload payload)
        {
            m_enable = payload.Value;
        }

        private void OnBulletThrowEvent(BulletThrowEventPayload payload)
        {
            if (payload.Sender != m_playerEntity.transform) return;
            m_currentBullets -= 1;
            m_eventBus.Dispatch(PlayerUpdateBulletEventPayload.Create(m_currentBullets));
        }
        
        private void OnActionAEvent(InputActionAEventPayload payload)
        {
            if (payload.State == InputActionStateEnum.Down && m_enable)
            {
                m_eventBus.Dispatch(BulletThrowEventPayload.Create(m_playerEntity.transform, m_playerEntity.transform.position, Vector2.up, 5));
            }
        }
    }

}