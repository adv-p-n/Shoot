using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float targetRange = 5f;
    NavMeshAgent navMeshAgent;
    float targetDistance;
    void Start()
    {
        navMeshAgent= GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();

    }

     void MoveToTarget()
    {
        targetDistance = Vector3.Distance(target.position, transform.position);
        if (targetDistance <= targetRange)
        {
            navMeshAgent.SetDestination(target.position);
        }
    }
}
