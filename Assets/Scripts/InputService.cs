using UnityEngine;

public class InputService : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    public Vector3 MoveDirection => new Vector3(Input.GetAxis(HorizontalAxis), 0, Input.GetAxis(VerticalAxis)).normalized;
}