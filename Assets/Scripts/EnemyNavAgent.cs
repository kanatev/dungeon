using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavAgent : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator enemyAnimator;
    
    private Transform _target;
    
    // Start is called before the first frame update
    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // check if collision with a sword (checking for attack will be added later)
        // run death animation  
        // run event enemy_death (GM will increment counter in UI)
        
        // if ()
        _agent.SetDestination(_target.position);
    }
    
    
    // void OnTriggerEnter(Collider objectName)
    // {
    //     Debug.Log("Entered collision with " + objectName.gameObject.name);
    //     if (objectName.gameObject.name == "SWORD")
    //     {
    //         Destroy(gameObject);
    //     }
    // }
    
    
}
