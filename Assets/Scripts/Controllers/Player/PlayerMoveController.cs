using Entities;
using Events;
using Events.Payloads;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerMoveController
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
            m_playerEntity.transform.Translate(payload.Value * (m_playerSpeed * Time.deltaTime));
        }
    }
}