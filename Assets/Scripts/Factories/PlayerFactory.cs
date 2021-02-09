using Entities;
using UnityEngine;

namespace Factories
{
    public class PlayerFactory : Factory<PlayerEntity>
    {
        public PlayerEntity Create()
        { 
            PlayerEntity playerEntity = Instantiate(GetFirstPrefab(), Vector3.zero, Quaternion.identity);
            RegisterEntity(playerEntity);
            return playerEntity;
        }
    }
}