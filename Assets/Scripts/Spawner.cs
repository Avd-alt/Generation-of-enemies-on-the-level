using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Zombie _prefab;
    [SerializeField] private SpawnPoint _spawnPoint;

    private float _delay = 2f;
    private WaitForSeconds _spawnDelay;
    private Coroutine _spawnCoroutine;

    private void Awake()
    {
        UpdateSpawnDelay();
    }

    private void Start()
    {
        _spawnCoroutine = StartCoroutine(SpawnZombie());
    }

    private IEnumerator SpawnZombie()
    {
        bool isWorking = true;

        while (isWorking)
        {
            Zombie spawnedZombie = Instantiate(_prefab, _spawnPoint.transform.position, Quaternion.identity);

            spawnedZombie.transform.forward = _spawnPoint.MoveDirection;

            yield return _spawnDelay;
        }
    }

    private void UpdateSpawnDelay()
    {
        _spawnDelay = new WaitForSeconds(_delay);
    }
}