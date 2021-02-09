using Events.Payloads;
using UnityEngine;

namespace Entities
{
    public class BulletEntity : Entity
    {
        private float m_force { get; set; }

        private void Update()
        {
            Vector2 lastPosition = transform.position;
            transform.Translate(transform.up * (m_force * Time.deltaTime));
            Vector2 currentPosition = transform.position;
            RaycastHit2D hit = Physics2D.Linecast(lastPosition, currentPosition);
            if (hit) EventBus.Dispatch(BulletCollisionEventPayload.Create(this, hit.transform, hit.point, hit.normal));
        }

        public void SetForce(float force)
        {
            m_force = force;
        }
        
        public void SetDirection(Vector2 direction)
        {
            float angle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg / 2f;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}