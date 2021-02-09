using System;
using Entities;
using Events;
using Events.Payloads;
using Managers;
using UnityEngine;

namespace Mechanics
{
    public class BulletMechanic : IDisposable
    {
        private IEventBus m_eventBus { get; set; }

        public BulletMechanic(IEventBus eventBus)
        {
            m_eventBus = eventBus;
            m_eventBus.Register<BulletThrowEventPayload>(OnBulletThrowEvent);
            m_eventBus.Register<BulletCollisionEventPayload>(OnBulletColllision);
        }
        
        private void OnBulletColllision(BulletCollisionEventPayload payload)
        {   
            GameManager.Instance.GameFactory.BulletFactory.DestroyEntity(payload.BulletEntity);
        }

        private void OnBulletThrowEvent(BulletThrowEventPayload payload)
        {
            BulletEntity bulletEntity = GameManager.Instance.GameFactory.BulletFactory.Create();
            bulletEntity.SetOwner(payload.Sender);
            bulletEntity.SetEventBus(m_eventBus);
            bulletEntity.transform.position = payload.FromPosition;
            bulletEntity.SetDirection(payload.ToDirection);
            bulletEntity.SetForce(payload.Force);
            
            GameManager.Instance.GameFactory.BulletFactory.DestroyEntity(bulletEntity, 10);
            GameManager.Instance.GameFactory.BulletFactory.DestroyEntity(bulletEntity, x => Vector2.Distance(payload.FromPosition, x.transform.position) > 10);
        }
        
        public void Dispose()
        {
            m_eventBus.Unregister<BulletThrowEventPayload>(OnBulletThrowEvent);
            m_eventBus.Unregister<BulletCollisionEventPayload>(OnBulletColllision);
        }
    }
}