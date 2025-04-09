using UnityEngine;

[RequireComponent(typeof(SignalToggler))]
public class SignalingArea : MonoBehaviour
{
    [SerializeField] private SignalToggler _signalController;

    private void Awake()
    {
        _signalController = GetComponent<SignalToggler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Rogue>(out _))
        {
            _signalController.StartSignaling();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Rogue>(out _))
        {
            _signalController.StopSignaling();
        }
    }
}
