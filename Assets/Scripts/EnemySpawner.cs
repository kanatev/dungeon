using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] private int enemyCount;
    private GameObject[] _enemies;
    //private int _enemyCount;
    public int EnemyCount => enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        _enemies = new GameObject[enemyCount];
        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i] = Instantiate(_enemyPrefab);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        Instantiate(_enemyPrefab);
    }

}
