using UnityEngine;

public class InputService : MonoBehaviour
{
    public Vector3 MoveDirection => new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
}