using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] private int enemyCount;
    private GameObject[] _enemies;
    public int EnemyCount => enemyCount;

    void Start()
    {
        _enemies = new GameObject[enemyCount];
        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i] = Instantiate(_enemyPrefab);
        }
    }
    
    public void SpawnEnemy()
    {
        Instantiate(_enemyPrefab);
    }
}
