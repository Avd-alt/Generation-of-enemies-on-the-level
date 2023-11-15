using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Vector3 _moveDirection;

    public Vector3 MoveDirection => _moveDirection;

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, _moveDirection);
    }
}
