using UnityEngine;

public class Rogue : MonoBehaviour
{
    [SerializeField] private InputService _inputService;
    [SerializeField] private float _movementSpeed = 3;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += _inputService.MoveDirection * _movementSpeed * Time.deltaTime;
    }
}