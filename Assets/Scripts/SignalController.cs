using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SignalController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _fadeSpeed = 0.25f;

    private float _maxVolume = 1;
    private float _minVolume = 0;
    private float _volume = 0;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    private void Update()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _volume, _fadeSpeed * Time.deltaTime);
    }

    public void StartSignaling()
    {
        _volume = _maxVolume;
    }

    public void StopSignaling()
    {
        _volume = _minVolume;
    }
}
