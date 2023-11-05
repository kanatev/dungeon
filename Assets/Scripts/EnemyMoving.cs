using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMoving : MonoBehaviour
{
    //ClickToMove= gameObject.GetComponent("ClickToMoveScript") as ClickToMoveScript;
    //ClickToMove.PlayWoodCuttingAnim();

    [SerializeField] private float _monsterSpeed;
    private GameObject _target;
    private bool _destroyInProgress;
    
    // Start is called before the first frame update
    void Start()
    {
        _destroyInProgress = false;
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log(gameObjects.Length);
        _target = gameObjects[0];
        Debug.Log(_target.name);


        // set random starting position
        // пусть враги появляются в радиусе 10 метров от персонажа
        //transform.position = new Vector3(3.0f, 0.0f, 3.0f);
        transform.position = new Vector3(Random.Range(-10, 10), 0.0f, Random.Range(-10, 10));
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 targetDirection = _target.transform.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = 3 * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        //Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);

        //transform.Translate(targetDirection);



        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, _target.transform.position) > 1.0f)
        {
            // Swap the position of the cylinder.
            //transform.position *= -1.0f;
            //Destroy(gameObject);

            // Move our position a step closer to the target.
            var step = _monsterSpeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, step);

        }
        else
        {
            // если карутина не запущена
            if (!_destroyInProgress)
            {
                StartCoroutine(DeathCoroutine());
            }
            
        }

    }

    IEnumerator DeathCoroutine()
    {
        _destroyInProgress = true;
        //Print the time of when the function is first called.
        Debug.Log("Death in progress : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Dead in : " + Time.time);

        //ClickToMove = FindObjectOfType<ClickToMoveScript>();
        //EnemySpawner spawner = FindAnyObjectByType<EnemySpawner>().gameObject.GetComponent<EnemySpawner>;
        //    hitInfo.gameObject.getComponent(PlayerControlHS);
        //playerScript.ResetPlayer();

        EnemySpawner spawner = FindAnyObjectByType<EnemySpawner>();
        spawner.GetComponent<EnemySpawner>().SpawnEnemy();

        Destroy(gameObject);
    }
}
