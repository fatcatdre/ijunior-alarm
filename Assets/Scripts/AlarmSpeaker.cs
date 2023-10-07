using UnityEngine;
using UnityEngine.UI;

public class AlarmSpeaker : MonoBehaviour
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

    public void TurnOn()
    {
        _targetVolume = _maxVolume;
    }

    public void TurnOff()
    {
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
