using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] private float _monsterSpeed;
    private GameObject _target;
    private bool _destroyInProgress;
    
    void Start()
    {
        _destroyInProgress = false;
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log(gameObjects.Length);
        _target = gameObjects[0];
        Debug.Log(_target.name);
        transform.position = new Vector3(Random.Range(-10, 10), 0.0f, Random.Range(-10, 10));
    }

    void Update()
    {
        Vector3 targetDirection = _target.transform.position - transform.position;
        float singleStep = 3 * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        if (Vector3.Distance(transform.position, _target.transform.position) > 1.0f)
        {
            var step = _monsterSpeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, step);
        }
        else
        {
            if (!_destroyInProgress)
            {
                StartCoroutine(DeathCoroutine());
            }
        }
    }

    IEnumerator DeathCoroutine()
    {
        _destroyInProgress = true;

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);

        EnemySpawner spawner = FindAnyObjectByType<EnemySpawner>();
        spawner.GetComponent<EnemySpawner>().SpawnEnemy();

        Destroy(gameObject);
    }
}
