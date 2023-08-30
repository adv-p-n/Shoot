using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] float damage = 40f;

    public void AttackHitEvent()
    {
        if(Target == null) { return; }
        Debug.Log("Aarg");
    }
}
