using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Zombie _prefab;
    [SerializeField] private SpawnPoint[] _points;

    private float _delay = 2f;
    private Vector3 _direction = Vector3.forward;
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
            SpawnPoint spawnPoint = GetRandomPoint();

            Zombie spawnedZombie = Instantiate(_prefab, spawnPoint.transform.position, Quaternion.identity);

            spawnedZombie.SetDirection(_direction);

            yield return _spawnDelay;
        }
    }

    private void UpdateSpawnDelay()
    {
        _spawnDelay = new WaitForSeconds(_delay);
    }

    private SpawnPoint GetRandomPoint() => _points[Random.Range(0, _points.Length)];
}