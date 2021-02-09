using System;
using System.Collections.Generic;
using System.Linq;

namespace Events
{
    public class EventBus : IEventBus
    {
        private Dictionary<Type, List<object>> m_events { get; set; } = new Dictionary<Type, List<object>>();

        private static EventBus m_defaulEventBus { get; set; }
        public static EventBus Default => m_defaulEventBus ?? (m_defaulEventBus = new EventBus());

        public void Register<T>(EventDelegate<T> eventHandle) where T : EventPayload, new()
        {
            Type key = typeof(T);
            if (!m_events.ContainsKey(key)) m_events.Add(key, new List<object>());
            if (m_events[key].Contains(eventHandle)) return;
            m_events[key].Add(eventHandle);
        }

        public void Unregister<T>(EventDelegate<T> eventHandle) where T : EventPayload, new()
        {
            Type key = typeof(T);
            if (!m_events.ContainsKey(key)) return;
            m_events[key].Remove(eventHandle);
        }

        public void Dispatch<T>(T payload) where T : EventPayload, new()
        {
            Type key = typeof(T);
            if (!m_events.ContainsKey(key)) return;

            List<object> events = m_events[key];
            bool removeNullReference = false;
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i] == null)
                {
                    removeNullReference = true; ;
                    continue;
                }
                ((EventDelegate<T>)events[i]).Invoke(payload);
            }

            if (removeNullReference) RemoveNullReference();
        }

        public void RemoveNullReference()
        {
            List<Type> types = m_events.Keys.ToList();
            for (int j = 0; j < types.Count; j++)
            {
                List<object> events = m_events[types[j]];
                for (int i = 0; i < events.Count; i++)
                    if (events[i] == null)
                        m_events[types[j]].RemoveAt(i);
            }
        }
    }
}
