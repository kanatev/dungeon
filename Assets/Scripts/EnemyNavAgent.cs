using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavAgent : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator enemyAnimator;
    private Transform _target;
    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        _agent.SetDestination(_target.position);
    }
}
