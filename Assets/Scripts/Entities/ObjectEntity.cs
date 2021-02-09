using Events.Payloads;
using Managers;

namespace Entities
{
    public class ObjectEntity : Entity
    {
        private void Start()
        {
            EventBus.Register<BulletCollisionEventPayload>(OnBulletCollisionEvent);
            OnStart();
        }

        protected virtual void OnStart() { }

        private void OnDestroy()
        {
            EventBus.Unregister<BulletCollisionEventPayload>(OnBulletCollisionEvent);
        }

        private void OnBulletCollisionEvent(BulletCollisionEventPayload payload)
        {
            if (payload.CollisionTransform != transform) return;
            EventBus.Dispatch(DestroyObjectEntityEventPayload.Create(this, payload.BulletEntity.transform));
            GameManager.Instance.GameFactory.ObjectFactory.DestroyEntity(this);
        }
    }
}