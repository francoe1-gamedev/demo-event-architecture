using Events;
using Events.Payloads;
using UnityEngine;
using UnityEngine.UI;

namespace Components.UI
{
    public class PlayerBulletUIComponent : MonoBehaviour
    {
        [SerializeField] private Text m_bulletText;
        
        private void Start()
        {
            EventBus.Default.Register<PlayerUpdateBulletEventPayload>(OnPlayerUpdateBulletEvent);
        }
        
        private void OnPlayerUpdateBulletEvent(PlayerUpdateBulletEventPayload payload)
        {
            m_bulletText.text = $"Bullets {payload.Amount}";
        }
    }
}