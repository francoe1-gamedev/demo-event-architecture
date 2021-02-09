using System;
using System.Collections.Generic;
using Controllers.Player;
using Entities;
using Events;
using Events.Payloads;
using Managers;
using Mechanics;
using UnityEngine;

namespace Bootstraps
{
    public class GameBootstrap : IDisposable
    {
        private PlayerEntity m_playerEntity { get; set; }
        private List<IDisposable> m_disposableElements { get; set; } = new List<IDisposable>();
        
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
            GameManager.Instance.GameFactory.ObjectFactory.Create(1).SetEventBus(EventBus.Default).transform.position = new Vector2(-1, 4);
            GameManager.Instance.GameFactory.ObjectFactory.Create().SetEventBus(EventBus.Default).transform.position = new Vector2(0, 4);
            GameManager.Instance.GameFactory.ObjectFactory.Create(1).SetEventBus(EventBus.Default).transform.position = new Vector2(1, 4);
            GameManager.Instance.GameFactory.ObjectFactory.Create().SetEventBus(EventBus.Default).transform.position = new Vector2(2, 4);
        }

        private void CreatePlayerAndMechanics()
        {
            m_playerEntity = GameManager.Instance.GameFactory.PlayerFactory.Create();
            m_disposableElements.Add(new PlayerMoveController(EventBus.Default, m_playerEntity));
            m_disposableElements.Add(new PlayerShotController(EventBus.Default, m_playerEntity));

            m_disposableElements.Add(new BulletMechanic(EventBus.Default));
            m_disposableElements.Add(new BulletPlayerMechanic(EventBus.Default));
            m_disposableElements.Add(new DestroyObjectEntityAddPlayerBulletMechanic(EventBus.Default, m_playerEntity));
        }

        public void Dispose()
        { 
            m_playerEntity = null;
            GameManager.Instance.GameFactory.PlayerFactory.Clear();
            GameManager.Instance.GameFactory.ObjectFactory.Clear();
            GameManager.Instance.GameFactory.BulletFactory.Clear();
            foreach (IDisposable disposableElement in m_disposableElements)
                disposableElement?.Dispose();
        }
    }
}