using UnityEngine;

[RequireComponent(typeof(SignalController))]
public class SignalingArea : MonoBehaviour
{
    [SerializeField] private SignalController _signalController;

    private void Awake()
    {
        _signalController = GetComponent<SignalController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.GetComponentInParent<Rogue>() != null);

        if(other.GetComponentInParent<Rogue>() != null)
        {
            _signalController.StartSignaling();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<Rogue>() != null)
        {
            _signalController.StopSignaling();
        }
    }
}
