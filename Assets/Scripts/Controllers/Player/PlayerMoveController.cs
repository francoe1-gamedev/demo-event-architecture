using System;
using Entities;
using Events;
using Events.Payloads;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerMoveController : IDisposable
    {
        private IEventBus m_eventBus { get; set; }
        private float m_playerSpeed { get; set; } = 5;
        private PlayerEntity m_playerEntity { get; set; }
        
        public PlayerMoveController(IEventBus eventBus, PlayerEntity playerEntity)
        {
            m_eventBus = eventBus;
            m_playerEntity = playerEntity;
            m_eventBus.Register<InputLeftAxisEventPayload>(OnLeftAxisEvent);
        }
        
        private void OnLeftAxisEvent(InputLeftAxisEventPayload payload)
        { 
            Vector2 position = (Vector2)m_playerEntity.transform.position + payload.Value * (m_playerSpeed * Time.deltaTime);
            position.x = Mathf.Clamp(position.x, -4, 4);
            position.y = Mathf.Clamp(position.y, -4, 4);
            m_playerEntity.transform.position = position;
        }
        
        public void Dispose()
        {
            m_eventBus.Unregister<InputLeftAxisEventPayload>(OnLeftAxisEvent);
        }
    }
}