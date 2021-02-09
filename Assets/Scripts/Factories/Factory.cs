using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Factories
{
    [Serializable]
    public abstract class Factory<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private T[] m_prefabs;

        public class CreateUnityEvent : UnityEvent<T> { }
        public CreateUnityEvent CreateEvent { get; private set; } = new CreateUnityEvent();

        private List<T> m_instances { get; set; } = new List<T>();
        public IReadOnlyList<T> Instances => m_instances;

        protected T GetFirstPrefab() => m_prefabs[0];

        protected T GetPrefab(int index) => m_prefabs[index];

        protected T GetRandomPrefab() => m_prefabs[Random.Range(0, m_prefabs.Length)];

        protected void RegisterEntity(T entity)
        {
            m_instances.Add(entity);
        }
        
        public void DestroyEntity(T entity)
        {
            OnDestroyEntity(entity);
            m_instances.Remove(entity);
            DestroyEntityProcess(entity);
        }

        public void DestroyEntity(T entity, float delay) => StartCoroutine(IDestroyEntity(entity, delay));

        public void DestroyEntity(T entity, Predicate<T> predicate) => StartCoroutine(IDestroyEntity(entity, predicate));
        
        private IEnumerator IDestroyEntity(T entity, float delay)
        {
            if (!entity) yield break;
            yield return new WaitForSeconds(delay);
            if (entity) DestroyEntity(entity);
        }
        
        private IEnumerator IDestroyEntity(T entity, Predicate<T> predicate)
        {
            if (!entity) yield break;
            while (entity && !predicate(entity)) yield return new WaitForEndOfFrame();
            if (entity) DestroyEntity(entity);
        }

        public IEnumerable<T> Query(Predicate<T> predicate)
        {
            for(int i = 0 ;i < m_instances.Count; i++)
                if (m_instances[i] && predicate(m_instances[i]))
                    yield return m_instances[i];
        }
        
        public void Clear()
        {
            OnClear();
            while (m_instances.Count > 0) DestroyEntity(m_instances[0]);
        }

        private void OnDestroyEntity(T entity) { }

        private void OnClear() { }

        protected void DestroyEntityProcess(T entity)
        {
            if (entity)
            {
                Destroy(entity.gameObject);
            }
        }
    }
}