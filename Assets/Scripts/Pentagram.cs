using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pentagram : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] private int enemyCount;
    private GameObject[] _enemies;
    // Start is called before the first frame update
    void Start()
    {
        _enemies = new GameObject[enemyCount];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider objectName)
    {
        // Debug.Log("Entered collision with " + objectName.tag);
        if (objectName.CompareTag("Player"))
        {
            Vector3 spawnPlace = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,
                gameObject.transform.position.z+5);
            // Transform spawnPlace = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,
                //gameObject.transform.position.z);
                //gameObject.transform;
            for (int i = 0; i < _enemies.Length; i++)
            {
                //_enemies[i] = Instantiate(_enemyPrefab);
                // _enemies[i] = Instantiate(_enemyPrefab, gameObject.transform);
                // _enemies[i] = Instantiate(_enemyPrefab, gameObject.transform.position, Quaternion.identity);
                _enemies[i] = Instantiate(_enemyPrefab, spawnPlace, Quaternion.identity);
            }
        }
    }
}
