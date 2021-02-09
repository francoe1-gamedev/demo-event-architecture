using System;
using Entities;
using UnityEngine;

namespace Factories
{
    [Serializable]
    public class BulletFactory : Factory<BulletEntity>
    {
        public BulletEntity Create()
        { 
            return Instantiate(GetFirstPrefab());
        }
    }
}