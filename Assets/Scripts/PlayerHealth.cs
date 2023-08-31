using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 100;

    public void DamagePlayer(int damage)
    {
        if(hitPoints> 0)
        {
            hitPoints-=damage;
        }
        else if(hitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();

        }
    }
    
 
}
