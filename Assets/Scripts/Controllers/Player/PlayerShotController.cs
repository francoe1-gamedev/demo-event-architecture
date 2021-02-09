using System;
using Entities;
using Events;
using Events.Payloads;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerShotController : IDisposable
    {
        private PlayerEntity m_playerEntity { get; set; }
        private int m_currentBullets { get; set; }
        private IEventBus m_eventBus { get; set; }
        private bool m_enable { get; set; }

        public PlayerShotController(IEventBus eventBus, PlayerEntity playerEntity)
        {
            m_playerEntity = playerEntity;
            m_eventBus = eventBus;
            m_eventBus.Register<PlayerSetBulletEventPayload>(OnPlayerSetBulletEvent);
            m_eventBus.Register<PlayerAddBulletEventPayload>(OnPlayerAddBulletEvent);
            
            m_eventBus.Register<PlayerEnableShotEventPayload>(OnPlayerEnableShotEvent);
            
            m_eventBus.Register<BulletThrowEventPayload>(OnBulletThrowEvent);
            m_eventBus.Register<InputActionAEventPayload>(OnActionAEvent);
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
        
        public void Dispose()
        {  
            m_eventBus.Unregister<PlayerSetBulletEventPayload>(OnPlayerSetBulletEvent);
            m_eventBus.Unregister<PlayerAddBulletEventPayload>(OnPlayerAddBulletEvent);
            
            m_eventBus.Unregister<PlayerEnableShotEventPayload>(OnPlayerEnableShotEvent);
            
            m_eventBus.Unregister<BulletThrowEventPayload>(OnBulletThrowEvent);
            m_eventBus.Unregister<InputActionAEventPayload>(OnActionAEvent);
        }
    }

}