using Entities;
using UnityEngine;

namespace Factories
{
    public class ObjectFactory : Factory<ObjectEntity>
    {
        public ObjectEntity Create()
        {
            ObjectEntity objectEntity = Instantiate(GetFirstPrefab(), Vector2.zero, Quaternion.identity);
            RegisterEntity(objectEntity);
            return objectEntity;
        }
    }
}