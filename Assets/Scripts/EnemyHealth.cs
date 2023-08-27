using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints=100f;

    public void ReduceHealth(float damage)
    {
        if (hitPoints > 0)
        {
            hitPoints-=damage;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
