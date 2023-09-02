using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints=100f;
    bool isDead = false;
    public bool GetIsDead()
    {
        return isDead;
    }

    public void ReduceHealth(float damage)
    {
        if (isDead) { return; }
        if (hitPoints >= 0)
        {
            hitPoints-=damage;
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        isDead= true;
        GetComponent<Animator>().SetBool("death", true);
    }
}
