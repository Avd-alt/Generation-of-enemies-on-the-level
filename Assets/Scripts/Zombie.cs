using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _direction;

    private void Update()
    {
        MoveInDirection();
    }

    private void MoveInDirection()
    {
        Vector3 newPosition = transform.position + _direction * _speed * Time.deltaTime;
        
        transform.position = newPosition;
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction.normalized;
    }
}