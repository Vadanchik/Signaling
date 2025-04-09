using System;
using UnityEngine;

public class SignalingArea : MonoBehaviour
{
    public event Action OnAreaEntry;
    public event Action OnAreaExit;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Rogue>(out _))
        {
            OnAreaEntry?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Rogue>(out _))
        {
            OnAreaExit?.Invoke();
        }
    }
}
