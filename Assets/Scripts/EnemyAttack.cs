using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] int damage = 40;
    

    private void Awake()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if(target == null) { return; }
        target.DamagePlayer(damage);
        target.GetComponent<DisplayDamage>().DisplayDamageCanvas();
        Debug.Log("Aarg");
    }
}
