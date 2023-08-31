using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;

    public int GetAmmoAmount()
    {
        return ammoAmount;
    }
    public void ReduceAmmoAmount()
    {
        ammoAmount--;
    }
}
