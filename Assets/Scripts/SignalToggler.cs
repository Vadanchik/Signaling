using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SignalToggler : MonoBehaviour
{
    [SerializeField] private AudioSource _signalSound;
    [SerializeField] private SignalingArea _signalingArea;
    [SerializeField] private float _fadeSpeed = 0.25f;

    private float _maxVolume = 1;
    private float _minVolume = 0;

    private Coroutine _volumeCoroutine;

    private void Awake()
    {
        _signalSound = GetComponent<AudioSource>();
        _signalSound.volume = 0;
    }

    private void OnEnable()
    {
        _signalingArea.OnAreaEntry += StartSignaling;
        _signalingArea.OnAreaExit += StopSignaling;
    }

    private void OnDisable()
    {
        _signalingArea.OnAreaEntry -= StartSignaling;
        _signalingArea.OnAreaExit -= StopSignaling;
    }

    public void StartSignaling()
    {
        if (_volumeCoroutine == null)
        {
            _signalSound.Play();
        }
        else
        {
            StopCoroutine(_volumeCoroutine);
        }

        _volumeCoroutine = StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void StopSignaling()
    {
        StopCoroutine(_volumeCoroutine);
        _volumeCoroutine = StartCoroutine(ChangeVolume(_minVolume));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();

        while (Mathf.Abs(_signalSound.volume - targetVolume) > 0)
        {
            _signalSound.volume = Mathf.MoveTowards(_signalSound.volume, targetVolume, _fadeSpeed * Time.deltaTime);
            yield return wait;
        }

        if (targetVolume == _minVolume)
        {
            _volumeCoroutine = null;
            _signalSound.Stop();
        }
    }
}
