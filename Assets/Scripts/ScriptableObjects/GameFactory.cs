using Factories;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameFactory", menuName = "GameFactory", order = 0)]
    public class GameFactory : ScriptableObject
    {
        [Header("Factories")]
        [SerializeField] private PlayerFactory m_playerFactory;
        [SerializeField] private BulletFactory m_bulletFactory;
        [SerializeField] private ObjectFactory m_objectFactory;

        public PlayerFactory PlayerFactory => m_playerFactory;
        public BulletFactory BulletFactory => m_bulletFactory;
        public ObjectFactory ObjectFactory => m_objectFactory;

        private void Awake()
        {
            m_playerFactory = Instantiate(m_playerFactory);
            m_bulletFactory = Instantiate(m_bulletFactory);
            m_objectFactory = Instantiate(m_objectFactory);
        }
    }
}