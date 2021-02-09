using Entities;
using UnityEngine;

namespace Events.Payloads
{
    public class BulletCollisionEventPayload : EventPayload
    {
        public BulletEntity BulletEntity { get; private set; }
        public Transform CollisionTransform { get; private set; }
        public Vector2 CollisionPoint { get; private set; }
        public Vector2 CollisionNormal { get; private set; }

        public static BulletCollisionEventPayload Create(BulletEntity bulletEntity, Transform collisionTransform, Vector2 collisionPoint, Vector2 collisionNormal)
        {
            return new BulletCollisionEventPayload
            {
                BulletEntity = bulletEntity,
                CollisionTransform = collisionTransform,
                CollisionPoint = collisionPoint,
                CollisionNormal = collisionNormal
            };
        }
    }
}