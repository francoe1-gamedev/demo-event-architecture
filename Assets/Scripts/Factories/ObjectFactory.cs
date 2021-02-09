using System;
using Entities;
using UnityEngine;

namespace Factories
{
    [Serializable]
    public class ObjectFactory : Factory<ObjectEntity>
    {
        public ObjectEntity Create()
        {
            return Instantiate(GetFirstPrefab());
        }
    }
}