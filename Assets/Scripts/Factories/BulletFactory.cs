using Entities;
using UnityEngine;

namespace Factories
{
    public class BulletFactory : Factory<BulletEntity>
    {
        public BulletEntity Create()
        { 
            BulletEntity bulletEntity = Instantiate(GetFirstPrefab(), Vector3.zero, Quaternion.identity);
            RegisterEntity(bulletEntity);
            return bulletEntity;
        }
    }
}