using UnityEngine;
using UnityEngine.UI;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private Text _volumeReadout;
    [SerializeField] private float _maxVolume = 100f;
    [SerializeField] private float _volumeRateOfChange = 20f;

    private float _currentVolume;
    private float _targetVolume;

    private void Update()
    {
        UpdateVolume();
        UpdateReadout();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Rogue _) == false)
            return;

        _targetVolume = _maxVolume;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Rogue _) == false)
            return;

        _targetVolume = 0f;
    }

    private void UpdateVolume()
    {
        _currentVolume = Mathf.MoveTowards(_currentVolume, _targetVolume, _volumeRateOfChange * Time.deltaTime);
    }

    private void UpdateReadout()
    {
        _volumeReadout.text = "Alarm volume: " + _currentVolume.ToString("0.0");
    }
}
