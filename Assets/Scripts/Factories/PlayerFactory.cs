using System;
using Entities;
using UnityEngine;

namespace Factories
{
    [Serializable]
    public class PlayerFactory : Factory<PlayerEntity>
    {
        public PlayerEntity Create()
        { 
            return Instantiate(GetFirstPrefab());
        }
    }
}