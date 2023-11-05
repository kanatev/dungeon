using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    private GameObject[] _enemies;
    private int _enemyCount;
    public int EnemyCount => _enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        _enemyCount = 20;
        //_enemies = new GameObject[] { Instantiate(_enemyPrefab), Instantiate(_enemyPrefab), Instantiate(_enemyPrefab) };
        _enemies = new GameObject[5];
        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i] = Instantiate(_enemyPrefab);
        }
        
        //Instantiate(_enemyPrefab, new Vector3(0.0f, 0, 0), Quaternion.identity);
        //Instantiate(_enemyPrefab);
        //Instantiate(_enemyPrefab);
        //Instantiate(_enemyPrefab);
        Debug.Log("did it");
        Debug.Log(_enemies.Length);

        Debug.Log(_enemies.Length);
        //_enemies = null;
        //_enemies = new GameObject[] { Instantiate(_enemyPrefab, new Vector3(0.0f, 0, 0), Quaternion.identity), null };
        //_enemies = new GameObject[] { Instantiate(_enemyPrefab, new Vector3(0.0f, 0, 0), Quaternion.identity), Instantiate(_enemyPrefab, new Vector3(0.0f, 0, 0), Quaternion.identity) };

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
