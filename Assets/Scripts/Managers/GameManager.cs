using System.Collections;
using Bootstraps;
using ScriptableObjects;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private GameBootstrap m_gameBootstrap { get; set; }

        [SerializeField] private GameFactory m_gameFactory;
        public GameFactory GameFactory => m_gameFactory;

        private void Awake()
        {
            if (Instance)
            {
                Destroy(this);
                return;
            }
            
            Instance = this;
            DontDestroyOnLoad(Instance);
        }

        private void Start()
        {
            m_gameFactory = Instantiate(m_gameFactory);
            m_gameFactory.BulletFactory.CorrutineHandle = FactoryCorrutine;
            m_gameFactory.PlayerFactory.CorrutineHandle = FactoryCorrutine;
            m_gameFactory.ObjectFactory.CorrutineHandle = FactoryCorrutine;
            m_gameBootstrap = new GameBootstrap();
        }

        private void FactoryCorrutine(IEnumerator enumerator) => StartCoroutine(enumerator);

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                m_gameBootstrap?.Dispose();
                m_gameBootstrap = new GameBootstrap();
            }
        }
    }
}