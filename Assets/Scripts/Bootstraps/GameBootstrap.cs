using System;
using Controllers.Player;
using Entities;
using Events;
using Events.Payloads;
using Managers;
using Mechanics;
using ScriptableObjects;
using UnityEngine;

namespace Bootstraps
{
    public class GameBootstrap : IDisposable
    {
        private PlayerEntity m_playerEntity { get; set; }
        
        public GameBootstrap()
        {
            CreateScenaryObjects();
            CreatePlayerAndMechanics();
            StartGame();
        }

        private void StartGame()
        {
            EventBus.Default.Dispatch(PlayerSetBulletEventPayload.Create(10));
        }

        private void CreateScenaryObjects()
        {
            GameManager.Instance.GameFactory.ObjectFactory.Create().SetEventBus(EventBus.Default).transform.position = new Vector2(-2, 4);
            GameManager.Instance.GameFactory.ObjectFactory.Create().SetEventBus(EventBus.Default).transform.position = new Vector2(0, 4);
            GameManager.Instance.GameFactory.ObjectFactory.Create().SetEventBus(EventBus.Default).transform.position = new Vector2(2, 4);
        }

        private void CreatePlayerAndMechanics()
        {
            m_playerEntity = GameManager.Instance.GameFactory.PlayerFactory.Create();
            new PlayerMoveController(EventBus.Default, m_playerEntity);
            new PlayerShotController(EventBus.Default, m_playerEntity);

            new BulletMechanic(EventBus.Default);
            new BulletPlayerMechanic(EventBus.Default);
            new DestroyObjectEntityAddPlayerBulletMechanic(EventBus.Default, m_playerEntity);
        }

        public void Dispose()
        { 
            m_playerEntity = null;
            GameManager.Instance.GameFactory.PlayerFactory.Clear();
            GameManager.Instance.GameFactory.ObjectFactory.Clear();
            GameManager.Instance.GameFactory.BulletFactory.Clear();
        }
    }
}