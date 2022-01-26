using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : ObjectPool
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _secondsBetweenSpawn;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_enemyPrefab);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {   
            if (TryGetObject(out GameObject enemy))
            {
                _elapsedTime = 0;
                SetEnemy(enemy, GetRandomPos());
            }
        }
    }

    private Vector3 GetRandomPos() =>
         new Vector3(Random.Range(-9, 9), 10, Random.Range(-9, 9));

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
        enemy.AddComponent<Rigidbody>();
    }

}
