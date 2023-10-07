using UnityEngine;
using UnityEngine.Events;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private UnityEvent _onRogueEntered;
    [SerializeField] private UnityEvent _onRogueExited;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Rogue _) == false)
            return;

        _onRogueEntered.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Rogue _) == false)
            return;

        _onRogueExited.Invoke();
    }
}
