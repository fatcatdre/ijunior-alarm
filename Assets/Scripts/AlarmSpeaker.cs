using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AlarmSpeaker : MonoBehaviour
{
    [SerializeField] private Text _volumeReadout;
    [SerializeField] private float _maxVolume = 100f;
    [SerializeField] private float _volumeRateOfChange = 20f;

    private float _currentVolume;
    private float _targetVolume;
    private bool _isUpdatingVolume;

    public void TurnOn()
    {
        _targetVolume = _maxVolume;
        StartCoroutine(UpdateVolume());
    }

    public void TurnOff()
    {
        _targetVolume = 0f;
        StartCoroutine(UpdateVolume());
    }

    private IEnumerator UpdateVolume()
    {
        if (_isUpdatingVolume)
            yield break;

        _isUpdatingVolume = true;

        while (Mathf.Approximately(_currentVolume, _targetVolume) == false)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, _targetVolume, _volumeRateOfChange * Time.deltaTime);
            UpdateReadout();

            yield return null;
        }

        _isUpdatingVolume = false;
    }

    private void UpdateReadout()
    {
        _volumeReadout.text = "Alarm volume: " + _currentVolume.ToString("0.0");
    }
}
