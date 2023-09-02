using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float targetRange = 5f;
    [SerializeField] float lookSpeed = 10f;
    NavMeshAgent navMeshAgent;
    Animator myAnimator;
    EnemyHealth enemyHealth;
    float targetDistance;
    bool isProvoked = false;
    void Start()
    {
        myAnimator= GetComponent<Animator>();
        navMeshAgent= GetComponent<NavMeshAgent>();
        enemyHealth= GetComponent<EnemyHealth>();
    }


    void Update()
    {
        if (enemyHealth.GetIsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;

        }
        else
        {
            MoveToTarget();
        }
    }

     void MoveToTarget()
    {
        targetDistance = Vector3.Distance(target.position, transform.position);
        if(isProvoked)
        {
            EngageTarget();
        }
        else if (targetDistance <= targetRange)
        {
            isProvoked= true;
        }
        
    }
    void EngageTarget()
    {
        LookAtTarget();
        if (targetDistance >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        else if(targetDistance<= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

     void AttackTarget()
    {
        myAnimator.SetBool("attack",true);
        Debug.Log("You are being attacked by" + name);
    }

    void ChaseTarget()
    {
        myAnimator.SetBool("attack", false);
        myAnimator.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, targetRange);
    }

    void LookAtTarget()
    {
        Vector3 directiion = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directiion.x, 0, directiion.z));
        Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed);
    }
}
