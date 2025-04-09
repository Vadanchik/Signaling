using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SignalToggler : MonoBehaviour
{
    [SerializeField] private AudioSource _signalSound;
    [SerializeField] private float _fadeSpeed = 0.25f;

    private float _maxVolume = 1;
    private float _minVolume = 0;
    private float _targetVolume = 0;

    private Coroutine _volumeCoroutine;

    private void Awake()
    {
        _signalSound = GetComponent<AudioSource>();
        _signalSound.volume = 0;
    }

    public void StartSignaling()
    {
        _targetVolume = _maxVolume;

        if (_volumeCoroutine == null)
        {
            _signalSound.Play();
            _volumeCoroutine = StartCoroutine(ChangeVolume());
        }
    }

    public void StopSignaling()
    {
        _targetVolume = _minVolume;
    }

    private IEnumerator ChangeVolume()
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();

        while (Mathf.Abs(_signalSound.volume - _targetVolume) > 0)
        {
            _signalSound.volume = Mathf.MoveTowards(_signalSound.volume, _targetVolume, _fadeSpeed * Time.deltaTime);
            yield return wait;
        }

        if (_targetVolume == _minVolume)
        {
            _volumeCoroutine = null;
            _signalSound.Stop();
        }
    }
}
