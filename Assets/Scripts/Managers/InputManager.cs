using Events;
using Events.Payloads;
using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        private const string AXIS_HORIZONTAL = "Horizontal";
        private const string AXIS_VERTICAL = "Vertical";

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) EventBus.Default.Dispatch(InputActionAEventPayload.Create(InputActionStateEnum.Down));
            else if (Input.GetKeyUp(KeyCode.Space)) EventBus.Default.Dispatch(InputActionAEventPayload.Create(InputActionStateEnum.Up));
            else if (Input.GetKey(KeyCode.Space)) EventBus.Default.Dispatch(InputActionAEventPayload.Create(InputActionStateEnum.Pressed));
            EventBus.Default.Dispatch(InputLeftAxisEventPayload.Create(new Vector2(Input.GetAxis(AXIS_HORIZONTAL), Input.GetAxis(AXIS_VERTICAL))));
        }
    }
}